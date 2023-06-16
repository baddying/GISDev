using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geodatabase;

namespace 最短路径分析
{
    public partial class frmShortPathSolver : Form
    {
        IMapDocument mapDocument;
        public IFeatureWorkspace pFWorkspace;
        string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        public frmShortPathSolver()
        {
            InitializeComponent();
        }

        private void open_Click(object sender, EventArgs e)
        {
            mapDocument = new MapDocumentClass();
            try
            {
                System.Windows.Forms.OpenFileDialog openFileDialog;
                openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "打开图层文件";
                openFileDialog.Filter = "map documents(*.mxd)|*.mxd";
                openFileDialog.ShowDialog();
                string filePath = openFileDialog.FileName;
                mapDocument.Open(filePath, "");
                for (int i = 0; i < mapDocument.MapCount; i++)
                {
                    mainMapControl.Map = mapDocument.get_Map(i);
                }
                mainMapControl.Refresh();
                               
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载失败" + ex.ToString());
            }
        }
        //加载站点
        private void addStops_Click(object sender, EventArgs e)
        {
            ICommand pCommand;
            pCommand = new AddNetStopsTool();
            pCommand.OnCreate(mainMapControl.Object);
            mainMapControl.CurrentTool = pCommand as ITool;
            pCommand = null;
        }
        //加载障碍点
        private void addBarriers_Click(object sender, EventArgs e)
        {
            ICommand pCommand;
            pCommand = new AddNetBarriesTool();
            pCommand.OnCreate(mainMapControl.Object);
            mainMapControl.CurrentTool = pCommand as ITool;
            pCommand = null;
        }
        //最短路径分析
        private void routeSolver_Click(object sender, EventArgs e)
        {
            ICommand pCommand;
            pCommand = new ShortPathSolveCommand();
            pCommand.OnCreate(mainMapControl.Object);
            pCommand.OnClick();
            pCommand = null;
        }
        //清除分析
        private void clear_Click(object sender, EventArgs e)
        {
            mainMapControl.CurrentTool = null;
            try
            {
                string name = @"D:\code\AO107\AO102\chp10\最短路径分析" + "\\data\\HuanbaoGeodatabase.gdb";
                //打开工作空间
                pFWorkspace = NetWorkAnalysClass.OpenWorkspace(name) as IFeatureWorkspace;
                IGraphicsContainer pGrap = this.mainMapControl.ActiveView as IGraphicsContainer;
                pGrap.DeleteAllElements();//删除所添加的图片要素
                IFeatureClass inputFClass = pFWorkspace.OpenFeatureClass("Stops");
                //删除站点要素
                if (inputFClass.FeatureCount(null) > 0)
                {
                    ITable pTable = inputFClass as ITable;
                    pTable.DeleteSearchedRows(null);                 
                }
                IFeatureClass barriesFClass = pFWorkspace.OpenFeatureClass("Barries");//删除障碍点要素
                if (barriesFClass.FeatureCount(null) > 0)
                {
                    ITable pTable = barriesFClass as ITable;
                    pTable.DeleteSearchedRows(null);
                }
                for (int i = 0; i < mainMapControl.LayerCount; i++)//删除分析结果
                {
                    ILayer pLayer = mainMapControl.get_Layer(i);
                    if (pLayer.Name == ShortPathSolveCommand.m_NAContext.Solver.DisplayName)
                    {
                        mainMapControl.DeleteLayer(i);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.mainMapControl.Refresh();
        }


    }
}
