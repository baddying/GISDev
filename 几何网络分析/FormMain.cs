using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.NetworkAnalysis;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.SystemUI;

namespace UtilityNetwork
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// 当前进行分析的几何网络
        /// </summary>
        private IGeometricNetwork geometricNetwork;
        /// <summary>
        /// 执行网络追踪分析任务所使用的接口
        /// </summary>
        private ITraceFlowSolverGEN traceFlowSolverGEN;
        /// <summary>
        /// 进行网络追踪分析所使用的另一接口
        /// </summary>
        private INetSolver netSolver;
        /// <summary>
        /// 管点标识的列表
        /// </summary>
        private List<IJunctionFlag> listJunctionFlags;
        /// <summary>
        /// 管线标识的列表
        /// </summary>
        private List<IEdgeFlag> listEdgeFlags;
        /// <summary>
        /// 管点障碍标识的列表
        /// </summary>
        private List<int> listJunctionBarrierEIDs;
        /// <summary>
        /// 管线障碍标识的列表
        /// </summary>
        private List<int> listEdgeBarrierEIDs;
        /// <summary>
        /// 爆管管线的EID列表
        /// </summary>
        private List<int> listBurstPipeEIDs;
        /// <summary>
        /// 需关闭的所有阀门的EID
        /// </summary>
        private List<int> listClosedValveEIDs;

        public FormMain()
        {
            InitializeComponent();
            traceFlowSolverGEN = new TraceFlowSolverClass();
            netSolver = traceFlowSolverGEN as INetSolver;
            listJunctionFlags = new List<IJunctionFlag>();
            listEdgeFlags = new List<IEdgeFlag>();
            listJunctionBarrierEIDs = new List<int>();
            listEdgeBarrierEIDs = new List<int>();
            listBurstPipeEIDs = new List<int>();
            listClosedValveEIDs = new List<int>();
            toolStripComboBoxTraceTasks.SelectedIndex = 0;
        }

        #region 加载地图文档及几何网络

        private void ToolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            //选择需要打开的地图文档，并加载文档中的几何网络
            OpenFileDialog openFilgeDialog = new OpenFileDialog();
            openFilgeDialog.Filter = "ArcMap Document (*.mxd)|*.mxd";
            if (openFilgeDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                axMapControl.LoadMxFile(openFilgeDialog.FileName);
                LoadGeometricNetwork();
            }
        }

        /// <summary>
        /// 加载地图文档中的几何网络。
        /// </summary>
        private void LoadGeometricNetwork()
        {
            //得到当前几何网络所在的FeatureDataset
            IMap map = axMapControl.Map;
            IFeatureLayer featureLayer = map.get_Layer(0) as IFeatureLayer;
            IFeatureDataset featureDataset = featureLayer.FeatureClass.FeatureDataset;
            //得到接口转换获得当前所加载的几何网络
            INetworkCollection2 networkCollection2 = featureDataset as INetworkCollection2;
            geometricNetwork = networkCollection2.get_GeometricNetwork(0);
            //得到网络分析器所使用的逻辑网络
            netSolver.SourceNetwork = geometricNetwork.Network;
            //通过接口转换得到几何网络的名称，并加载到相应控件中
            IDataset dataset = geometricNetwork as IDataset;
            toolStripComboBoxNetworksName.Items.Add(dataset.Name);
            toolStripComboBoxNetworksName.SelectedIndex = 0;
        }

        #endregion

        #region 添加及清除Flags和Barriers

        private void toolStripButtonAddJunctionFlag_Click(object sender, EventArgs e)
        {
            ToolAddJunctionFlag toolAddJunctionFlag = new ToolAddJunctionFlag();
            toolAddJunctionFlag.ListJunctionFlags = listJunctionFlags;
            toolAddJunctionFlag.GeometricNetwork = geometricNetwork;
            toolAddJunctionFlag.OnCreate(axMapControl.Object);
            axMapControl.CurrentTool = toolAddJunctionFlag as ITool;
            this.toolStripStatusLabel.Text = "当前选择的工具为添加分析管点工具";
        }

        private void toolStripButtonAddEdgeFlag_Click(object sender, EventArgs e)
        {
            ToolAddEdgeFlag toolAddEdgeFlag = new ToolAddEdgeFlag();
            toolAddEdgeFlag.ListEdgeFlags = listEdgeFlags;
            toolAddEdgeFlag.GeometricNetwork = geometricNetwork;
            toolAddEdgeFlag.OnCreate(axMapControl.Object);
            axMapControl.CurrentTool = toolAddEdgeFlag as ITool;
            this.toolStripStatusLabel.Text = "当前选择的工具为添加分析管线工具";
        }

        private void toolStripButtonAddJunctionBarrier_Click(object sender, EventArgs e)
        {
            ToolAddJunctionBarriers toolAddJunctionBarriers = new ToolAddJunctionBarriers();
            toolAddJunctionBarriers.GeometricNetwork = geometricNetwork;
            toolAddJunctionBarriers.ListJunctionBarrierEIDs = listJunctionBarrierEIDs;
            toolAddJunctionBarriers.OnCreate(axMapControl.Object);
            axMapControl.CurrentTool = toolAddJunctionBarriers as ITool;
            this.toolStripStatusLabel.Text = "当前选择的工具为添加管点障碍工具";
        }

        private void toolStripButtonAddEdgeBarrier_Click(object sender, EventArgs e)
        {
            ToolAddEdgeBarriers toolAddEdgeBarriers = new ToolAddEdgeBarriers();
            toolAddEdgeBarriers.GeometricNetwork = geometricNetwork;
            toolAddEdgeBarriers.ListEdgeBarrierEIDs = listEdgeBarrierEIDs;
            toolAddEdgeBarriers.OnCreate(axMapControl.Object);
            axMapControl.CurrentTool = toolAddEdgeBarriers as ITool;
            this.toolStripStatusLabel.Text = "当前选择的工具为添加管线障碍工具";
        }

        private void ToolStripMenuItemClearFlags_Click(object sender, EventArgs e)
        {
            //清除各类标识显示图形，并将管点和管线标识列表清空
            ClearElements(axMapControl.ActiveView, "Flag");
            listJunctionFlags.Clear();
            listEdgeFlags.Clear();
        }

        private void ToolStripMenuItemClearBarriers_Click(object sender, EventArgs e)
        {
            //清除各类障碍显示图形，并将管点和管线障碍列表清空
            ClearElements(axMapControl.ActiveView, "Barriers");
            listJunctionBarrierEIDs.Clear();
            listEdgeBarrierEIDs.Clear();
        }

        private void ToolStripMenuItemClearResults_Click(object sender, EventArgs e)
        {
            ClearElements(axMapControl.ActiveView, "Result");
        }

        #endregion

        #region 设置网络流向

        //点击“显示流向按钮”时触发
        private void toolStripButtonShowFlow_Click(object sender, EventArgs e)
        {
            try
            {
                //获取当前的逻辑网络            
                INetwork network = geometricNetwork.Network;
                IUtilityNetworkGEN utilityNetworkGEN = network as IUtilityNetworkGEN;
                //针对实例网络，有2个管线图层，分别得到图层的FeatureClass，并绘制管线流向
                IFeatureClass lowPressurePipeFeatureClass = ((IFeatureLayer)axMapControl.Map.get_Layer(5)).FeatureClass;
                IFeatureClass pipeFeatureClass = ((IFeatureLayer)axMapControl.Map.get_Layer(6)).FeatureClass;
                ShowFlowForFeatureClass(lowPressurePipeFeatureClass, utilityNetworkGEN);
                ShowFlowForFeatureClass(pipeFeatureClass, utilityNetworkGEN);
                axMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, axMapControl.ActiveView.FullExtent);
            }
            catch { }
        }

        /// <summary>
        /// 对几何网络中的管线图层的流向进行绘制。
        /// </summary>
        /// <param name="featureClass">所需绘制的图层</param>
        /// <param name="utilityNetworkGEN">当前几何网络对应的逻辑网络</param>
        private void ShowFlowForFeatureClass(IFeatureClass featureClass, IUtilityNetworkGEN utilityNetworkGEN)
        {
            //使用INetElements接口查询网络要素的ElementID
            INetElements netElements = utilityNetworkGEN as INetElements;
            //定义相关变量
            esriFlowDirection flowDirection = new esriFlowDirection();
            int currentEID = -1;
            //对整个图层进行遍历，从而对每个边要素进行绘制
            IFeatureCursor featureCursor = featureClass.Search(null, false);
            IFeature feature = featureCursor.NextFeature();
            while (feature != null)
            {
                currentEID = netElements.GetEID(featureClass.FeatureClassID, feature.OID, 0, esriElementType.esriETEdge);
                //使用IUtilityNetworkGEN接口查询每个网络边要素的流向
                flowDirection = utilityNetworkGEN.GetFlowDirection(currentEID);
                //进行绘制
                DrawArrowElementForEdgeElement(feature, axMapControl.Map, flowDirection);
                feature = featureCursor.NextFeature();
            }
        }

        /// <summary>
        /// 对地图中的要素根据网络流向的值进行绘制。
        /// </summary>
        /// <param name="feature">要绘制的要素</param>
        /// <param name="map">当前地图</param>
        /// <param name="flowDirection">网络流向值</param>
        private void DrawArrowElementForEdgeElement(IFeature feature, IMap map, esriFlowDirection flowDirection)
        {
            //得到管线的中心点，作为绘制箭头符号的位置
            IPolyline polyline = feature.Shape as IPolyline;
            IPoint middlePoint = new PointClass();
            polyline.QueryPoint(esriSegmentExtension.esriNoExtension, polyline.Length / 2, false, middlePoint);
            //定义相关变量
            IArrowMarkerSymbol arrowMarkerSymbol = new ArrowMarkerSymbolClass();
            ISimpleMarkerSymbol simpleMarkerSymbol = new SimpleMarkerSymbolClass();
            IElement element = null;
            //如果流向沿管线数字化方向
            if (flowDirection == esriFlowDirection.esriFDWithFlow)
            {
                //通过线段的起点和终点得到流向的角度
                arrowMarkerSymbol.Angle = GetLineAngleFrom2Points(polyline.FromPoint, polyline.ToPoint);
                arrowMarkerSymbol.Color = GetColorByRGBValue(0, 0, 0);
                arrowMarkerSymbol.Size = 12;
                element = new MarkerElementClass();
                element.Geometry = middlePoint;
                ((IMarkerElement)element).Symbol = arrowMarkerSymbol;
                //将Element的名字设置为Flow，便于今后清除
                ((IElementProperties)element).Name = "Flow";
            }
            //如果流向与数字化方向相反
            else if (flowDirection == esriFlowDirection.esriFDAgainstFlow)
            {
                arrowMarkerSymbol.Angle = GetLineAngleFrom2Points(polyline.ToPoint, polyline.FromPoint);
                arrowMarkerSymbol.Color = GetColorByRGBValue(0, 0, 0);
                arrowMarkerSymbol.Size = 12;
                element = new MarkerElementClass();
                element.Geometry = middlePoint;
                ((IMarkerElement)element).Symbol = arrowMarkerSymbol;
                ((IElementProperties)element).Name = "Flow";
            }
            //如果是未确定的流向
            else if (flowDirection == esriFlowDirection.esriFDIndeterminate)
            {
                simpleMarkerSymbol.Color = GetColorByRGBValue(0, 0, 0);
                simpleMarkerSymbol.Size = 8;
                element = new MarkerElementClass();
                element.Geometry = middlePoint;
                ((IMarkerElement)element).Symbol = simpleMarkerSymbol;
                ((IElementProperties)element).Name = "Flow";
            }
            //如果流向尚未初始化
            else
            {
                simpleMarkerSymbol.Color = GetColorByRGBValue(255, 0, 0);
                simpleMarkerSymbol.Size = 8;
                element = new MarkerElementClass();
                element.Geometry = middlePoint;
                ((IMarkerElement)element).Symbol = simpleMarkerSymbol;
                ((IElementProperties)element).Name = "Flow";
            }
            //添加箭头符号
            IGraphicsContainer gc = map as IGraphicsContainer;
            gc.AddElement(element, 0);
        }

        /// <summary>
        /// 通过线段的起点和终点得到线段的角度
        /// </summary>
        /// <param name="startPoint">线段的起点</param>
        /// <param name="endPoint">线段的终点</param>
        /// <returns>线段的角度</returns>
        private double GetLineAngleFrom2Points(IPoint startPoint, IPoint endPoint)
        {
            double angle = -1;
            //如果起点和终点的纵坐标相等
            if (startPoint.Y == endPoint.Y)
            {
                if (startPoint.X < endPoint.X)
                    angle = 0;
                else
                    angle = 180;
            }
            //如果起点和终点的横坐标相等
            else if (startPoint.X == endPoint.X)
            {
                if (startPoint.Y < endPoint.Y)
                    angle = 90;
                else
                    angle = 270;
            }
            //如果起点的纵坐标小于终点的纵坐标
            else if (startPoint.Y < endPoint.Y)
            {
                if (startPoint.X < endPoint.X)
                    angle = (Math.Atan((endPoint.Y - startPoint.Y) / (endPoint.X - startPoint.X))) * 180 / Math.PI;
                else
                    angle = Math.Atan((startPoint.X - endPoint.X) / (endPoint.Y - startPoint.Y)) * 180 / Math.PI + 90;
            }
            //如果起点的纵坐标大于终点的纵坐标
            else
            {
                if (endPoint.X < startPoint.X)
                    angle = Math.Atan((startPoint.Y - endPoint.Y) / (startPoint.X - endPoint.X)) * 180 / Math.PI + 180;
                else
                    angle = 360 - Math.Atan((startPoint.Y - endPoint.Y) / (endPoint.X - startPoint.X)) * 180 / Math.PI;
            }
            return angle;
        }

        private void toolStripButtonClearFlow_Click(object sender, EventArgs e)
        {
            //清除管线的流向显示
            ClearElements(axMapControl.ActiveView, "Flow");
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 根据R、G、B值获取IColor接口的颜色变量。
        /// </summary>
        /// <param name="red">R分量值</param>
        /// <param name="green">G分量值</param>
        /// <param name="blue">B分量值</param>
        /// <returns>IColor接口的颜色变量</returns>
        public static IColor GetColorByRGBValue(int red, int green, int blue)
        {
            IRgbColor rgbColor = new RgbColorClass();
            rgbColor.Red = red;
            rgbColor.Green = green;
            rgbColor.Blue = blue;
            return rgbColor as IColor;
        }

        /// <summary>
        /// 根据FeatureClass的ID在当前地图中获取FeatureClass。
        /// </summary>
        /// <param name="userClassID">FeatureClass的ID</param>
        /// <param name="map">当前地图</param>
        /// <returns>IFeatureClass接口的变量，或为空</returns>
        private IFeatureClass GetFeatureClassByID(int userClassID, IMap map)
        {
            IFeatureClass featureClass = null;
            for (int i = 0; i < map.LayerCount; i++)
            {
                featureClass = ((IFeatureLayer)map.get_Layer(i)).FeatureClass;
                if (featureClass.FeatureClassID == userClassID)
                    return featureClass;
            }
            return null;
        }

        /// <summary>
        /// 根据Element的名称清除当前视图中的Element。
        /// </summary>
        /// <param name="activeView">当前视图</param>
        /// <param name="elementName">Element的名称</param>
        private void ClearElements(IActiveView activeView, string elementName)
        {
            IGraphicsContainer graphicsContainer = activeView as IGraphicsContainer;
            graphicsContainer.Reset();
            IElement element = graphicsContainer.Next();
            while (element != null)
            {
                if (((IElementProperties)element).Name == elementName)
                    graphicsContainer.DeleteElement(element);
                element = graphicsContainer.Next();
            }
            activeView.Refresh();
        }

        /// <summary>
        /// 返回当前数组中值的总和。
        /// </summary>
        /// <param name="segmentCosts">数据来源数组</param>
        /// <returns>值的总和</returns>
        private int GetSegmentCosts(object[] segmentCosts)
        {
            int sum = 0;
            for (int i = 0; i < segmentCosts.Length; i++)
                sum += Convert.ToInt32(segmentCosts[i]);
            return sum;
        }

        /// <summary>
        /// 根据管点标识列表和管线标识列表返回两个列表元素的总个数。
        /// </summary>
        /// <returns>两个列表元素的总个数</returns>
        private int GetSegmentCounts()
        {
            int counts = 0;
            if (listJunctionFlags.Count > 0 && listEdgeFlags.Count > 0)
            {
                counts = listJunctionFlags.Count + listEdgeFlags.Count;
            }
            else if (listJunctionFlags.Count > 0)
            {
                counts = listJunctionFlags.Count;
            }
            else if (listEdgeFlags.Count > 0)
            {
                counts = listEdgeFlags.Count;
            }
            return counts;
        }

        /// <summary>
        /// 根据FeatureClass的名称获取当前地图中该FeatureClass的ID。
        /// </summary>
        /// <param name="featureClassName">FeatureClass的名称</param>
        /// <param name="map">当前地图</param>
        /// <returns>该FeatureClass的ID</returns>
        private int GetFeatureClassIDByName(string featureClassName, IMap map)
        {
            int id = 0;
            IFeatureLayer featureLayer;
            for (int i = 0; i < map.LayerCount; i++)
            {
                featureLayer = map.get_Layer(i) as IFeatureLayer;
                if (featureLayer.FeatureClass.AliasName == featureClassName)
                    id = featureLayer.FeatureClass.FeatureClassID;
            }
            return id;
        }

        #endregion

        #region 网络追踪分析

        private void toolStripButtonSolver_Click(object sender, EventArgs e)
        {
            try
            {
                //首先清除已有的分析结果
                ClearElements(axMapControl.ActiveView, "Result");

                //为追踪任务解决器设置进行分析的管点
                IJunctionFlag[] arrayJunctionFlag = new IJunctionFlag[listJunctionFlags.Count];
                for (int i = 0; i < listJunctionFlags.Count; i++)
                    arrayJunctionFlag[i] = listJunctionFlags[i];
                traceFlowSolverGEN.PutJunctionOrigins(ref arrayJunctionFlag);
                //为追踪任务解决器设置进行分析的管线
                IEdgeFlag[] arrayEdgeFlag = new IEdgeFlag[listEdgeFlags.Count];
                for (int j = 0; j < listEdgeFlags.Count; j++)
                    arrayEdgeFlag[j] = listEdgeFlags[j];
                traceFlowSolverGEN.PutEdgeOrigins(ref arrayEdgeFlag);
                //为追踪任务解决器设置进行分析的管点障碍或管线障碍
                INetElementBarriersGEN netElementBarriersGEN = new NetElementBarriersClass();
                netElementBarriersGEN.Network = geometricNetwork.Network;
                //如果目前有管点障碍，则加入分析器中
                if (listJunctionBarrierEIDs.Count > 0)
                {
                    int[] junctionBarrierEIDs = new int[listJunctionBarrierEIDs.Count];
                    for (int u = 0; u < junctionBarrierEIDs.Length; u++)
                        junctionBarrierEIDs[u] = listJunctionBarrierEIDs[u];
                    netElementBarriersGEN.ElementType = esriElementType.esriETJunction;
                    netElementBarriersGEN.SetBarriersByEID(ref junctionBarrierEIDs);
                    netSolver.set_ElementBarriers(esriElementType.esriETJunction, netElementBarriersGEN as INetElementBarriers);
                }
                //否则将管点障碍设置为空
                else
                    netSolver.set_ElementBarriers(esriElementType.esriETJunction, null);
                //如果目前有管线障碍，则加入分析器中
                if (listEdgeBarrierEIDs.Count > 0)
                {
                    int[] edgeBarrierEIDs = new int[listEdgeBarrierEIDs.Count];
                    for (int u = 0; u < edgeBarrierEIDs.Length; u++)
                        edgeBarrierEIDs[u] = listEdgeBarrierEIDs[u];
                    netElementBarriersGEN.ElementType = esriElementType.esriETEdge;
                    netElementBarriersGEN.SetBarriersByEID(ref edgeBarrierEIDs);
                    netSolver.set_ElementBarriers(esriElementType.esriETEdge, netElementBarriersGEN as INetElementBarriers);
                }
                //否则将管线障碍设置为空
                else
                    netSolver.set_ElementBarriers(esriElementType.esriETEdge, null);
                //定义相关变量
                IEnumNetEID junctionEIDs = new EnumNetEIDArrayClass();
                IEnumNetEID edgeEIDs = new EnumNetEIDArrayClass();
                int count = -1;
                object[] segmentCosts = null;
                object pTotalCost = null;

                switch (toolStripComboBoxTraceTasks.SelectedIndex)
                {
                    //查找共同祖先
                    case 0:
                        traceFlowSolverGEN.FindCommonAncestors(esriFlowElements.esriFEJunctionsAndEdges,
                            out junctionEIDs, out edgeEIDs);
                        toolStripStatusLabel.Text = "";
                        break;
                    //查找相连接的网络要素
                    case 1:
                        traceFlowSolverGEN.FindFlowElements(esriFlowMethod.esriFMConnected, esriFlowElements.esriFEJunctionsAndEdges,
                            out junctionEIDs, out edgeEIDs);
                        toolStripStatusLabel.Text = "";
                        break;
                    //查找网络中的环
                    case 2:
                        traceFlowSolverGEN.FindCircuits(esriFlowElements.esriFEJunctionsAndEdges, out junctionEIDs, out edgeEIDs);
                        toolStripStatusLabel.Text = "";
                        break;
                    //查找未连接的网络要素
                    case 3:
                        traceFlowSolverGEN.FindFlowUnreachedElements(esriFlowMethod.esriFMConnected, esriFlowElements.esriFEJunctionsAndEdges,
                            out junctionEIDs, out edgeEIDs);
                        toolStripStatusLabel.Text = "";
                        break;
                    //查找上游路径。同时获取网络追踪的耗费。
                    case 4:
                        count = GetSegmentCounts();
                        segmentCosts = new object[count];
                        traceFlowSolverGEN.FindSource(esriFlowMethod.esriFMUpstream, esriShortestPathObjFn.esriSPObjFnMinSum,
                            out junctionEIDs, out edgeEIDs, count, ref segmentCosts);
                        toolStripStatusLabel.Text = "网络追踪的总耗费为：" + GetSegmentCosts(segmentCosts).ToString();
                        break;
                    //查找路径。同时获取网络追踪的耗费。count比所有标识的总数少1个。当同时存在JunctionFlag和EdgeFlag时，该功能不可用。
                    case 5:
                        if (listJunctionFlags.Count > 0 && listEdgeFlags.Count > 0)
                            break;
                        else if (listJunctionFlags.Count > 0)
                            count = listJunctionFlags.Count - 1;
                        else if (listEdgeFlags.Count > 0)
                            count = listEdgeFlags.Count - 1;
                        else
                            break;
                        segmentCosts = new object[count];
                        traceFlowSolverGEN.FindPath(esriFlowMethod.esriFMConnected, esriShortestPathObjFn.esriSPObjFnMinSum,
                            out junctionEIDs, out edgeEIDs, count, ref segmentCosts);
                        toolStripStatusLabel.Text = "网络追踪的总耗费为：" + GetSegmentCosts(segmentCosts).ToString();
                        break;
                    //下游追踪
                    case 6:
                        traceFlowSolverGEN.FindFlowElements(esriFlowMethod.esriFMDownstream, esriFlowElements.esriFEJunctionsAndEdges,
                            out junctionEIDs, out edgeEIDs);
                        toolStripStatusLabel.Text = "";
                        break;
                    //查找上游路径累积消耗。同时获取网络追踪的耗费。
                    case 7:
                        pTotalCost = new object();
                        traceFlowSolverGEN.FindAccumulation(esriFlowMethod.esriFMUpstream, esriFlowElements.esriFEJunctionsAndEdges,
                            out junctionEIDs, out edgeEIDs, out pTotalCost);
                        toolStripStatusLabel.Text = "网络追踪的总耗费为：" + pTotalCost.ToString();
                        break;
                    //上游追踪。
                    case 8:
                        count = GetSegmentCounts();
                        segmentCosts = new object[count];
                        traceFlowSolverGEN.FindSource(esriFlowMethod.esriFMUpstream, esriShortestPathObjFn.esriSPObjFnMinSum,
                            out junctionEIDs, out edgeEIDs, count, ref segmentCosts);
                        toolStripStatusLabel.Text = "";
                        break;
                }
                //绘制分析结果
                DrawTraceResults(junctionEIDs, edgeEIDs, GetColorByRGBValue(255, 0, 0));
            }
            catch { }
        }

        /// <summary>
        /// 根据设定的颜色绘制网络分析结果中的管点和管线。
        /// </summary>
        /// <param name="junctionEIDs">分析结果管点</param>
        /// <param name="edgeEIDs">分析结果管线</param>
        /// <param name="color">设定的颜色</param>
        private void DrawTraceResults(IEnumNetEID junctionEIDs, IEnumNetEID edgeEIDs, IColor color)
        {
            INetElements netElements = geometricNetwork.Network as INetElements;
            int userClassID = -1;
            int userID = -1;
            int userSubID = -1;
            int eid = -1;
            IFeature feature;
            IFeatureClass featureClass;
            //设置管点和管线显示的Symbol
            ISimpleMarkerSymbol simpleMarkerSymbol = new SimpleMarkerSymbolClass();
            simpleMarkerSymbol.Color = color;
            simpleMarkerSymbol.Size = 6;
            simpleMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
            ISimpleLineSymbol simpleLineSymbol = new SimpleLineSymbolClass();
            simpleLineSymbol.Color = color;
            simpleLineSymbol.Width = 2;
            simpleLineSymbol.Style = esriSimpleLineStyle.esriSLSSolid;
            IElement element;
            //如果分析结果中包含管点，则查询其对应的空间要素并绘制
            if (junctionEIDs != null)
            {
                for (int i = 0; i < junctionEIDs.Count; i++)
                {
                    eid = junctionEIDs.Next();
                    netElements.QueryIDs(eid, esriElementType.esriETJunction, out userClassID, out userID, out userSubID);
                    featureClass = GetFeatureClassByID(userClassID, axMapControl.Map);
                    if (featureClass != null)
                    {
                        feature = featureClass.GetFeature(userID);

                        element = new MarkerElementClass();
                        element.Geometry = feature.Shape;
                        ((IMarkerElement)element).Symbol = simpleMarkerSymbol;
                        ((IElementProperties)element).Name = "Result";
                        ((IGraphicsContainer)axMapControl.ActiveView).AddElement(element, 0);
                    }
                }
            }
            //如果分析结果中包含管线，则查询其对应的空间要素并绘制
            if (edgeEIDs != null)
            {
                for (int i = 0; i < edgeEIDs.Count; i++)
                {
                    eid = edgeEIDs.Next();
                    netElements.QueryIDs(eid, esriElementType.esriETEdge, out userClassID, out userID, out userSubID);
                    featureClass = GetFeatureClassByID(userClassID, axMapControl.Map);
                    feature = featureClass.GetFeature(userID);

                    element = new LineElementClass();
                    element.Geometry = feature.Shape;
                    ((ILineElement)element).Symbol = simpleLineSymbol;
                    ((IElementProperties)element).Name = "Result";
                    ((IGraphicsContainer)axMapControl.ActiveView).AddElement(element, 0);
                }
            }
            //刷新地图中的图形
            axMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, axMapControl.ActiveView.Extent);
        }

        #endregion

        #region 爆管分析

        private void toolStripButtonAddBGFlag_Click(object sender, EventArgs e)
        {
            ToolSelectBurstPipe toolSelectBurstPipe = new ToolSelectBurstPipe();
            toolSelectBurstPipe.GeometricNetwork = geometricNetwork;
            toolSelectBurstPipe.ListBurstPipeEIDs = listBurstPipeEIDs;
            toolSelectBurstPipe.OnCreate(axMapControl.Object);
            axMapControl.CurrentTool = toolSelectBurstPipe as ITool;
            this.toolStripStatusLabel.Text = "请选择爆管的管线";
        }

        //点击爆管关阀分析时执行
        private void ToolStripMenuItemBurstAnalysis_Click(object sender, EventArgs e)
        {
            try
            {
                ClearElements(axMapControl.ActiveView, "BurstResult");
                ClearElements(axMapControl.ActiveView, "Result");
                //先清空所分析网络的管点标识
                IJunctionFlag[] junctionFlagArray = new IJunctionFlag[0];
                traceFlowSolverGEN.PutJunctionOrigins(ref junctionFlagArray);
                //查询并定义所需关闭的阀门为网络分析标识
                INetElements netElements = geometricNetwork.Network as INetElements;
                int userClassID = 0;
                int userID = 0;
                int userSubID = 0;
                netElements.QueryIDs(listBurstPipeEIDs[0], esriElementType.esriETEdge, out userClassID, out userID, out userSubID);
                INetFlag edgeFlag = new EdgeFlagClass();
                edgeFlag.UserClassID = userClassID;
                edgeFlag.UserID = userID;
                edgeFlag.UserSubID = userSubID;
                IEdgeFlag[] edgeFlagArray = new IEdgeFlag[1];
                edgeFlagArray[0] = edgeFlag as IEdgeFlag;
                traceFlowSolverGEN.PutEdgeOrigins(ref edgeFlagArray);
                //首先进行上游追踪分析，返回并用蓝色绘制上游的所有管点和管线
                IEnumNetEID upstreamJunctionEIDs = new EnumNetEIDArrayClass();
                IEnumNetEID upstreamEdgeEIDs = new EnumNetEIDArrayClass();
                int count = edgeFlagArray.Length;
                object[] segmentCosts = new object[count];
                traceFlowSolverGEN.FindSource(esriFlowMethod.esriFMUpstream, esriShortestPathObjFn.esriSPObjFnMinSum,
                    out upstreamJunctionEIDs, out upstreamEdgeEIDs, count, ref segmentCosts);
                DrawTraceResults(upstreamJunctionEIDs, upstreamEdgeEIDs, GetColorByRGBValue(0, 0, 255));
                //再进行下游追踪分析，以便得到下游的阀门
                IEnumNetEID downstreamJunctionEIDs = new EnumNetEIDArrayClass();
                IEnumNetEID downstreamEdgeEIDs = new EnumNetEIDArrayClass();
                traceFlowSolverGEN.FindFlowElements(esriFlowMethod.esriFMDownstream, esriFlowElements.esriFEJunctions,
                    out downstreamJunctionEIDs, out downstreamEdgeEIDs);
                //对分析结果进行遍历和判断，如果该网络元素对应的空间要素为阀门，则其为需要关闭的阀门，直接结束方法的运行            
                StringBuilder sb = new StringBuilder();
                GetClosedValves(upstreamJunctionEIDs, netElements, userClassID, userID, userSubID, true, sb);
                GetClosedValves(downstreamJunctionEIDs, netElements, userClassID, userID, userSubID, false, sb);
                MessageBox.Show(sb.ToString());
            }
            catch { }
        }

        //点击影响范围分析时执行
        private void ToolStripMenuItemAffectArea_Click(object sender, EventArgs e)
        {
            try
            {
                //首先查询并定义所需关闭的阀门为网络分析标识
                INetElements netElements = geometricNetwork.Network as INetElements;
                int userClassID = 0;
                int userID = 0;
                int userSubID = 0;
                IJunctionFlag[] junctionFlagArray = new IJunctionFlag[listClosedValveEIDs.Count];
                for (int i = 0; i < listClosedValveEIDs.Count; i++)
                {
                    netElements.QueryIDs(listClosedValveEIDs[i], esriElementType.esriETJunction, out userClassID, out userID, out userSubID);
                    INetFlag junctionFlag = new JunctionFlagClass();
                    junctionFlag.UserClassID = userClassID;
                    junctionFlag.UserID = userID;
                    junctionFlag.UserSubID = userSubID;
                    junctionFlagArray[i] = junctionFlag as IJunctionFlag;
                }
                traceFlowSolverGEN.PutJunctionOrigins(ref junctionFlagArray);
                //再进行下游追踪分析，返回并用红色绘制分析结果
                IEnumNetEID junctionEIDs = new EnumNetEIDArrayClass();
                IEnumNetEID edgeEIDs = new EnumNetEIDArrayClass();
                traceFlowSolverGEN.FindFlowElements(esriFlowMethod.esriFMDownstream, esriFlowElements.esriFEJunctionsAndEdges,
                            out junctionEIDs, out edgeEIDs);
                DrawTraceResults(junctionEIDs, edgeEIDs, GetColorByRGBValue(255, 0, 0));
            }
            catch { }
        }

        private void ToolStripMenuItemClearBurstAnalysisResults_Click(object sender, EventArgs e)
        {
            //清除爆管分析的各类标识和结果，并清空爆管和阀门元素记录
            ClearElements(axMapControl.ActiveView, "BurstPipe");
            ClearElements(axMapControl.ActiveView, "BurstResult");
            ClearElements(axMapControl.ActiveView, "Result");
            listBurstPipeEIDs.Clear();
            listClosedValveEIDs.Clear();
        }

        /// <summary>
        /// 根据已分析得到的管点获取需要关闭的阀门。
        /// </summary>
        /// <param name="junctionEIDs">已得到的管点分析结果</param>
        /// <param name="netElements">所分析的逻辑网络</param>
        /// <param name="userClassID">要素类ID</param>
        /// <param name="userID">要素ID</param>
        /// <param name="userSubID">要素子ID</param>
        /// <param name="isUpstreamValve">是否是上游追踪得到的阀门</param>
        /// <param name="sb">记录需要输出字符串的字符串生成器</param>
        private void GetClosedValves(IEnumNetEID junctionEIDs, INetElements netElements,
            int userClassID, int userID, int userSubID, bool isUpstreamValve, StringBuilder sb)
        {
            int eid = -1;
            junctionEIDs.Reset();
            for (int i = 0; i < junctionEIDs.Count; i++)
            {
                eid = junctionEIDs.Next();
                netElements.QueryIDs(eid, esriElementType.esriETJunction, out userClassID, out userID, out userSubID);
                if (userClassID == GetFeatureClassIDByName("famen", axMapControl.Map))
                {
                    listClosedValveEIDs.Add(eid);
                    IFeature feature = GetFeatureClassByID(userClassID, axMapControl.Map).GetFeature(userID);
                    ISimpleMarkerSymbol simpleMarkerSymbol = new SimpleMarkerSymbolClass();
                    simpleMarkerSymbol.Color = FormMain.GetColorByRGBValue(255, 0, 0);
                    simpleMarkerSymbol.Size = 12;
                    simpleMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSSquare;
                    IElement element = new MarkerElementClass();
                    element.Geometry = feature.Shape;
                    ((IMarkerElement)element).Symbol = simpleMarkerSymbol;
                    ((IElementProperties)element).Name = "BurstResult";
                    ((IGraphicsContainer)axMapControl.ActiveView).AddElement(element, 0);
                    axMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, axMapControl.ActiveView.Extent);
                    sb.AppendLine("应关闭的阀门编号为：" + feature.get_Value(feature.Fields.FindField("阀门编号")).ToString());
                    return;
                }
            }
        }

        #endregion
    }
}