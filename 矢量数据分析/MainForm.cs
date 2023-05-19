using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using System.IO;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using EditSDELayerDemo.Menu;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.ConversionTools;
using ESRI.ArcGIS.Geoprocessor;

namespace EditSDELayerDemo
{
    public partial class MainFrom : Form
    {
        public MainFrom()
        {
            InitializeComponent();
        }

        private void MainFrom_Load(object sender, EventArgs e)
        {
        }

        public AxMapControl getMainAxMapControl()
        {
            return axMapControl1;
        }

        #region //文件操作相关方法
        /// <summary>
        /// 打开MXD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemOpenMxd_Click(object sender, EventArgs e)
        {
            ICommand command = new ControlsOpenDocCommandClass();
            command.OnCreate(axMapControl1.Object);
            command.OnClick();
        }

        private void MenuItemAddData_Click(object sender, EventArgs e)
        {
            ControlsAddDataCommand adddata = new ControlsAddDataCommandClass();
            adddata.OnCreate(axMapControl1.Object);
            adddata.OnClick();
        }

        private void MenuItemSaveMxd_Click(object sender, EventArgs e)
        {
            ICommand pCommand = new ESRI.ArcGIS.Controls.ControlsSaveAsDocCommandClass();
            pCommand.OnCreate(axMapControl1.Object);
            pCommand.OnClick();
            MessageBox.Show("保存文档成功！", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MenuItemExportJPEG_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog exportJPGDialog = new SaveFileDialog();
                exportJPGDialog.Title = "导出JPEG图像";
                exportJPGDialog.Filter = "Jpeg Files(*.jpg,*.jpeg)|*.jpg,*.jpeg";
                exportJPGDialog.RestoreDirectory = true;
                exportJPGDialog.ValidateNames = true;
                exportJPGDialog.OverwritePrompt = true;
                exportJPGDialog.DefaultExt = "jpg";

                if (exportJPGDialog.ShowDialog() == DialogResult.OK)
                {
                    double lScreenResolution;
                    lScreenResolution = axMapControl1.ActiveView.ScreenDisplay.DisplayTransformation.Resolution;

                    IExport pExporter = new ExportJPEGClass() as IExport;
                    //IExport pExporter = new ExportPDFClass() as IExport;//直接可以用！！
                    pExporter.ExportFileName = exportJPGDialog.FileName;
                    pExporter.Resolution = lScreenResolution;

                    tagRECT deviceRECT;
                    //用这句的话执行到底下的ｏｕｔｐｕｔ（）时就会出现错误：Not enough memory to create requested bitmap
                    //MainaxMapControl.ActiveView.ScreenDisplay.DisplayTransformation.set_DeviceFrame(ref deviceRECT);
                    deviceRECT = axMapControl1.ActiveView.ExportFrame;

                    IEnvelope pDriverBounds = new EnvelopeClass();
                    //pDriverBounds = MainaxMapControl.ActiveView.FullExtent;

                    pDriverBounds.PutCoords(deviceRECT.left, deviceRECT.bottom, deviceRECT.right, deviceRECT.top);

                    pExporter.PixelBounds = pDriverBounds;

                    ITrackCancel pCancel = new CancelTrackerClass();
                    axMapControl1.ActiveView.Output(pExporter.StartExporting(), (int)lScreenResolution, ref deviceRECT, axMapControl1.ActiveView.Extent, pCancel);
                    pExporter.FinishExporting();
                    pExporter.Cleanup();
                    MessageBox.Show("导出Jpeg图像成功！图像保存在" + exportJPGDialog.FileName, "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); return; }
        }

        private void MenuItemCloseMap_Click(object sender, EventArgs e)
        {
            axMapControl1.ActiveView.Clear();
            axMapControl1.ActiveView.Refresh();
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        /// <summary>
        /// 显示当前比例尺与坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            ScaleLabel.Text = " 比例尺 1:" + ((long)this.axMapControl1.MapScale).ToString();
            CoordinateLabel.Text = " 当前坐标 X = " + e.mapX.ToString() + " Y = " + e.mapY.ToString() + " " + this.axMapControl1.MapUnits;
        }
        /// <summary>
        /// 缓冲区查询（点击选择要素并做缓冲区）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBufferAnalysis_Click(object sender, EventArgs e)
        {
            ICommand pCommand = new ToolBufferAnalysis();
            pCommand.OnCreate(this.axMapControl1.Object);
            this.axMapControl1.CurrentTool = pCommand as ITool;
            pCommand = null;
        }
        /// <summary>
        /// 获取点击多边形要素边界
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFeatureBoundary_Click(object sender, EventArgs e)
        {
            ICommand pCommand = new ToolGetBoundary();
            pCommand.OnCreate(this.axMapControl1.Object);
            this.axMapControl1.CurrentTool = pCommand as ITool;
            pCommand = null;
        }
        /// <summary>
        /// 邻接要素查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueryNearFeature_Click(object sender, EventArgs e)
        {
            ICommand pCommand = new ToolGetNearFeature();
            pCommand.OnCreate(this.axMapControl1.Object);
            this.axMapControl1.CurrentTool = pCommand as ITool;
            pCommand = null;
        }

        /// <summary>
        /// 裁剪分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClipAnalysis_Click(object sender, EventArgs e)
        {
            //获得裁剪图层和被裁剪图层
            ILayer pInputLayer = GetLayerByName("省界面");
            ILayer pClipLayer = GetLayerByName("总地区界面");
            if (pInputLayer != null && pClipLayer != null)
            {
                IFeatureLayer pInputFeaLayer = pInputLayer as IFeatureLayer;
                IFeatureLayer pClipFeaLayer = pClipLayer as IFeatureLayer;
                //通过Clip方法进行裁剪操作，返回结果FeatureClass
                IFeatureClass outFeatureClass = Clip(pInputFeaLayer.FeatureClass, pClipFeaLayer.FeatureClass, @"c:\", "裁剪分析结果");
                if (outFeatureClass != null)
                {
                    //将结果FeatureClass数据集转为FeatureLayer
                    IFeatureLayer pFeatueLayer = new FeatureLayerClass();
                    pFeatueLayer.FeatureClass = outFeatureClass;
                    pFeatueLayer.Name = outFeatureClass.AliasName;
                    //将结果数据加载到地图中，并刷新地图控件
                    this.axMapControl1.AddLayer(pFeatueLayer);
                    this.axMapControl1.Refresh();
                    this.axTOCControl1.Refresh();
                }
            }
        }
        /// <summary>
        /// Clip裁剪分析
        /// </summary>
        /// <param name="pInputFeatureClass">第一个要素(被相交要素)</param>
        /// <param name="pClipFeatureClass">第二个要素（裁剪要素）</param>
        /// <param name="filePath">生成要素的存储路径</param>
        /// <param name="_pFileName">生成新要素FeatureClass名称</param>
        ///  使用示例：IFeatureClass outFeatureClass = Clip(pFeatureClass1, pFeatureClass2, @".\data\矢量数据", "clip");
        /// <returns></returns>
        public IFeatureClass Clip(IFeatureClass pInputFeatureClass, IFeatureClass pClipFeatureClass, string filePath, string _pFileName)
        {
            //设置输出结果IFeatureClassName相关必备属性
            IFeatureClassName pOutPut = new FeatureClassNameClass();
            pOutPut.ShapeType = pInputFeatureClass.ShapeType;
            pOutPut.ShapeFieldName = pInputFeatureClass.ShapeFieldName;
            pOutPut.FeatureType = esriFeatureType.esriFTSimple;
            //获取shapeFile数据工作空间
            IWorkspaceName pWsN = new WorkspaceNameClass();
            pWsN.WorkspaceFactoryProgID = "esriDataSourcesFile.ShapefileWorkspaceFactory";
            pWsN.PathName = filePath;
            //通过IDatasetName设置输出结果相关参数
            IDatasetName pDatasetName = pOutPut as IDatasetName;
            pDatasetName.Name = _pFileName;
            pDatasetName.WorkspaceName = pWsN;
            //初始化IBasicGeoprocessor对象，调用Clip方法
            IBasicGeoprocessor pBasicGeo = new BasicGeoprocessorClass();
            pBasicGeo.SpatialReference = axMapControl1.SpatialReference;
            //进行裁剪运算
            IFeatureClass pFeatureClass = pBasicGeo.Clip(pInputFeatureClass as ITable, false, pClipFeatureClass as ITable, false, 0.01, pOutPut);
            return pFeatureClass;
        }

        /// <summary>
        /// 通过图层名称获取目标图层
        /// </summary>
        /// <param name="layerName"></param>
        /// <returns></returns>
        private ILayer GetLayerByName(string layerName)
        {
            // 通过图层名称获取目标图层，传入参数为layerName
            ILayer pLayer = null;
            //遍历MapControl中所有图层，找到与layerName名称相同的图层
            for (int i = 0; i < this.axMapControl1.LayerCount; i++)
            {
                if (this.axMapControl1.get_Layer(i).Name == layerName)
                {
                    pLayer = this.axMapControl1.get_Layer(i);
                    break;
                }
            }
            return pLayer;
        }

        /// <summary>
        /// ShapeFile数据转换为File Geodatabase数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemShapeToFeaCla_Click(object sender, EventArgs e)
        {
            //首先打开ShapeFile数据
            IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactory();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "ShapeFile(*.shp)|*.shp";
            openFileDialog1.Multiselect = false;
            DialogResult pDialogResult = openFileDialog1.ShowDialog();
            if (pDialogResult != DialogResult.OK)
                return;
            string pPath = openFileDialog1.FileName;
            string pFolder = System.IO.Path.GetDirectoryName(pPath);
            string pFileName = System.IO.Path.GetFileName(pPath);
            //获得ShapeFile数据的工作空间
            IWorkspaceName sourceWorkspaceName = new WorkspaceNameClass();
            sourceWorkspaceName.WorkspaceFactoryProgID = "esriDataSourcesFile.ShapefileWorkspaceFactory";
            sourceWorkspaceName.PathName = pFolder;
            IName sourceWorkspaceIName = (IName)sourceWorkspaceName;
            IWorkspace sourceWorkspace = (IWorkspace)sourceWorkspaceIName.Open();
            // 打开目标存储File GeodataBase然后并打开此文件数据库工作空间
            IWorkspaceName targetWorkspaceName = new WorkspaceNameClass
            {
                WorkspaceFactoryProgID = "esriDataSourcesGDB.FileGDBWorkspaceFactory",
                PathName =pFolder+@"\FileGDB.gdb"
            };
            IName targetWorkspaceIName = (IName)targetWorkspaceName;
            IWorkspace targetWorkspace = null;
            try
            {
                targetWorkspace = (IWorkspace)targetWorkspaceIName.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, "未能正确读取目标工作空间，请确保读取ShapeFile数据路径下有FileGDB.gdb空间数据库（直接将数据压缩文件解压即可）！", "运行提示");
            }
             
            // 将ShapeFile数据转化为IDatasetName数据集
            IFeatureClassName sourceFeatureClassName = new FeatureClassNameClass();
            IDatasetName sourceDatasetName = (IDatasetName)sourceFeatureClassName;
            sourceDatasetName.Name = pFileName.Split('.')[0];
            sourceDatasetName.WorkspaceName = sourceWorkspaceName;
            // 为目标转化图层创建数据集
            IFeatureClassName targetFeatureClassName = new FeatureClassNameClass();
            IDatasetName targetDatasetName = (IDatasetName)targetFeatureClassName;
            targetDatasetName.Name = pFileName.Split('.')[0];
            targetDatasetName.WorkspaceName = targetWorkspaceName;
            // 打开源ShapeFile数据获得IFeatureClass
            IName sourceName = (IName)sourceFeatureClassName;
            IFeatureClass sourceFeatureClass = (IFeatureClass)sourceName.Open();
            // 获得源ShapeFile数据的所有字段
            IFieldChecker fieldChecker = new FieldCheckerClass();
            IFields sourceFields = sourceFeatureClass.Fields;
            IFields targetFields = null; 
            IEnumFieldError enumFieldError = null;
            // 设置字段检验参数
            fieldChecker.InputWorkspace = sourceWorkspace;
            fieldChecker.ValidateWorkspace = targetWorkspace;
            // 检验字段集合是否符合转换要求
            fieldChecker.Validate(sourceFields, out enumFieldError, out targetFields);
            if (enumFieldError != null)
            {
                MessageBox.Show("数据在进行字段转换过程中出现错误！");
            }    
            // 获ShapeFile数据图形要素字段
            String shapeFieldName = sourceFeatureClass.ShapeFieldName;
            int shapeFieldIndex = sourceFeatureClass.FindField(shapeFieldName);
            IField shapeField = sourceFields.get_Field(shapeFieldIndex);
            // 进行图形要素克隆
            IGeometryDef geometryDef = shapeField.GeometryDef;
            IClone geometryDefClone = (IClone)geometryDef;
            IClone targetGeometryDefClone = geometryDefClone.Clone();
            IGeometryDef targetGeometryDef = (IGeometryDef)targetGeometryDefClone;
            // 利用IGeometryDefEdit进行目标要素图层属性设置
            IGeometryDefEdit targetGeometryDefEdit = (IGeometryDefEdit)targetGeometryDef;
            targetGeometryDefEdit.GridCount_2 = 1;
            targetGeometryDefEdit.set_GridSize(0, 0.75);
            // 选择特定条件要素
            IQueryFilter queryFilter = new QueryFilterClass();
            queryFilter.WhereClause = "PROVINCE = 37";
            queryFilter.SubFields = "*";
            // 通过IFeatureDataConverter进行数据转换
            try
            {
                IFeatureDataConverter featureDataConverter = new FeatureDataConverterClass();
                IEnumInvalidObject enumInvalidObject = featureDataConverter.ConvertFeatureClass
                    (sourceFeatureClassName, queryFilter, null, targetFeatureClassName,
                    targetGeometryDef, targetFields, "", 1000, 0);    // Check for errors.
                IInvalidObjectInfo invalidObjectInfo = null;
                enumInvalidObject.Reset();
                while ((invalidObjectInfo = enumInvalidObject.Next()) != null)
                {
                    //输出转换过程日志
                    MessageBox.Show("数据在进行" + invalidObjectInfo.InvalidObjectID + "要素转换过程中出现错误！");
                }
                MessageBox.Show("转换成功结束！");
            }
            catch
            {
                MessageBox.Show("在目标文件夹中存在同名称图层，请先删除！","消息",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// ShapeFile数据转换为CAD数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemShapeToCAD_Click(object sender, EventArgs e)
        {
            try
            {
                IMap map = this.axMapControl1.Map;
                ILayer layer = map.get_Layer(0);
                this.axMapControl1.CustomProperty = layer;
                ICommand cmd = new CommandExportDxf();
                cmd.OnCreate(this.axMapControl1.Object);
                cmd.OnClick();
                cmd = null;
            }
            catch 
            {
                MessageBox.Show("请添加图层数据");
            }
        }

        /// <summary>
        /// 将Excel数据源表转化为空间点数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcelXYToPoint_Click(object sender, EventArgs e)
        {
            FrmXYToPoint pFrmXYToPoint = new FrmXYToPoint();
            pFrmXYToPoint.GetAxMapControl = this.axMapControl1;
            pFrmXYToPoint.GetAxTOCControl = this.axTOCControl1;
            pFrmXYToPoint.ShowDialog();
        }

        /// <summary>
        /// GP工具调用，生成缓冲区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGPBuffer_Click(object sender, EventArgs e)
        {
            try
            {
                //缓冲区分析-GP工具调用
                Geoprocessor gp = new Geoprocessor();
                gp.OverwriteOutput = true;
                ESRI.ArcGIS.AnalysisTools.Buffer pBuffer = new ESRI.ArcGIS.AnalysisTools.Buffer();
                //获取缓冲区分析图层
                ILayer pLayer = this.axMapControl1.get_Layer(0);
                IFeatureLayer featLayer = pLayer as IFeatureLayer;
                pBuffer.in_features = featLayer;
                string filepath = @"c:\";
                //设置生成结果存储路径
                pBuffer.out_feature_class = filepath + "\\" + pLayer.Name + ".shp";
                //设置缓冲区距离
                pBuffer.buffer_distance_or_field = "50000 Meters";
                pBuffer.dissolve_option = "ALL";
                //执行缓冲区分析
                gp.Execute(pBuffer, null);
                //将生成结果添加到地图中
                this.axMapControl1.AddShapeFile(filepath, pLayer.Name);
                this.axMapControl1.MoveLayerTo(1, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("请输入有效数据");
            }
        }
        /// <summary>
        /// GP工具调用，ShapeFile数据转CAD数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGPShapeaToCAD_Click(object sender, EventArgs e)
        {
            FrmShapeToCAD pFrmShapeToCAD = new FrmShapeToCAD(this.axMapControl1);
            pFrmShapeToCAD.ShowDialog();
            if (pFrmShapeToCAD.DialogResult == DialogResult.OK)
            {
                this.axMapControl1.Refresh();
                this.axTOCControl1.Refresh();
            }
        }

    }
}
