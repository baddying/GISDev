using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.NetworkAnalyst;
using System.Collections;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;

namespace 交通网络分析
{
    public partial class frmVRPSolver : Form
    {
        INAContext m_naContext;
        private Hashtable m_unitTimeList;
        private Hashtable m_unitDistList;
        public frmVRPSolver()
        {
            InitializeComponent();
            lstOutput.Items.Clear();
            chkUseRestriction.Checked = false;
            axMapControl1.ClearLayers();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            txtWorkspacePath.Text = getPath(path);
            txtNetworkDataset.Text = "Road_network_ND";
            txtFeatureDataset.Text = "Road_network";
            txtInputStops.Text = "Stops";
            txtInputDepots.Text = "Depots";
            txtInputRoutes.Text = "Routes";
            gbVRPSolver.Enabled = false;
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
            path = path.Substring(0, t - 1) + "\\data\\网络数据集多路径配送分析\\chapter10.mdb";
            string name = path;
            return name;
        }
        //加载数据
        private void btnLoadMap_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            gbVRPSolver.Enabled = false;
            lstOutput.Items.Clear();
            IWorkspace workspace = NetWorkAnalysClass.OpenWorkspace(txtWorkspacePath.Text);
            if (workspace == null)
            {
                this.Cursor = Cursors.Default;
                return;
            }
            INetworkDataset networkDataset = NetWorkAnalysClass.OpenNetworkDataset(workspace, txtFeatureDataset.Text, txtNetworkDataset.Text);
            IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;
            m_naContext = NetWorkAnalysClass.CreatePathSolverContext(networkDataset, "VRPSolver");
            if (m_naContext == null)
            {
                this.Cursor = Cursors.Default;
                return;
            }
            LoadAttributes(networkDataset);
            LoadUnits(networkDataset);
            loadTWImportance();
            IFeatureClass inputFeatureClass1 = featureWorkspace.OpenFeatureClass(txtInputStops.Text);
            IFeatureClass inputFeatureClass2 = featureWorkspace.OpenFeatureClass(txtInputDepots.Text);
            IFeatureClass inputFeatureClass3 = featureWorkspace.OpenFeatureClass(txtInputRoutes.Text);
            NetWorkAnalysClass.LoadNANetworkLocations(m_naContext, "Orders", inputFeatureClass1 as ITable);
            NetWorkAnalysClass.LoadNANetworkLocations(m_naContext, "Depots", inputFeatureClass2 as ITable);
            NetWorkAnalysClass.LoadNANetworkLocations(m_naContext, "Routes", inputFeatureClass3 as ITable);
            AddNetworkDatasetLayerToMap(networkDataset);
            AddNetworkAnalysisLayerToMap();
            IGeoDataset geoDataset = networkDataset as IGeoDataset;
            axMapControl1.Extent = axMapControl1.FullExtent;
            axMapControl1.Extent = geoDataset.Extent;
            if (m_naContext != null) gbVRPSolver.Enabled = true;
            this.Cursor = Cursors.Default;
        }
        //加载代价类型
        private void LoadAttributes(INetworkDataset networkDataset)
        {
            INetworkAttribute networkAttribute;
            for (int i = 0; i < networkDataset.AttributeCount; i++)
            {
                networkAttribute = networkDataset.get_Attribute(i);
                if (networkAttribute.UsageType == esriNetworkAttributeUsageType.esriNAUTCost)
                {
                    string unitType = GetAttributeUnitType(networkAttribute.Units);
                    if (unitType == "Time")
                    {
                        comboTimeAttribute.Items.Add(networkAttribute.Name);
                    }
                    else if (unitType == "Distance")
                    {
                        comboDistanceAttribute.Items.Add(networkAttribute.Name);
                    }
                }
            }
            comboTimeAttribute.SelectedIndex = 0;
            comboDistanceAttribute.SelectedIndex = 0;
        }
        //加载单位类型
        private void LoadUnits(INetworkDataset networkDataset)
        {
            m_unitTimeList = new Hashtable();
            m_unitTimeList.Add("Seconds", esriNetworkAttributeUnits.esriNAUSeconds);
            m_unitTimeList.Add("Minutes", esriNetworkAttributeUnits.esriNAUMinutes);
            foreach (System.Collections.DictionaryEntry timeUnit in m_unitTimeList)
            {
                comboTimeUnits.Items.Add(timeUnit.Key.ToString());
            }
            comboTimeUnits.SelectedIndex = 1;
            m_unitDistList = new Hashtable();
            m_unitDistList.Add("Miles", esriNetworkAttributeUnits.esriNAUMiles);
            m_unitDistList.Add("Meters", esriNetworkAttributeUnits.esriNAUMeters);
            foreach (System.Collections.DictionaryEntry distUnit in m_unitDistList)
            {
                comboDistUnits.Items.Add(distUnit.Key.ToString());
            }
            comboDistUnits.SelectedIndex = 0;
        }
        //加载时间窗重要性参数
        private void loadTWImportance()
        {
            comboTWImportance.Items.Add("High");
            comboTWImportance.Items.Add("Medium");
            comboTWImportance.Items.Add("Low");
            comboTWImportance.SelectedIndex = 0;
        }
        private string GetAttributeUnitType(esriNetworkAttributeUnits units)
        {
            string unitType = "";
            switch (units)
            {
                case esriNetworkAttributeUnits.esriNAUDays:
                case esriNetworkAttributeUnits.esriNAUHours:
                case esriNetworkAttributeUnits.esriNAUMinutes:
                case esriNetworkAttributeUnits.esriNAUSeconds:
                    unitType = "Time";
                    break;
                case esriNetworkAttributeUnits.esriNAUYards:
                case esriNetworkAttributeUnits.esriNAUMillimeters:
                case esriNetworkAttributeUnits.esriNAUMiles:
                case esriNetworkAttributeUnits.esriNAUMeters:
                case esriNetworkAttributeUnits.esriNAUKilometers:
                case esriNetworkAttributeUnits.esriNAUInches:
                case esriNetworkAttributeUnits.esriNAUFeet:
                case esriNetworkAttributeUnits.esriNAUDecimeters:
                case esriNetworkAttributeUnits.esriNAUNauticalMiles:
                case esriNetworkAttributeUnits.esriNAUCentimeters:
                    unitType = "Distance";
                    break;
                default:
                    lstOutput.Items.Add("查询网络属性单位失败");
                    break;
            }
            return unitType;
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
        //实现多路径配送分析
        private void btnSolve_Click(object sender, EventArgs e)
        {
            try
            {
                lstOutput.Items.Clear();
                SetSolverSettings();
                IGPMessages gpMessages = new GPMessagesClass();
                m_naContext.Solver.Solve(m_naContext, gpMessages, null);
                //获取多路径配送分析结果
                GetVRPOutput();
                if (gpMessages != null)
                {
                    for (int i = 0; i < gpMessages.Count; i++)
                    {
                        switch (gpMessages.GetMessage(i).Type)
                        {
                            case esriGPMessageType.esriGPMessageTypeError:
                                lstOutput.Items.Add("Error: " + gpMessages.GetMessage(i).ErrorCode.ToString() + " " + gpMessages.GetMessage(i).Description);
                                break;
                            case esriGPMessageType.esriGPMessageTypeWarning:
                                lstOutput.Items.Add("Warning: " + gpMessages.GetMessage(i).Description);
                                break;
                            default:
                                lstOutput.Items.Add("Information: " + gpMessages.GetMessage(i).Description);
                                break;
                        }
                    }
                }
                IGeoDataset gDataset = m_naContext.NAClasses.get_ItemByName("Routes") as IGeoDataset;
                IEnvelope envelope = gDataset.Extent;
                if (!envelope.IsEmpty)
                {
                    envelope.Expand(1.1, 1.1, true);
                    axMapControl1.Extent = envelope;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        //设置分析参数
        public void SetSolverSettings()
        {
            INASolver solver = m_naContext.Solver;
            INAVRPSolver vrpSolver = solver as INAVRPSolver;
            //设置容量计数
            vrpSolver.CapacityCount = 1;
            //设置时间和距离单位
            vrpSolver.DistanceFieldUnits = (esriNetworkAttributeUnits)m_unitDistList[comboDistUnits.Items[comboDistUnits.SelectedIndex].ToString()];
            vrpSolver.TimeFieldUnits = (esriNetworkAttributeUnits)m_unitTimeList[comboTimeUnits.Items[comboTimeUnits.SelectedIndex].ToString()];
            //设置时间窗重要性参数
            string importance = comboTWImportance.Items[comboTWImportance.SelectedIndex].ToString();
            if (importance == "Low")
                vrpSolver.TimeWindowViolationPenaltyFactor = 0;
            else if (importance == "Medium")
                vrpSolver.TimeWindowViolationPenaltyFactor = 1;
            else if (importance == "High")
                vrpSolver.TimeWindowViolationPenaltyFactor = 10;
            //设置输出线类型
            vrpSolver.OutputLines = esriNAOutputLineType.esriNAOutputLineTrueShapeWithMeasure;//具有测量值的实际形状
            //设置时间属性作为阻抗
            INASolverSettings solverSettings = solver as INASolverSettings;
            solverSettings.ImpedanceAttributeName = comboTimeAttribute.Text;
            //设置距离属性作为累积属性
            IStringArray accumulatedAttributes = solverSettings.AccumulateAttributeNames;
            accumulatedAttributes.RemoveAll();
            accumulatedAttributes.Insert(0, comboDistanceAttribute.Text);
            solverSettings.AccumulateAttributeNames = accumulatedAttributes;
            //设置单行线限制
            IStringArray restrictions = solverSettings.RestrictionAttributeNames;
            restrictions.RemoveAll();
            if (chkUseRestriction.Checked)
                restrictions.Add("oneway");
            solverSettings.RestrictionAttributeNames = restrictions;
            //设置U型转弯
            solverSettings.RestrictUTurns = esriNetworkForwardStarBacktrack.esriNFSBAllowBacktrack;
            //更新网络分析上下文
            solver.UpdateContext(m_naContext, NetWorkAnalysClass.GetPathDENetworkDataset(m_naContext.NetworkDataset), new GPMessagesClass());
        }
        //打印分析结果
        public void GetVRPOutput()
        {
            ITable naTable = m_naContext.NAClasses.get_ItemByName("Routes") as ITable;
            if (naTable.RowCount(null) > 0)
            {
                lstOutput.Items.Add("Route Name,\tOrder Count,\tTotal Cost,\tTotal Time,\tTotal Distance,\tStart Time,\tEnd Time:");
                string routeName;
                long orderCount;
                double totalCost;
                double totalTime;
                double totalDistance;
                string routeStart;
                string routeEnd;
                ICursor naCursor = naTable.Search(null, false);
                IRow naRow = naCursor.NextRow();
                //显示分析结果信息
                while (naRow != null)
                {
                    routeName = naRow.get_Value(naTable.FindField("Name")).ToString();
                    orderCount = long.Parse(naRow.get_Value(naTable.FindField("OrderCount")).ToString());
                    totalCost = double.Parse(naRow.get_Value(naTable.FindField("TotalCost")).ToString());
                    totalTime = double.Parse(naRow.get_Value(naTable.FindField("TotalTime")).ToString());
                    totalDistance = double.Parse(naRow.get_Value(naTable.FindField("TotalDistance")).ToString());
                    routeStart = Convert.ToDateTime(naRow.get_Value(naTable.FindField("StartTime")).ToString()).ToString("T");
                    routeEnd = Convert.ToDateTime(naRow.get_Value(naTable.FindField("EndTime")).ToString()).ToString("T");
                    lstOutput.Items.Add(routeName + ",\t\t" + orderCount.ToString() + ",\t\t" + totalCost.ToString("#0.00") + ",\t\t" + totalTime.ToString("#0.00")
                        + ",\t\t" + totalDistance.ToString("#0.00") + ",\t\t" + routeStart + ",\t\t" + routeEnd);
                    naRow = naCursor.NextRow();
                }
            }
            lstOutput.Items.Add("");
            lstOutput.Refresh();
        }

        private void frmVRPSolver_Load(object sender, EventArgs e)
        {

        }
    }
}
