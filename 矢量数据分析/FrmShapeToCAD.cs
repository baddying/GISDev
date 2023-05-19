using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.ConversionTools;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;

namespace EditSDELayerDemo
{
    public partial class FrmShapeToCAD : Form
    {
        private List<string> CadTypes = new List<string>() { "DWG_R14", "DWG_R2000", "DWG_R2004", "DWG_R2005",
                "DWG_R2007", "DWG_R2010", "DXF_R14", "DXF_R2000", "DXF_R2004",
                "DXF_R2005", "DXF_R2007", "DXF_R2010"};
        private AxMapControl axMapControl1;
        public FrmShapeToCAD(AxMapControl axMapControl)
        {
            InitializeComponent();
            axMapControl1 = axMapControl;
        }
    
        private void FrmShapeToCAD_Load(object sender, EventArgs e)
        {
            foreach (string type in CadTypes)
            {
                this.listBoxOfCADType.Items.Add(type);
            }
            this.listBoxOfCADType.SelectedIndex = 5;
        }

        private void btnOpenShape_Click(object sender, EventArgs e)
        {
            //首先打开ShapeFile数据
            IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactory();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "ShapeFile(*.shp)|*.shp";
            openFileDialog1.Multiselect = false;
            DialogResult pDialogResult = openFileDialog1.ShowDialog();
            if (pDialogResult != DialogResult.OK)
                return;
            this.txtShapePath.Text = openFileDialog1.FileName;
           
        }

        private void btnSaveCADPath_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "AutoCad文件(*.dwg)|*.dwg|AutoCad文件(*.dxf)|*.dxf";
            saveDialog.Title = "选择保存路径";
            saveDialog.OverwritePrompt = false;
            if (saveDialog.ShowDialog(this) == DialogResult.OK)
            {
                var strFullPath = saveDialog.FileName;
                this.txtCADPath.Text = strFullPath;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (this.txtShapePath.Text == string.Empty || this.txtCADPath.Text == string.Empty)
            {
                return;
            }
            string pShapePath = this.txtShapePath.Text;
            string cadType = this.listBoxOfCADType.SelectedItem.ToString();
            string pCADPath = this.txtCADPath.Text;
            ExportCAD GPexport = new ExportCAD(pShapePath, cadType, pCADPath);
            GPexport.Ignore_FileNames = "1";
            GPexport.Append_To_Existing = "1";

            Geoprocessor GP = new Geoprocessor();
            var result = GP.Execute(GPexport, null) as ESRI.ArcGIS.Geoprocessing.IGeoProcessorResult;
            if (result.Status == ESRI.ArcGIS.esriSystem.esriJobStatus.esriJobSucceeded)
            {
                //将当前CAD图层添加到地图
                var Index = pCADPath.LastIndexOf("\\");
                var filePath = pCADPath.Substring(0, Index);
                var fileName = pCADPath.Substring(Index + 1);

                CadWorkspaceFactory pWorkspaceFactory = new CadWorkspaceFactory();
                IFeatureWorkspace pFeatWorkSpace = pWorkspaceFactory.OpenFromFile(filePath, 0) as IFeatureWorkspace;
                var dataset = pFeatWorkSpace.OpenFeatureDataset(fileName);

                //初始化CAD图层转化为Layer
                var pCadDrawingWorkspace = pFeatWorkSpace as ICadDrawingWorkspace;
                var pCadDrawingDataset = pCadDrawingWorkspace.OpenCadDrawingDataset(fileName);
                ICadLayer pCadLayer = new CadLayerClass();
                pCadLayer.CadDrawingDataset = pCadDrawingDataset;
                pCadLayer.Name = fileName;
                axMapControl1.AddLayer(pCadLayer,0);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }



    }
}
