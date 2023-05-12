using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using 专题地图.Class;
using 专题地图.Class.EnumType;
using 专题地图.Symbol;

using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Output;
using stdole;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.CatalogUI;
namespace 专题地图
{
    public partial class frmMainUI : Form
    {
        #region  变量定义              
        //地图到处窗体
        private frmUniqueValueRender frmUniqueValueRen = null;
        private frmUniqueValueMany_fields frmUniqueValueMany_fields = null;       
        private frmSimpleRender frmSimRender = null;
        private frmChartRender frmChartRender = null;
        private frmDotDensity frmDotDensity = null;  // 点密度 
        private frmProportional frmProportional = null;//比例符号化
        private frmGraduatedcolors frmGraduatedcolors = null; // 分级色彩
        private frmGraduatedSymbols frmGraduatedSymbols = null;// 分级符号      
        private frmBivariateRenderer frmBivariateRenderer = null; // 双值渲染
        private frmScaleDependentRenderer frmScaleDependentRenderer = null;//多比例尺渲染           
        //对地图的基本操作类
        private OperateMap m_OperateMap = null;             
        private EnumChartRenderType _enumChartType = EnumChartRenderType.UnKnown;                          
        #endregion
        public frmMainUI()
        {
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
            InitializeComponent();
            m_OperateMap = new OperateMap();
        }       
        #region 文件打开、保存、另存为
        private void Openfile_Click(object sender, EventArgs e)
        {
            ICommand Cmd = new ControlsOpenDocCommandClass();
            Cmd.OnCreate(mainMapControl.Object);
            Cmd.OnClick();
        }
        private void Savefile_Click(object sender, EventArgs e)
        {
            m_OperateMap.SaveMap(mainMapControl.DocumentFilename, mainMapControl.Map);
        }
        private void SaveAs_Click(object sender, EventArgs e)
        {
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(mainMapControl.Object);
            command.OnClick();
        }
        #endregion                                                                       
        #region 单一符号化
        private void SingleSymbol_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmSimRender == null || frmSimRender.IsDisposed)
                {
                    frmSimRender = new frmSimpleRender();
                    frmSimRender.SimpleRender += new frmSimpleRender.SimpleRenderEventHandler(frmSimRender_SimpleRender);
                }
                frmSimRender.PMap = mainMapControl.Map;
                frmSimRender.InitUI();
                frmSimRender.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }
        void frmSimRender_SimpleRender(string sFeatClsName, IRgbColor pRgbColr)
        {
            IFeatureLayer pFeatLyr = m_OperateMap.GetFeatLyrByName(mainMapControl.Map, sFeatClsName);
            SimpleRenderer(pFeatLyr, pRgbColr);
        }
        /// <summary>
        /// 单一符号化
        /// </summary>
        /// <param name="pFeatLyr">渲染图层</param>
        /// <param name="pRgbColor">渲染颜色</param>
        private void SimpleRenderer(IFeatureLayer pFeatLyr, IRgbColor pRgbColor)
        {
            try
            {
                esriGeometryType types = pFeatLyr.FeatureClass.ShapeType;
                ISimpleRenderer pSimRender = new SimpleRendererClass();
                if (types == esriGeometryType.esriGeometryPolygon)
                {
                    ISimpleFillSymbol pSimFillSym = new SimpleFillSymbolClass();
                    pSimFillSym.Color = pRgbColor;                   
                    pSimRender.Symbol = pSimFillSym as ISymbol; // 设置渲染的样式 
                }
                else if (types == esriGeometryType.esriGeometryPoint)
                {
                    ISimpleMarkerSymbol pSimpleMarkerSymbol = new SimpleMarkerSymbolClass();
                    pSimpleMarkerSymbol.Color = pRgbColor;
                    pSimRender.Symbol = pSimpleMarkerSymbol as ISymbol;
                }
                else if (types == esriGeometryType.esriGeometryPolyline)
                {
                    ISimpleLineSymbol pSimpleLineSymbol = new SimpleLineSymbolClass();
                    pSimpleLineSymbol.Color = pRgbColor;                 
                    pSimRender.Symbol = pSimpleLineSymbol as ISymbol;
                }
                IGeoFeatureLayer pGeoFeatLyr = pFeatLyr as IGeoFeatureLayer;
                pGeoFeatLyr.Renderer = pSimRender as IFeatureRenderer;
                (mainMapControl.Map as IActiveView).PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                mainTOCControl.Update();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion      
        #region 唯一值单字段 
        private void UniqueValue_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmUniqueValueRen == null || frmUniqueValueRen.IsDisposed)
                {
                    frmUniqueValueRen = new frmUniqueValueRender();
                    frmUniqueValueRen.UniqueValueRender += new frmUniqueValueRender.UniqueValueRenderEventHandler(frmUniqueValueRen_UniqueValueRender);
                }
                frmUniqueValueRen.Map = mainMapControl.Map;
                frmUniqueValueRen.InitUI();
                frmUniqueValueRen.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }
        void frmUniqueValueRen_UniqueValueRender(string sFeatClsName, string sFieldName)
        {
            IFeatureLayer pFeatLyr = m_OperateMap.GetFeatLyrByName(mainMapControl.Map, sFeatClsName);
            UniqueValueRenderer(pFeatLyr, sFieldName);

        }
        /// <summary>
        /// 唯一值符号化
        /// </summary>
        /// <param name="pFeatLyr">渲染图层</param>
        /// <param name="sFieldName">渲染字段</param>
        private void UniqueValueRenderer(IFeatureLayer pFeatLyr, string sFieldName)
        {
            try
            {
                IGeoFeatureLayer pGeoFeatLyr = pFeatLyr as IGeoFeatureLayer;
                ITable pTable = pFeatLyr as ITable;
                IUniqueValueRenderer pUniqueValueRender = new UniqueValueRendererClass();

                int intFieldNumber = pTable.FindField(sFieldName);
                pUniqueValueRender.FieldCount = 1;//设置唯一值符号化的关键字段为一个
                pUniqueValueRender.set_Field(0, sFieldName);//设置唯一值符号化的第一个关键字段

                IRandomColorRamp pRandColorRamp = new RandomColorRampClass();
                pRandColorRamp.StartHue = 0;
                pRandColorRamp.MinValue = 0;
                pRandColorRamp.MinSaturation = 15;
                pRandColorRamp.EndHue = 360;
                pRandColorRamp.MaxValue = 100;
                pRandColorRamp.MaxSaturation = 30;
                //根据渲染字段的值的个数，设置一组随机颜色，如某一字段有5个值，则创建5个随机颜色与之匹配
                IQueryFilter pQueryFilter = new QueryFilterClass();
                pRandColorRamp.Size = pFeatLyr.FeatureClass.FeatureCount(pQueryFilter);
                bool bSuccess = false;
                pRandColorRamp.CreateRamp(out bSuccess);

                IEnumColors pEnumRamp = pRandColorRamp.Colors;
                IColor pNextUniqueColor = null;
                //查询字段的值
                pQueryFilter = new QueryFilterClass();
                pQueryFilter.AddField(sFieldName);
                ICursor pCursor = pTable.Search(pQueryFilter, true);
                IRow pNextRow = pCursor.NextRow();
                object codeValue = null;
                IRowBuffer pNextRowBuffer = null;


                while (pNextRow != null)
                {
                    pNextRowBuffer = pNextRow as IRowBuffer;
                    codeValue = pNextRowBuffer.get_Value(intFieldNumber);//获取渲染字段的每一个值

                    pNextUniqueColor = pEnumRamp.Next();
                    if (pNextUniqueColor == null)
                    {
                        pEnumRamp.Reset();
                        pNextUniqueColor = pEnumRamp.Next();
                    }
                    IFillSymbol pFillSymbol = null;
                    ILineSymbol pLineSymbol;
                    IMarkerSymbol pMarkerSymbol;
                    switch (pGeoFeatLyr.FeatureClass.ShapeType)
                    {
                        case esriGeometryType.esriGeometryPolygon:
                            {
                                pFillSymbol = new SimpleFillSymbolClass();
                                pFillSymbol.Color = pNextUniqueColor;
                                pUniqueValueRender.AddValue(codeValue.ToString(), "", pFillSymbol as ISymbol);//添加渲染字段的值和渲染样式
                                pNextRow = pCursor.NextRow();
                                break;
                            }
                        case esriGeometryType.esriGeometryPolyline:
                            {
                                pLineSymbol = new SimpleLineSymbolClass();
                                pLineSymbol.Color = pNextUniqueColor;
                                pUniqueValueRender.AddValue(codeValue.ToString(), "", pLineSymbol as ISymbol);//添加渲染字段的值和渲染样式
                                pNextRow = pCursor.NextRow();
                                break;
                            }
                        case esriGeometryType.esriGeometryPoint:
                            {
                                pMarkerSymbol = new SimpleMarkerSymbolClass();
                                pMarkerSymbol.Color = pNextUniqueColor;
                                pUniqueValueRender.AddValue(codeValue.ToString(), "", pMarkerSymbol as ISymbol);//添加渲染字段的值和渲染样式
                                pNextRow = pCursor.NextRow();
                                break;
                            }
                    }
                }
                pGeoFeatLyr.Renderer = pUniqueValueRender as IFeatureRenderer;
                mainMapControl.Refresh();
                mainTOCControl.Update();
            }
            catch (Exception ex)
            {

            }

        }
        #endregion
        #region 唯一值多字段
        private void UniqueValuesManyFileds_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmUniqueValueMany_fields == null || frmUniqueValueMany_fields.IsDisposed)
                {
                    frmUniqueValueMany_fields = new frmUniqueValueMany_fields();
                    frmUniqueValueMany_fields.UniqueValueRender += new frmUniqueValueMany_fields.UniqueValueRenderEventHandler(frmUniqueValueMany_fields_UniqueValueRender);
                }

                frmUniqueValueMany_fields.Map = mainMapControl.Map;
                frmUniqueValueMany_fields.InitUI();
                frmUniqueValueMany_fields.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }
        void frmUniqueValueMany_fields_UniqueValueRender(string sFeatClsName, string[] sFieldName)
        {
            IFeatureLayer pFeatLyr = m_OperateMap.GetFeatLyrByName(mainMapControl.Map, sFeatClsName);
            UniqueValueMany_fieldsRenderer(pFeatLyr, sFieldName);
        }
        /// <summary>
        /// 唯一值多字段
        /// </summary>
        /// <param name="pFeatLyr">渲染图层</param>
        /// <param name="sFieldName">渲染字段</param>
        private void UniqueValueMany_fieldsRenderer(IFeatureLayer pFeatLyr, string[] sFieldName)
        {
            IUniqueValueRenderer pUniqueValueRender;
            IColor pNextUniqueColor;
            IEnumColors pEnumRamp;
            ITable pTable;
            IRow pNextRow;
            ICursor pCursor;
            IQueryFilter pQueryFilter;
            IRandomColorRamp pRandColorRamp = new RandomColorRampClass();
            pRandColorRamp.StartHue = 0;
            pRandColorRamp.MinValue = 0;
            pRandColorRamp.MinSaturation = 15;
            pRandColorRamp.EndHue = 360;
            pRandColorRamp.MaxValue = 100;
            pRandColorRamp.MaxSaturation = 30;
            //根据渲染字段值的个数，设置一组随即颜色，如某一字段有5个不同值，则创建5个随机颜色与之匹配
            IQueryFilter pQueryFilter1 = new QueryFilterClass();
            pRandColorRamp.Size = pFeatLyr.FeatureClass.FeatureCount(pQueryFilter1);
            bool bSuccess = false;
            pRandColorRamp.CreateRamp(out bSuccess);
            //所选字段数为两个时
            if (sFieldName.Length == 2)
            {
                string sFieldName1 = sFieldName[0];
                string sFieldName2 = sFieldName[1];
                IGeoFeatureLayer pGeoFeatureL = (IGeoFeatureLayer)pFeatLyr;
                pUniqueValueRender = new UniqueValueRendererClass();
                pTable = (ITable)pGeoFeatureL;
                int pFieldNumber = pTable.FindField(sFieldName1);
                int pFieldNumber2 = pTable.FindField(sFieldName2);
                pUniqueValueRender.FieldCount = 2;//设置渲染字段的个数
                pUniqueValueRender.set_Field(0, sFieldName1);//设置渲染的第一个字段
                pUniqueValueRender.set_Field(1, sFieldName2);//设置渲染的第二个字段
                pEnumRamp = pRandColorRamp.Colors;
                pNextUniqueColor = null;
                //获取渲染字段的每个属性值
                pQueryFilter = new QueryFilterClass();
                pQueryFilter.AddField(sFieldName1);
                pQueryFilter.AddField(sFieldName2);
                pCursor = pTable.Search(pQueryFilter, true);
                pNextRow = pCursor.NextRow();
                string codeValue;//这里的codeValue还可以定义成object类型
                while (pNextRow != null)
                {
                    codeValue = pNextRow.get_Value(pFieldNumber).ToString() + pUniqueValueRender.FieldDelimiter + pNextRow.get_Value(pFieldNumber2).ToString();
                    pNextUniqueColor = pEnumRamp.Next();
                    if (pNextUniqueColor == null)
                    {
                        pEnumRamp.Reset();
                        pNextUniqueColor = pEnumRamp.Next();
                    }
                    IFillSymbol pFillSymbol;
                    ILineSymbol pLineSymbol;
                    IMarkerSymbol pMarkerSymbol;
                    switch (pGeoFeatureL.FeatureClass.ShapeType)
                    {
                        case esriGeometryType.esriGeometryPolygon:
                            {
                                pFillSymbol = new SimpleFillSymbolClass();
                                pFillSymbol.Color = pNextUniqueColor;
                                //设置渲染字段组合值对应的符号
                                pUniqueValueRender.AddValue(codeValue, sFieldName1 + " " + sFieldName2, (ISymbol)pFillSymbol);
                                break;
                            }
                        case esriGeometryType.esriGeometryPolyline:
                            {
                                pLineSymbol = new SimpleLineSymbolClass();
                                pLineSymbol.Color = pNextUniqueColor;
                                //设置渲染字段组合值对应的符号
                                pUniqueValueRender.AddValue(codeValue, sFieldName1 + " " + sFieldName2, (ISymbol)pLineSymbol);
                                break;
                            }
                        case esriGeometryType.esriGeometryPoint:
                            {
                                pMarkerSymbol = new SimpleMarkerSymbolClass();
                                pMarkerSymbol.Color = pNextUniqueColor;
                                //设置渲染字段组合值对应的符号
                                pUniqueValueRender.AddValue(codeValue, sFieldName1 + " " + sFieldName2, (ISymbol)pMarkerSymbol);
                                break;
                            }
                    }
                    pNextRow = pCursor.NextRow();
                }
                pGeoFeatureL.Renderer = (IFeatureRenderer)pUniqueValueRender;
                mainMapControl.Refresh();
                mainTOCControl.Update();
            }
            else if (sFieldName.Length == 3)
            {
                string sFieldName1 = sFieldName[0];
                string sFieldName2 = sFieldName[1];
                string sFieldName3 = sFieldName[2];
                IGeoFeatureLayer pGeoFeatureL = (IGeoFeatureLayer)pFeatLyr;
                pUniqueValueRender = new UniqueValueRendererClass();
                pTable = (ITable)pGeoFeatureL;
                int pFieldNumber = pTable.FindField(sFieldName1);
                int pFieldNumber2 = pTable.FindField(sFieldName2);
                int pFieldNumber3 = pTable.FindField(sFieldName3);
                pUniqueValueRender.FieldCount = 3;
                pUniqueValueRender.set_Field(0, sFieldName1);
                pUniqueValueRender.set_Field(1, sFieldName2);
                pUniqueValueRender.set_Field(2, sFieldName3);
                pEnumRamp = pRandColorRamp.Colors;
                pNextUniqueColor = null;
                pQueryFilter = new QueryFilterClass();
                pQueryFilter.AddField(sFieldName1);
                pQueryFilter.AddField(sFieldName2);
                pQueryFilter.AddField(sFieldName3);
                pCursor = pTable.Search(pQueryFilter, true);
                pNextRow = pCursor.NextRow();
                string codeValue;
                while (pNextRow != null)
                {
                    codeValue = pNextRow.get_Value(pFieldNumber).ToString() + pUniqueValueRender.FieldDelimiter + pNextRow.get_Value(pFieldNumber2).ToString() + pUniqueValueRender.FieldDelimiter + pNextRow.get_Value(pFieldNumber3).ToString();
                    pNextUniqueColor = pEnumRamp.Next();
                    if (pNextUniqueColor == null)
                    {
                        pEnumRamp.Reset();
                        pNextUniqueColor = pEnumRamp.Next();
                    }
                    IFillSymbol pFillSymbol;
                    ILineSymbol pLineSymbol;
                    IMarkerSymbol pMarkerSymbol;
                    switch (pGeoFeatureL.FeatureClass.ShapeType)
                    {
                        case esriGeometryType.esriGeometryPolygon:
                            {
                                pFillSymbol = new SimpleFillSymbolClass();
                                pFillSymbol.Color = pNextUniqueColor;
                                pUniqueValueRender.AddValue(codeValue, sFieldName1 + " " + sFieldName2 + "" + sFieldName3, (ISymbol)pFillSymbol);
                                break;
                            }
                        case esriGeometryType.esriGeometryPolyline:
                            {
                                pLineSymbol = new SimpleLineSymbolClass();
                                pLineSymbol.Color = pNextUniqueColor;
                                pUniqueValueRender.AddValue(codeValue, sFieldName1 + " " + sFieldName2 + "" + sFieldName3, (ISymbol)pLineSymbol);
                                break;
                            }
                        case esriGeometryType.esriGeometryPoint:
                            {
                                pMarkerSymbol = new SimpleMarkerSymbolClass();
                                pMarkerSymbol.Color = pNextUniqueColor;
                                pUniqueValueRender.AddValue(codeValue, sFieldName1 + " " + sFieldName2 + "" + sFieldName3, (ISymbol)pMarkerSymbol);
                                break;
                            }
                    }
                    pNextRow = pCursor.NextRow();
                }
                pGeoFeatureL.Renderer = (IFeatureRenderer)pUniqueValueRender;
                mainMapControl.Refresh();
                mainTOCControl.Update();
            }
        }
        #endregion
        #region 分级色彩
        private void Graduatedcolor_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmGraduatedcolors == null || frmGraduatedcolors.IsDisposed)
                {
                    frmGraduatedcolors = new frmGraduatedcolors();
                    frmGraduatedcolors.Graduatedcolors += new frmGraduatedcolors.GraduatedcolorsEventHandler(frmGraduatedcolors_Graduatedcolors);
                }
                frmGraduatedcolors.Map = mainMapControl.Map;
                frmGraduatedcolors.InitUI();
                frmGraduatedcolors.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }
        void frmGraduatedcolors_Graduatedcolors(string sFeatClsName, string sFieldName, int numclasses)
        {
            IFeatureLayer pFeatLyr = m_OperateMap.GetFeatLyrByName(mainMapControl.Map, sFeatClsName);
            GraduatedColors(pFeatLyr, sFieldName, numclasses);
        }
        /// <summary>
        /// 分级色彩
        /// </summary>
        /// <param name="pFeatLyr">渲染图层</param>
        /// <param name="sFieldName">渲染字段</param>
        /// <param name="numclasses">分级数目</param>
        public void GraduatedColors(IFeatureLayer pFeatLyr, string sFieldName, int numclasses)
        {
            IGeoFeatureLayer pGeoFeatureL = pFeatLyr as IGeoFeatureLayer;
            object dataFrequency;
            object dataValues;
            bool ok;
            int breakIndex;

            ITable pTable = pGeoFeatureL.FeatureClass as ITable;
            ITableHistogram pTableHistogram = new BasicTableHistogramClass();
            IBasicHistogram pBasicHistogram = (IBasicHistogram)pTableHistogram;
            pTableHistogram.Field = sFieldName;
            pTableHistogram.Table = pTable;
            pBasicHistogram.GetHistogram(out dataValues, out dataFrequency);     //获取渲染字段的值及其出现的频率
            IClassifyGEN pClassify = new EqualIntervalClass();
            try
            {
                pClassify.Classify(dataValues, dataFrequency, ref  numclasses);  //根据获取字段的值和出现的频率对其进行等级划分 
            }
            catch (Exception ex)
            {

            }
            //返回一个数组
            double[] Classes = pClassify.ClassBreaks as double[];
            int ClassesCount = Classes.GetUpperBound(0);
            IClassBreaksRenderer pClassBreaksRenderer = new ClassBreaksRendererClass();
            pClassBreaksRenderer.Field = sFieldName; //设置分级字段
            pClassBreaksRenderer.BreakCount = ClassesCount; //设置分级数目
            pClassBreaksRenderer.SortClassesAscending = true;//分级后的图例是否按升级顺序排列
            //设置分级着色所需颜色带的起止颜色
            IHsvColor pFromColor = new HsvColorClass();
            pFromColor.Hue = 0;//黄色
            pFromColor.Saturation = 50;
            pFromColor.Value = 96;
            IHsvColor pToColor = new HsvColorClass();
            pToColor.Hue = 80;
            pToColor.Saturation = 100;
            pToColor.Value = 96;
            //产生颜色带对象
            IAlgorithmicColorRamp pAlgorithmicCR = new AlgorithmicColorRampClass();
            pAlgorithmicCR.Algorithm = esriColorRampAlgorithm.esriHSVAlgorithm;
            pAlgorithmicCR.FromColor = pFromColor;
            pAlgorithmicCR.ToColor = pToColor;
            pAlgorithmicCR.Size = ClassesCount;
            pAlgorithmicCR.CreateRamp(out ok);
            //获得颜色
            IEnumColors pEnumColors = pAlgorithmicCR.Colors;
            //需要注意的是分级着色对象中的symbol和break的下标都是从0开始
            for (breakIndex = 0; breakIndex <= ClassesCount - 1; breakIndex++)
            {
                IColor pColor = pEnumColors.Next();
                switch (pGeoFeatureL.FeatureClass.ShapeType)
                {
                    case esriGeometryType.esriGeometryPolygon:
                        {
                            ISimpleFillSymbol pSimpleFillS = new SimpleFillSymbolClass();
                            pSimpleFillS.Color = pColor;
                            pSimpleFillS.Style = esriSimpleFillStyle.esriSFSSolid;
                            pClassBreaksRenderer.set_Symbol(breakIndex, (ISymbol)pSimpleFillS);//设置填充符号
                            pClassBreaksRenderer.set_Break(breakIndex, Classes[breakIndex + 1]);//设定每一分级的分级断点
                            break;
                        }
                    case esriGeometryType.esriGeometryPolyline:
                        {
                            ISimpleLineSymbol pSimpleLineSymbol = new SimpleLineSymbolClass();
                            pSimpleLineSymbol.Color = pColor;
                            pClassBreaksRenderer.set_Symbol(breakIndex, (ISymbol)pSimpleLineSymbol);
                            pClassBreaksRenderer.set_Break(breakIndex, Classes[breakIndex + 1]);
                            break;
                        }
                    case esriGeometryType.esriGeometryPoint:
                        {
                            ISimpleMarkerSymbol pSimpleMarkerSymbol = new SimpleMarkerSymbolClass();
                            pSimpleMarkerSymbol.Color = pColor;
                            pClassBreaksRenderer.set_Symbol(breakIndex, (ISymbol)pSimpleMarkerSymbol);//设置填充符号
                            pClassBreaksRenderer.set_Break(breakIndex, Classes[breakIndex + 1]);//设定每一分级的分级断点
                            break;
                        }
                }
            }
            pGeoFeatureL.Renderer = (IFeatureRenderer)pClassBreaksRenderer;
            mainMapControl.Refresh();
            mainTOCControl.Update();
        }
        #endregion
        #region 分级符号
        private void Graduatedsymbol_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmGraduatedSymbols == null || frmGraduatedSymbols.IsDisposed)
                {
                    frmGraduatedSymbols = new frmGraduatedSymbols();
                    frmGraduatedSymbols.GraduatedSymbols += new frmGraduatedSymbols.GraduatedSymbolsEventHandler(frmGraduatedSymbols_GraduatedSymbols);
                }
                frmGraduatedSymbols.Map = mainMapControl.Map;
                frmGraduatedSymbols.InitUI();
                frmGraduatedSymbols.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }
        // 分级符号 
        void frmGraduatedSymbols_GraduatedSymbols(string sFeatClsName, string sFieldName, int numclasses)
        {
            IFeatureLayer pFeatLyr = m_OperateMap.GetFeatLyrByName(mainMapControl.Map, sFeatClsName);
            GraduatedSymbols(pFeatLyr, sFieldName, numclasses);
        }
        /// <summary>
        /// 分级符号
        /// </summary>
        /// <param name="pFeatLyr">渲染图层</param>
        /// <param name="sFieldName">渲染字段</param>
        /// <param name="numclasses">分级数目</param>
        public void GraduatedSymbols(IFeatureLayer pFeatLyr, string sFieldName, int numclasses)
        {
            ISimpleMarkerSymbol pSimpleMarkerSymbol = new SimpleMarkerSymbolClass();
            pSimpleMarkerSymbol.Color = m_OperateMap.GetRgbColor(255, 100, 100);
            ISimpleLineSymbol pSimpleLineSymbol = new SimpleLineSymbolClass();
            pSimpleLineSymbol.Color = m_OperateMap.GetRgbColor(255, 100, 100);
            int IbreakIndex;
            object dataFrequency;
            object dataValues;

            //获得要着色的图层
            IGeoFeatureLayer pGeoFeatureL = pFeatLyr as IGeoFeatureLayer;
            ITable pTable = pGeoFeatureL.FeatureClass as ITable;
            ITableHistogram pTableHistogram = new BasicTableHistogramClass();
            IBasicHistogram pBasicHistogram = (IBasicHistogram)pTableHistogram;
            pTableHistogram.Field = sFieldName;
            pTableHistogram.Table = pTable;
            pBasicHistogram.GetHistogram(out dataValues, out dataFrequency);//获取渲染字段的值及其出现的频率                    
            IClassifyGEN pClassify = new EqualIntervalClass();
            try
            {
                pClassify.Classify(dataValues, dataFrequency, ref numclasses);//根据获取字段的值和出现的频率对其进行等级划分 
            }
            catch (Exception ex)
            {
            }
            //返回一个数组
            double[] Classes = (double[])pClassify.ClassBreaks;
            int ClassesCount = Classes.GetUpperBound(0);
            IClassBreaksRenderer pClassBreakRenderer = new ClassBreaksRendererClass();
            pClassBreakRenderer.Field = sFieldName;// 设置分级字段
            //设置着色对象的分级数目
            pClassBreakRenderer.BreakCount = ClassesCount;//设置分级数目
            pClassBreakRenderer.SortClassesAscending = true;//升序排列
            //需要注意的是分级着色对象中的symbol和break的下标都是从0开始
            double symbolSizeOrigin = 5.0;
            if (ClassesCount <= 5)
            {
                symbolSizeOrigin = 8;
            }
            if (ClassesCount < 10 && ClassesCount > 5)
            {
                symbolSizeOrigin = 7;
            }
            IFillSymbol pBackgroundSymbol = new SimpleFillSymbolClass();
            pBackgroundSymbol.Color = m_OperateMap.GetRgbColor(255, 255, 100);
            //不同的要素类型，生成不同的分级符号
            switch (pGeoFeatureL.FeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPolygon:
                    {
                        for (IbreakIndex = 0; IbreakIndex <= ClassesCount - 1; IbreakIndex++)
                        {                           
                            pClassBreakRenderer.set_Break(IbreakIndex, Classes[IbreakIndex + 1]);                           
                            pClassBreakRenderer.BackgroundSymbol = pBackgroundSymbol;
                            pSimpleMarkerSymbol.Size = symbolSizeOrigin + IbreakIndex * symbolSizeOrigin / 3.0d;
                            pClassBreakRenderer.set_Symbol(IbreakIndex, (ISymbol)pSimpleMarkerSymbol);
                        }
                        break;
                    }
                case esriGeometryType.esriGeometryPolyline:
                    {
                        for (IbreakIndex = 0; IbreakIndex <= ClassesCount - 1; IbreakIndex++)
                        {
                            pClassBreakRenderer.set_Break(IbreakIndex, Classes[IbreakIndex + 1]);                                                      
                            pSimpleLineSymbol.Width = symbolSizeOrigin/5 + IbreakIndex * (symbolSizeOrigin/5) / 5.0d;
                            pClassBreakRenderer.set_Symbol(IbreakIndex, (ISymbol)pSimpleLineSymbol);
                        }
                        break;
                    }
                case esriGeometryType.esriGeometryPoint:
                    {
                        for (IbreakIndex = 0; IbreakIndex <= ClassesCount - 1; IbreakIndex++)
                        {
                            pClassBreakRenderer.set_Break(IbreakIndex, Classes[IbreakIndex + 1]);                                                    
                            pSimpleMarkerSymbol.Size = symbolSizeOrigin + IbreakIndex * symbolSizeOrigin / 3.0d;
                            pClassBreakRenderer.set_Symbol(IbreakIndex, (ISymbol)pSimpleMarkerSymbol);
                        }
                        break;
                    }
            }           
            pGeoFeatureL.Renderer = pClassBreakRenderer as IFeatureRenderer;
            mainMapControl.ActiveView.Refresh();
            mainTOCControl.Update();
        }
        #endregion
        #region 比例符号化
        private void Proportionalsymbol_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmProportional == null || frmProportional.IsDisposed)
                {
                    frmProportional = new frmProportional();
                    frmProportional.Proportional += new frmProportional.ProportionalEventHandler(frmProportional_Proportional);
                }
                frmProportional.Map = mainMapControl.Map;
                frmProportional.InitUI();
                frmProportional.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }
        // 比例符号 
        void frmProportional_Proportional(string sFeatClsName, string sFieldName)
        {
            IFeatureLayer pFeatLyr = m_OperateMap.GetFeatLyrByName(mainMapControl.Map, sFeatClsName);
            Proportional(pFeatLyr, sFieldName);
        }
        /// <summary>
        /// 比例符号化
        /// </summary>
        /// <param name="sender">渲染图层</param>
        /// <param name="e">渲染字段</param>        
        private void Proportional(IFeatureLayer pFeatLyr, string sFieldName)
        {
            try
            {
                IGeoFeatureLayer pGeoFeatureLayer = pFeatLyr as IGeoFeatureLayer;
                ITable pTable = pFeatLyr as ITable;
                ICursor pCursor = pTable.Search(null, true);
                //利用IDataStatistics和IStatisticsResults获取渲染字段的统计值，最主要是或得最大值和最小值
                IDataStatistics pDataStatistics = new DataStatisticsClass();
                pDataStatistics.Cursor = pCursor;
                pDataStatistics.Field = sFieldName;
                IStatisticsResults pStatisticsResult = pDataStatistics.Statistics;
                if (pStatisticsResult != null)
                {
                    //设置渲染背景色
                    IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
                    pFillSymbol.Color = m_OperateMap.GetRgbColor(155, 255, 0);
                    //设置比例符号的样式                 
                    ISimpleMarkerSymbol pSimpleMarkerSymbol = new SimpleMarkerSymbolClass();
                    pSimpleMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSDiamond;
                    pSimpleMarkerSymbol.Size = 3;
                    pSimpleMarkerSymbol.Color = m_OperateMap.GetRgbColor(255, 90, 0);
                    IProportionalSymbolRenderer pProportionalSymbolRenderer = new ProportionalSymbolRendererClass();
                    pProportionalSymbolRenderer.ValueUnit = esriUnits.esriUnknownUnits;//设置渲染单位
                    pProportionalSymbolRenderer.Field = sFieldName; //设置渲染字段   
                    pProportionalSymbolRenderer.FlanneryCompensation = false;//是否使用Flannery补偿
                    pProportionalSymbolRenderer.MinDataValue = pStatisticsResult.Minimum;//获取渲染字段的最大值
                    pProportionalSymbolRenderer.MaxDataValue = pStatisticsResult.Maximum;//获取渲染字段的最小值
                    pProportionalSymbolRenderer.BackgroundSymbol = pFillSymbol;
                    pProportionalSymbolRenderer.MinSymbol = pSimpleMarkerSymbol as ISymbol;//向设置渲染字段最小值的渲染符号，其余值的符号根据此符号产生
                    pProportionalSymbolRenderer.LegendSymbolCount = 5;// 设置TOC控件中显示的数目
                    pProportionalSymbolRenderer.CreateLegendSymbols();//生成图例
                    pGeoFeatureLayer.Renderer = pProportionalSymbolRenderer as IFeatureRenderer;
                }
                mainMapControl.Refresh();
                mainTOCControl.Update();
            }
            catch (Exception ex)
            {
            }
        }
        #endregion 
        #region 点密度
        private void Dotdensitys_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmDotDensity == null || frmDotDensity.IsDisposed)
                {
                    frmDotDensity = new frmDotDensity();
                    frmDotDensity.DotDensity += new frmDotDensity.DotDensityEventHandler(frmDotDensity_DotDensity);
                }
                frmDotDensity.Map = mainMapControl.Map;
                frmDotDensity.InitUI();
                frmDotDensity.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }
        // 点密度
        void frmDotDensity_DotDensity(string sFeatClsName, string sFieldName, int intRendererDensity)
        {
            IFeatureLayer pFeatLyr = m_OperateMap.GetFeatLyrByName(mainMapControl.Map, sFeatClsName);
            DotDensity(pFeatLyr, sFieldName, intRendererDensity);
        }
        /// <summary>
        /// 点密度图
        /// </summary>
        /// <param name="pFeatLyr">渲染图层</param>
        /// <param name="sFieldName">渲染字段</param>
        /// <param name="intRendererDensity">每个点多代表的值</param>           
        private void DotDensity(IFeatureLayer pFeatLyr, string sFieldName, int intRendererDensity)
        {
            try
            {
                IGeoFeatureLayer pGeoFeatureLayer = pFeatLyr as IGeoFeatureLayer;
                IDotDensityRenderer pDotDensityRenderer = new DotDensityRendererClass();
                IRendererFields pRendererFields = pDotDensityRenderer as IRendererFields;
                //设置渲染字段               
                pRendererFields.AddField(sFieldName);
                //设置填充背景色
                IDotDensityFillSymbol pDotDensityFillSymbol = new DotDensityFillSymbolClass();
                pDotDensityFillSymbol.DotSize = 3;
                pDotDensityFillSymbol.BackgroundColor = m_OperateMap.GetRgbColor(0, 255, 0);
                //设置渲染符号
                ISymbolArray pSymbolArray = pDotDensityFillSymbol as ISymbolArray;
                ISimpleMarkerSymbol pSimpleMarkerSymbol = new SimpleMarkerSymbolClass();
                pSimpleMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
                pSimpleMarkerSymbol.Color = m_OperateMap.GetRgbColor(0, 0, 255);
                pSymbolArray.AddSymbol(pSimpleMarkerSymbol as ISymbol);
                pDotDensityRenderer.DotDensitySymbol = pDotDensityFillSymbol;
                //设置渲染密度，即每个点符号所代表的数值大小
                pDotDensityRenderer.DotValue = intRendererDensity;
                //创建图例
                pDotDensityRenderer.CreateLegend();
                pGeoFeatureLayer.Renderer = pDotDensityRenderer as IFeatureRenderer;
                mainMapControl.Refresh();
                mainTOCControl.Update();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region 统计图表符号化
        private void Pie_Click(object sender, EventArgs e)
        {
            try
            {
                _enumChartType = EnumChartRenderType.PieChart;
                if (frmChartRender == null || frmChartRender.IsDisposed)
                {
                    frmChartRender = new frmChartRender();
                    frmChartRender.ChartRender += new frmChartRender.ChartRenderEventHandler(frmChartRender_ChartRender);
                }
                frmChartRender.Map = mainMapControl.Map;
                frmChartRender.InitUI();
                frmChartRender.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }
        private void Bar_Click(object sender, EventArgs e)
        {
            try
            {
                _enumChartType = EnumChartRenderType.BarChart;
                if (frmChartRender == null || frmChartRender.IsDisposed)
                {
                    frmChartRender = new frmChartRender();
                    frmChartRender.ChartRender += new frmChartRender.ChartRenderEventHandler(frmChartRender_ChartRender);
                }
                frmChartRender.Map = mainMapControl.Map;
                frmChartRender.InitUI();
                frmChartRender.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }
        private void Stacked_Click(object sender, EventArgs e)
        {
            try
            {
                _enumChartType = EnumChartRenderType.StackChart;
                if (frmChartRender == null || frmChartRender.IsDisposed)
                {
                    frmChartRender = new frmChartRender();
                    frmChartRender.ChartRender += new frmChartRender.ChartRenderEventHandler(frmChartRender_ChartRender);
                }
                frmChartRender.Map = mainMapControl.Map;
                frmChartRender.InitUI();
                frmChartRender.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }
        // 统计图表             
        void frmChartRender_ChartRender(string sFeatClsName, Dictionary<string, IRgbColor> _dicFieldAndColor)
        {
            IFeatureLayer pFeatLyr = m_OperateMap.GetFeatLyrByName(mainMapControl.Map, sFeatClsName);
            ChartRenderer(pFeatLyr, _dicFieldAndColor);
        }
        /// <summary>
        /// 图表
        /// </summary>
        /// <param name="pFeatLyr">渲染图层</param>
        /// <param name="_dicFieldAndColor">储存渲染字段和其对应的颜色</param> 
        private void ChartRenderer(IFeatureLayer pFeatLyr, Dictionary<string, IRgbColor> dicFieldAndColor)
        {
            IGeoFeatureLayer pGeoFeatLyr = pFeatLyr as IGeoFeatureLayer;
            IChartRenderer pChartRender = new ChartRendererClass();
            IRendererFields pRenderFields = pChartRender as IRendererFields;
            IFeatureCursor pCursor = null;
            IDataStatistics pDataSta = null;
            double dMax = 0; double dTemp = 0;
            IQueryFilter pQueryFilter = new QueryFilterClass();
            pCursor = pGeoFeatLyr.Search(pQueryFilter, true);
            //遍历出所选择的第一个字段的最大值，，作为设置专题图的比例大小的依据
            foreach (KeyValuePair<string, IRgbColor> _keyValue in dicFieldAndColor)
            {
                pRenderFields.AddField(_keyValue.Key, _keyValue.Key);
                pDataSta = new DataStatisticsClass();
                pDataSta.Cursor = pCursor as ICursor;
                pDataSta.Field = _keyValue.Key;
                dTemp = pDataSta.Statistics.Maximum;
                if (dTemp >= dMax)
                {
                    dMax = dTemp;
                }
            }

            IRgbColor pRgbColor = null;
            IChartSymbol pChartSym = null;
            IFillSymbol pFillSymbol = null;
            IMarkerSymbol pMarkerSym = null;
            IBarChartSymbol pBarChartSym = null;
            IPieChartSymbol pPieChartSymbol = null;
            IStackedChartSymbol pStackChartSym = null;

            // 定义并设置渲染样式
            switch (_enumChartType)
            {
                case EnumChartRenderType.PieChart:
                    pPieChartSymbol = new PieChartSymbolClass();
                    pPieChartSymbol.Clockwise = true;//说明饼图是否顺时针方向
                    pPieChartSymbol.UseOutline = true;//说明是否使用轮廓线
                    ILineSymbol pLineSym = new SimpleLineSymbolClass();
                    pLineSym.Color = m_OperateMap.GetRgbColor(100, 205, 30) as IColor;
                    pLineSym.Width = 1;
                    pPieChartSymbol.Outline = pLineSym;
                    break;
                case EnumChartRenderType.BarChart:
                    pBarChartSym = new BarChartSymbolClass();
                    pBarChartSym.Width = 6;//设置每个条形图的宽度
                    break;
                case EnumChartRenderType.StackChart:
                    pStackChartSym = new StackedChartSymbolClass();
                    pStackChartSym.Width = 6;//设置每个堆叠图的宽度
                    break;
            }
            if (pPieChartSymbol != null)
            {
                pChartSym = pPieChartSymbol as IChartSymbol;
                pMarkerSym = pPieChartSymbol as IMarkerSymbol;
                pMarkerSym.Size = 30; //设置饼状图的大小
            }
            if (pBarChartSym != null)
            {
                pChartSym = pBarChartSym as IChartSymbol;
                pMarkerSym = pBarChartSym as IMarkerSymbol;
                pMarkerSym.Size = 30;//设置条形图的高度
            }
            else if (pStackChartSym != null)
            {
                pChartSym = pStackChartSym as IChartSymbol;
                pMarkerSym = pStackChartSym as IMarkerSymbol;
                pMarkerSym.Size = 30;//设置堆叠图的高度
            }
            pChartSym.MaxValue = dMax;
            ISymbolArray pSymArray = null;
            if (pBarChartSym != null)
            {
                pSymArray = pBarChartSym as ISymbolArray;
            }
            else if (pStackChartSym != null)
            {
                pSymArray = pStackChartSym as ISymbolArray;
            }
            else if (pPieChartSymbol != null)
            {
                pSymArray = pPieChartSymbol as ISymbolArray;
            }

            foreach (KeyValuePair<string, IRgbColor> _keyValue in dicFieldAndColor)
            {
                //获取渲染字段的颜色值
                pRgbColor = _keyValue.Value;
                pFillSymbol = new SimpleFillSymbolClass();
                pFillSymbol.Color = pRgbColor as IColor;
                pSymArray.AddSymbol(pFillSymbol as ISymbol);
            }
            if (pPieChartSymbol != null)
            {
                pChartRender.ChartSymbol = pPieChartSymbol as IChartSymbol;
            }
            if (pBarChartSym != null)
            {
                pChartRender.ChartSymbol = pBarChartSym as IChartSymbol;
            }
            else if (pStackChartSym != null)
            {
                pChartRender.ChartSymbol = pStackChartSym as IChartSymbol;
            }

            pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = m_OperateMap.GetRgbColor(239, 228, 190);
            pChartRender.BaseSymbol = pFillSymbol as ISymbol;// 设置背景符号
            //让符号处于图形中央（若渲染的图层为点图层，则该句应去掉，否则不显示渲染结果）
            //pChartRender.UseOverposter = false; 
            pChartRender.CreateLegend();
            pGeoFeatLyr.Renderer = pChartRender as IFeatureRenderer;
            mainMapControl.Refresh();           
            mainTOCControl.Update();
            _enumChartType = EnumChartRenderType.UnKnown;
        }
        #endregion       
        #region 双值渲染
        private void Bivariate_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmScaleDependentRenderer == null || frmScaleDependentRenderer.IsDisposed)
                {
                    frmBivariateRenderer = new frmBivariateRenderer();
                    frmBivariateRenderer.BivariateRenderer += new frmBivariateRenderer.BivariateRendererEventHandler(frmBivariateRenderer_BivariateRenderer);
                }
                frmBivariateRenderer.Map = mainMapControl.Map;
                frmBivariateRenderer.InitUI();
                frmBivariateRenderer.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }
        void frmBivariateRenderer_BivariateRenderer(string sFeatClsName, string sFieldName, int numclasses)
        {
            IFeatureLayer pFeatLyr = m_OperateMap.GetFeatLyrByName(mainMapControl.Map, sFeatClsName);
            BivariateRenderer(pFeatLyr, sFieldName, numclasses);
        }
        private void BivariateRenderer(IFeatureLayer pFeatLyr, string sFieldName, int numclasses)
        {
            IGeoFeatureLayer pGeoFeatLyr = pFeatLyr as IGeoFeatureLayer;
            ITable pTable = pFeatLyr as ITable;
            IUniqueValueRenderer pUniqueValueRender = new UniqueValueRendererClass();
            int intFieldNumber = pTable.FindField(sFieldName);
            pUniqueValueRender.FieldCount = 1;          //设置唯一值符号化的关键字段为一个
            pUniqueValueRender.set_Field(0, sFieldName);//设置唯一值符号化的第一个关键字段

            IRandomColorRamp pRandColorRamp = new RandomColorRampClass();
            pRandColorRamp.StartHue = 0;
            pRandColorRamp.MinValue = 0;
            pRandColorRamp.MinSaturation = 15;
            pRandColorRamp.EndHue = 360;
            pRandColorRamp.MaxValue = 100;
            pRandColorRamp.MaxSaturation = 30;
            //根据渲染字段的值的个数，设置一组随机颜色，如某一字段有5个值，则创建5个随机颜色与之匹配
            IQueryFilter pQueryFilter = new QueryFilterClass();
            pRandColorRamp.Size = pFeatLyr.FeatureClass.FeatureCount(pQueryFilter);
            bool bSuccess = false;
            pRandColorRamp.CreateRamp(out bSuccess);
            IEnumColors pEnumRamp = pRandColorRamp.Colors;
            IColor pNextUniqueColor = null;
            pQueryFilter = new QueryFilterClass();
            pQueryFilter.AddField(sFieldName);
            ICursor pCursor = pTable.Search(pQueryFilter, true);
            IRow pNextRow = pCursor.NextRow();
            object codeValue = null;
            IRowBuffer pNextRowBuffer = null;


            while (pNextRow != null)
            {
                pNextRowBuffer = pNextRow as IRowBuffer;
                codeValue = pNextRowBuffer.get_Value(intFieldNumber);//获取渲染字段的每一个值

                pNextUniqueColor = pEnumRamp.Next();
                if (pNextUniqueColor == null)
                {
                    pEnumRamp.Reset();
                    pNextUniqueColor = pEnumRamp.Next();
                }
                IFillSymbol pFillSymbol = null;
                ILineSymbol pLineSymbol;
                IMarkerSymbol pMarkerSymbol;
                switch (pGeoFeatLyr.FeatureClass.ShapeType)
                {
                    case esriGeometryType.esriGeometryPolygon:
                        {
                            pFillSymbol = new SimpleFillSymbolClass();
                            pFillSymbol.Color = pNextUniqueColor;
                            pUniqueValueRender.AddValue(codeValue.ToString(), "", pFillSymbol as ISymbol);//添加渲染字段的值和渲染样式
                            pNextRow = pCursor.NextRow();
                            break;
                        }
                    case esriGeometryType.esriGeometryPolyline:
                        {
                            pLineSymbol = new SimpleLineSymbolClass();
                            pLineSymbol.Color = pNextUniqueColor;
                            pUniqueValueRender.AddValue(codeValue.ToString(), "", pLineSymbol as ISymbol);//添加渲染字段的值和渲染样式
                            pNextRow = pCursor.NextRow();
                            break;
                        }
                    case esriGeometryType.esriGeometryPoint:
                        {
                            pMarkerSymbol = new SimpleMarkerSymbolClass();
                            pMarkerSymbol.Color = pNextUniqueColor;
                            pUniqueValueRender.AddValue(codeValue.ToString(), "", pMarkerSymbol as ISymbol);//添加渲染字段的值和渲染样式
                            pNextRow = pCursor.NextRow();
                            break;
                        }
                }

                // 分级渲染  
                ISimpleMarkerSymbol pSimpleMarkerSymbol = new SimpleMarkerSymbolClass();
                int IbreakIndex;
                object dataFrequency;
                object dataValues;
                //获得要着色的图层             
                ITable pTable2 = pGeoFeatLyr.FeatureClass as ITable;
                ITableHistogram pTableHistogram = new BasicTableHistogramClass();
                IBasicHistogram pBasicHistogram = (IBasicHistogram)pTableHistogram;
                pTableHistogram.Field = sFieldName;
                pTableHistogram.Table = pTable2;
                pBasicHistogram.GetHistogram(out dataValues, out dataFrequency);//获取渲染字段的值及其出现的频率
                //分级方法，用于根据获得的值计算得出符合要求的数据           
                IClassifyGEN pClassify = new EqualIntervalClass();
                try
                {
                    pClassify.Classify(dataValues, dataFrequency, ref numclasses);//根据获取字段的值和出现的频率对其进行等级划分 
                }
                catch (Exception ex)
                {
                }
                //返回一个数组
                double[] Classes = (double[])pClassify.ClassBreaks;
                int ClassesCount = Classes.GetUpperBound(0);

                ILegendInfo pLegendInfo = new ClassBreaksRendererClass();
                pLegendInfo.SymbolsAreGraduated = true;

                IClassBreaksRenderer pClassBreakRenderer = pLegendInfo as IClassBreaksRenderer;
                pClassBreakRenderer.Field = sFieldName;// 设置分级字段

                //设置着色对象的分级数目
                pClassBreakRenderer.BreakCount = ClassesCount;//设置分级数目   自己改的
                pClassBreakRenderer.SortClassesAscending = true;//升序排列
                //需要注意的是分级着色对象中的symbol和break的下标都是从0开始
                double symbolSizeOrigin = 5.0;
                if (ClassesCount <= 5)
                {
                    symbolSizeOrigin = 12;
                }
                if (ClassesCount < 10 && ClassesCount > 5)
                {
                    symbolSizeOrigin = 7;
                }
                IFillSymbol pBackgroundSymbol = new SimpleFillSymbolClass();
                for (IbreakIndex = 0; IbreakIndex <= ClassesCount - 1; IbreakIndex++)
                {
                    pClassBreakRenderer.set_Break(IbreakIndex, Classes[IbreakIndex + 1]);
                    pSimpleMarkerSymbol = new SimpleMarkerSymbolClass();
                    pSimpleMarkerSymbol.Color = m_OperateMap.GetRgbColor(255, 100, 100);
                    //当渲染面图层时，需要设置BackgroundSymbol
                    switch (pFeatLyr.FeatureClass.ShapeType)
                    {
                        case esriGeometryType.esriGeometryPolygon:
                            {
                                pClassBreakRenderer.BackgroundSymbol = pBackgroundSymbol;
                                break;
                            }
                    }

                    pSimpleMarkerSymbol.Size = symbolSizeOrigin + IbreakIndex * symbolSizeOrigin / 3.0d;
                    pClassBreakRenderer.set_Symbol(IbreakIndex, (ISymbol)pSimpleMarkerSymbol);
                }

                IBivariateRenderer bivariateRenderer = new BiUniqueValueRendererClass();
                bivariateRenderer.MainRenderer = (IFeatureRenderer)pUniqueValueRender;//设置主渲染
                bivariateRenderer.VariationRenderer = (IFeatureRenderer)pClassBreakRenderer;//设置二元渲染
                bivariateRenderer.CreateLegend();
                pGeoFeatLyr.Renderer = (IFeatureRenderer)bivariateRenderer;
                mainMapControl.ActiveView.Refresh();
                mainTOCControl.Update();
            }
        }
        #endregion
        #region 多比例尺渲染
        private void ScaleDependent_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmScaleDependentRenderer == null || frmScaleDependentRenderer.IsDisposed)
                {
                    frmScaleDependentRenderer = new frmScaleDependentRenderer();
                    frmScaleDependentRenderer.ScaleDependentRenderer += new frmScaleDependentRenderer.ScaleDependentRendererEventHandler(frmScaleDependentRenderer_ScaleDependentRenderer);
                }
                frmScaleDependentRenderer.Map = mainMapControl.Map;
                frmScaleDependentRenderer.InitUI();
                frmScaleDependentRenderer.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }
        void frmScaleDependentRenderer_ScaleDependentRenderer(string sFeatClsName, string sFieldName, int numclasses)
        {
            IFeatureLayer pFeatLyr = m_OperateMap.GetFeatLyrByName(mainMapControl.Map, sFeatClsName);
            ScaleDependentRenderer(pFeatLyr, sFieldName, numclasses);
        }
        private void ScaleDependentRenderer(IFeatureLayer pFeatLyr, string sFieldName, int numclasses)
        {
            IGeoFeatureLayer pGeoFeatLyr = pFeatLyr as IGeoFeatureLayer;
            ITable pTable = pFeatLyr as ITable;
            //唯一值渲染
            IUniqueValueRenderer pUniqueValueRender = new UniqueValueRendererClass();
            int intFieldNumber = pTable.FindField(sFieldName);
            pUniqueValueRender.FieldCount = 1;          //设置唯一值符号化的关键字段为一个
            pUniqueValueRender.set_Field(0, sFieldName);//设置唯一值符号化的第一个关键字段

            IRandomColorRamp pRandColorRamp = new RandomColorRampClass();
            pRandColorRamp.StartHue = 0;
            pRandColorRamp.MinValue = 0;
            pRandColorRamp.MinSaturation = 15;
            pRandColorRamp.EndHue = 360;
            pRandColorRamp.MaxValue = 100;
            pRandColorRamp.MaxSaturation = 30;
            //根据渲染字段的值的个数，设置一组随机颜色，如某一字段有5个值，则创建5个随机颜色与之匹配
            IQueryFilter pQueryFilter = new QueryFilterClass();
            pRandColorRamp.Size = pFeatLyr.FeatureClass.FeatureCount(pQueryFilter);
            bool bSuccess = false;
            pRandColorRamp.CreateRamp(out bSuccess);

            IEnumColors pEnumRamp = pRandColorRamp.Colors;
            IColor pNextUniqueColor = null;

            pQueryFilter = new QueryFilterClass();
            pQueryFilter.AddField(sFieldName);
            ICursor pCursor = pTable.Search(pQueryFilter, true);
            IRow pNextRow = pCursor.NextRow();
            object codeValue = null;
            IRowBuffer pNextRowBuffer = null;


            while (pNextRow != null)
            {
                pNextRowBuffer = pNextRow as IRowBuffer;
                codeValue = pNextRowBuffer.get_Value(intFieldNumber);//获取渲染字段的每一个值

                pNextUniqueColor = pEnumRamp.Next();
                if (pNextUniqueColor == null)
                {
                    pEnumRamp.Reset();
                    pNextUniqueColor = pEnumRamp.Next();
                }
                IFillSymbol pFillSymbol = null;
                ILineSymbol pLineSymbol;
                IMarkerSymbol pMarkerSymbol;
                switch (pGeoFeatLyr.FeatureClass.ShapeType)
                {
                    case esriGeometryType.esriGeometryPolygon:
                        {
                            pFillSymbol = new SimpleFillSymbolClass();
                            pFillSymbol.Color = pNextUniqueColor;
                            pUniqueValueRender.AddValue(codeValue.ToString(), "", pFillSymbol as ISymbol);//添加渲染字段的值和渲染样式
                            pNextRow = pCursor.NextRow();
                            break;
                        }
                    case esriGeometryType.esriGeometryPolyline:
                        {
                            pLineSymbol = new SimpleLineSymbolClass();
                            pLineSymbol.Color = pNextUniqueColor;
                            pUniqueValueRender.AddValue(codeValue.ToString(), "", pLineSymbol as ISymbol);//添加渲染字段的值和渲染样式
                            pNextRow = pCursor.NextRow();
                            break;
                        }
                    case esriGeometryType.esriGeometryPoint:
                        {
                            pMarkerSymbol = new SimpleMarkerSymbolClass();
                            pMarkerSymbol.Color = pNextUniqueColor;
                            pUniqueValueRender.AddValue(codeValue.ToString(), "", pMarkerSymbol as ISymbol);//添加渲染字段的值和渲染样式
                            pNextRow = pCursor.NextRow();
                            break;
                        }
                }

                // 分级渲染
                ISimpleMarkerSymbol pSimpleMarkerSymbol = new SimpleMarkerSymbolClass();
                int IbreakIndex;
                object dataFrequency;
                object dataValues;
                //获得要着色的图层             
                ITable pTable2 = pGeoFeatLyr.FeatureClass as ITable;
                ITableHistogram pTableHistogram = new BasicTableHistogramClass();
                IBasicHistogram pBasicHistogram = (IBasicHistogram)pTableHistogram;
                pTableHistogram.Field = sFieldName;
                pTableHistogram.Table = pTable2;
                pBasicHistogram.GetHistogram(out dataValues, out dataFrequency);//获取渲染字段的值及其出现的频率
                //分级方法，用于根据获得的值计算得出符合要求的数据           
                IClassifyGEN pClassify = new EqualIntervalClass();
                try
                {
                    pClassify.Classify(dataValues, dataFrequency, ref numclasses);//根据获取字段的值和出现的频率对其进行等级划分 
                }
                catch (Exception ex)
                {
                }
                //返回一个数组
                double[] Classes = (double[])pClassify.ClassBreaks;
                int ClassesCount = Classes.GetUpperBound(0);
                ILegendInfo pLegendInfo = new ClassBreaksRendererClass();
                pLegendInfo.SymbolsAreGraduated = true;
                IClassBreaksRenderer pClassBreakRenderer = pLegendInfo as IClassBreaksRenderer;
                pClassBreakRenderer.Field = sFieldName;// 设置分级字段
                //设置着色对象的分级数目
                pClassBreakRenderer.BreakCount = ClassesCount;//设置分级数目   自己改的
                pClassBreakRenderer.SortClassesAscending = true;//升序排列
                //需要注意的是分级着色对象中的symbol和break的下标都是从0开始
                double symbolSizeOrigin = 5.0;
                if (ClassesCount <= 5)
                {
                    symbolSizeOrigin = 12;
                }
                if (ClassesCount < 10 && ClassesCount > 5)
                {
                    symbolSizeOrigin = 7;
                }
                IFillSymbol pBackgroundSymbol = new SimpleFillSymbolClass(); //另外添加（这个在分级符号中也得添加）
                pBackgroundSymbol.Color = m_OperateMap.GetRgbColor(255, 255, 100);
                for (IbreakIndex = 0; IbreakIndex <= ClassesCount - 1; IbreakIndex++)
                {
                    pClassBreakRenderer.set_Break(IbreakIndex, Classes[IbreakIndex + 1]);
                    pSimpleMarkerSymbol = new SimpleMarkerSymbolClass();
                    pSimpleMarkerSymbol.Color = m_OperateMap.GetRgbColor(255, 100, 100);
                    pClassBreakRenderer.BackgroundSymbol = pBackgroundSymbol;// 另外添加（这个在分级符号中也得添加）
                    pSimpleMarkerSymbol.Size = symbolSizeOrigin + IbreakIndex * symbolSizeOrigin / 3.0d;
                    pClassBreakRenderer.set_Symbol(IbreakIndex, (ISymbol)pSimpleMarkerSymbol);
                }                
                IScaleDependentRenderer pScaleDependentRenderer = new ScaleDependentRendererClass();
                pScaleDependentRenderer.AddRenderer(pUniqueValueRender as IFeatureRenderer);
                pScaleDependentRenderer.AddRenderer(pClassBreakRenderer as IFeatureRenderer);
                pScaleDependentRenderer.set_Break(0, 20000000);
                pScaleDependentRenderer.set_Break(1, 40000000);                
                pGeoFeatLyr.Renderer = (IFeatureRenderer)pScaleDependentRenderer;
                mainMapControl.ActiveView.Refresh();
                mainTOCControl.Update();
            }
        }
        #endregion                   
    }
}

