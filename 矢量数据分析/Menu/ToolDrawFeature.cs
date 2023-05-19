using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;

namespace EditSDELayerDemo.Menu
{
    /// <summary>
    /// Summary description for ToolDrawFeature.
    /// </summary>
    [Guid("5afe7ab9-9478-4174-aec2-08df58f84995")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("EditSDELayerDemo.Menu.ToolDrawFeature")]
    public sealed class ToolDrawFeature : BaseTool
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

        private IFeatureLayer editFeatureLayer = null;
        private IWorkspaceEdit workSpaceEdit = null;
        //������
        private bool m_LineMouseDown = false;
        private IPointCollection linePointCollection = new PolylineClass() as IPointCollection;
        private INewLineFeedback m_pNewLineFeedback = null;
        //������
        private bool m_PolygonMouseDown = false;
        private IPointCollection polygonPointCollection = new PolygonClass() as IPointCollection;
        private INewPolygonFeedback m_pNewPolygonFeedback;

        public ToolDrawFeature()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "��Ϣ�༭"; //localizable text 
            base.m_caption = "���Ҫ��";  //localizable text 
            base.m_message = "�½��༭Ҫ��";  //localizable text
            base.m_toolTip = "���Ҫ��";  //localizable text
            base.m_name = "ToolDrawFeature";   //unique id, non-localizable (e.g. "MyCategory_MyTool")
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
            if (EditCommonClass.workSpaceEdit == null)
            {
                MessageBox.Show("δ�򿪹����ռ䣡");
                return;
            }
            workSpaceEdit = EditCommonClass.workSpaceEdit;
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            if (EditCommonClass.focusFeatureLayer == null)
            {
                MessageBox.Show("δ���Ŀ��༭ͼ�㣡");
                return;
            }
            editFeatureLayer = EditCommonClass.focusFeatureLayer;
            if (editFeatureLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
            {
                if (Button != 1)
                    return;
                workSpaceEdit.StartEditOperation();
                IPoint pPoint = m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                //������Ҫ��
                IFeatureClass pFeatureClass = editFeatureLayer.FeatureClass;

                IFeatureBuffer featureBuffer = pFeatureClass.CreateFeatureBuffer();
                IFeatureCursor featureCursor = pFeatureClass.Insert(true);
                var geoDataset = pFeatureClass as IGeoDataset;
                pPoint.SpatialReference = geoDataset.SpatialReference;
                featureBuffer.Shape = pPoint;
                featureCursor.InsertFeature(featureBuffer);
                featureCursor.Flush();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(featureCursor);           

                //var feature = pFeatureClass.CreateFeature();
                //var geoDataset = pFeatureClass as IGeoDataset;
                //pPoint.SpatialReference = geoDataset.SpatialReference;
                //feature.Shape = pPoint;
                //feature.Store();
                workSpaceEdit.StopEditOperation();
                //ˢ�µ�ͼ
                m_hookHelper.ActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
            }
            else if (editFeatureLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
            {
                //������Ҫ��
                if (Button == 1)
                {
                    m_LineMouseDown = true;
                   IPoint  m_pPoint = m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                   if (m_pNewLineFeedback == null)
                   {
                       m_pNewLineFeedback = new NewLineFeedback();
                       m_pNewLineFeedback.Display = m_hookHelper.ActiveView.ScreenDisplay;

                       m_pNewLineFeedback.Start(m_pPoint);
                   }
                   else
                   {
                       m_pNewLineFeedback.AddPoint(m_pPoint);
                   }
                   linePointCollection.AddPoint(m_pPoint);

                }
                else if (Button == 2)
                {
                    m_LineMouseDown = false;
                }

            }
            else if (editFeatureLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
            {
                //������Ҫ��
                if (Button == 1)
                {
                    m_PolygonMouseDown = true;
                    IPoint m_pPoint = m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                    if (m_pNewPolygonFeedback == null)
                    {
                        m_pNewPolygonFeedback = new NewPolygonFeedback();
                        m_pNewPolygonFeedback.Display = m_hookHelper.ActiveView.ScreenDisplay;
                        m_pNewPolygonFeedback.Start(m_pPoint);
                    }
                    else
                    {
                        m_pNewPolygonFeedback.AddPoint(m_pPoint);
                    }
                    polygonPointCollection.AddPoint(m_pPoint);
                }
                else if (Button == 2)
                {
                    m_PolygonMouseDown = false;
                }
            }

        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            if (editFeatureLayer == null)
            {
                return;
            }
            IPoint pPt = default(IPoint);
            pPt = m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
            if (editFeatureLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
            {
                if (m_LineMouseDown == false)
                    return;
                //�ƶ� Feedback ����ǰ���λ��
                if ((m_pNewLineFeedback != null))
                {
                    m_pNewLineFeedback.MoveTo(pPt);
                }

            }
            else if (editFeatureLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
            {
                if (m_PolygonMouseDown == false)
                    return;
                //�ƶ� Feedback ����ǰ���λ��
                if ((m_pNewPolygonFeedback != null))
                {
                    m_pNewPolygonFeedback.MoveTo(pPt);
                }
            }

        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            if (Button == 1)
            {
                IActiveView pActiveView = m_hookHelper.ActiveView;
                pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            }
        }
        //˫��ʵ�����Ҫ��
        public override void OnDblClick()
        {
            if (editFeatureLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline && linePointCollection.PointCount >0)
            {
                if (m_pNewLineFeedback != null)
                {
                    IPolyline pPolyline = m_pNewLineFeedback.Stop();
                    if (pPolyline == null)
                    {
                        return;
                    }
                    //������Ҫ��
                    workSpaceEdit.StartEditOperation();
                    IFeatureClass pFeatureClass = editFeatureLayer.FeatureClass;

                    IFeatureBuffer featureBuffer = pFeatureClass.CreateFeatureBuffer();
                    IFeatureCursor featureCursor = pFeatureClass.Insert(true);
                    var geoDataset = pFeatureClass as IGeoDataset;
                    pPolyline.SpatialReference = geoDataset.SpatialReference;
                    featureBuffer.Shape = pPolyline;
                    featureCursor.InsertFeature(featureBuffer);
                    featureCursor.Flush();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(featureCursor);              
                    workSpaceEdit.StopEditOperation();
                    //ˢ�µ�ͼ
                    m_hookHelper.ActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
                    m_pNewLineFeedback = null;
                }
            }
            else if (editFeatureLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon && polygonPointCollection.PointCount > 0)
            {
                if (m_pNewPolygonFeedback != null)
                {
                    IPolygon pPolygon = m_pNewPolygonFeedback.Stop();
                    if (pPolygon == null)
                    {
                        return;
                    }
                    workSpaceEdit.StartEditOperation();
                    //������Ҫ��
                    IFeatureClass pFeatureClass = editFeatureLayer.FeatureClass;

                    IFeatureBuffer featureBuffer = pFeatureClass.CreateFeatureBuffer();
                    IFeatureCursor featureCursor = pFeatureClass.Insert(true);
                    var geoDataset = pFeatureClass as IGeoDataset;
                    pPolygon.SpatialReference = geoDataset.SpatialReference;
                    featureBuffer.Shape = pPolygon;
                    featureCursor.InsertFeature(featureBuffer);
                    featureCursor.Flush();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(featureCursor);      

                    workSpaceEdit.StopEditOperation();
                    //ˢ�µ�ͼ
                    m_hookHelper.ActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
                    m_pNewPolygonFeedback = null;
                } 
            }
        }
        #endregion
    }
}
