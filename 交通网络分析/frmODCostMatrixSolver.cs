using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.NetworkAnalyst;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;

namespace 交通网络分析
{
    public partial class frmODCostMatrixSolver : Form
    {
        INAContext m_naContext;
        public frmODCostMatrixSolver()
        {
            InitializeComponent();
            txtTargetFacility.Text = "16";
            txtCutOff.Text = "15";
            lstOutput.Items.Clear();
            cboCostAttribute.Items.Clear();
            chkUseRestriction.Checked = false;
            axMapControl1.ClearLayers();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            txtWorkspacePath.Text = getPath(path);
            txtNetworkDataset.Text = "Road_network_ND";
            txtFeatureDataset.Text = "Road_network";
            txtInputOrigins.Text = "Origins";
            txtInputDestinations.Text = "Destinattions";
            gbODCostMatrixSolver.Enabled = false;
        }
        private string getPath(string path)
        {
            int t;
            for (t = 0; t < path.Length; t++)
            {
                if (path.Substring(t, 4) == "code")
                {
                    break;
                }
            }
            path = path.Substring(0, t - 1) + "\\data\\网络数据集OD成本矩阵分析\\chapter10.mdb";
            string name = path;
            return name;
        }
        //加载数据
        private void btnLoadMap_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            gbODCostMatrixSolver.Enabled = false;
            lstOutput.Items.Clear();
            IWorkspace workspace = NetWorkAnalysClass.OpenWorkspace(txtWorkspacePath.Text);
            if (workspace == null)
            {
                this.Cursor = Cursors.Default;
                return;
            }
            INetworkDataset networkDataset = NetWorkAnalysClass.OpenNetworkDataset(workspace, txtFeatureDataset.Text, txtNetworkDataset.Text);
            IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;
            m_naContext = NetWorkAnalysClass.CreatePathSolverContext(networkDataset, "ODCostMatrixSolver");
            if (m_naContext == null)
            {
                this.Cursor = Cursors.Default;
                return;
            }
            LoadCostAttributes(networkDataset);//加载代价类型
            IFeatureClass inputFeatureClass1 = featureWorkspace.OpenFeatureClass(txtInputOrigins.Text);
            IFeatureClass inputFeatureClass2 = featureWorkspace.OpenFeatureClass(txtInputDestinations.Text);
            //调用NetWorkAnalysClass类的LoadNANetworkLocations加载起始点和目的点
            NetWorkAnalysClass.LoadNANetworkLocations(m_naContext, "Origins", inputFeatureClass1 as ITable);
            NetWorkAnalysClass.LoadNANetworkLocations(m_naContext, "Destinations", inputFeatureClass2 as ITable);
            AddNetworkDatasetLayerToMap(networkDataset);
            AddNetworkAnalysisLayerToMap();
            IGeoDataset geoDataset = networkDataset as IGeoDataset;
            axMapControl1.Extent = axMapControl1.FullExtent;
            axMapControl1.Extent = geoDataset.Extent;
            if (m_naContext != null) gbODCostMatrixSolver.Enabled = true;
            this.Cursor = Cursors.Default;
        }
        private void AddNetworkDatasetLayerToMap(INetworkDataset networkDataset)
        {
            INetworkLayer networkLayer = new NetworkLayerClass();
            networkLayer.NetworkDataset = networkDataset;
            ILayer layer = networkLayer as ILayer;
            layer.Name = "Network Dataset";
            axMapControl1.AddLayer(layer);
        }
        private void AddNetworkAnalysisLayerToMap()
        {
            ILayer layer = m_naContext.Solver.CreateLayer(m_naContext) as ILayer;
            layer.Name = m_naContext.Solver.DisplayName;
            axMapControl1.AddLayer(layer);
        }
        //加载代价类型
        private void LoadCostAttributes(INetworkDataset networkDataset)
        {
            cboCostAttribute.Items.Clear();
            int attrCount = networkDataset.AttributeCount;
            for (int attrIndex = 0; attrIndex < attrCount; attrIndex++)
            {
                INetworkAttribute networkAttribute = networkDataset.get_Attribute(attrIndex);
                if (networkAttribute.UsageType == esriNetworkAttributeUsageType.esriNAUTCost)
                    cboCostAttribute.Items.Add(networkAttribute.Name);
            }
            if (cboCostAttribute.Items.Count > 0)
                cboCostAttribute.SelectedIndex = 0;
        }
        //实现OD成本矩阵分析
        private void btnSolve_Click(object sender, EventArgs e)
        {
            try
            {
                lstOutput.Items.Clear();
                SetSolverSettings();
                IGPMessages gpMessages = new GPMessagesClass();
                if (!m_naContext.Solver.Solve(m_naContext, gpMessages, null))
                {
                    //获取OD成本矩阵分析结果
                    GetODOutput();
                }
                else
                    lstOutput.Items.Add("部分结果");
                if (gpMessages != null)
                {
                    for (int i = 0; i < gpMessages.Count; i++)
                    {
                        switch (gpMessages.GetMessage(i).Type)
                        {
                            case esriGPMessageType.esriGPMessageTypeError:
                                lstOutput.Items.Add("Error " + gpMessages.GetMessage(i).ErrorCode.ToString() + " " + gpMessages.GetMessage(i).Description);
                                break;
                            case esriGPMessageType.esriGPMessageTypeWarning:
                                lstOutput.Items.Add("Warning " + gpMessages.GetMessage(i).Description);
                                break;
                            default:
                                lstOutput.Items.Add("Information " + gpMessages.GetMessage(i).Description);
                                break;
                        }
                    }
                }
                IGeoDataset gDataset = m_naContext.NAClasses.get_ItemByName("ODLines") as IGeoDataset;
                IEnvelope envelope = gDataset.Extent;
                if (!envelope.IsEmpty)
                {
                    envelope.Expand(1.1, 1.1, true);
                    axMapControl1.Extent = envelope;
                }
                axMapControl1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //打印分析结果
        public void GetODOutput()
        {
            ITable naTable = m_naContext.NAClasses.get_ItemByName("ODLines") as ITable;
            if (naTable == null)
                lstOutput.Items.Add("无法获取分析结果线要素表");
            lstOutput.Items.Add("目标个数为：" + naTable.RowCount(null).ToString());
            lstOutput.Items.Add("");
            if (naTable.RowCount(null) > 0)
            {
                lstOutput.Items.Add("OriginID, DestinationID, DestinationRank, Total_" + cboCostAttribute.Text);
                double total_impedance;
                long OriginID;
                long DestinationID;
                long DestinationRank;
                ICursor naCursor = naTable.Search(null, false);
                IRow naRow = naCursor.NextRow();
                while (naRow != null)
                {
                    OriginID = long.Parse(naRow.get_Value(naTable.FindField("OriginID")).ToString());
                    DestinationID = long.Parse(naRow.get_Value(naTable.FindField("DestinationID")).ToString());
                    DestinationRank = long.Parse(naRow.get_Value(naTable.FindField("DestinationRank")).ToString());
                    total_impedance = double.Parse(naRow.get_Value(naTable.FindField("Total_" + cboCostAttribute.Text)).ToString());
                    lstOutput.Items.Add(OriginID.ToString() + ", " + DestinationID.ToString() + ", " +
                        DestinationRank.ToString() + ", " + total_impedance.ToString("#0.00"));
                    naRow = naCursor.NextRow();
                }
            }
            lstOutput.Refresh();
        }
        //设置分析参数
        public void SetSolverSettings()
        {
            INASolver solver = m_naContext.Solver;
            INAODCostMatrixSolver odSolver = solver as INAODCostMatrixSolver;
            if (txtCutOff.Text.Length > 0 && IsNumeric(txtCutOff.Text.Trim()))
                odSolver.DefaultCutoff = txtCutOff.Text;
            else
                odSolver.DefaultCutoff = null;
            if (txtTargetFacility.Text.Length > 0 && IsNumeric(txtTargetFacility.Text.Trim()))
                odSolver.DefaultTargetDestinationCount = txtTargetFacility.Text;
            else
                odSolver.DefaultTargetDestinationCount = null;
            odSolver.OutputLines = esriNAOutputLineType.esriNAOutputLineStraight;
            INASolverSettings solverSettings = solver as INASolverSettings;
            solverSettings.ImpedanceAttributeName = cboCostAttribute.Text;
            //设置单行线约束
            IStringArray restrictions = solverSettings.RestrictionAttributeNames;
            restrictions.RemoveAll();
            if (chkUseRestriction.Checked)
                restrictions.Add("oneway");
            solverSettings.RestrictionAttributeNames = restrictions;
            //设置允许U型转弯
            solverSettings.RestrictUTurns = esriNetworkForwardStarBacktrack.esriNFSBAllowBacktrack;
            //设置忽略无效位置
            solverSettings.IgnoreInvalidLocations = true;
            solver.UpdateContext(m_naContext, NetWorkAnalysClass.GetPathDENetworkDataset(m_naContext.NetworkDataset), new GPMessagesClass());
        }
        private bool IsNumeric(string str)
        {
            try
            {
                double.Parse(str.Trim());
            }
            catch (Exception) 
            { 
                return false; 
            }
            return true;
        }

        private void frmODCostMatrixSolver_Load(object sender, EventArgs e)
        {

        }
    }
}
