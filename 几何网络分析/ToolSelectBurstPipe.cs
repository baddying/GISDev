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
    /// Summary description for ToolSelectBurstPipe.
    /// </summary>
    [Guid("43b29d39-b9d1-4c92-9772-292ab05d789c")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("UtilityNetwork.ToolSelectBurstPipe")]
    public sealed class ToolSelectBurstPipe : BaseTool
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
        /// 保存发生爆管的管线列表
        /// </summary>
        private List<int> listBurstPipeEIDs;

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
        /// 设置保存发生爆管的管线列表
        /// </summary>
        public List<int> ListBurstPipeEIDs
        {
            set
            {
                listBurstPipeEIDs = value;
            }
        }

        public ToolSelectBurstPipe()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "几何网络分析"; //localizable text 
            base.m_caption = "选择爆管位置";  //localizable text 
            base.m_message = "在地图上点击管线，将其设置为爆管管线。";  //localizable text
            base.m_toolTip = "选择爆管位置";  //localizable text
            base.m_name = "SelectBurstPipeTool";   //unique id, non-localizable (e.g. "MyCategory_MyTool")
            try
            {
                //
                // TODO: change resource name if necessary
                //
                //使用资源来获取当前工具的图标，资源名称为“项目名称.图标文件名”
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
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

            // TODO:  Add ToolSelectBurstPipe.OnCreate implementation
        }

        /// <summary>
        /// Occurs when this tool is clicked
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add ToolSelectBurstPipe.OnClick implementation
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
            pointToEID.GetNearestEdge(point, out nearestEdgeEID, out outPoint, out percent);
            //如果获取得到管线元素
            if (outPoint != null)
            {
                //设置爆管元素
                listBurstPipeEIDs.Add(nearestEdgeEID);
                //绘制并显示标识点
                ISimpleMarkerSymbol simpleMarkerSymbol = new SimpleMarkerSymbolClass();
                simpleMarkerSymbol.Color = FormMain.GetColorByRGBValue(255, 0, 0);
                simpleMarkerSymbol.Size = 12;
                simpleMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
                IElement element = new MarkerElementClass();
                element.Geometry = outPoint;
                ((IMarkerElement)element).Symbol = simpleMarkerSymbol;
                ((IElementProperties)element).Name = "BurstPipe";
                ((IGraphicsContainer)activeView).AddElement(element, 0);
                activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, activeView.Extent);
            }
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ToolSelectBurstPipe.OnMouseMove implementation
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ToolSelectBurstPipe.OnMouseUp implementation
        }
        #endregion
    }
}
