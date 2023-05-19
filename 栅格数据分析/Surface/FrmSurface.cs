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

namespace Surface
{
    public partial class FrmSurface : Form
    {
        public FrmSurface()
        {
            InitializeComponent();
        }

        private object Missing = Type.Missing;

        private ISurfaceOp surfaceOp;//表面分析对象
        private IGeoDataset inGeodataset;//输入数据
        private IGeoDataset outGeodataset;//输出数据

        private double interValue;//Contour等值线间距

        private IGeoDataset beforeGeo;//填挖之前的数据
        private IGeoDataset afterGeo;//填挖之后的数据

        private esriGeoAnalysisSlopeEnum slopeEnum;//Slopes输出测量单位

        private double altitude;//光源高度角
        private double azimuth;//光源方位角

        private IGeoDataset observeLayer;//观察点数据
        private esriGeoAnalysisVisibilityEnum visibilityEnum;//可见性分析类型


        #region 设置共有参数

       //实例化表面分析对象
        private void FrmSurface_Load(object sender, EventArgs e)
        {
            surfaceOp = new RasterSurfaceOpClass();
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

        //设置输入的栅格数据集
        private void cmbLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ILayer layer = getLayerFromName(cmbLayers.SelectedItem.ToString());
                IRasterLayer rasterLayer = layer as IRasterLayer;

                IRaster raster = rasterLayer.Raster;
                inGeodataset = raster as IGeoDataset;
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择图层不是栅格图层！");
            }
        }


        #endregion

        #region Aspect
        private void btnAspect_Click(object sender, EventArgs e)
        {
            try
            {
                outGeodataset = surfaceOp.Aspect(inGeodataset);
                ShowRasterResult(outGeodataset, "Aspect");
            }
            catch { }
        }	 
	    #endregion
        
        #region Contour
        private void btnContour_Click(object sender, EventArgs e)
        {
            try
            {
                //等值线计算方法
                outGeodataset = surfaceOp.Contour(inGeodataset, interValue, Missing);//等值线计算方法
                ShowVectorResult(outGeodataset, "Counter");
            }
            catch { }
        }

        //设置Contour方法的interValue参数
        private void txtInterval_TextChanged(object sender, EventArgs e)
        {
            interValue = Convert.ToDouble(txtInterval.Text);
        }
        #endregion

        #region Curvature
        private void btnCurvature_Click(object sender, EventArgs e)
        {
            try
            {
                outGeodataset = surfaceOp.Curvature(inGeodataset, true, true);//曲率计算方法
                ShowRasterResult(outGeodataset, "Curvature");
            }
            catch { }
        }
        #endregion

        #region CutFill
        private void btnCutFill_Click(object sender, EventArgs e)
        {
            try
            {
                outGeodataset = surfaceOp.CutFill(beforeGeo, afterGeo, ref Missing);//填挖计算方法
                ShowRasterResult(outGeodataset, "CutFill");
            }
            catch { }
        }

        private void cmbBefore_MouseClick(object sender, MouseEventArgs e)
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

        private void cmbAfter_MouseClick(object sender, MouseEventArgs e)
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
        //设置参数
        //设置填挖之前的数据集
        private void cmbBefore_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ILayer layer = getLayerFromName(cmbBefore.SelectedItem.ToString());
                IRasterLayer rasterLayer = layer as IRasterLayer;

                IRaster raster = rasterLayer.Raster;
                beforeGeo = raster as IGeoDataset;
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择图层不是栅格图层！");
            }
        }

        //设置填挖之后的数据集
        private void cmbAfter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ILayer layer = getLayerFromName(cmbAfter.SelectedItem.ToString());
                IRasterLayer rasterLayer = layer as IRasterLayer;

                IRaster raster = rasterLayer.Raster;
                afterGeo = raster as IGeoDataset;
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择图层不是栅格图层！");
            }
        }
        #endregion

        #region Slope
        private void btnSlope_Click(object sender, EventArgs e)
        {
            try
            {
                outGeodataset = surfaceOp.Slope(inGeodataset, slopeEnum, ref Missing);//坡度计算方法
                ShowRasterResult(outGeodataset, "Slope");
            }
            catch { }
        }

        //设置Slope输出测量单位
        private void cmbSlopeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbSlopeType.SelectedIndex;
            switch (index)
            {
                case 0://DEGREE（度）
                    slopeEnum = esriGeoAnalysisSlopeEnum.esriGeoAnalysisSlopeDegrees;
                    break;
                case 1://高程增量百分比
                    slopeEnum = esriGeoAnalysisSlopeEnum.esriGeoAnalysisSlopePercentrise;
                    break;
            }
        }
        #endregion

        #region HillShade
        private void btnHillShade_Click(object sender, EventArgs e)
        {
            //山体阴影计算方法
            try
            {
                outGeodataset = surfaceOp.HillShade(inGeodataset, azimuth, altitude, true, ref Missing);//山体阴影计算方法
                ShowRasterResult(outGeodataset, "HillShade");
            }
            catch { }
        }

        //设置光源方位角
        private void txtaZimuth_TextChanged(object sender, EventArgs e)
        {
            azimuth = Convert.ToDouble(txtaZimuth.Text);
        }
        //设置光源高度角
        private void txtAltitude_TextChanged(object sender, EventArgs e)
        {

            altitude = Convert.ToDouble(txtAltitude.Text);
        }
        #endregion

        #region Visibility
        private void btnVisibility_Click(object sender, EventArgs e)
        {
            //可见性分析方法
            try
            {
                outGeodataset = surfaceOp.Visibility(inGeodataset, observeLayer, visibilityEnum);//可见性分析方法
                ShowRasterResult(outGeodataset, "Visibility");
            }
            catch { }
        }

        private void cmbObserverLayer_MouseClick(object sender, MouseEventArgs e)
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
        //设置观察点数据
        private void cmbObserverLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ILayer layer = getLayerFromName(cmbObserverLayer.SelectedItem.ToString());
                IFeatureLayer fl = layer as IFeatureLayer;
                IFeatureClass fc = fl.FeatureClass;
                observeLayer = fc as IGeoDataset;
            }
            catch
            {
                MessageBox.Show("所选图层不是观察点图层！");
            }
        }
        //设置可见性分析类型
        private void cmbVisibilityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbVisibilityType.SelectedIndex;
            switch (index)
            {
                case 0://视点分析
                    visibilityEnum = esriGeoAnalysisVisibilityEnum.esriGeoAnalysisVisibilityFrequency;
                    break;
                case 1://视域分析
                    visibilityEnum = esriGeoAnalysisVisibilityEnum.esriGeoAnalysisVisibilityObservers;
                    break;
            }
        }
        #endregion

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

        //显示矢量结果
        private void ShowVectorResult(IGeoDataset geoDataset, string interType)
        {
            IFeatureClass fc = geoDataset as IFeatureClass;
            IFeatureLayer fl = new FeatureLayerClass();
            fl.FeatureClass = fc;
            fl.Name = interType;

            axMapControl1.AddLayer((ILayer)fl, 0);
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