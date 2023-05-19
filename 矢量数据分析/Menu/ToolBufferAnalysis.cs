using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Display;

namespace EditSDELayerDemo.Menu
{
    /// <summary>
    /// Summary description for ToolBufferAnalysis.
    /// </summary>
    [Guid("16fb0390-e544-4815-b7b0-178ce89fa7ba")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("EditSDELayerDemo.Menu.ToolBufferAnalysis")]
    public sealed class ToolBufferAnalysis : BaseTool
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

        public ToolBufferAnalysis()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "ʸ������"; //localizable text 
            base.m_caption = "����������";  //localizable text 
            base.m_message = "���ѡ��Ҫ�����ɻ�����";  //localizable text
            base.m_toolTip = "���ѡ��Ҫ�����ɻ�����";  //localizable text
            base.m_name = "ToolBufferAnalysis";   //unique id, non-localizable (e.g. "MyCategory_MyTool")
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
            //�ж�MapControl�Ƿ���ͼ��
            if (m_hookHelper.FocusMap.LayerCount <= 0)
            {
                MessageBox.Show("���ȼ���ͼ�����ݣ�");
                return;
            }
            //�޸������ʽ
            (this.m_hookHelper.Hook as MapControl).MousePointer = esriControlsMousePointer.esriPointerHand;
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            if (Button != 1 || m_hookHelper.FocusMap.LayerCount <= 0)
                return;
            IActiveView pActiveView = m_hookHelper.ActiveView;
            IGraphicsContainer pGraCont = (IGraphicsContainer)pActiveView;
            //ɾ����ͼ����ӵ�����Element
            pGraCont.DeleteAllElements();
            //��õ��λ�ò�ת��Ϊ��ͼ��Ҫ��
            IPoint pPoint = pActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
            //��õ�ͼ��ͼ��
            IFeatureLayer pFeatureLayer = m_hookHelper.FocusMap.get_Layer(0) as IFeatureLayer;
            if (pFeatureLayer == null)
            {
                return;
            }
            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
            //���е������ѯͼ��Ҫ��
            ISpatialFilter pSpatialFilter = new SpatialFilterClass();
            pSpatialFilter.Geometry = pPoint;
            pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
            IFeatureCursor featureCursor = pFeatureClass.Search(pSpatialFilter, false);
            //��õ����ѯ��Ҫ��
            IFeature pFeature = featureCursor.NextFeature();
            if (pFeature != null && pFeature.Shape.GeometryType == esriGeometryType.esriGeometryPolygon)
            {
                IGeometry pGeometry = pFeature.Shape as IGeometry;
                //ͨ��ITopologicalOperator�ӿڽ��ж���εļ򵥻�����
                ITopologicalOperator pTopoOpe = (ITopologicalOperator)pGeometry;
                pTopoOpe.Simplify();
                //ͨ���������������
                IGeometry pBufferGeo = pTopoOpe.Buffer(5000);
                //��������η�����ʽ����ӵ���ͼ��
                IScreenDisplay pdisplay = pActiveView.ScreenDisplay;
                ISimpleFillSymbol pSymbol = new SimpleFillSymbolClass();
                pSymbol.Style = esriSimpleFillStyle.esriSFSCross;
                RgbColor pColor = new RgbColorClass();
                pColor.Blue = 200;
                pColor.Red = 211;
                pColor.Green = 100;
                pSymbol.Color = (IColor)pColor;
                //�����������ȾЧ����Element
                IFillShapeElement pFillShapeElm = new PolygonElementClass(); 
                IElement pElm = (IElement)pFillShapeElm;
                pElm.Geometry = pBufferGeo;
                pFillShapeElm.Symbol = pSymbol;
                //����Ⱦ֮��Ķ����Element��ӵ���ͼIGraphicsContainer����
                pGraCont.AddElement((IElement)pFillShapeElm, 0);
            }
            //ˢ�µ�ͼ
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ToolBufferAnalysis.OnMouseMove implementation
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ToolBufferAnalysis.OnMouseUp implementation
        }
        #endregion
    }
}
