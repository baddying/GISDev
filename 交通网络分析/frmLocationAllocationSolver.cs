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

namespace 交通网络分析
{
    public partial class frmLocationAllocationSolver : Form
    {
        INAContext m_naContext;
        private string m_ProblemType = "Minimize Impedance";
        public frmLocationAllocationSolver()
        {
            InitializeComponent();
            lstOutput.Items.Clear();
            cboCostAttribute.Items.Clear();
            axMapControl1.ClearLayers();
            txtFacilitiesToLocate.Text = "2";
            txtCutOff.Text = "<None>";
            //加载设施点的类型
            cboProblemType.Items.Add("Minimize Impedance");//最小化阻抗
            cboProblemType.Items.Add("Maximize Coverage");//最大化覆盖范围
            cboProblemType.Items.Add("Minimize Facilities");//最小化设施点
            cboProblemType.Items.Add("Maximize Attendance");//最大化客流量
            cboProblemType.Items.Add("Maximize Market Share");//最大化市场份额
            cboProblemType.Items.Add("Target Market Share");//目标市场份额
            cboProblemType.Text = "Minimize Impedance";
            m_ProblemType = "Minimize Impedance";
            //添加阻抗变换类型
            cboImpTransformation.Items.Add("Linear");
            cboImpTransformation.Items.Add("Power");
            cboImpTransformation.Items.Add("Exponential");
            cboImpTransformation.Text = "Linear";
            //设置默认的阻抗变换参数
            txtImpParameter.Text = "1.0";
            //目标市场份额，默认为10%
            txtTargetMarketShare.Text = "10.0";
            //图层属性
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            txtWorkspacePath.Text = getPath(path);
            txtNetworkDataset.Text = "Road_network_ND";
            txtFeatureDataset.Text = "Road_network";
            txtInputIncidents.Text = "Incidents";
            txtInputFacilities.Text = "Facility";
            gbLocationAllocationSolver.Enabled = false;
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
            path = path.Substring(0, t - 1) + "\\data\\网络数据集位置分配分析\\chapter10.mdb";
            string name = path;
            return name;
        }
        //加载数据
        private void btnLoadMap_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            gbLocationAllocationSolver.Enabled = false;
            lstOutput.Items.Clear();
            IWorkspace workspace = NetWorkAnalysClass.OpenWorkspace(txtWorkspacePath.Text);
            if (workspace == null)
            {
                this.Cursor = Cursors.Default;
                return;
            }
            INetworkDataset networkDataset = NetWorkAnalysClass.OpenNetworkDataset(workspace, txtFeatureDataset.Text, txtNetworkDataset.Text);
            IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;
            m_naContext = NetWorkAnalysClass.CreatePathSolverContext(networkDataset, "LocationAllocationSolver");
            if (m_naContext == null)
            {
                this.Cursor = Cursors.Default;
                return;
            }
            LoadCostAttributes(networkDataset);//加载代价类型
            IFeatureClass inputFeatureClass1 = featureWorkspace.OpenFeatureClass(txtInputFacilities.Text);
            IFeatureClass inputFeatureClass2 = featureWorkspace.OpenFeatureClass(txtInputIncidents.Text);
            //调用NetWorkAnalysClass类的LoadNANetworkLocations加载设施点和需求点
            NetWorkAnalysClass.LoadNANetworkLocations(m_naContext, "Facilities", inputFeatureClass1 as ITable);
            NetWorkAnalysClass.LoadNANetworkLocations(m_naContext, "DemandPoints", inputFeatureClass2 as ITable);
            AddNetworkDatasetLayerToMap(networkDataset);
            AddNetworkAnalysisLayerToMap();
            IGeoDataset geoDataset = networkDataset as IGeoDataset;
            axMapControl1.Extent = axMapControl1.FullExtent;
            axMapControl1.Extent = geoDataset.Extent;
            if (m_naContext != null) gbLocationAllocationSolver.Enabled = true;
            this.Cursor = Cursors.Default;
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
        //设置分析参数
        public void SetSolverSettings()
        {
            INASolver naSolver = m_naContext.Solver;
            INALocationAllocationSolver laSolver = naSolver as INALocationAllocationSolver;
            //要选择的设施点的个数
            if (txtFacilitiesToLocate.Text.Length > 0 && IsNumeric(txtFacilitiesToLocate.Text))
                laSolver.NumberFacilitiesToLocate = int.Parse(txtFacilitiesToLocate.Text);
            else
                laSolver.NumberFacilitiesToLocate = 1;
            //设置阻抗中断
            if (txtCutOff.Text.Length > 0 && IsNumeric(txtCutOff.Text.Trim()))
                laSolver.DefaultCutoff = txtCutOff.Text;
            else
                laSolver.DefaultCutoff = null;
            //设置问题类型
            if (cboProblemType.Text.Equals("Maximize Attendance"))
                laSolver.ProblemType = esriNALocationAllocationProblemType.esriNALAPTMaximizeAttendance;
            else if (cboProblemType.Text.Equals("Maximize Coverage"))
                laSolver.ProblemType = esriNALocationAllocationProblemType.esriNALAPTMaximizeCoverage;
            else if (cboProblemType.Text.Equals("Minimize Facilities"))
                laSolver.ProblemType = esriNALocationAllocationProblemType.esriNALAPTMaximizeCoverageMinimizeFacilities;
            else if (cboProblemType.Text.Equals("Maximize Market Share"))
                laSolver.ProblemType = esriNALocationAllocationProblemType.esriNALAPTMaximizeMarketShare;
            else if (cboProblemType.Text.Equals("Minimize Impedance"))
                laSolver.ProblemType = esriNALocationAllocationProblemType.esriNALAPTMinimizeWeightedImpedance;
            else if (cboProblemType.Text.Equals("Target Market Share"))
            {
                laSolver.ProblemType = esriNALocationAllocationProblemType.esriNALAPTTargetMarketShare;
            }
            else
                laSolver.ProblemType = esriNALocationAllocationProblemType.esriNALAPTMinimizeWeightedImpedance;
            //设置阻抗变换类型
            if (cboImpTransformation.Text.Equals("Linear"))
                laSolver.ImpedanceTransformation = esriNAImpedanceTransformationType.esriNAITTLinear;
            else if (cboImpTransformation.Text.Equals("Power"))
                laSolver.ImpedanceTransformation = esriNAImpedanceTransformationType.esriNAITTPower;
            else if (cboImpTransformation.Text.Equals("Exponential"))
                laSolver.ImpedanceTransformation = esriNAImpedanceTransformationType.esriNAITTExponential;
            //设置阻抗变换参数
            if (txtImpParameter.Text.Length > 0 && IsNumeric(txtCutOff.Text.Trim()))
                laSolver.TransformationParameter = double.Parse(txtImpParameter.Text);
            else
                laSolver.TransformationParameter = 1.0;
            //设置目标市场份额
            if (txtTargetMarketShare.Text.Length > 0 && IsNumeric(txtCutOff.Text.Trim()))
            {
                double targetPercentage;
                targetPercentage = double.Parse(txtTargetMarketShare.Text);
                if ((targetPercentage <= 0.0) || (targetPercentage > 100.0))
                {
                    targetPercentage = 10.0;
                    lstOutput.Items.Add("目标超出百分比范围（0.0-100.0）将重置为10%");
                }
                laSolver.TargetMarketSharePercentage = targetPercentage;
                txtTargetMarketShare.Text = laSolver.TargetMarketSharePercentage.ToString();
            }
            else
                laSolver.TargetMarketSharePercentage = 10.0;
            //设置输出线的类型
            laSolver.OutputLines = esriNAOutputLineType.esriNAOutputLineStraight;
            //设置遍历方向
            laSolver.TravelDirection = esriNATravelDirection.esriNATravelDirectionFromFacility;
            //设置代价类型
            INASolverSettings naSolverSettings = naSolver as INASolverSettings;
            naSolverSettings.ImpedanceAttributeName = cboCostAttribute.Text;
            naSolverSettings.IgnoreInvalidLocations = true;
            //禁止U型转弯
            naSolverSettings.RestrictUTurns = esriNetworkForwardStarBacktrack.esriNFSBNoBacktrack;
            //更新上下文
            naSolver.UpdateContext(m_naContext, NetWorkAnalysClass.GetPathDENetworkDataset(m_naContext.NetworkDataset), new GPMessagesClass());
        }
        private bool IsNumeric(string str)
        {
            try
            {
                double.Parse(str.Trim());
            }
            catch (Exception) { return false; }
            return true;
        }
        //实现位置分配分析
        private void btnSolver_Click(object sender, EventArgs e)
        {
            try
            {
                lstOutput.Items.Clear();
                SetSolverSettings();
                IGPMessages gpMessages = new GPMessagesClass();
                if (!m_naContext.Solver.Solve(m_naContext, gpMessages, null))
                {
                    GetLAFacilitiesOutput("Facilities");
                    GetLALinesOutput("LALines");
                }
                else
                    lstOutput.Items.Add("部分结果");
                IGeoDataset geoDataset = m_naContext.NAClasses.get_ItemByName("LALines") as IGeoDataset;
                IEnvelope envelope = geoDataset.Extent;
                if (!envelope.IsEmpty)
                    envelope.Expand(1.1, 1.1, true);
                axMapControl1.Extent = envelope;
                axMapControl1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //打印分析结果
        public void GetLAFacilitiesOutput(string strNAClass)
        {
            ITable table = m_naContext.NAClasses.get_ItemByName(strNAClass) as ITable;
            if (table == null)
                lstOutput.Items.Add("无法获取分析结果表");
            if (table.RowCount(null) > 0)
            {
                ICursor cursor;
                IRow row;
                string facilityName;
                double demandWeight, total_impedance;
                long demandCount;
                long facilityCount = 0;
                long sumDemand = 0;
                double sumWeightedDistance = 0.0;
                cursor = table.Search(null, false);
                row = cursor.NextRow();
                while (row != null)
                {
                    demandCount = long.Parse(row.get_Value(table.FindField("DemandCount")).ToString());
                    if (demandCount > 0)
                    {
                        facilityCount = facilityCount + 1;
                        facilityName = row.get_Value(table.FindField("Name")).ToString();
                        demandWeight = double.Parse(row.get_Value(table.FindField("DemandWeight")).ToString());
                        total_impedance = double.Parse(row.get_Value(table.FindField("TotalWeighted_" + cboCostAttribute.Text)).ToString());
                        sumWeightedDistance = sumWeightedDistance + total_impedance;
                        sumDemand = sumDemand + demandCount;
                    }
                    row = cursor.NextRow();
                }
                lstOutput.Items.Add("设施点的个数为：" + facilityCount.ToString());
                lstOutput.Items.Add("需求点的个数为：" + sumDemand.ToString());
                lstOutput.Items.Add("代价累积值（Minutes）:" + sumWeightedDistance.ToString());
                lstOutput.Items.Add("");
            }
            lstOutput.Refresh();
        }
        public void GetLALinesOutput(string strNAClass)
        {
            ITable table = m_naContext.NAClasses.get_ItemByName(strNAClass) as ITable;
            if (table == null)
            {
                lstOutput.Items.Add("无法获取 " + strNAClass + " 表");
            }
            lstOutput.Items.Add("设施点信息:");
            if (table.RowCount(null) > 0)
            {
                lstOutput.Items.Add("DemandID,FacilityID,Weight,TotalWeighted_" + cboCostAttribute.Text);
                double total_impedance;
                long demandID;
                long facilityID;
                double facilityWeight;
                ICursor cursor;
                IRow row;
                cursor = table.Search(null, false);
                row = cursor.NextRow();
                while (row != null)
                {
                    facilityID = long.Parse(row.get_Value(table.FindField("FacilityID")).ToString());
                    demandID = long.Parse(row.get_Value(table.FindField("DemandID")).ToString());
                    facilityWeight = double.Parse(row.get_Value(table.FindField("Weight")).ToString());
                    total_impedance = double.Parse(row.get_Value(table.FindField("TotalWeighted_" + cboCostAttribute.Text)).ToString());
                    lstOutput.Items.Add(demandID.ToString() + ",\t" + facilityID.ToString() +
                      ",\t" + facilityWeight.ToString() + ",\t" + total_impedance.ToString("F2"));
                    row = cursor.NextRow();
                }
            }
            lstOutput.Refresh();
        }
        private void cboProblemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProblemType.Text.Equals("Minimize Impedance"))
            {
                if (!m_ProblemType.Equals("Minimize Impedance"))
                    if (!txtCutOff.Text.Equals("<None>"))
                        txtCutOff.Text = "<None>";
            }
            else if (txtCutOff.Text.Equals("<None>"))
                txtCutOff.Text = "15";
            if (cboProblemType.Text.Equals("Target Market Share"))
                txtTargetMarketShare.Enabled = true;
            else
                txtTargetMarketShare.Enabled = false;
            m_ProblemType = cboProblemType.Text;
        }
        private void cboImpTransformation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboImpTransformation.Text == "Linear")
                txtImpParameter.Text = "1.0";
            else if (cboImpTransformation.Text == "Power")
                txtImpParameter.Text = "2";
            else if (cboImpTransformation.Text == "Exponential")
                txtImpParameter.Text = "0.02";
        }

        private void frmLocationAllocationSolver_Load(object sender, EventArgs e)
        {

        }
    }
}
