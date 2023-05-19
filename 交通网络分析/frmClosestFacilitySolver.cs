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
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;

namespace 交通网络分析
{
    public partial class frmClosestFacilitySolver : Form
    {
        INAContext m_naContext;
        public frmClosestFacilitySolver()
        {
            InitializeComponent();
            txtTargetFacility.Text = "1";
            txtCutOff.Text = "15";
            lstOutput.Items.Clear();
            cboCostAttribute.Items.Clear();
            chkUseRestriction.Checked = false;
            axMapControl1.ClearLayers();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            txtWorkspacePath.Text = getPath(path);
            txtNetworkDataset.Text = "Road_network_ND";
            txtFeatureDataset.Text = "Road_network";
            txtInputIncidents.Text = "Incidents";
            txtInputFacilities.Text = "Facility";
            gbFacilitySolverSolver.Enabled = false;

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
            path = path.Substring(0, t - 1) + "\\data\\网络数据集最近设施点分析\\chapter10.mdb";
            string name = path;
            return name;
        }
        //加载数据
        private void btnLoadMap_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            gbFacilitySolverSolver.Enabled = false;
            lstOutput.Items.Clear();
            //调用NetWorkAnalysClass类的OpenWorkspace方法打开工作空间
            IWorkspace workspace = NetWorkAnalysClass.OpenWorkspace(txtWorkspacePath.Text);
            if (workspace == null)
            {
                this.Cursor = Cursors.Default;
                return;
            }
            //调用NetWorkAnalysClass类的OpenNetworkDataset方法打开网络数据集
            INetworkDataset networkDataset = NetWorkAnalysClass.OpenNetworkDataset(workspace, txtFeatureDataset.Text, txtNetworkDataset.Text);
            IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;
            //调用NetWorkAnalysClass类的CreatePathSolverContext方法创建分析上下文
            m_naContext = NetWorkAnalysClass.CreatePathSolverContext(networkDataset, "ClosestFacility");
            if (m_naContext == null)
            {
                this.Cursor = Cursors.Default;
                return;
            }
            LoadCostAttributes(networkDataset);
            IFeatureClass inputFeatureClass1 = featureWorkspace.OpenFeatureClass(txtInputFacilities.Text);
            IFeatureClass inputFeatureClass2 = featureWorkspace.OpenFeatureClass(txtInputIncidents.Text);
            //调用NetWorkAnalysClass类的LoadNANetworkLocations加载设施点和事件点
            NetWorkAnalysClass.LoadNANetworkLocations(m_naContext, "Facilities", inputFeatureClass1 as ITable);
            NetWorkAnalysClass.LoadNANetworkLocations(m_naContext, "Incidents", inputFeatureClass2 as ITable);
            AddNetworkDatasetLayerToMap(networkDataset);
            AddNetworkAnalysisLayerToMap();
            IGeoDataset geoDataset = networkDataset as IGeoDataset;
            axMapControl1.Extent = axMapControl1.FullExtent;
            axMapControl1.Extent = geoDataset.Extent;
            if (m_naContext != null) gbFacilitySolverSolver.Enabled = true;
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
        //实现最近设施点分析
        private void btnSolve_Click(object sender, EventArgs e)
        {
            lstOutput.Items.Clear();
            SetSolverSettings();
            IGPMessages gpMessages = new GPMessagesClass();
            if (!m_naContext.Solver.Solve(m_naContext, gpMessages, null))
                GetCFOutput("CFRoutes");
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
            IGeoDataset geoDataset;
            IEnvelope envelope;
            geoDataset = m_naContext.NAClasses.get_ItemByName("CFRoutes") as IGeoDataset;
            envelope = geoDataset.Extent;
            if (!envelope.IsEmpty)
                envelope.Expand(1.1, 1.1, true);
            axMapControl1.Extent = envelope;
            axMapControl1.Refresh();
        }
        //打印分析结果
        public void GetCFOutput(string strNAClass)
        {
            ITable table = m_naContext.NAClasses.get_ItemByName(strNAClass) as ITable;
            if (table == null)
            {
                lstOutput.Items.Add("表为空，无法获取");
            }
            lstOutput.Items.Add("设施点的个数为：" + table.RowCount(null).ToString());
            lstOutput.Items.Add("");
            if (table.RowCount(null) > 0)
            {
                lstOutput.Items.Add("IncidentID, FacilityID,FacilityRank,Total_" + cboCostAttribute.Text);
                double total_impedance;
                long incidentID;
                long facilityID;
                long facilityRank;
                ICursor cursor;
                IRow row;
                cursor = table.Search(null, false);
                row = cursor.NextRow();
                while (row != null)
                {
                    incidentID = long.Parse(row.get_Value(table.FindField("IncidentID")).ToString());
                    facilityID = long.Parse(row.get_Value(table.FindField("FacilityID")).ToString());
                    facilityRank = long.Parse(row.get_Value(table.FindField("FacilityRank")).ToString());
                    total_impedance = double.Parse(row.get_Value(table.FindField("Total_" + cboCostAttribute.Text)).ToString());
                    lstOutput.Items.Add(incidentID.ToString() + ",\t" + facilityID.ToString() +
                        ",\t" + facilityRank.ToString() + ",\t" + total_impedance.ToString("F2"));
                    row = cursor.NextRow();
                }
            }
            lstOutput.Refresh();
        }
        //设置分析参数
        public void SetSolverSettings()
        {
            INASolver naSolver = m_naContext.Solver;
            INAClosestFacilitySolver cfSolver = naSolver as INAClosestFacilitySolver;           
            if (txtCutOff.Text.Length > 0 && IsNumeric(txtCutOff.Text.Trim()))
                cfSolver.DefaultCutoff = txtCutOff.Text; 
            else
                cfSolver.DefaultCutoff = null;
            if (txtTargetFacility.Text.Length > 0 && IsNumeric(txtTargetFacility.Text))
                //设置要查找的设施点的数目
                cfSolver.DefaultTargetFacilityCount = int.Parse(txtTargetFacility.Text);
            else
                cfSolver.DefaultTargetFacilityCount = 1;
            //设置生成线的类型
            cfSolver.OutputLines = esriNAOutputLineType.esriNAOutputLineTrueShapeWithMeasure;
            //设置遍历方向
            cfSolver.TravelDirection = esriNATravelDirection.esriNATravelDirectionToFacility;
            // 设置代价类型
            INASolverSettings naSolverSettings;
            naSolverSettings = naSolver as INASolverSettings;
            naSolverSettings.ImpedanceAttributeName = cboCostAttribute.Text;
            //设置单行线限制
            IStringArray restrictions;
            restrictions = naSolverSettings.RestrictionAttributeNames;
            restrictions.RemoveAll();
            if (chkUseRestriction.Checked)
                restrictions.Add("oneway");
            naSolverSettings.RestrictionAttributeNames = restrictions;
            //设置允许U型转弯
            naSolverSettings.RestrictUTurns = esriNetworkForwardStarBacktrack.esriNFSBAllowBacktrack;
            //设置忽略无效位置
            naSolverSettings.IgnoreInvalidLocations = true;
            //更新分析上下文
            naSolver.UpdateContext(m_naContext, NetWorkAnalysClass.GetPathDENetworkDataset(m_naContext.NetworkDataset), new GPMessagesClass());
        }
        private void cboCostAttribute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCostAttribute.Text == "Minutes")
                txtCutOff.Text = "15";
            else if (cboCostAttribute.Text == "Meters")
                txtCutOff.Text = "7000";
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

        private void frmClosestFacilitySolver_Load(object sender, EventArgs e)
        {

        }

       

    }
}
