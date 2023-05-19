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

namespace Interpolation
{
    public partial class FrmInterpolation : Form
    {
        public FrmInterpolation()
        {
            InitializeComponent();
        }

        private IRasterAnalysisEnvironment rasterEnv;//分析环境
        private IInterpolationOp2 interOp;//空间插值对象
        private IFeatureClass feaClass;
        private IFeatureClassDescriptor feaDes;
        private IGeoDataset inGeodataset;//输入栅格
        private IGeoDataset outGeodataset;//输出栅格

        #region 环境变量

        private double cellSize = 500;//输出像元大小
        private object Missing = Type.Missing;
        private object cellSizeObj;
        private object extentProObj;//处理范围
        private IRasterRadius radius;
        #endregion

        #region IDW变量

        private double power;
        #endregion

        #region Krige变量

        private esriGeoAnalysisSemiVariogramEnum semiEnum;
        #endregion

        #region Spline变量

        private esriGeoAnalysisSplineEnum splineEnum;
        #endregion

        #region NaturalNeighbor变量
        #endregion

        #region Trend变量

        private esriGeoAnalysisTrendEnum trendEnum;
        private int order;
        #endregion
       
        //IDW内插
        private void btnIDW_Click(object sender, EventArgs e)
        {
            try
            {
                interOp = rasterEnv as IInterpolationOp2;
                outGeodataset = interOp.IDW(inGeodataset, power, radius, ref Missing);//反距离权重法
                ShowResult(outGeodataset, "IDW");// 显示分析结果函数
                MessageBox.Show("完成");
            }
            catch { }
        }
        //Krige插值
        private void btnKrige_Click(object sender, EventArgs e)
        {
            try
            {
                interOp = rasterEnv as IInterpolationOp2;
                //克里金插值方法
                outGeodataset = interOp.Krige(inGeodataset, semiEnum, radius, true, ref Missing);
                ShowResult(outGeodataset, "Krige");
                MessageBox.Show("完成");
            }
            catch { }
        }
        //Spline插值
        private void btnSpline_Click(object sender, EventArgs e)
        {
            try
            {
                interOp = rasterEnv as IInterpolationOp2;
                outGeodataset = interOp.Spline(inGeodataset, splineEnum, ref Missing, ref Missing);
                ShowResult(outGeodataset, "Spline");
                MessageBox.Show("完成");
            }
            catch { }
        }

        //Trend插值
        private void cmdTrend_Click(object sender, EventArgs e)
        {
            try
            {
                interOp = rasterEnv as IInterpolationOp2;
                outGeodataset = interOp.Trend(inGeodataset, trendEnum, order);//趋势面法方法
                ShowResult(outGeodataset, "Trend");
                MessageBox.Show("完成");
            }
            catch { }
        }

        //NaturalNeighbor插值 
        private void btnNaturalNeighbor_Click(object sender, EventArgs e)
        {
            try
            {
                interOp = rasterEnv as IInterpolationOp2;
                outGeodataset = interOp.NaturalNeighbor(inGeodataset);
                ShowResult(outGeodataset, "NaturalNeighbor ");
                MessageBox.Show("完成");
            }
            catch { }
        }

        #region 设置公共环境参数
        private void FrmInterpolation_Load(object sender, EventArgs e)
        {
            rasterEnv = new RasterInterpolationOpClass();
        }
        //设置输入要素数据集 
        private void cmbFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                feaDes = new FeatureClassDescriptorClass();
                feaDes.Create(feaClass, null, cmbFields.SelectedItem.ToString());
                inGeodataset = feaDes as IGeoDataset;
            }
            catch
            { MessageBox.Show("请输入栅格图层！");
            };
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
        //下拉控件选择输入要素数据集
        private void cmbLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbFields.Items.Clear();

