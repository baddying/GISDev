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
    public partial class FrmExtraction : Form
    {
        public FrmExtraction()
        {
            InitializeComponent();
        }

        private IExtractionOp extractOp;//提取分析对象
        private IRaster raster;
        private IGeoDataset maskRaster;//掩膜数据集
        private IGeoDataset inGeodataset;//输入数据集
        private IGeoDataset outGeodataset;//输出数据集
        private IQueryFilter queryFilter;
        private IRasterDescriptor rasterDes;


        private void FrmExtraction_Load(object sender, EventArgs e)
        {
            extractOp = new RasterExtractionOpClass();
            queryFilter = new QueryFilterClass();
            rasterDes = new RasterDescriptorClass();
        }

        //设置参数
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
        //设置输入栅格数据集
        private void cmbLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ILayer layer = getLayerFromName(cmbLayers.SelectedItem.ToString());
                IRasterLayer rasterLayer = layer as IRasterLayer;

                raster = rasterLayer.Raster;
                inGeodataset = raster as IGeoDataset;
            }
            catch
            {
                MessageBox.Show("请输入栅格图层！");
            };
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
        //按属性提取
        private void btnExtByAtt_Click(object sender, EventArgs e)
        {
            try
            {
                string strSQL = txtField.Text + cmbLogical.SelectedItem.ToString() + txtValue.Text;
                queryFilter.WhereClause = strSQL;
                rasterDes.Create(raster, queryFilter, txtField.Text);

                outGeodataset = extractOp.Attribute(rasterDes);//按属性提取方法
                ShowRasterResult(outGeodataset, "ByAttribute");
            }
            catch {
                MessageBox.Show("请正确输入字符串！");
            };
        }
        //设置掩膜图层
        private void cmbMaskLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ILayer layer = getLayerFromName(cmbMaskLayer.SelectedItem.ToString());
                IRasterLayer rasterLayer = layer as IRasterLayer;
                IRaster raster = rasterLayer.Raster;
                maskRaster = raster as IGeoDataset;
            }
            catch
            {
                MessageBox.Show("请输入栅格图层！");
            };
        }
        //掩膜提取
        private void btnByMask_Click(object sender, EventArgs e)
        {
            try
            {
                outGeodataset = extractOp.Raster(inGeodataset, maskRaster);//按掩膜提取方法
                ShowRasterResult(outGeodataset, "ByMask");
            }
            catch { }

        }
        //按形状提取,将地图的当前视图范围设为提取矩形
        private void btnByShape_Click(object sender, EventArgs e)
        {
            try
            {
                IEnvelope env = axMapControl1.Extent;
                outGeodataset = extractOp.Rectangle(inGeodataset, env, true);
                ShowRasterResult(outGeodataset, "Rectangle");
            }
            catch { }
        }
    }
}