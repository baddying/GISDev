using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;

namespace EditSDELayerDemo.Menu
{
    /// <summary>
    /// Summary description for ToolDeleteFeature.
    /// </summary>
    [Guid("9178f46a-b450-4ea0-8273-ad85401fb78e")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("EditSDELayerDemo.Menu.ToolDeleteFeature")]
    public sealed class ToolDeleteFeature : BaseTool
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

        public ToolDeleteFeature()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "信息编辑"; //localizable text 
            base.m_caption = "删除要素";  //localizable text 
            base.m_message = "信息编辑_删除要素";  //localizable text
            base.m_toolTip = "删除要素";  //localizable text
            base.m_name = "ToolDeleteFeature";   //unique id, non-localizable (e.g. "MyCategory_MyTool")
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
                MessageBox.Show("未打开工作空间！");
                return;
            }
            workSpaceEdit = EditCommonClass.workSpaceEdit;

        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            try
            {
                if (Button != 1)
                {
                    return;
                }
                if (EditCommonClass.focusFeatureLayer == null)
                {
                    MessageBox.Show("未获得目标编辑图层！");
                    return;
                }
                editFeatureLayer = EditCommonClass.focusFeatureLayer;
                IRubberBand envRubber = new RubberEnvelopeClass();
                IEnvelope pEnvelop = envRubber.TrackNew(m_hookHelper.ActiveView.ScreenDisplay, null) as IEnvelope;
                if (pEnvelop == null)
                {
                    return;
                }
                //通过矩形选择要素
                IGeometry thGeotry = pEnvelop as IGeometry;
                ISpatialFilter filter = new SpatialFilterClass();
                filter.Geometry = thGeotry;
                filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;

                var feaCur = editFeatureLayer.FeatureClass.Search(filter, false);
                var fea = feaCur.NextFeature();
                var feaselection = editFeatureLayer as IFeatureSelection;
                feaselection.Clear();
                while (fea != null)
                {
                    feaselection.Add(fea);
                    fea = feaCur.NextFeature();
                }

                //var feaSelection = editFeatureLayer as IFeatureSelection;
                //if (feaSelection == null)
                //{
                //    return;
                //}
                //feaSelection.SelectFeatures(filter, esriSelectionResultEnum.esriSelectionResultNew, false);
                //m_hookHelper.ActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeoSelection,null,null);
                m_hookHelper.ActiveView.Refresh();


                IFeatureCursor updateCursor = editFeatureLayer.FeatureClass.Update(filter, false);
                IFeature pFeature = updateCursor.NextFeature();
                if (pFeature != null)
                {
                    if (MessageBox.Show("是否确认删除当前选中要素?", "删除提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        workSpaceEdit.StartEditOperation();
                        while (pFeature != null)
                        {
                            updateCursor.DeleteFeature();
                            pFeature = updateCursor.NextFeature();
                        }
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(updateCursor);
                        workSpaceEdit.StopEditOperation();
                        feaselection.Clear();
                        m_hookHelper.ActiveView.Refresh();
                        // m_hookHelper.ActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
                    }
                }

            }
            catch
            {
 
            }
        
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ToolDeleteFeature.OnMouseUp implementation
        }
        #endregion
    }
}
