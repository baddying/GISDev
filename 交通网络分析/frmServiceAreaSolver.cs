using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.NetworkAnalyst;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;

namespace 交通网络分析
{
    public partial class frmServiceAreaSolver : Form
    {
        INAContext m_naContext;
        public frmServiceAreaSolver()
        {
            InitializeComponent();
            txtCutOff.Text = "5";//默认中断
            lbOutput.Items.Clear();
            cbCostAttribute.Items.Clear();
            chkShowLines.Checked = false;//默认分析结果不显示路径
            chkUseRestriction.Checked = false;//默认不启用单行线限制
            axMapControl1.ClearLayers();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            txtWorkspacePath.Text = getPath(path);
            txtNetworkDataset.Text = "Road_network_ND";
            txtFeatureDataset.Text = "Road_network";
            txtInputFacilities.Text = "Facilities";
            gbServiceAreaSolver.Enabled = false;
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
            path = path.Substring(0, t - 1) + "\\data\\网络数据集服务区分析\\chapter10.mdb";
            string name = path;
            return name;
        }
        //加载数据
        private void btnLoadMap_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            gbServiceAreaSolver.Enabled = false;
            lbOutput.Items.Clear();
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
            m_naContext = NetWorkAnalysClass.CreatePathSolverContext(networkDataset, "ServiceArea");
            if (m_naContext == null)
            {
                this.Cursor = Cursors.Default;
                return;
            }
            LoadCostAttributes(networkDataset);
            IFeatureClass inputFeatureClass = featureWorkspace.OpenFeatureClass(txtInputFacilities.Text);
            //调用NetWorkAnalysClass类的LoadNANetworkLocations方法加载设施点
            NetWorkAnalysClass.LoadNANetworkLocations(m_naContext, "Facilities", inputFeatureClass as ITable);
            AddNetworkDatasetLayerToMap(networkDataset);//加载网络数据集图层
            AddNetworkAnalysisLayerToMap();//加载网络分析图层
            IGeoDataset geoDataset = networkDataset as IGeoDataset;
            axMapControl1.Extent = axMapControl1.FullExtent;
            axMapControl1.Extent = geoDataset.Extent;
            if (m_naContext != null) gbServiceAreaSolver.Enabled = true;
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
        //设置代价类型
        private void LoadCostAttributes(INetworkDataset networkDataset)
        {
            cbCostAttribute.Items.Clear();
            int attrCount = networkDataset.AttributeCount;
            for (int attrIndex = 0; attrIndex < attrCount; attrIndex++)
            {
                INetworkAttribute networkAttribute = networkDataset.get_Attribute(attrIndex);
                if (networkAttribute.UsageType == esriNetworkAttributeUsageType.esriNAUTCost)
                    cbCostAttribute.Items.Add(networkAttribute.Name);
            }
            if (cbCostAttribute.Items.Count > 0)
                cbCostAttribute.SelectedIndex = 0;
        }
        //实现查找服务区分析
        private void btnSolve_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            lbOutput.Items.Clear();
            ConfigureSolverSettings();//配置分析设置
            try
            {
                IGPMessages gpMessages = new GPMessagesClass();
                if (m_naContext.Solver.Solve(m_naContext, gpMessages, null))
                    LoadListboxAfterPartialSolve(gpMessages);
                else
                    LoadListboxAfterSuccessfulSolve();
            }
            catch (Exception ex)
            {
                lbOutput.Items.Add("分析失败：" + ex.Message);
            }
            UpdateMapDisplayAfterSolve();
            this.Cursor = Cursors.Default;
        }
        private void ConfigureSolverSettings()
        {
            //设置分析参数
            ConfigureSettingsSpecificToServiceAreaSolver();
            //设置分析限制
            ConfigureGenericSolverSettings();
            //更新分析上下文
            UpdateContextAfterChangingSettings();
        }
        private void ConfigureSettingsSpecificToServiceAreaSolver()
        {
            INAServiceAreaSolver naSASolver = m_naContext.Solver as INAServiceAreaSolver;
            //加载中断
            naSASolver.DefaultBreaks = ParseBreaks(txtCutOff.Text);
            naSASolver.MergeSimilarPolygonRanges = false;
            naSASolver.OutputPolygons = esriNAOutputPolygonType.esriNAOutputPolygonSimplified;
            naSASolver.OverlapLines = true;
            naSASolver.SplitLinesAtBreaks = false;
            naSASolver.TravelDirection = esriNATravelDirection.esriNATravelDirectionFromFacility;
            if (chkShowLines.Checked)//设置分析结果显示路径
                naSASolver.OutputLines = esriNAOutputLineType.esriNAOutputLineTrueShape;
            else
                naSASolver.OutputLines = esriNAOutputLineType.esriNAOutputLineNone;
        }
        private void ConfigureGenericSolverSettings()
        {
            INASolverSettings naSolverSettings = m_naContext.Solver as INASolverSettings;
            naSolverSettings.ImpedanceAttributeName = cbCostAttribute.Text;
            //设置单行线限制
            IStringArray restrictions = naSolverSettings.RestrictionAttributeNames;
            restrictions.RemoveAll();
            if (chkUseRestriction.Checked)
                restrictions.Add("Oneway");
            naSolverSettings.RestrictionAttributeNames = restrictions;
            //设置禁止U型转弯
            naSolverSettings.RestrictUTurns = esriNetworkForwardStarBacktrack.esriNFSBNoBacktrack;
        }
        private void UpdateContextAfterChangingSettings()
        {
            IDatasetComponent datasetComponent = m_naContext.NetworkDataset as IDatasetComponent;
            IDENetworkDataset deNetworkDataset = datasetComponent.DataElement as IDENetworkDataset;
            m_naContext.Solver.UpdateContext(m_naContext, deNetworkDataset, new GPMessagesClass());
        }
        private IDoubleArray ParseBreaks(string p)
        {
            String[] breaks = p.Split(' ');
            IDoubleArray pBrks = new DoubleArrayClass();
            int firstIndex = breaks.GetLowerBound(0);
            int lastIndex = breaks.GetUpperBound(0);
            for (int splitIndex = firstIndex; splitIndex <= lastIndex; splitIndex++)
            {
                try
                {
                    pBrks.Add(Convert.ToDouble(breaks[splitIndex]));
                }
                catch (FormatException)
                {
                    MessageBox.Show("添加多个中断的格式不正确，中断之间用空格隔开");
                    pBrks.RemoveAll();
                    return pBrks;
                }
            }
            return pBrks;
        }
        //加载消息信息
        private void LoadListboxAfterPartialSolve(IGPMessages gpMessages)
        {
            lbOutput.Items.Add("生成部分分析参数");
            for (int msgIndex = 0; msgIndex < gpMessages.Messages.Count; msgIndex++)
            {
                string errorText = "";
                switch (gpMessages.GetMessage(msgIndex).Type)
                {
                    case esriGPMessageType.esriGPMessageTypeError:
                        errorText = "Error " + gpMessages.GetMessage(msgIndex).ErrorCode.ToString() + " " + gpMessages.GetMessage(msgIndex).Description;
                        break;
                    case esriGPMessageType.esriGPMessageTypeWarning:
                        errorText = "Warning " + gpMessages.GetMessage(msgIndex).ErrorCode.ToString() + " " + gpMessages.GetMessage(msgIndex).Description;
                        break;
                    default:
                        errorText = "Information " + gpMessages.GetMessage(msgIndex).Description;
                        break;
                }
                lbOutput.Items.Add(errorText);
            }
        }
        //打印分析结果
        private void LoadListboxAfterSuccessfulSolve()
        {
            ITable table = m_naContext.NAClasses.get_ItemByName("SAPolygons") as ITable;
            if (table.RowCount(null) > 0)
            {
                IGPMessage gpMessage = new GPMessageClass();
                lbOutput.Items.Add("FacilityID, FromBreak, ToBreak");
                ICursor cursor = table.Search(null, true);
                IRow row = cursor.NextRow();
                while (row != null)
                {
                    int facilityID = (int)row.get_Value(table.FindField("FacilityID"));
                    double fromBreak = (double)row.get_Value(table.FindField("FromBreak"));
                    double toBreak = (double)row.get_Value(table.FindField("ToBreak"));
                    lbOutput.Items.Add(facilityID.ToString() + ", " + fromBreak.ToString("#####0.00") + ", " + toBreak.ToString("#####0.00"));
                    row = cursor.NextRow();
                }
            }
        }
        private void UpdateMapDisplayAfterSolve()
        {
            IGeoDataset geoDataset = m_naContext.NAClasses.get_ItemByName("SAPolygons") as IGeoDataset;
            IEnvelope envelope = geoDataset.Extent;
            if (!envelope.IsEmpty)
            {
                envelope.Expand(1.1, 1.1, true);
                axMapControl1.Extent = envelope;
                //基于新的参数设置，更新分析结果
                m_naContext.Solver.UpdateLayer(axMapControl1.get_Layer(0) as INALayer);
            }
            axMapControl1.Refresh();
        }

        private void frmServiceAreaSolver_Load(object sender, EventArgs e)
        {

        }
    }
}
