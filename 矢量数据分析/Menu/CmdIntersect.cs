using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;

namespace EditSDELayerDemo.Menu
{
    /// <summary>
    /// Command that works in ArcMap/Map/PageLayout
    /// </summary>
    [Guid("5f12f062-bf48-45b6-82e6-f46d874b5c81")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("EditSDELayerDemo.Menu.CmdIntersect")]
    public sealed class CmdIntersect : BaseCommand
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
        private IMap pMap = null;
        public CmdIntersect()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "矢量分析"; //localizable text
            base.m_caption = "求交分析";  //localizable text 
            base.m_message = "矢量叠加求交分析";  //localizable text
            base.m_toolTip = "矢量叠加求交分析";  //localizable text
            base.m_name = "CmdIntersect";   //unique id, non-localizable (e.g. "MyCategory_MyCommand")

            try
            {
                //
                // TODO: change bitmap name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this command is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            if (hook == null)
                return;

            try
            {
                m_hookHelper = new HookHelperClass();
                m_hookHelper.Hook = hook;
                if (m_hookHelper.ActiveView == null)
                    m_hookHelper = null;
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
        /// Command点击事件
        /// </summary>
        public override void OnClick()
        {
            IActiveView pActiveView = m_hookHelper.ActiveView;
            pMap = m_hookHelper.FocusMap;
            //判断MapControl是否有图层
            if (pMap.LayerCount <= 0)
            {
                MessageBox.Show("请先加载图层数据！");
                return;
            }
            ILayer pInputLayer = GetLayerByName("县界面");    
            IFeatureLayer pInputFeatureLayer = pInputLayer as IFeatureLayer;
            IFeatureClass pInputFeatureClass = pInputFeatureLayer.FeatureClass;

            ILayer pOverLayer = GetLayerByName("山东省行政区");
            IFeatureLayer pOverFeatureLayer = pOverLayer as IFeatureLayer;
            IFeatureClass pOverFeatureClass = pOverFeatureLayer.FeatureClass;

            IFeatureClass pOutFeatureClass = Clip(pInputFeatureClass, pOverFeatureClass, @"c:\", "山东省县区面");
            if (pOutFeatureClass != null)
            {
                IFeatureLayer pFeatueLayer = new FeatureLayerClass();
                pFeatueLayer.FeatureClass = pOutFeatureClass;
                pFeatueLayer.Name = pOutFeatureClass.AliasName;
                pMap.AddLayer(pFeatueLayer);
            }
        }

        /// <summary>
        /// Clip裁剪分析
        /// </summary>
        /// <param name="pInputFeatureClass">第一个要素(被相交要素)</param>
        /// <param name="pClipFeatureClass">第二个要素（裁剪要素）</param>
        /// <param name="filePath">生成要素的存储路径</param>
        /// <param name="_pFileName">生成新要素FeatureClass名称</param>
        ///  使用示例：IFeatureClass outFeatureClass = Clip(pFeatureClass1, pFeatureClass2, @".\data\矢量数据", "clip");
        /// <returns></returns>
        public IFeatureClass Clip(IFeatureClass pInputFeatureClass, IFeatureClass pClipFeatureClass, string filePath, string _pFileName)
        {
            IFeatureClassName pOutPut = new FeatureClassNameClass();
            pOutPut.ShapeType = pInputFeatureClass.ShapeType;            
            pOutPut.FeatureType = esriFeatureType.esriFTSimple;
            pOutPut.ShapeFieldName = pInputFeatureClass.ShapeFieldName;

            //利用IDataset获得IWorkspaceName
            IWorkspaceFactory pWsFc = new ShapefileWorkspaceFactoryClass();
            IWorkspace pWs = pWsFc.OpenFromFile(filePath, 0);
            IDataset pDataset = pWs as IDataset;
            IWorkspaceName pWsN = pDataset.FullName as IWorkspaceName;

            IDatasetName pDatasetName = pOutPut as IDatasetName;
            pDatasetName.Name = _pFileName;
            pDatasetName.WorkspaceName = pWsN;
            //初始化IBasicGeoprocessor接口
            IBasicGeoprocessor pBasicGeo = new BasicGeoprocessorClass();
            pBasicGeo.SpatialReference = pMap.SpatialReference;

            //运用进行裁剪运算
            IFeatureClass pFeatureClass = pBasicGeo.Clip(pInputFeatureClass as ITable, false, pClipFeatureClass as ITable, false, 0.1, pOutPut);
            return pFeatureClass;
        }

        /// <summary>
        /// 通过图层名称获取目标图层
        /// </summary>
        /// <param name="layerName"></param>
        /// <returns></returns>
        private ILayer GetLayerByName(string layerName)
        {
            ILayer pLayer = null;
            for (int i = 0; i < pMap.LayerCount; i++)
            {
                if (pMap.get_Layer(i).Name == layerName)
                {
                    pLayer = pMap.get_Layer(i);
                    break;
                }
            }
            return pLayer;
        }

        #endregion
    }
}
