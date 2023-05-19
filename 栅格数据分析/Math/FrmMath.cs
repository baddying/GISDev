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

namespace Math
{
    public partial class FrmMath : Form
    {
        public FrmMath()
        {
            InitializeComponent();
        }

        private IGeoDataset inGeodataset1;//输入数据1
        private IGeoDataset inGeodataset2;//输入数据2
        private IGeoDataset result;//返回结果

        private IMathOp mathOp;//数学计算对象
        private ILogicalOp logicalOp;//逻辑运算对象
        private ITrigOp trigOp;//三角函数计算对象
        private IBitwiseOp bitwiseOp;//按位计算对象
        

        #region 参数设置
        private void cmbInputData1_MouseClick(object sender, MouseEventArgs e)
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
        //设置输入数据1 
        private void cmbInputData1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ILayer layer = getLayerFromName(cmbInputData1.SelectedItem.ToString());
                IRasterLayer rasterLayer = layer as IRasterLayer;

                IRaster raster = rasterLayer.Raster;
                inGeodataset1 = raster as IGeoDataset;
            }
            catch {
                MessageBox.Show("请输入栅格数据！");
            };
        }
        //设置输入数据2
        private void cmbInputData2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ILayer layer = getLayerFromName(cmbInputData2.SelectedItem.ToString());
                IRasterLayer rasterLayer = layer as IRasterLayer;

                IRaster raster = rasterLayer.Raster;
                inGeodataset2 = raster as IGeoDataset;
            }
            catch
            {
                MessageBox.Show("请输入栅格数据！");
            };
        }
        //对象实例化
        private void FrmMath_Load(object sender, EventArgs e)
        {
            mathOp = new RasterMathOpsClass();
            logicalOp = new RasterMathOpsClass();
            trigOp = new RasterMathOpsClass();
            bitwiseOp = new RasterMathOpsClass();
        }
        #endregion

        #region 数学计算
        private void btnPlus_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbInputData1.SelectedItem == null || cmbInputData2.SelectedItem == null)
                    return;
                result = mathOp.Plus(inGeodataset1, inGeodataset2);
                ShowResult(result, "Plus");
            }
            catch { }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbInputData1.SelectedItem == null || cmbInputData2.SelectedItem == null)
                    return;
                result = mathOp.Minus(inGeodataset1, inGeodataset2);
                ShowResult(result, "Minus");
            }
            catch { }
        }

        private void btnTimes_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbInputData1.SelectedItem == null || cmbInputData2.SelectedItem == null)
                    return;
                result = mathOp.Times(inGeodataset1, inGeodataset2);
                ShowResult(result, "Times");
            }
            catch { }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            try
            {

                if (cmbInputData1.SelectedItem == null || cmbInputData2.SelectedItem == null)
                    return;
                result = mathOp.Divide(inGeodataset1, inGeodataset2);
                ShowResult(result, "Divide");
            }
            catch { }
        }

        private void btnAbs_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbInputData1.SelectedItem == null || cmbInputData2.SelectedItem == null)
                    return;
                result = mathOp.Abs(inGeodataset1);
                ShowResult(result, "Abs");
            }
            catch { }
        }
        #endregion
        
        #region 逻辑运算
        private void btnGreaterThan_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbInputData1.SelectedItem == null || cmbInputData2.SelectedItem == null)
                    return;
                result = logicalOp.GreaterThan(inGeodataset1, inGeodataset2);
                ShowResult(result, "GreaterThan");
            }
            catch { }
        }

        private void btnLessThan_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbInputData1.SelectedItem == null || cmbInputData2.SelectedItem == null)
                    return;
                result = logicalOp.LessThan(inGeodataset1, inGeodataset2);
                ShowResult(result, "LessThan");
            }
            catch { }
        }

        private void btnNotEqual_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbInputData1.SelectedItem == null || cmbInputData2.SelectedItem == null)
                    return;
                result = logicalOp.NotEqual(inGeodataset1, inGeodataset2);
                ShowResult(result, "NotEqual");
            }
            catch { }
        }

        private void btnEqualTo_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbInputData1.SelectedItem == null || cmbInputData2.SelectedItem == null)
                    return;
                result = logicalOp.EqualTo(inGeodataset1, inGeodataset2);
                ShowResult(result, "EqualTo");
            }
            catch { }
        }
        #endregion
                
        #region 三角函数运算
        private void btnSin_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbInputData1.SelectedItem == null || cmbInputData2.SelectedItem == null)
                    return;
                result = trigOp.Sin(inGeodataset1);
                ShowResult(result, "Sin");
            }
            catch { }
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbInputData1.SelectedItem == null || cmbInputData2.SelectedItem == null)
                    return;
                result = trigOp.Cos(inGeodataset1);
                ShowResult(result, "Cos");
            }
            catch { }
        }

        private void btnAsin_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbInputData1.SelectedItem == null || cmbInputData2.SelectedItem == null)
                    return;
                result = trigOp.ASin(inGeodataset1);
                ShowResult(result, "ASin");
            }
            catch { }
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbInputData1.SelectedItem == null || cmbInputData2.SelectedItem == null)
                    return;
                result = trigOp.Tan(inGeodataset1);
                ShowResult(result, "Tan");
            }
            catch { }
        }

        private void btnACos_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbInputData1.SelectedItem == null || cmbInputData2.SelectedItem == null)
                    return;
                result = trigOp.ACos(inGeodataset1);
                ShowResult(result, "ACos");
            }
            catch { }
        }
        #endregion
        
        #region 按位运算

        private void btnAnd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbInputData1.SelectedItem == null || cmbInputData2.SelectedItem == null)
                    return;
                result = bitwiseOp.And(inGeodataset1, inGeodataset2);
                ShowResult(result, "And");
            }
            catch { }
        }

        private void btnOr_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbInputData1.SelectedItem == null || cmbInputData2.SelectedItem == null)
                    return;
                result = bitwiseOp.Or(inGeodataset1, inGeodataset2);
                ShowResult(result, "Or");
            }
            catch { }
        }

        private void btnNot_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbInputData1.SelectedItem == null || cmbInputData2.SelectedItem == null)
                    return;
                result = bitwiseOp.Not(inGeodataset1);
                ShowResult(result, "Not");
            }
            catch { }
        }
        #endregion

        //显示栅格结果
        private void ShowResult(IGeoDataset geoDataset, string interType)
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