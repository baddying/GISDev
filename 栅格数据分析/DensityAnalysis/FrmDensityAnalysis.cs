using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.SpatialAnalyst;
using ESRI.ArcGIS.DataSourcesRaster;


namespace DensityAnalysis
{
    public partial class FrmDensityAnalysis : Form
    {
        public FrmDensityAnalysis()
        {
            InitializeComponent();
        }

        private double cellSize = 50;//设置像元大小
        private double radioDis = 600;//设置搜索半径
        private object Missing = Type.Missing;
        private IRasterNeighborhood rnh;//邻域分析

        private object cellSizeObj;
        private object radioDisObj;
        private object extentProviderObj;


        private IRasterAnalysisEnvironment rasterEnv;//环境分析对象
        private IDensityOp densityOp;//密度分析对象
        private IFeatureClass featureClass;
        private IFeatureClassDescriptor featureDes;
        private IGeoDataset inGeoDataset;//输入数据集
        private IGeoDataset outGeoDataset;//输出数据集


        //核密度分析
        private void btnKernel_Click(object sender, EventArgs e)
        {
            try
            {
                densityOp = rasterEnv as IDensityOp;
                //核密度分析方法
                outGeoDataset = densityOp.KernelDensity(inGeoDataset, ref radioDisObj, Missing);//核密度分析方法
                ShowResult(outGeoDataset, "KernelDensity");
            }
            catch {
                MessageBox.Show("请输入点图层");
            };
        }
        //线密度分析
        private void btnLine_Click(object sender, EventArgs e)
        {
            //线密度分析方法
            try
            {
                densityOp = rasterEnv as IDensityOp;
                outGeoDataset = densityOp.LineDensity(inGeoDataset, ref radioDisObj, Missing);
                ShowResult(outGeoDataset, "LineDensity");
            }
            catch {
                MessageBox.Show("请输入线图层！");
            };
        }
        //点密度分析
        private void btnPoint_Click(object sender, EventArgs e)
        {
            try
            {
                densityOp = rasterEnv as IDensityOp;
                outGeoDataset = densityOp.PointDensity(inGeoDataset, rnh, Missing);//点密度分析方法
                ShowResult(outGeoDataset, "PointDensity");
            }
            catch { }
        }
        //显示分析结果
        private void ShowResult(IGeoDataset geoDataset,string densityType)
        {
            IRasterLayer rasterLayer = new RasterLayerClass();
            IRaster raster = new Raster();
            raster = (IRaster)geoDataset;
            rasterLayer.CreateFromRaster(raster);
            rasterLayer.Name = densityType;

            axMapControl1.AddLayer((ILayer)rasterLayer);
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

        private void FrmDensityAnalysis_Load(object sender, EventArgs e)
        {
            rasterEnv = new RasterDensityOpClass();
        }
        #region 设置环境参数
        private void cmbLayer_MouseClick(object sender, MouseEventArgs e)
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
        //设置输入数据集和分析范围
        private void cmbLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbFields.Items.Clear();

                ILayer layer = getLayerFromName(cmbLayer.SelectedItem.ToString());
                IFeatureLayer fl = layer as IFeatureLayer;
                featureClass = fl.FeatureClass;
                for (int i = 0; i < featureClass.Fields.FieldCount; i++)
                {
                    cmbFields.Items.Add(featureClass.Fields.get_Field(i).Name);
                }

                extentProviderObj = layer;
                rasterEnv.SetExtent(esriRasterEnvSettingEnum.esriRasterEnvValue, ref extentProviderObj, Missing);
            }
            catch {
                MessageBox.Show("请输入点图层或线图层！");
            }
        }
        //设置计数字段
        private void cmbFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                featureDes = new FeatureClassDescriptorClass();
                featureDes.Create(featureClass, null, cmbFields.SelectedItem.ToString());

                inGeoDataset = featureDes as IGeoDataset;
            }
            catch { }
        }
        //设置输出栅格大小
        private void txtCellSize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cellSize = Convert.ToDouble(txtCellSize.Text);
                cellSizeObj = cellSize;
                rasterEnv.SetCellSize(esriRasterEnvSettingEnum.esriRasterEnvValue, ref cellSizeObj);
            }
            catch { }
        }
        //设置搜索半径
        private void txtRadioDis_TextChanged(object sender, EventArgs e)
        {
            try
            {
                radioDis = Convert.ToDouble(txtRadioDis.Text);
                radioDisObj = radioDis;
            }
            catch { }
        }

        private void cmbNbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                rnh = new RasterNeighborhoodClass();
                switch (cmbNbType.SelectedIndex)
                {
                    case 0://邻域分析类型为圆形，半径为20像元
                        rnh.SetCircle(20, esriGeoAnalysisUnitsEnum.esriUnitsCells);
                        break;
                    case 1://邻域分析类型为矩形，高为10像元，宽为20像元
                        rnh.SetRectangle(20, 20, esriGeoAnalysisUnitsEnum.esriUnitsCells);
                        break;
                    case 2://邻域分析类型为环形，内半径为10像元，外半径为30像元
                        rnh.SetAnnulus(10, 30, esriGeoAnalysisUnitsEnum.esriUnitsCells);
                        break;
                }
            }
            catch { }
        }

        #endregion

        private void label2_Click(object sender, EventArgs e)
        {

        }










    }
}