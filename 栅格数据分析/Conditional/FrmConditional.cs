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

namespace Extraction
{
    public partial class FrmConditional : Form
    {
        public FrmConditional()
        {
            InitializeComponent();
        }

        private IConditionalOp conditionalOp;//条件分析对象
        private IRaster raster;

        private IGeoDataset inGeodataset;//输入栅格
        private IGeoDataset trueRaster;
        private IGeoDataset outGeodataset;//输出栅格
        private IQueryFilter queryFilter;
        private IRasterDescriptor rasterDes;
        private object falseRasterObj = Type.Missing;
        
        #region 参数设置
        //实例化对象
        private void FrmExtraction_Load(object sender, EventArgs e)
        {
            conditionalOp = new RasterConditionalOpClass();
            queryFilter = new QueryFilterClass();
            rasterDes = new RasterDescriptorClass();
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

                raster = rasterLayer.Raster;
                inGeodataset = raster as IGeoDataset;
            }
            catch { MessageBox.Show("请选择栅格图层！");
            };
        }
        //输入条件为true时所取栅格数据
        private void cmbtrueRaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            ILayer layer = getLayerFromName(cmbtrueRaster.SelectedItem.ToString());
            IRasterLayer rasterLayer = layer as IRasterLayer;

            raster = rasterLayer.Raster;
            trueRaster = raster as IGeoDataset;
        }

        #endregion
              
        //条件分析
        private void btnCon_Click(object sender, EventArgs e)
        {
            try
            {
                object Missing = Type.Missing;
                string strSQL = txtField.Text + cmbCon.SelectedItem.ToString() + txtValue.Text;//条件表达
                queryFilter.WhereClause = strSQL;
                rasterDes.Create(raster, queryFilter, txtField.Text);
                inGeodataset = rasterDes as IGeoDataset;

                outGeodataset = conditionalOp.Con(inGeodataset, trueRaster, Missing);//条件函数方法
                ShowRasterResult(outGeodataset, "条件分析");
            }
            catch { }
        }
        
        //显示栅格结果
        private void ShowRasterResult(IGeoDataset geoDataset, string interType)
        {
            IRasterLayer rasterLayer = new RasterLayerClass();
            IRaster raster = new Raster();
            raster = (IRaster)geoDataset;
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