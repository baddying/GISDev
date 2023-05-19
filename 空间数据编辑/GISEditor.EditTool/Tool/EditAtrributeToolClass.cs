using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Display;
using GISEditor.EditTool.BasicClass;
using GISEditor.EditTool.Tool.UC;

namespace GISEditor.EditTool.Tool
{
    public class EditAtrributeToolClass : ICommand, ITool 
    {
        private IMap m_Map = null;
        private bool bEnable = true;
        private IHookHelper m_hookHelper = null;
        private IActiveView m_activeView = null;
        private IEngineEditor m_EngineEditor = null;
        private IEngineEditLayers m_EngineEditLayers = null;
        private List<IFeature> m_lstFeature;
        private frmAttributeEdit frmAttributeEdit;

        #region ICommand 成员

        public int Bitmap
        {
            get { return -1; }
        }

        public string Caption
        {
            get { return "属性编辑"; }
        }

        public string Category
        {
            get { return "编辑工具"; }
        }

        public bool Checked
        {
            get { return false; }
        }

        public bool Enabled
        {
            get { return bEnable; }
        }

        public int HelpContextID
        {
            get { return -1; }
        }

        public string HelpFile
        {
            get { return ""; }
        }

        public string Message
        {
            get { return "属性编辑"; }
        }

        public string Name
        {
            get { return "AttributeEditTool"; }
        }

        public void OnClick()
        {
            m_Map = m_hookHelper.FocusMap;
            m_activeView = m_Map as IActiveView;
            m_EngineEditor = MapManager.EngineEditor;
            m_EngineEditLayers = MapManager.EngineEditor as IEngineEditLayers;

            EditVertexClass.ClearResource();
        }

        public void OnCreate(object Hook)
        {
            if (Hook == null) return;
            try
            {
                m_hookHelper = new HookHelperClass();
                m_hookHelper.Hook = Hook;
                if (m_hookHelper.ActiveView == null)
                    m_hookHelper = null;
            }
            catch
            {
                m_hookHelper = null;
            }

            if (m_hookHelper == null)
                bEnable = false;
            else
                bEnable = true;
        }

        public string Tooltip
        {
            get { return "属性编辑"; }
        }

        #endregion

        #region ITool 成员

        public int Cursor
        {
            get { return -1; }
        }

        public bool Deactivate()
        {
            return true;
        }

        public bool OnContextMenu(int x, int y)
        {
            return false;
        }

        public void OnDblClick()
        {
           
        }

        public void OnKeyDown(int keyCode, int shift)
        {
           
        }

        public void OnKeyUp(int keyCode, int shift)
        {
            
        }

        public void OnMouseDown(int button, int shift, int x, int y)
        {
            try
            {
                if (m_EngineEditor == null) return;
                if (m_EngineEditor.EditState != esriEngineEditState.esriEngineStateEditing) return;
                if (m_EngineEditLayers == null) return;
                IFeatureLayer pFeatLyr = m_EngineEditLayers.TargetLayer;
                if (pFeatLyr == null) return;             

                m_Map.ClearSelection();
                m_lstFeature = new List<IFeature>();
                IPoint pPt = m_activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
                SelectFeature(pFeatLyr, pPt as IGeometry);
                if (frmAttributeEdit == null || frmAttributeEdit.IsDisposed)
                {
                    frmAttributeEdit = new frmAttributeEdit();
                    frmAttributeEdit.Owner = MapManager.ToolPlatForm;
                }
                frmAttributeEdit.GisEdit = m_EngineEditor;
                frmAttributeEdit.FeatLyr = pFeatLyr;
                frmAttributeEdit.LstFeature = m_lstFeature;
                frmAttributeEdit.InitTreeView();
                frmAttributeEdit.Show(MapManager.ToolPlatForm);
            }
            catch (Exception ex)
            {
            }
        }

        void frmAttributeEdit_frmColsed()
        {
           
        }

        public void OnMouseMove(int button, int shift, int x, int y)
        {
            
        }

        public void OnMouseUp(int button, int shift, int x, int y)
        {
           
        }

        public void Refresh(int hdc)
        {
            
        }

        #endregion

        #region 操作函数

        private void SelectFeature(IFeatureLayer pFeatLyr, IGeometry pGeometry)
        {
            double dLength = 0;
            IGeometry pBuffer = null;
            IFeatureClass pFeatCls = pFeatLyr.FeatureClass;
            if (pFeatCls == null) return;
            if (pGeometry == null) return;
            ITopologicalOperator pTopo = pGeometry as ITopologicalOperator;
            ISpatialFilter pSpatialFilter = new SpatialFilterClass();
            switch (pFeatCls.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    dLength = MapManager.ConvertPixelsToMapUnits(m_activeView, 8);
                    pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    dLength = MapManager.ConvertPixelsToMapUnits(m_activeView, 4);
                    pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                    break;
                case esriGeometryType.esriGeometryPolyline:
                    dLength = MapManager.ConvertPixelsToMapUnits(m_activeView, 4);
                    pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelCrosses;
                    break;
            }
            pBuffer = pTopo.Buffer(dLength);
            pGeometry = pBuffer.Envelope as IGeometry;
            pSpatialFilter.Geometry = pGeometry;
            pSpatialFilter.GeometryField = pFeatCls.ShapeFieldName;
            IQueryFilter pQueryFilter = pSpatialFilter as IQueryFilter;
            IFeatureCursor pFeatCursor = pFeatCls.Search(pQueryFilter, false);
            IFeature pFeature = pFeatCursor.NextFeature();
            while (pFeature != null)
            {
                m_Map.SelectFeature(pFeatLyr as ILayer, pFeature);
                if (!m_lstFeature.Contains(pFeature))
                    m_lstFeature.Add(pFeature);
                pFeature = pFeatCursor.NextFeature();
            }
            m_activeView.Refresh();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pFeatCursor);
        }

        #endregion

       
    }
}
