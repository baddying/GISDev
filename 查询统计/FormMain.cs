using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;

namespace QueryAndStatistics
{
    public partial class FormMain : Form
    {
        //定义ISelectionEnvironment接口的对象来设置选择环境
        private ISelectionEnvironment selectionEnvironment;

        public FormMain()
        {
            InitializeComponent();
            //窗体初始化时新建ISelectionEnvironment接口的对象，对象具有默认的选项设置值
            selectionEnvironment = new SelectionEnvironmentClass();
        }

        private void ToolStripMenuItemQueryByAttribute_Click(object sender, EventArgs e)
        {
            //新创建属性查询窗体
            FormQueryByAttribute formQueryByAttribute = new FormQueryByAttribute();
            //将当前主窗体中MapControl控件中的Map对象赋值给FormQueryByAttribute窗体的CurrentMap属性
            formQueryByAttribute.CurrentMap = axMapControl.Map;
            //显示属性查询窗体
            formQueryByAttribute.Show();
        }

        private void ToolStripMenuItemMapSelection_Click(object sender, EventArgs e)
        {
            //新创建地图选择集窗体
            FormSelection formSelection = new FormSelection();
            //将当前主窗体中MapControl控件中的Map对象赋值给FormSelection窗体的CurrentMap属性
            formSelection.CurrentMap = axMapControl.Map;
            //显示地图选择集窗体
            formSelection.Show();
        }

        private void ToolStripMenuItemQueryBySpatial_Click(object sender, EventArgs e)
        {
            //新创建空间查询窗体
            FormQueryBySpatial formQueryBySpatial = new FormQueryBySpatial();
            //将当前主窗体中MapControl控件中的Map对象赋值给FormSelection窗体的CurrentMap属性
            formQueryBySpatial.CurrentMap = axMapControl.Map;
            //显示空间查询窗体
            formQueryBySpatial.Show();
        }

        private void ToolStripMenuItemQueryByGraphics_Click(object sender, EventArgs e)
        {
            try
            {
                //首先清空地图选择集，以进行后续的选择操作
                axMapControl.Map.FeatureSelection.Clear();

                //使用IGraphicsContainer接口获取地图中的各个图形（Graphics）
                IGraphicsContainer graphicsContainer = axMapControl.Map as IGraphicsContainer;
                //重置访问图形的游标，使IGraphicsContainer接口的Next()方法定位于地图中的第一个图形
                graphicsContainer.Reset();
                //使用IElement接口操作所获取第一个图形
                IElement element = graphicsContainer.Next();
                //获取图形的几何信息
                IGeometry geometry = element.Geometry;
                //使用第一个图形的几何形状来选择地图中的要素。
                axMapControl.Map.SelectByShape(geometry, null, false);
                //进行部分刷新以显示最新的选择集
                axMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, axMapControl.ActiveView.Extent);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void ToolStripMenuItemStatistics_Click(object sender, EventArgs e)
        {
            //新创建统计窗体
            FormStatistics formStatistics = new FormStatistics();
            //将当前主窗体中MapControl控件中的Map对象赋值给FormStatistics窗体的CurrentMap属性
            formStatistics.CurrentMap = axMapControl.Map;
            //显示统计窗体
            formStatistics.Show();
        }

        private void ToolStripMenuItemOptions_Click(object sender, EventArgs e)
        {
            //新创建选择操作选项窗体
            FormOptions formOptions = new FormOptions();
            //将当前主窗体中MapControl控件中的Map对象赋值给FormOptions窗体的CurrentMap属性
            formOptions.CurrentSelectionEnvironment = selectionEnvironment;
            //显示选择操作选项窗体
            formOptions.Show();
        }

        private void ToolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            //使用对话框选择要打开的mxd文档
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "ArcMap Documents (*.mxd)|*.mxd";                
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    axMapControl.LoadMxFile(filePath);
                }
            }
        }

        private void axTOCControl_OnMouseDown(object sender, ESRI.ArcGIS.Controls.ITOCControlEvents_OnMouseDownEvent e)
        {

        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}