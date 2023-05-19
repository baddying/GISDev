using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SpatialAnalyst;
using ESRI.ArcGIS.GeoAnalyst;

namespace RasterStatistics
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        private IRasterBandCollection bandCol;

        private double Maximum;//最大值
        private double Mean;//平均值
        private double Median;//中值
        private double Minimum;//最小值
        private double Mode;//最多值
        private double StandardDeviation;//标准差
        //栅格统计分析
        private void btnStatic_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbLayers.SelectedItem == null)
                    return;

                IEnumRasterBand enumband = bandCol.Bands;
                IRasterBand rasterBand = enumband.Next();
                while (rasterBand != null)
                {
                    if (rasterBand.Statistics == null) break;
                    IRasterStatistics rasterStatic = rasterBand.Statistics;
                    Maximum = rasterStatic.Maximum;
                    Mean = rasterStatic.Mean;
                    Median = rasterStatic.Median;
                    Mode = rasterStatic.Mode;
                    Minimum = rasterStatic.Minimum;
                    StandardDeviation = rasterStatic.StandardDeviation;
                    ShowStaticResult();
                    rasterBand = enumband.Next();


                }
            }
            catch { }
        }
        //参数设置
        private void cmbLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ILayer layer = getLayerFromName(cmbLayers.SelectedItem.ToString());
                IRasterLayer rasterLayer = layer as IRasterLayer;
                IRaster2 raster = rasterLayer.Raster as IRaster2;//IRaster是访问内存中成员？
                IRasterDataset rd = raster.RasterDataset;
                bandCol = rd as IRasterBandCollection;
            }
            catch
            {
                MessageBox.Show("请添加栅格数据！");
            }
        }
        

        //输出统计结果
        private void ShowStaticResult()
        {
            rtxtStaticResult.AppendText("栅格数据 " + cmbLayers.SelectedItem.ToString() + "统计结果如下：\n");
            rtxtStaticResult.AppendText("所有像元的最小值： " + Minimum.ToString("0.00") + "\n");
            rtxtStaticResult.AppendText("所有像元的最大值： " + Maximum.ToString("0.00") + "\n");
            rtxtStaticResult.AppendText("所有像元的平均值： " + Mean.ToString("0.00") + "\n");
            rtxtStaticResult.AppendText("像元最多的值 ： " + Mode.ToString("0.00") + "\n");
            rtxtStaticResult.AppendText("所有像元的中植： " + Median.ToString("0.00") + "\n");
            rtxtStaticResult.AppendText("所有像元的标准差： " + StandardDeviation.ToString("0.00") + "\n");             
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
                    cmbLayers.Items.Add(map.get_Layer(i).Name);
                }
            }
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

        private void rtxtStaticResult_TextChanged(object sender, EventArgs e)
        {

        }



    }
}
