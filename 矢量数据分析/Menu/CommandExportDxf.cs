using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;

namespace EditSDELayerDemo.Menu
{
    /// <summary>
    /// Command that works in ArcMap/Map/PageLayout
    /// </summary>
    [Guid("a9f2f1ea-355f-448c-bb9d-894428bce8af")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("EditSDELayerDemo.Menu.CommandExportDxf")]
    public sealed class CommandExportDxf : BaseCommand
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
        public CommandExportDxf()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = ""; //localizable text
            base.m_caption = "";  //localizable text 
            base.m_message = "This should work in ArcMap/MapControl/PageLayoutControl";  //localizable text
            base.m_toolTip = "";  //localizable text
            base.m_name = "";   //unique id, non-localizable (e.g. "MyCategory_MyCommand")

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
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
            //通过m_hookHelper获取地图中加载的ShapeFile数据转换为ILayer接口的对象
            if (null == m_hookHelper)
                return;
            object hook = null;
            if (m_hookHelper.Hook is IToolbarControl2)
            {
                hook = ((IToolbarControl2)m_hookHelper.Hook).Buddy;
            }
            else
            {
                hook = m_hookHelper.Hook;
            }
            object customProperty = null;
            IMapControl3 mapControl = null;
            if (hook is IMapControl3)
            {
                mapControl = (IMapControl3)hook;
                customProperty = mapControl.CustomProperty;
            }
            else
                return;
            if (null == customProperty || !(customProperty is ILayer))
                return;
            ILayer layer = customProperty as ILayer;
            //选择转换成功的CAD数据存储路径
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "DXF File|*.dxf";
            saveFileDialog.Title = "导出ShapeFile数据到dxf";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = System.IO.Path.Combine(saveFileDialog.InitialDirectory, ((ILayer)customProperty).Name + ".dxf");
            DialogResult dr = saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != string.Empty && dr == DialogResult.OK)
            {
                if (System.IO.File.Exists(saveFileDialog.FileName))
                {
                    System.IO.File.Delete(saveFileDialog.FileName);
                }
                //利用封装的ConvertShapeToDXF公共方法进行ShapeFile到CAD数据格式的转换
                ConvertShapeToDXF dxf = new ConvertShapeToDXF(saveFileDialog.FileName, layer as IFeatureLayer);
                //转换成功后执行OnCompleted方法
                dxf.completed += new ConvertShapeToDXF.OnCompleted(dxf_completed);
                dxf.Convert();
            }
        }

        void dxf_completed(object sender, ConvertShapeToDXFArgs e)
        {
            if (e.Result)
                MessageBox.Show("导出成功!");
            else
                MessageBox.Show("导出失败:" + e.Exception.Message);
        }

        #endregion
    }
}
