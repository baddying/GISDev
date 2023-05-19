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
    public sealed class ToolGetNearFeature : BaseTool
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

        public ToolGetNearFeature()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "ʸ������"; //localizable text 
            base.m_caption = "��ȡ�ڽ�Ҫ��";  //localizable text 
            base.m_message = "������һ�����Ҫ�ص������ڽ�Ҫ��";  //localizable text
            base.m_toolTip = "������һ�����Ҫ�ص������ڽ�Ҫ��";  //localizable text
            base.m_name = "ToolGetNearFeature";   //unique id, non-localizable (e.g. "MyCategory_MyTool")
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
            IMap pMap = m_hookHelper.FocusMap;
            IActiveView pActiveView = m_hookHelper.ActiveView;       
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
                pMap.ClearSelection();
                IRelationalOperator pRelationalOperator = pFeature.Shape as IRelationalOperator;
                //���ñ�ѡ��Ҫ�ص���ɫ
                IRgbColor pColor = new RgbColorClass();
                pColor.Red = 255;
                IFeatureSelection pFeatueSelection = pFeatureLayer as IFeatureSelection;
                pFeatueSelection.SelectionColor = pColor;
                //�����ڽ�Ҫ�أ������ڵ�ͼ��ѡ����
                IFeatureCursor pCompFeaureCursor = pFeatureLayer.Search(null, false);
                IFeature pCompFeature = pCompFeaureCursor.NextFeature();
                //����ͼ��������Ҫ�ؽ����ڽ��ж�
                while(pCompFeature != null)
                {
                    if (pRelationalOperator.Touches(pCompFeature.Shape))
                    {
                        //����Ա�Ҫ���뵱ǰѡ��Ҫ�������ӣ�����뵽��ͼѡ����
                        pMap.SelectFeature(pFeatureLayer,pCompFeature);
                    }
                    pCompFeature = pCompFeaureCursor.NextFeature();
                }
            }
            //ˢ�µ�ͼ
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, pActiveView.Extent);
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
