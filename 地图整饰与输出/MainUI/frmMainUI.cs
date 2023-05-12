using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using 地图整饰与输出.Class;
using 地图整饰与输出.Class.EnumType;
using 地图整饰与输出.PageLayout;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Output;
using PrintPreview;
using stdole;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.CatalogUI;
using System.Diagnostics;
using System.IO;
namespace 地图整饰与输出
{
    public partial class frmMainUI : Form
    {
        #region  变量定义      
        //地图到处窗体                 
        private frmSymbol frmSym = null;           
        private frmPrintPreview frmPrintPreview = null; // 打印                      
        //对地图的基本操作类
        private OperatePageLayout m_OperatePageLayout = null;         
        private INewEnvelopeFeedback pNewEnvelopeFeedback;      
        private EnumMapSurroundType _enumMapSurType = EnumMapSurroundType.None;
        private IStyleGalleryItem pStyleGalleryItem;   
        private IPoint m_MovePt = null;
        private IPoint m_PointPt = null;     
        private System.Drawing.Printing.PrintDocument document = new System.Drawing.Printing.PrintDocument(); //打印 
        string filepath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;        
        #endregion
        public frmMainUI()
        {           
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
            InitializeComponent();
            m_OperatePageLayout = new OperatePageLayout();           
        }       
        #region 文件打开       
        private void OpenFile_Click(object sender, EventArgs e)
        {
            ICommand Cmd = new ControlsOpenDocCommandClass();
            Cmd.OnCreate(mainPagelayoutControl.Object);
            Cmd.OnClick();
        }      
        #endregion    
        #region  添加制图要素1
        private void AddLegend_Click(object sender, EventArgs e)
        {
            try
            {
                _enumMapSurType = EnumMapSurroundType.Legend;
            }
            catch (Exception ex)
            {

            }
        }
        private void frmSym_GetSelSymbolItem(ref IStyleGalleryItem pStyleItem)
        {
            pStyleGalleryItem = pStyleItem;
        }
        private void AddNorthArrows_Click(object sender, EventArgs e)
        {
            try
            {
                _enumMapSurType = EnumMapSurroundType.NorthArrow;
                if (frmSym == null || frmSym.IsDisposed)
                {
                    frmSym = new frmSymbol();
                    frmSym.GetSelSymbolItem += new frmSymbol.GetSelSymbolItemEventHandler(frmSym_GetSelSymbolItem);
                }
                frmSym.EnumMapSurType = _enumMapSurType;
                frmSym.InitUI();
                frmSym.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        private void AddScaleBar_Click(object sender, EventArgs e)
        {
            try
            {
                _enumMapSurType = EnumMapSurroundType.ScaleBar;
                if (frmSym == null || frmSym.IsDisposed)
                {
                    frmSym = new frmSymbol();
                    frmSym.GetSelSymbolItem += new frmSymbol.GetSelSymbolItemEventHandler(frmSym_GetSelSymbolItem);
                }
                frmSym.EnumMapSurType = _enumMapSurType;
                frmSym.InitUI();
                frmSym.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        #endregion
        #region 添加制图要素2
        //通过OnMouseDown事件，产生矩形框的第一个点
        private void mainPagelayoutControl_OnMouseDown(object sender, IPageLayoutControlEvents_OnMouseDownEvent e)
        {
            try
            {
                if (_enumMapSurType != EnumMapSurroundType.None)
                {
                    IActiveView pActiveView = null;
                    pActiveView = mainPagelayoutControl.PageLayout as IActiveView;
                    m_PointPt = pActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);
                    if (pNewEnvelopeFeedback == null)
                    {
                        pNewEnvelopeFeedback = new NewEnvelopeFeedbackClass();
                        pNewEnvelopeFeedback.Display = pActiveView.ScreenDisplay;
                        pNewEnvelopeFeedback.Start(m_PointPt);
                    }
                    else
                    {
                        pNewEnvelopeFeedback.MoveTo(m_PointPt);
                    }

                }
            }
            catch
            {
            }
        }
        private void mainPagelayoutControl_OnMouseMove(object sender, IPageLayoutControlEvents_OnMouseMoveEvent e)
        {
            try
            {
                if (_enumMapSurType != EnumMapSurroundType.None)
                {
                    if (pNewEnvelopeFeedback != null)
                    {
                        m_MovePt = (mainPagelayoutControl.PageLayout as IActiveView).ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);
                        pNewEnvelopeFeedback.MoveTo(m_MovePt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        //通过OnMouseUp事件，产生矩形框的第一个点的对焦点，返回一个矩形，并将制图要素添加到该矩形中
        private void mainPagelayoutControl_OnMouseUp(object sender, IPageLayoutControlEvents_OnMouseUpEvent e)
        {
            if (_enumMapSurType != EnumMapSurroundType.None)
            {
                if (pNewEnvelopeFeedback != null)
                {
                    IActiveView pActiveView = null;
                    pActiveView = mainPagelayoutControl.PageLayout as IActiveView;
                    IEnvelope pEnvelope = pNewEnvelopeFeedback.Stop();
                    AddMapSurround(pActiveView, _enumMapSurType, pEnvelope);
                    pNewEnvelopeFeedback = null;
                    _enumMapSurType = EnumMapSurroundType.None;
                }
            }
        }
        /// <summary>
        /// 添加地图整饰要素
        /// </summary>
        /// <param name="pAV"></param>
        /// <param name="_enumMapSurroundType"></param>
        /// <param name="pEnvelope"></param>
        private void AddMapSurround(IActiveView pAV, EnumMapSurroundType _enumMapSurroundType, IEnvelope pEnvelope)
        {
            try
            {
                switch (_enumMapSurroundType)
                {
                    case EnumMapSurroundType.NorthArrow:
                        addNorthArrow(mainPagelayoutControl.PageLayout, pEnvelope, pAV);
                        break;
                    case EnumMapSurroundType.ScaleBar:
                        makeScaleBar(pAV, mainPagelayoutControl.PageLayout, pEnvelope);
                        break;
                    case EnumMapSurroundType.Legend:
                        MakeLegend(pAV, mainPagelayoutControl.PageLayout, pEnvelope);
                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }
        #region 添加图例
        /// <summary>
        /// 添加图例
        /// </summary>
        /// <param name="activeView"></活动窗口>
        /// <param name="pageLayout"></布局窗口>
        /// <param name="pEnv"></包络线>
        private void MakeLegend(IActiveView pActiveView, IPageLayout pPageLayout, IEnvelope pEnv)
        {
            UID pID = new UID();
            pID.Value = "esriCarto.Legend";
            IGraphicsContainer pGraphicsContainer = pPageLayout as IGraphicsContainer;
            IMapFrame pMapFrame = pGraphicsContainer.FindFrame(pActiveView.FocusMap) as IMapFrame;
            IMapSurroundFrame pMapSurroundFrame = pMapFrame.CreateSurroundFrame(pID, null);//根据唯一标示符，创建与之对应MapSurroundFrame
            IElement pDeletElement = mainPagelayoutControl.FindElementByName("Legend");//获取PageLayout中的图例元素
            if (pDeletElement != null)
            {
                pGraphicsContainer.DeleteElement(pDeletElement);  //如果已经存在图例，删除已经存在的图例
            }
            //设置MapSurroundFrame背景
            ISymbolBackground pSymbolBackground = new SymbolBackgroundClass();
            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            ILineSymbol pLineSymbol = new SimpleLineSymbolClass();
            pLineSymbol.Color = m_OperatePageLayout.GetRgbColor(0, 0, 0);
            pFillSymbol.Color = m_OperatePageLayout.GetRgbColor(240, 240, 240);
            pFillSymbol.Outline = pLineSymbol;
            pSymbolBackground.FillSymbol = pFillSymbol;
            pMapSurroundFrame.Background = pSymbolBackground;
            //添加图例
            IElement pElement = pMapSurroundFrame as IElement;
            pElement.Geometry = pEnv as IGeometry;
            IMapSurround pMapSurround = pMapSurroundFrame.MapSurround;
            ILegend pLegend = pMapSurround as ILegend;
            pLegend.ClearItems();
            pLegend.Title = "图例";
            for (int i = 0; i < pActiveView.FocusMap.LayerCount; i++)
            {
                ILegendItem pLegendItem = new HorizontalLegendItemClass();
                pLegendItem.Layer = pActiveView.FocusMap.get_Layer(i);//获取添加图例关联图层             
                pLegendItem.ShowDescriptions = false;
                pLegendItem.Columns = 1;
                pLegendItem.ShowHeading = true;
                pLegendItem.ShowLabels = true;
                pLegend.AddItem(pLegendItem);//添加图例内容
            }
            pGraphicsContainer.AddElement(pElement, 0);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);            
        }
        #endregion
        #region 指北针
        /// <summary>
        /// 插入指北针
        /// </summary>
        /// <param name="pPageLayout"></param>
        /// <param name="pEnv"></param>
        /// <param name="pActiveView"></param>
        void addNorthArrow(IPageLayout pPageLayout, IEnvelope pEnv, IActiveView pActiveView)
        {
            IMap pMap = pActiveView.FocusMap;
            IGraphicsContainer pGraphicsContainer = pPageLayout as IGraphicsContainer;
            IMapFrame pMapFrame = pGraphicsContainer.FindFrame(pMap) as IMapFrame;
            if (pStyleGalleryItem == null) return;
            IMapSurroundFrame pMapSurroundFrame = new MapSurroundFrameClass();
            pMapSurroundFrame.MapFrame = pMapFrame;
            INorthArrow pNorthArrow = new MarkerNorthArrowClass();
            pNorthArrow = pStyleGalleryItem.Item as INorthArrow;
            pNorthArrow.Size = pEnv.Width*50;
            pMapSurroundFrame.MapSurround = (IMapSurround)pNorthArrow;//根据用户的选取，获取相应的MapSurround            
            IElement pElement = mainPagelayoutControl.FindElementByName("NorthArrows");//获取PageLayout中的指北针元素
            if (pElement != null)
            {
                pGraphicsContainer.DeleteElement(pElement);  //如果存在指北针，删除已经存在的指北针
            }
            IElementProperties pElePro = null;
            pElement = (IElement)pMapSurroundFrame;
            pElement.Geometry = (IGeometry)pEnv;
            pElePro = pElement as IElementProperties;
            pElePro.Name = "NorthArrows";
            pGraphicsContainer.AddElement(pElement, 0);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
        #endregion
        #region  比例尺
        /// <summary>
        /// 比例尺
        /// </summary>
        /// <param name="pActiveView"></param>
        /// <param name="pPageLayout"></param>
        /// <param name="pEnv"></param>
        public void makeScaleBar(IActiveView pActiveView, IPageLayout pPageLayout, IEnvelope pEnv)
        {           
            IMap pMap = pActiveView.FocusMap;
            IGraphicsContainer pGraphicsContainer = pPageLayout as IGraphicsContainer;
            IMapFrame pMapFrame = pGraphicsContainer.FindFrame(pMap) as IMapFrame;
            if (pStyleGalleryItem == null) return;
            IMapSurroundFrame pMapSurroundFrame = new MapSurroundFrameClass();
            pMapSurroundFrame.MapFrame = pMapFrame;
            pMapSurroundFrame.MapSurround = (IMapSurround)pStyleGalleryItem.Item;
            IElement pElement = mainPagelayoutControl.FindElementByName("ScaleBar");
            if (pElement != null)
            {
                pGraphicsContainer.DeleteElement(pElement);  //删除已经存在的比例尺
            }
            IElementProperties pElePro = null;
            pElement = (IElement)pMapSurroundFrame;
            pElement.Geometry = (IGeometry)pEnv;
            pElePro = pElement as IElementProperties;
            pElePro.Name = "ScaleBar";
            pGraphicsContainer.AddElement(pElement, 0);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
        #endregion      
        #endregion
        #region 添加制图要素3
        #region Graticule格网
        private void AddGraticuleh_Click(object sender, EventArgs e)
        {
            try
            {
                IActiveView pActiveView = mainPagelayoutControl.ActiveView;
                IPageLayout pPageLayout = mainPagelayoutControl.PageLayout;
                DeleteMapGrid(pActiveView, pPageLayout);
                CreateGraticuleMapGrid(pActiveView, pPageLayout);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void CreateGraticuleMapGrid(IActiveView pActiveView, IPageLayout pPageLayout)
        {
            IMap pMap = pActiveView.FocusMap;
            IGraticule pGraticule = new GraticuleClass();//看这个改动是否争取
            pGraticule.Name = "Map Grid";
            //设置网格线的符号样式
            ICartographicLineSymbol pLineSymbol;
            pLineSymbol = new CartographicLineSymbolClass();
            pLineSymbol.Cap = esriLineCapStyle.esriLCSButt;
            pLineSymbol.Width = 1;
            pLineSymbol.Color = m_OperatePageLayout.GetRgbColor(166, 187, 208);
            pGraticule.LineSymbol = pLineSymbol;
            //设置网格的边框样式           
            ISimpleMapGridBorder simpleMapGridBorder = new SimpleMapGridBorderClass();
            ISimpleLineSymbol simpleLineSymbol = new SimpleLineSymbolClass();
            simpleLineSymbol.Style = esriSimpleLineStyle.esriSLSSolid;
            simpleLineSymbol.Color = m_OperatePageLayout.GetRgbColor(100, 255, 0);
            simpleLineSymbol.Width = 2;
            simpleMapGridBorder.LineSymbol = simpleLineSymbol as ILineSymbol;
            pGraticule.Border = simpleMapGridBorder as IMapGridBorder;
            pGraticule.SetTickVisibility(true, true, true, true);
            //设置网格的主刻度的样式和可见性
            pGraticule.TickLength = 15;
            pLineSymbol = new CartographicLineSymbolClass();
            pLineSymbol.Cap = esriLineCapStyle.esriLCSButt;
            pLineSymbol.Width = 1;
            pLineSymbol.Color = m_OperatePageLayout.GetRgbColor(255, 187, 208);
            pGraticule.TickMarkSymbol = null;
            pGraticule.TickLineSymbol = pLineSymbol;
            pGraticule.SetTickVisibility(true, true, true, true);
            //设置网格的次级刻度的样式和可见性
            pGraticule.SubTickCount = 5;
            pGraticule.SubTickLength = 10;
            pLineSymbol = new CartographicLineSymbolClass();
            pLineSymbol.Cap = esriLineCapStyle.esriLCSButt;
            pLineSymbol.Width = 0.1;
            pLineSymbol.Color = m_OperatePageLayout.GetRgbColor(166, 187, 208);
            pGraticule.SubTickLineSymbol = pLineSymbol;
            pGraticule.SetSubTickVisibility(true, true, true, true);
            //设置网格的标签的样式和可见性
            IGridLabel pGridLabel;
            pGridLabel = pGraticule.LabelFormat;
            pGridLabel.LabelOffset = 15;
            stdole.StdFont pFont = new stdole.StdFont();
            pFont.Name = "Arial";
            pFont.Size = 16;
            pGraticule.LabelFormat.Font = pFont as stdole.IFontDisp;
            pGraticule.Visible = true;
            //创建IMeasuredGrid对象
            IMeasuredGrid pMeasuredGrid = new MeasuredGridClass();
            IProjectedGrid pProjectedGrid = pMeasuredGrid as IProjectedGrid;
            pProjectedGrid.SpatialReference = pMap.SpatialReference;
            pMeasuredGrid = pGraticule as IMeasuredGrid;
            //获取坐标范围，设置网格的起始点和间隔
            double MaxX, MaxY, MinX, MinY;
            pProjectedGrid.SpatialReference.GetDomain(out MinX, out MaxX, out MinY, out MaxY);
            pMeasuredGrid.FixedOrigin = true;
            pMeasuredGrid.Units = pMap.MapUnits;
            pMeasuredGrid.XIntervalSize = (MaxX - MinX) / 200;//纬度间隔
            pMeasuredGrid.XOrigin = MinX;
            pMeasuredGrid.YIntervalSize = (MaxY - MinY) / 200;//经度间隔.
            pMeasuredGrid.YOrigin = MinY;
            //将网格对象添加到地图控件中                              
            IGraphicsContainer pGraphicsContainer = pActiveView as IGraphicsContainer;
            IMapFrame pMapFrame = pGraphicsContainer.FindFrame(pMap) as IMapFrame;
            IMapGrids pMapGrids = pMapFrame as IMapGrids;
            pMapGrids.AddMapGrid(pGraticule);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewBackground, null, null);
        }
        #endregion
        #region MeasuredGrid格网
        private void AddMeasuredGrid_Click(object sender, EventArgs e)
        {
            IActiveView pActiveView = mainPagelayoutControl.ActiveView;
            IPageLayout pPageLayout = mainPagelayoutControl.PageLayout;
            DeleteMapGrid(pActiveView, pPageLayout);//删除已存在格网
            CreateMeasuredGrid(pActiveView, pPageLayout);
        }
        public void CreateMeasuredGrid(IActiveView pActiveView, IPageLayout pPageLayout)
        {
            IMap map = pActiveView.FocusMap;
            IMeasuredGrid pMeasuredGrid = new MeasuredGridClass();
            //设置格网基本属性           
            pMeasuredGrid.FixedOrigin = false;
            pMeasuredGrid.Units = map.MapUnits;
            pMeasuredGrid.XIntervalSize = 5;//纬度间隔           
            pMeasuredGrid.YIntervalSize = 5;//经度间隔.             
            //设置GridLabel格式
            IGridLabel pGridLabel = new FormattedGridLabelClass();
            IFormattedGridLabel pFormattedGridLabel = new FormattedGridLabelClass();
            INumericFormat pNumericFormat = new NumericFormatClass();
            pNumericFormat.AlignmentOption = esriNumericAlignmentEnum.esriAlignLeft;
            pNumericFormat.RoundingOption = esriRoundingOptionEnum.esriRoundNumberOfDecimals;
            pNumericFormat.RoundingValue = 0;
            pNumericFormat.ZeroPad = true;
            pFormattedGridLabel.Format = pNumericFormat as INumberFormat;
            pGridLabel = pFormattedGridLabel as IGridLabel;
            StdFont myFont = new stdole.StdFontClass();
            myFont.Name = "宋体";
            myFont.Size = 25;
            pGridLabel.Font = myFont as IFontDisp;
            IMapGrid pMapGrid = new MeasuredGridClass();
            pMapGrid = pMeasuredGrid as IMapGrid;
            pMapGrid.LabelFormat = pGridLabel;
            //将格网添加到地图上           
            IGraphicsContainer graphicsContainer = pPageLayout as IGraphicsContainer;
            IFrameElement frameElement = graphicsContainer.FindFrame(map);
            IMapFrame mapFrame = frameElement as IMapFrame;
            IMapGrids mapGrids = null;
            mapGrids = mapFrame as IMapGrids;
            mapGrids.AddMapGrid(pMapGrid);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewBackground, null, null);
        }
        #endregion
        #region IndexGrid格网
        private void AddIndexGrid_Click(object sender, EventArgs e)
        {
            IActiveView pActiveView = mainPagelayoutControl.ActiveView;
            IPageLayout pPageLayout = mainPagelayoutControl.PageLayout;
            DeleteMapGrid(pActiveView, pPageLayout);
            CreateIndexGrid(pActiveView, pPageLayout);
        }
        public void CreateIndexGrid(IActiveView pActiveView, IPageLayout pPageLayout)
        {
            IIndexGrid pIndexGrid = new IndexGridClass();
            //设置Index属性
            pIndexGrid.ColumnCount = 5;
            pIndexGrid.RowCount = 5;
            String[] indexnum = { "A", "B", "C", "D", "E" };
            //设置IndexLabel
            int i = 0;
            for (i = 0; i <= (pIndexGrid.ColumnCount - 1); i++)
            {
                pIndexGrid.set_XLabel(i, indexnum[i]);
            }
            for (i = 0; i <= (pIndexGrid.RowCount - 1); i++)
            {
                pIndexGrid.set_YLabel(i, i.ToString());
            }
            //设置GridLabel格式
            IGridLabel pGridLabel = new RoundedTabStyleClass();
            StdFont myFont = new stdole.StdFontClass();
            myFont.Name = "宋体";
            myFont.Size = 18;
            pGridLabel.Font = myFont as IFontDisp;
            IMapGrid pmapGrid = new IndexGridClass();
            pmapGrid = pIndexGrid as IMapGrid;
            pmapGrid.LabelFormat = pGridLabel;
            //添加IndexGrid         
            IMapGrid pMapGrid = pIndexGrid;
            IMap pMap = pActiveView.FocusMap;
            IGraphicsContainer graphicsContainer = pPageLayout as IGraphicsContainer;
            IFrameElement frameElement = graphicsContainer.FindFrame(pMap);
            IMapFrame mapFrame = frameElement as IMapFrame;
            IMapGrids mapGrids = null;
            mapGrids = mapFrame as IMapGrids;
            mapGrids.AddMapGrid(pMapGrid);
            mainPagelayoutControl.Refresh();
        }
        #endregion       
        #region 删除已存在格网
        public void DeleteMapGrid(IActiveView pActiveView, IPageLayout pPageLayout)
        {
            IMap pMap = pActiveView.FocusMap;
            IGraphicsContainer graphicsContainer = pPageLayout as IGraphicsContainer;
            IFrameElement frameElement = graphicsContainer.FindFrame(pMap);
            IMapFrame mapFrame = frameElement as IMapFrame;
            IMapGrids mapGrids = null;
            mapGrids = mapFrame as IMapGrids;
            if (mapGrids.MapGridCount > 0)
            {
                IMapGrid pMapGrid = mapGrids.get_MapGrid(0);
                mapGrids.DeleteMapGrid(pMapGrid);
            }
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewBackground, null, null);
        }
        #endregion
        #endregion
        #region 制图模板
        private void SelectTemplate_Click(object sender, EventArgs e)
        {
            frmTemplate fTemplate = new frmTemplate(mainPagelayoutControl);
            fTemplate.Show();
        }
        #endregion
        #region  输出
        private void ExportMap_Click(object sender, EventArgs e)
        {
            ExportMapToImage();
        }             
        private void  ExportMapToImage()
        {
            try
            {
                SaveFileDialog pSaveDialog = new SaveFileDialog();
                pSaveDialog.FileName = "";
                pSaveDialog.Filter = "JPG图片(*.JPG)|*.jpg|tif图片(*.tif)|*.tif|PDF文档(*.PDF)|*.pdf";
                if (pSaveDialog.ShowDialog() == DialogResult.OK)
                {
                    double iScreenDispalyResolution = mainPagelayoutControl.ActiveView.ScreenDisplay.DisplayTransformation.Resolution;// 获取屏幕分辨率的值
                    IExporter pExporter = null;
                    if (pSaveDialog.FilterIndex == 1)
                    {
                        pExporter = new JpegExporterClass();
                    }
                    else if (pSaveDialog.FilterIndex == 2)
                    {
                        pExporter = new TiffExporterClass();
                    }
                    else if (pSaveDialog.FilterIndex == 3)
                    {
                        pExporter = new PDFExporterClass();
                    }
                    pExporter.ExportFileName = pSaveDialog.FileName;
                    pExporter.Resolution = (short)iScreenDispalyResolution; //分辨率
                    tagRECT deviceRect = mainPagelayoutControl.ActiveView.ScreenDisplay.DisplayTransformation.get_DeviceFrame();
                    IEnvelope pDeviceEnvelope = new EnvelopeClass();
                    pDeviceEnvelope.PutCoords(deviceRect.left, deviceRect.bottom, deviceRect.right, deviceRect.top);
                    pExporter.PixelBounds = pDeviceEnvelope; // 输出图片的范围
                    ITrackCancel pCancle = new CancelTrackerClass();//可用ESC键取消操作
                    mainPagelayoutControl.ActiveView.Output(pExporter.StartExporting(), pExporter.Resolution, ref deviceRect, mainPagelayoutControl.ActiveView.Extent, pCancle);
                    Application.DoEvents();
                    pExporter.FinishExporting();                   
                }
               
            }
            catch (Exception Err)
            {
                 MessageBox.Show(Err.Message,"输出图片", MessageBoxButtons.OK, MessageBoxIcon.Information);              
            }
        }      
        #endregion
        #region 打印
        private void Print_Click(object sender, EventArgs e)
        {           
            frmPrintPreview = new frmPrintPreview(mainPagelayoutControl);
            frmPrintPreview.ShowDialog();
        }
        #endregion                                                                                                                                      
        #region 不同基准面的坐标转换
        public void ProjectExExample()
        {
            ISpatialReferenceFactory pSpatialReferenceFactory = new SpatialReferenceEnvironmentClass();
            IPoint pFromPoint = new PointClass();
            IZAware pZAware = pFromPoint as IZAware;
            pZAware.ZAware = true;
            //定义两种不同基准下的坐标系
            ((IGeometry)pFromPoint).SpatialReference = CreateCustomProjectedCoordinateSystem();
            IProjectedCoordinateSystem pProjectedCoordinateSystem =
            pSpatialReferenceFactory.CreateProjectedCoordinateSystem((int)esriSRProjCS4Type.esriSRProjCS_Xian1980_GK_Zone_19);
            //因为目标基准面和原始基准面不在同一个上，所以牵扯到参数  
            ICoordinateFrameTransformation pCoordinateFrameTransformation = new
            CoordinateFrameTransformationClass();
            //pCoordinateFrameTransformation.PutParameters("double dx,double dy, double dz,double rx,double ry,
            // double rz, double s");（此句不应注释）坐标转换所需的7个参数  
            pCoordinateFrameTransformation.PutSpatialReferences(CreateCustomProjectedCoordinateSystem(), pProjectedCoordinateSystem as ISpatialReference);
            //投影转换      
            IGeometry2 pGeometry = pFromPoint as IGeometry2;
            pGeometry.ProjectEx(pProjectedCoordinateSystem as
            ISpatialReference, esriTransformDirection.esriTransformForward, pCoordinateFrameTransformation, false, 0, 0);
        }

        private IProjectedCoordinateSystem CreateCustomProjectedCoordinateSystem()
        {
            ISpatialReferenceFactory pSpatialReferenceFactory = new SpatialReferenceEnvironmentClass();
            //高斯克吕格投影
            IProjectionGEN pProjection =
            pSpatialReferenceFactory.CreateProjection((int)esriSRProjectionType.esriSRProjection_GaussKruger) as IProjectionGEN;

            IGeographicCoordinateSystem pGeographicCoordinateSystem
            = pSpatialReferenceFactory.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_WGS1984);
            //定义投影坐标系的来源
            ILinearUnit pUnit =
            pSpatialReferenceFactory.CreateUnit((int)esriSRUnitType.esriSRUnit_Meter) as ILinearUnit;
            //从投影获得默认的参数
            IParameter[] pParameters = pProjection.GetDefaultParameters();
            // 用Define方法创建投影坐标系
            IProjectedCoordinateSystemEdit pProjectedCoordinateSystemEdit = new ProjectedCoordinateSystemClass();
            object pName = "WGS-BeiJing1954";
            object pAlias = "WGS-BeiJing1954";
            object pAbbreviation = "WGS-BeiJing1954";
            object pRemarks = "WGS-BeiJing1954";
            object pUsage = "Calculate Meter From lat and lon";
            object pGeographicCoordinateSystemObject = pGeographicCoordinateSystem as object;
            object pUnitObject = pUnit as object;
            object pProjectionObject = pProjection as object;
            object pParametersObject = pParameters as object;
            pProjectedCoordinateSystemEdit.Define(ref pName, ref pAlias, ref pAbbreviation, ref pRemarks, ref pUsage,
            ref pGeographicCoordinateSystemObject, ref pUnitObject, ref pProjectionObject, ref pParametersObject);
            IProjectedCoordinateSystem5 pProjectedCoordinateSystem = pProjectedCoordinateSystemEdit as IProjectedCoordinateSystem5;
            pProjectedCoordinateSystem.FalseEasting = 500000;//坐标横轴向西移动500KM
            pProjectedCoordinateSystem.FalseNorthing = 0;//坐标纵轴不变
            pProjectedCoordinateSystem.LatitudeOfOrigin = 0;
            pProjectedCoordinateSystem.set_CentralMeridian(true, 111);// 设置中央子午线度数为111度
            pProjectedCoordinateSystem.ScaleFactor = 1;//投影坐标系的比例因子

            return pProjectedCoordinateSystem;
        }
        #endregion
        #region 同一基准面下的坐标转换
        private IPoint GetpProjectPoint(IPoint pPoint, bool pBool)
        {
            ISpatialReferenceFactory pSpatialReferenceEnvironemnt =
            new SpatialReferenceEnvironment();
            ISpatialReference pFromSpatialReference =
            pSpatialReferenceEnvironemnt.CreateGeographicCoordinateSystem((int)esriSRGeoCS3Type.esriSRGeoCS_Xian1980);//1980西安          
            ISpatialReference pToSpatialReference =
            pSpatialReferenceEnvironemnt.CreateProjectedCoordinateSystem((int)esriSRProjCS4Type.esriSRProjCS_Xian1980_3_Degree_GK_Zone_34);//1980西安          
            if (pBool == true)//地理坐标转投影坐标   
            {
                IGeometry pGeo = (IGeometry)pPoint;
                pGeo.SpatialReference = pFromSpatialReference;
                pGeo.Project(pToSpatialReference);
                return pPoint;
            }
            else //投影坐标转地理坐标 
            {
                IGeometry pGeo = (IGeometry)pPoint;
                pGeo.SpatialReference = pToSpatialReference;
                pGeo.Project(pFromSpatialReference);
                return pPoint;
            }
        }
        #endregion                       
    }
}

