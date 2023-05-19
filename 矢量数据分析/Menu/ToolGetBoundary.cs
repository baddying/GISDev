using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;

namespace EditSDELayerDemo.Menu
{
    /// <summary>
    /// Summary description for ToolGetBoundary.
    /// </summary>
    [Guid("d5551be2-0e9f-4d99-8931-5d876ef86d6c")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("EditSDELayerDemo.Menu.ToolGetBoundary")]
    public sealed class ToolGetBoundary : BaseTool
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
            MxCommands.Register(regKey);
            ControlsCommands.Register(regKey);
        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Unregister(regKey);
            ControlsCommands.Unregister(regKey);
        }

        #endregion
        #endregion

        private IHookHelper m_hookHelper = null;

        public ToolGetBoundary()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "矢量分析"; //localizable text 
            base.m_caption = "获取边界";  //localizable text 
            base.m_message = "点击查询获取选择要素边界";  //localizable text
            base.m_toolTip = "点击查询获取选择要素边界";  //localizable text
            base.m_name = "ToolGetBoundary";   //unique id, non-localizable (e.g. "MyCategory_MyTool")
            try
            {
                //
                // TODO: change resource name if necessary
                //
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
            try
            {
                m_hookHelper = new HookHelperClass();
                m_hookHelper.Hook = hook;
                if (m_hookHelper.ActiveView == null)
                {
                    m_hookHelper = null;
                }
            }
            catch
            {
                m_hookHelper = null;
            }

            if (m_hookHelper == null)
                base.m_enabled = false;
            else
                base.m_enabled = true;

            // TODO:  Add other initialization code
        }

        /// <summary>
        /// Occurs when this tool is clicked
        /// </summary>
        public override void OnClick()
        {
            //判断MapControl是否有图层
            if (m_hookHelper.FocusMap.LayerCount <= 0)
            {
                MessageBox.Show("请先加载图层数据！");
                return;
            }
            //修改鼠标样式
            (this.m_hookHelper.Hook as MapControl).MousePointer = esriControlsMousePointer.esriPointerHand;
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            if (Button != 1 || m_hookHelper.FocusMap.LayerCount <= 0)
                return;
            IActiveView pActiveView = m_hookHelper.ActiveView;
            IGraphicsContainer pGraCont = (IGraphicsContainer)pActiveView;
            //删除地图上添加的所有Element
            pGraCont.DeleteAllElements();
            //获得点击位置并转化为点图形要素
            IPoint pPoint = pActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
            //获得地图中图层
            IFeatureLayer pFeatureLayer = m_hookHelper.FocusMap.get_Layer(0) as IFeatureLayer;
            if (pFeatureLayer == null)
            {
                return;
            }
            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
            //进行点击查询图层要素
            ISpatialFilter pSpatialFilter = new SpatialFilterClass();
            pSpatialFilter.Geometry = pPoint;
            pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
            IFeatureCursor featureCursor = pFeatureClass.Search(pSpatialFilter, false);
            //获得点击查询的要素
            IFeature pFeature = featureCursor.NextFeature();
            if (pFeature != null && pFeature.Shape.GeometryType == esriGeometryType.esriGeometryPolygon)
            {
                IGeometry pGeometry = pFeature.Shape as IGeometry;
                ITopologicalOperator pTopoOpe = (ITopologicalOperator)pGeometry;
                //获取边界
                IGeometry pBoundary = pTopoOpe.Boundary;
                ILineElement pLineEle = new LineElementClass();
                ISimpleLineSymbol pSLS = new SimpleLineSymbol();
                IRgbColor pColor = new RgbColor();
                pColor.Red = 0;
                pColor.Green = 255;
                pColor.Blue = 0;
                pSLS.Color = pColor;
                pSLS.Width = 5;
                pLineEle.Symbol = pSLS;

                IElement pElement = pLineEle as IElement;
                pElement.Geometry = pBoundary;
                pGraCont.AddElement(pElement, 0); //显示边界
            }
            //刷新地图
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private IRgbColor GetColor(int r, int g, int b)
        {
            IRgbColor pColor = new RgbColor();
            pColor.Red = r;
            pColor.Green = g;
            pColor.Blue = b;
            return pColor;
        }
        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ToolGetBoundary.OnMouseMove implementation
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ToolGetBoundary.OnMouseUp implementation
        }
        #endregion
    }
}
