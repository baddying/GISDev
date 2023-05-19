using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using GISEditor.EditTool.BasicClass;
using ESRI.ArcGIS.Display;


namespace GISEditor.EditTool.Tool
{
    public class SelectFeatureToolClass : ITool, ICommand
    {
        private IMap m_Map = null;
        private bool bEnable = true;
        private IHookHelper m_hookHelper = null;
        private IActiveView m_activeView = null;
        private IEngineEditor m_EngineEditor = null;
        private IEngineEditLayers m_EngineEditLayers = null;

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
                //获取目标图层
                IFeatureLayer pFeatLyr = m_EngineEditLayers.TargetLayer;
                IFeatureClass pFeatCls = pFeatLyr.FeatureClass;
                //获取地图上的坐标点
                IPoint pPt = m_activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
                IGeometry pGeometry = pPt as IGeometry;
                double dLength = 0;
                ITopologicalOperator pTopo = pGeometry as ITopologicalOperator;
                //设置选择过滤条件
                ISpatialFilter pSpatialFilter = new SpatialFilterClass();
                //不同的图层类型设置不同的过滤条件
                switch (pFeatCls.ShapeType)
                {
                    case esriGeometryType.esriGeometryPoint:
                        //将像素距离转换为地图单位距离
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
                //根据过滤条件进行缓冲
                IGeometry pBuffer = null;
                pBuffer = pTopo.Buffer(dLength);
                pGeometry = pBuffer.Envelope as IGeometry;
                pSpatialFilter.Geometry = pGeometry;
                pSpatialFilter.GeometryField = pFeatCls.ShapeFieldName;
                IQueryFilter pQueryFilter = pSpatialFilter as IQueryFilter;
                //根据过滤条件进行查询
                IFeatureCursor pFeatCursor = pFeatCls.Search(pQueryFilter, false);
                IFeature pFeature = pFeatCursor.NextFeature();
                while (pFeature != null)
                {
                    //获取地图选择集
                    m_Map.SelectFeature(pFeatLyr as ILayer, pFeature);
                    pFeature = pFeatCursor.NextFeature();
                } 
                m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null); 
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pFeatCursor);
            }
            catch (Exception ex)
            {

            }
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

        #region ICommand 成员

        public int Bitmap
        {
            get { return -1; }
        }

        public string Caption
        {
            get { return "选择要素"; }
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
            get { return "选择要素"; }
        }

        public string Name
        {
            get { return "SelectFeatureTool"; }
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
            get { return "选择要素"; }
        }

        #endregion

       
    }
}
