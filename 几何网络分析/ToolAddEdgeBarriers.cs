using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.NetworkAnalysis;
using System.Collections.Generic;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Display;

namespace UtilityNetwork
{
    /// <summary>
    /// Summary description for ToolAddEdgeBarriers.
    /// </summary>
    [Guid("9e19f6e8-3e95-451a-951c-3f525eacc74c")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("UtilityNetwork.ToolAddEdgeBarriers")]
    public sealed class ToolAddEdgeBarriers : BaseTool
    {
        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Register(regKey);

        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Unregister(regKey);

        }

        #endregion
        #endregion

        private IHookHelper m_hookHelper;
        /// <summary>
        /// 当前的几何网络
        /// </summary>
        private IGeometricNetwork geometricNetwork;
        /// <summary>
        /// 管线障碍标识的列表用来保存所有添加的管线障碍
        /// </summary>
        private List<int> listEdgeBarrierEIDs;

        /// <summary>
        /// 设置当前分析的几何网络
        /// </summary>
        public IGeometricNetwork GeometricNetwork
        {
            set
            {
                geometricNetwork = value;
            }
        }

        /// <summary>
        /// 设置保存所有管线障碍标识的列表
        /// </summary>
        public List<int> ListEdgeBarrierEIDs
        {
            set
            {
                listEdgeBarrierEIDs = value;
            }
        }

        public ToolAddEdgeBarriers()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "几何网络分析"; //localizable text 
            base.m_caption = "添加管线障碍";  //localizable text 
            base.m_message = "在地图上点击管点，将其添加为网络分析的点要素。";  //localizable text
            base.m_toolTip = "添加管线障碍";  //localizable text
            base.m_name = "AddEdgeBarrierTool";   //unique id, non-localizable (e.g. "MyCategory_MyTool")
            try
            {
                //
                // TODO: change resource name if necessary
                //
                //使用资源来获取当前工具的图标，资源名称为“项目名称.图标文件名”
                base.m_bitmap = new System.Drawing.Bitmap(
                   GetType().Assembly.GetManifestResourceStream("UtilityNetwork." + "UtilityNetworkBarrierEdgeAddTool16.png"));
                base.m_cursor = new System.Windows.Forms.Cursor(GetType(), GetType().Name + ".cur");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this tool is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            if (m_hookHelper == null)
                m_hookHelper = new HookHelperClass();

            m_hookHelper.Hook = hook;

            // TODO:  Add ToolAddEdgeBarriers.OnCreate implementation
        }

        /// <summary>
        /// Occurs when this tool is clicked
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add ToolAddEdgeBarriers.OnClick implementation
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            //获取鼠标点击位置的空间点
            IPoint point = new PointClass();
            IActiveView activeView = m_hookHelper.ActiveView;
            point = activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
            IMap map = m_hookHelper.FocusMap;
            //IPointToEID接口用来通过空间点获取该位置的几何网络元素
            IPointToEID pointToEID = new PointToEIDClass();
            pointToEID.GeometricNetwork = geometricNetwork;
            pointToEID.SourceMap = map;
            pointToEID.SnapTolerance = 10;
            //通过IPointToEID接口的GetNearestJunction方法获取点击位置最邻近的管线元素
            int nearestEdgeEID = -1;
            IPoint outPoint = new PointClass();
            double percent = -1;
            pointToEID.GetNearestEdge(point, out nearestEdgeEID, out outPoint,out percent);
            //如果获取得到管线元素
            if (outPoint != null)
            {
                //设置管点标识，并将其加入管线障碍标识列表中
                listEdgeBarrierEIDs.Add(nearestEdgeEID);
                //绘制并显示管线障碍标识
                ISimpleMarkerSymbol simpleMarkerSymbol = new SimpleMarkerSymbolClass();
                simpleMarkerSymbol.Color = FormMain.GetColorByRGBValue(255, 0, 0);
                simpleMarkerSymbol.Size = 12;
                simpleMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSX;
                IElement element = new MarkerElementClass();
                element.Geometry = outPoint;
                ((IMarkerElement)element).Symbol = simpleMarkerSymbol;
                ((IElementProperties)element).Name = "Barriers";
                ((IGraphicsContainer)activeView).AddElement(element, 0);
                activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, activeView.Extent);
            }
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ToolAddEdgeBarriers.OnMouseMove implementation
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ToolAddEdgeBarriers.OnMouseUp implementation
        }
        #endregion
    }
}
