using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SpatialAnalyst;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.DataSourcesGDB;

namespace ReClass
{
    public partial class FrmReClass : Form
    {
        public FrmReClass()
        {
            InitializeComponent();
        }

        private IReclassOp reclassOp;//提取分析对象
        private IGeoDataset inGeodataset;//输入数据集
        private IGeoDataset result;//结果数据集
        private bool retainMissingValues = false;

        private IWorkspace workspace;
        private ITable remapTable;//重分类映射表
        private string fromField;//来自值字段
        private string toField;//到值字段
        private string outField;//输出值字段
        
        private string ASCIIPath;//ASCII文件路径

        private int zoneCount;//分割区域个数
        private esriGeoAnalysisSliceEnum sliceEnum;//分割方法
        
        #region 参数设置
        //实例化重分类对象
        private void FrmReClass_Load(object sender, EventArgs e)
        {
            reclassOp = new RasterReclassOpClass();
        }
    
        private void cmbLayers_MouseClick(object sender, MouseEventArgs e)
        {
            ComboBox c = sender as ComboBox;
            c.Items.Clear();

            IMap map = axMapControl1.Map;
            if (map != null)
            {
                for (int i = 0; i < map.LayerCount; i++)
                {
                    c.Items.Add(map.get_Layer(i).Name);
                }
            }
        }
        //设置输入栅格
        private void cmbLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ILayer layer = getLayerFromName(cmbLayers.SelectedItem.ToString());
                IRasterLayer rasterLayer = layer as IRasterLayer;

                IRaster raster = rasterLayer.Raster;
                inGeodataset = raster as IGeoDataset;
            }
            catch
            {
                MessageBox.Show("请输入栅格图层！");
            };
        }
     
        //设置将缺失值改为NoData
        private void chkNoData_CheckedChanged(object sender, EventArgs e)
        {
            retainMissingValues = chkNoData.Checked;
        }
        #endregion

        #region 使用表重分类
        //返回含有表的数据库
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            string path = "";
            OpenFileDialog openFD = new OpenFileDialog();
            openFD.Title = "打开Access数据库";
            openFD.Filter = "Access数据库(.mdb)|*.MDB";
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                path = openFD.FileName;
                txtPath.Text = path;
            }
            IWorkspaceFactory wSF = new AccessWorkspaceFactoryClass();
            workspace = wSF.OpenFromFile(path, 0);

            IEnumDataset enumDataset = workspace.get_Datasets(esriDatasetType.esriDTTable);
            IDataset dataset = enumDataset.Next();
            while (dataset != null)
            {
                cmbTables.Items.Add(dataset.Name);
                dataset = enumDataset.Next();
            }

        }
        //返回重映射表以及表包含的字段信息
        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tableName = cmbTables.SelectedItem.ToString();
            IFeatureWorkspace fw = workspace as IFeatureWorkspace;
            remapTable = fw.OpenTable(tableName);

            IFields fields = remapTable.Fields;
            for (int i = 0; i < fields.FieldCount; i++)
            {
                cmbFromField.Items.Add(fields.get_Field(i).Name);
                cmbToField.Items.Add(fields.get_Field(i).Name);
                cmbOutField.Items.Add(fields.get_Field(i).Name);
            }
        }
        //设置来自值、到值和输出值字段
        private void cmbFromField_SelectedIndexChanged(object sender, EventArgs e)
        {
            fromField = cmbFromField.SelectedItem.ToString();
        }

        private void cmbToField_SelectedIndexChanged(object sender, EventArgs e)
        {
            toField = cmbToField.SelectedItem.ToString();
        }

        private void cmbOutField_SelectedIndexChanged(object sender, EventArgs e)
        {
            outField = cmbOutField.SelectedItem.ToString();
        }

        private void btnReclass_Click(object sender, EventArgs e)
        {
            try
            {
                result = reclassOp.Reclass(inGeodataset, remapTable, fromField, toField, outField, retainMissingValues);
                ShowRasterResult(result, "通过表重分类");
            }
            catch { }
        }
        #endregion

        #region 使用ASCII文件重分类
        //找到ASCII文件路径
        private void btnASCIIPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();
            openFD.Title = "打开ASCII文件";
            openFD.Filter = "ASCII文件|*.TXT;*.RMP;*.ASC";
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                ASCIIPath = openFD.FileName;
                txtASCIIPath.Text = ASCIIPath;
            }
        }

        private void btnASCII_Click(object sender, EventArgs e)
        {
            try
            {
                result = reclassOp.ReclassByASCIIFile(inGeodataset, ASCIIPath, retainMissingValues);//使用ASCII文件重分类方法
                ShowRasterResult(result, "通过ASCII文件重分类");
            }
            catch { }
        }
        #endregion

        #region 分割
        //设置输入区域的个数
        private void txtCount_TextChanged(object sender, EventArgs e)
        {
            zoneCount = Convert.ToInt16(txtCount.Text);
        }
        //设置分割方法
        private void cmbSliceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbSliceType.SelectedIndex;
            switch (index)
            {
                case 0:
                    sliceEnum = esriGeoAnalysisSliceEnum.esriGeoAnalysisSliceEqualInterval;
                    break;
                case 1:
                    sliceEnum = esriGeoAnalysisSliceEnum.esriGeoAnalysisSliceEqualArea;
                    break;
                case 2:
                    sliceEnum = esriGeoAnalysisSliceEnum.esriGeoAnalysisSliceNatualBreaks;
                    break;
            }
        }
        //分割
        private void btnSlice_Click(object sender, EventArgs e)
        {
            try
            {
                object Missing = Type.Missing;
                reclassOp = new RasterReclassOpClass();
                IGeoDataset result = reclassOp.Slice(inGeodataset, sliceEnum, zoneCount, Missing);//分割方法
                ShowRasterResult(result, "分割");
            }
            catch { }
        }
        #endregion

        //显示栅格结果
        private void ShowRasterResult(IGeoDataset geoDataset, string interType)
        {
            IRasterLayer rasterLayer = new RasterLayerClass();
            IRaster raster = new Raster();
            //IRasterDescriptor des = geoDataset as IRasterDescriptor;
            //raster = des.Raster;
            raster = geoDataset as IRaster;
            rasterLayer.CreateFromRaster(raster);
            rasterLayer.Name = interType;

            axMapControl1.AddLayer((ILayer)rasterLayer, 0);
            axMapControl1.ActiveView.Refresh();
        }

        //通过图层名得到图层
        private ILayer getLayerFromName(string layerName)
        {
            ILayer layer;
            IMap map = axMapControl1.Map;
            for (int i = 0; i < map.LayerCount; i++)
            {
                layer = map.get_Layer(i);
                if (layerName == layer.Name)
                    return layer;
            }
            return null;
        }
        
    }
}