                ILayer layer = getLayerFromName(cmbLayers.SelectedItem.ToString());
                IFeatureLayer fl = layer as IFeatureLayer;
                feaClass = fl.FeatureClass;
                for (int i = 0; i < feaClass.Fields.FieldCount; i++)
                {
                    cmbFields.Items.Add(feaClass.Fields.get_Field(i).Name);
                }
                extentProObj = layer;
                //设置空间处理范围
                rasterEnv.SetExtent(esriRasterEnvSettingEnum.esriRasterEnvValue, ref extentProObj, Missing);//设置空间处理范围
            }
            catch
            {
                MessageBox.Show("请输入栅格图层！");
            }
        }
        #endregion

        #region 设置IDW参数
        //设置IDW中的power参数
        private void txtPower_TextChanged(object sender, EventArgs e)
        {
            try
            {
                power = Convert.ToDouble(txtPower.Text);
            }
            catch { }
        }
        //设置搜索半径
        private void cmbRadius_TextChanged(object sender, EventArgs e)
        {
            radius = new RasterRadiusClass();
            int index = cmbRadius.SelectedIndex;
            switch (index)
            {
                case 0://搜索半径设为固定，距离为2500
                    //radius.SetFixed(2500, Missing);
                    radius.SetVariable(12, Missing);
                    break;
                case 1://搜索半径设为变量，点数为12
                    radius.SetVariable(12, Missing);
                    break;
            }
        }
        #endregion

        #region 设置Krige参数
        //设置Krige参数中变异函数的类型类型
        private void cmbSemiEnum_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbSemiEnum.SelectedIndex;
            switch (index)
            {
                case 0://球面 
                    semiEnum = esriGeoAnalysisSemiVariogramEnum.esriGeoAnalysisSphericalSemiVariogram;
                    break;
                case 1://圆
                    semiEnum = esriGeoAnalysisSemiVariogramEnum.esriGeoAnalysisCircularSemiVariogram;
                    break;
                case 2://指数
                    semiEnum = esriGeoAnalysisSemiVariogramEnum.esriGeoAnalysisExponentialSemiVariogram;
                    break;
                case 3://高斯
                    semiEnum = esriGeoAnalysisSemiVariogramEnum.esriGeoAnalysisGaussianSemiVariogram;
                    break;
                case 4://线型
                    semiEnum = esriGeoAnalysisSemiVariogramEnum.esriGeoAnalysisLinearSemiVariogram;
                    break;
            }
        }
        #endregion

        #region 设置Spline参数
        //设置Spline参数样条函数类型
        private void cmbSplineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbSplineType.SelectedIndex;
            switch (index)
            {
                case 0:// 规则样条函数方法 
                    splineEnum = esriGeoAnalysisSplineEnum.esriGeoAnalysisRegularizedSpline;
                    break;
                case 1://TENSION 张力样条函数方法
                    splineEnum = esriGeoAnalysisSplineEnum.esriGeoAnalysisTensionSpline;
                    break;
            }
        }
        #endregion

        #region 设置Trend参数
        //设置Trend参数回归类型
        private void cmbTrendType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbTrendType.SelectedIndex;
            switch (index)
            {
                case 0://LINEAR（多项式回归）
                    trendEnum = esriGeoAnalysisTrendEnum.esriGeoAnalysisLinearTrend;
                    break;
                case 1://LOGISTIC（逻辑趋势面）
                    trendEnum = esriGeoAnalysisTrendEnum.esriGeoAnalysisLogisticTrend;
                    break;
            }
        }
        //设置Trend参数多项式的阶
        private void txtorder_TextChanged(object sender, EventArgs e)
        {
            order = Convert.ToInt16(txtorder.Text);
        }
        #endregion

        #region 设置NaturalNeighbor参数
        #endregion


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

        //显示分析结果
        private void ShowResult(IGeoDataset geoDataset, string interType)
        {
            IRasterLayer rasterLayer = new RasterLayerClass();
            IRaster raster = new Raster();
            raster = (IRaster)geoDataset;
            rasterLayer.CreateFromRaster(raster);
            rasterLayer.Name = interType;

            axMapControl1.AddLayer((ILayer)rasterLayer,1);
            axMapControl1.ActiveView.Refresh();
        }

        private void axTOCControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.ITOCControlEvents_OnMouseDownEvent e)
        {

        }

        private void tabIDW_Click(object sender, EventArgs e)
        {

        }

                
    }
}