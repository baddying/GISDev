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

namespace Distance
{
    public partial class FrmDistance : Form
    {
        public FrmDistance()
        {
            InitializeComponent();
        }

        private IGeoDataset eucGeodataset;//欧氏距离输入要素数据

        private IGeoDataset costSource;
        private IGeoDataset costRaster;

        private IGeoDataset fromData;//目标数据
        private IGeoDataset distance;//距离数据
        private IGeoDataset backLink;//回溯链接数据
        private esriGeoAnalysisPathEnum pathEnum;

        private IGeoDataset corGeodataset1;//成本距离栅格数据1
        private IGeoDataset corGeodataset2;//成本距离栅格数据2

        private IDistanceOp distanceOp;//距离分析对象
        IRasterAnalysisEnvironment rasterEnv;//分析环境对象

        object Missing = Type.Missing;
        

        #region 参数设置
        private void FrmDistance_Load(object sender, EventArgs e)
        {
            rasterEnv = new RasterDistanceOpClass();
            double size = 50;
            object cellsize = size;
            rasterEnv.SetCellSize(esriRasterEnvSettingEnum.esriRasterEnvValue, cellsize);
            distanceOp = rasterEnv as IDistanceOp;
        }
        #endregion
        
        #region 欧氏分析

        private void cmbEucLayer_MouseClick(object sender, MouseEventArgs e)
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
        //获取输入的要素数据源
        private void cmbEucLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ILayer layer = getLayerFromName(cmbEucLayer.SelectedItem.ToString());
                IFeatureLayer fl = layer as IFeatureLayer;
                IFeatureClass fc = fl.FeatureClass;
                eucGeodataset = fc as IGeoDataset;
            }
            catch
            {
                MessageBox.Show("请输入点图层！");
            };
            }
        //欧氏距离
        private void btnEucDis_Click(object sender, EventArgs e)
        {
            //欧式距离方法
            try
            {
                IGeoDataset outGeodataset = distanceOp.EucDistance(eucGeodataset, ref Missing, ref Missing);//欧氏距离方法
                ShowRasterResult(outGeodataset, "EucDistance");
            }
            catch { }
        }
        //欧氏方向
        private void btnEucDir_Click(object sender, EventArgs e)
        {
            //欧氏方向方法
            try
            {
                IGeoDataset outGeodataset = distanceOp.EucDirection(eucGeodataset, ref Missing, ref Missing);//欧氏方向方法
                ShowRasterResult(outGeodataset, "EucDirection");
            }
            catch { }

        }
        //欧氏分配
        private void btnAll_Click(object sender, EventArgs e)
        {
            //欧氏分配方法
            try
            {
                IGeoDataset outGeodataset = distanceOp.EucAllocation(eucGeodataset, ref Missing, ref Missing);//欧氏分配方法
                ShowRasterResult(outGeodataset, "EucAllocation");
            }
            catch { }
        }
        #endregion
        
        #region 成本距离
        
        private void cmbCostSource_MouseClick(object sender, MouseEventArgs e)
        {

        }
        //设置输入的要素数据源
        private void cmbCostSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ILayer layer = getLayerFromName(cmbCostSource.SelectedItem.ToString());
                IFeatureLayer fl = layer as IFeatureLayer;
                IFeatureClass fc = fl.FeatureClass;
                costSource = fc as IGeoDataset;
            }
            catch {
                MessageBox.Show("请输入点图层！");
            };
          
        }
        //设置成本栅格数据 
        private void cmbCostRaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ILayer layer = getLayerFromName(cmbCostRaster.SelectedItem.ToString());
                IRasterLayer rasterLayer = layer as IRasterLayer;

                IRaster raster = rasterLayer.Raster;
                costRaster = raster as IGeoDataset;
            }
            catch {
                MessageBox.Show("请输入栅格数据！");
            };
        }
        //成本距离
        private void btnCostDis_Click(object sender, EventArgs e)
        {
            //成本距离方法
            try
            {
                IGeoDataset outGeodataset = distanceOp.CostDistance(costSource, costRaster);//成本距离方法
                ShowRasterResult(outGeodataset, "CostDistance");
            }
            catch { }
        }
        //回溯链接方向
        private void btnBackLink_Click(object sender, EventArgs e)
        {
            try
            {
                IGeoDataset outGeodataset = distanceOp.CostBackLink(costSource, costRaster);
                ShowRasterResult(outGeodataset, "CostBackLink");
            }
            catch { }
        }
        //成本分配
        private void btnCostAll_Click(object sender, EventArgs e)
        {
            try
            {
                IGeoDataset outGeodataset = distanceOp.CostAllocation(costSource, costRaster);//成本分配方法
                ShowRasterResult(outGeodataset, "CostAllocation");
            }
            catch { }
        }

        #endregion

        #region 成本路径
        private void btnCostPath_Click(object sender, EventArgs e)
        {
            try
            {
                IGeoDataset outGeodataset = distanceOp.CostPath(fromData, distance, backLink, pathEnum);
                ShowRasterResult(outGeodataset, "CostPath");
            }
            catch { }
        }

        private void cmbFromData_MouseClick(object sender, MouseEventArgs e)
        {

        }
        //设置要素目标数据
        private void cmbFromData_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ILayer layer = getLayerFromName(cmbFromData.SelectedItem.ToString());
                IFeatureLayer fl = layer as IFeatureLayer;
                IFeatureClass fc = fl.FeatureClass;
                fromData = fc as IGeoDataset;
            }
            catch { 
            MessageBox.Show("请输入点图层！");
            };
        }
        //设置成本距离栅格
        private void cmbDistance_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ILayer layer = getLayerFromName(cmbDistance.SelectedItem.ToString());
                IRasterLayer rasterLayer = layer as IRasterLayer;

                IRaster raster = rasterLayer.Raster;
                distance = raster as IGeoDataset;
            }
            catch {
                MessageBox.Show("请输入栅格图层！");
            };
        }
        //设置成本回溯栅格
        private void cmbBackLink_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ILayer layer = getLayerFromName(cmbBackLink.SelectedItem.ToString());
                IRasterLayer rasterLayer = layer as IRasterLayer;

                IRaster raster = rasterLayer.Raster;
                backLink = raster as IGeoDataset;
            }
            catch
            {
                MessageBox.Show("请输入栅格图层！");
            };
        }
        //设置成本路径计算方法
        private void cmbPathType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbPathType.SelectedIndex;
            switch (index)
            {
                case 0://EACH_CELL类型
                    pathEnum = esriGeoAnalysisPathEnum.esriGeoAnalysisPathForEachCell;
                    break;
                case 1://EACH_ZONE类型
                    pathEnum = esriGeoAnalysisPathEnum.esriGeoAnalysisPathForEachZone;
                    break;
                case 2://BEST_SINGLE类型
                    pathEnum = esriGeoAnalysisPathEnum.esriGeoAnalysisPathBestSingle;
                    break;
            }
        }

        #endregion

        #region 廊道分析

        private void cmbCorLayer1_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void cmbCorLayer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ILayer layer = getLayerFromName(cmbCorLayer2.SelectedItem.ToString());
                IRasterLayer rasterLayer = layer as IRasterLayer;

                IRaster raster = rasterLayer.Raster;
                corGeodataset2 = raster as IGeoDataset;
            }
            catch
            {
                MessageBox.Show("请输入栅格图层！");
            };
        }
        //设置距离栅格数据2
        private void cmbCorLayer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ILayer layer = getLayerFromName(cmbCorLayer1.SelectedItem.ToString());
                IRasterLayer rasterLayer = layer as IRasterLayer;

                IRaster raster = rasterLayer.Raster;
                corGeodataset1 = raster as IGeoDataset;
            }
            catch
            {
                MessageBox.Show("请输入栅格图层！");
            };
        }
        //廊道分析
        private void btnCorridor_Click(object sender, EventArgs e)
        {
            try
            {
                IGeoDataset outGeodataset = distanceOp.Corridor(corGeodataset1, corGeodataset2);//廊道分析方法
                ShowRasterResult(outGeodataset, "Corridor");
            }
            catch { }
        }
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



    }
}