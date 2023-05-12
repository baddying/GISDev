using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using TextSymbols;
using ESRI.ArcGIS.Controls;
using 符号化.Annotation;
using 符号化.Class;
using 符号化;
using ESRI.ArcGIS.Animation;
using ESRI.ArcGIS.esriSystem;
using 符号选择器;
using stdole;
using ESRI.ArcGIS.SystemUI;

namespace 点线面符号化
{
    public partial class frmMainUI : Form
    {
        private frmAnnotation frmAnnotation = null;  // 注记
        private frmTextElement frmTextElement = null;//标注
        private frmMapTips frmMapTips = null;//MapTips       
        private OperateMap m_OperateMap = null;
        public string  filepath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        public frmMainUI()
        {           
            InitializeComponent();
            m_OperateMap = new OperateMap();
        }
        #region 设置颜色函数
        /// <summary>
        ///RGB色彩模型
        /// </summary>
        /// <param name="intR"></param>
        /// <param name="intG"></param>
        /// <param name="intB"></param>
        /// <returns></returns>
        //输入RGB值，获得IRgbColor型值
        public IRgbColor GetRgbColor(int intR, int intG, int intB)
        {
            IRgbColor pRgbColor = null;
            if (intR < 0 || intR > 255 || intG < 0 || intG > 255 || intB < 0 || intB > 255)
            {
                return pRgbColor;
            }
            pRgbColor = new RgbColorClass();
            pRgbColor.Red = intR;
            pRgbColor.Green = intG;
            pRgbColor.Blue = intB;
            return pRgbColor;
        }
        /// <summary>
        /// HSV色彩模型
        /// </summary>
        /// <param name="intH"></param>
        /// <param name="intS"></param>
        /// <param name="intV"></param>
        /// <returns></returns>
        //输入HSV值，获得IHsvColor型值
        public IHsvColor GetHsvColor(int intH, int intS, int intV)
        {
            IHsvColor pHsvColor = null;
            if (intH < 0 || intH > 360 || intS < 0 || intS > 100 || intV < 0 || intV > 100)
            {
                return pHsvColor;
            }
            pHsvColor = new HsvColorClass();
            pHsvColor.Hue = intH;
            pHsvColor.Saturation = intS;
            pHsvColor.Value = intV;
            return pHsvColor;
        }
        /// <summary>
        /// 创建色带
        /// </summary>
        /// <returns></returns>
        public IColorRamp CreateAlgorithmicColorRamp()
        {
            //创建一个新AlgorithmicColorRampClass对象
            IAlgorithmicColorRamp pAlgColorRamp = new AlgorithmicColorRampClass();
            IRgbColor pFromColor = new RgbColorClass();
            IRgbColor pToColor = new RgbColorClass();
            //创建起始颜色对象
            pFromColor.Red = 255;
            pFromColor.Green = 0;
            pFromColor.Blue = 0;
            //创建终止颜色对象           
            pToColor.Red = 0;
            pToColor.Green = 255;
            pToColor.Blue = 0;
            //设置AlgorithmicColorRampClass的起止颜色属性
            pAlgColorRamp.ToColor = pFromColor;
            pAlgColorRamp.FromColor = pToColor;
            //设置梯度类型
            pAlgColorRamp.Algorithm = esriColorRampAlgorithm.esriCIELabAlgorithm;
            //设置颜色带颜色数量
            pAlgColorRamp.Size = 10;
            //创建颜色带
            bool bture = true;
            pAlgColorRamp.CreateRamp(out bture);
            return pAlgColorRamp;
        }
        #endregion
        #region 点符号化
        #region 简单类型点状符号化
        private void SimpleMaker_Click(object sender, EventArgs e)
        {
            try
            {
                //获取目标图层
                ILayer pLayer = new FeatureLayerClass();
                pLayer = mainMapControl.get_Layer(0);
                IGeoFeatureLayer pGeoFeatLyr = pLayer as IGeoFeatureLayer;
                //设置点符号
                ISimpleMarkerSymbol pMarkerSymbol = new SimpleMarkerSymbol();
                pMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSSquare;//设置点符号样式为方形
                IRgbColor pRgbColor = new RgbColor();
                pRgbColor = GetRgbColor(225, 100, 100);
                pMarkerSymbol.Color = pRgbColor;//设置点符号颜色
                ISymbol pSymbol = (ISymbol)pMarkerSymbol;
                //更改符号样式
                ISimpleRenderer pSimpleRenderer = new SimpleRendererClass();
                pSimpleRenderer.Symbol = pSymbol;
                pGeoFeatLyr.Renderer = pSimpleRenderer as IFeatureRenderer;
                mainMapControl.Refresh();
                mainTOCControl.Update();
            }
            catch
            {
                MessageBox.Show("请输入有效图层!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        #endregion
        #region 箭头类型符号化
        private void ArrowMarker_Click(object sender, EventArgs e)
        {
            try
            {
                //获取目标图层
                ILayer pLayer = new FeatureLayerClass();
                pLayer = mainMapControl.get_Layer(0);
                IGeoFeatureLayer pGeoFeatLyr = pLayer as IGeoFeatureLayer;
                //设置点符号
                IArrowMarkerSymbol pArrowMarkerSymbol = new ArrowMarkerSymbolClass();
                IRgbColor pRgbColor = new RgbColor();
                pRgbColor = GetRgbColor(255, 100, 0);
                pArrowMarkerSymbol.Angle = 90;
                pArrowMarkerSymbol.Color = pRgbColor;
                pArrowMarkerSymbol.Length = 20;//设置简单顶点到底边的距离
                pArrowMarkerSymbol.Width = 10;//设置箭头底边宽度
                pArrowMarkerSymbol.XOffset = 0;
                pArrowMarkerSymbol.YOffset = 0;
                pArrowMarkerSymbol.Style = esriArrowMarkerStyle.esriAMSPlain;//设置点符号样式
                //更改符号样式
                ISimpleRenderer pSimpleRenderer = new SimpleRendererClass();
                pSimpleRenderer.Symbol = pArrowMarkerSymbol as ISymbol;
                pGeoFeatLyr.Renderer = pSimpleRenderer as IFeatureRenderer;
                mainMapControl.Refresh();
                mainTOCControl.Update();
            }
            catch
            {
                MessageBox.Show("请输入有效图层","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        #endregion
        #region 字符型点符号化
        private void CharacterMarker_Click(object sender, EventArgs e)
        {
            try
            {
                //获取目标图层
                ILayer pLayer = new FeatureLayerClass();
                pLayer = mainMapControl.get_Layer(0);
                IGeoFeatureLayer pGeoFeatLyr = pLayer as IGeoFeatureLayer;
                //设置点符号
                ICharacterMarkerSymbol pCharacterMarkerSymbol = new CharacterMarkerSymbol();
                stdole.IFontDisp pFontDisp = (stdole.IFontDisp)(new stdole.StdFontClass());
                IRgbColor pRgbColor = new RgbColor();
                pRgbColor = GetRgbColor(255, 0, 0);
                pFontDisp.Name = "arial";//设置字体样式          
                pFontDisp.Italic = true;//设置是否采用斜体字符

                pCharacterMarkerSymbol.Angle = 0;
                pCharacterMarkerSymbol.CharacterIndex = 65;
                pCharacterMarkerSymbol.Color = pRgbColor;
                pCharacterMarkerSymbol.Font = pFontDisp;
                pCharacterMarkerSymbol.Size = 10;
                pCharacterMarkerSymbol.XOffset = 3;
                pCharacterMarkerSymbol.YOffset = 3;
                //更改符号样式
                ISimpleRenderer pSimpleRenderer = new SimpleRendererClass();
                pSimpleRenderer.Symbol = pCharacterMarkerSymbol as ISymbol;
                pGeoFeatLyr.Renderer = pSimpleRenderer as IFeatureRenderer;
                mainMapControl.Refresh();
                mainTOCControl.Update();
            }
            catch
            {
                MessageBox.Show("请输入有效图层", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region 图片型点符号化
        private void PictureMarker_Click(object sender, EventArgs e)
        {
            try
            {
                //获取目标图层
                ILayer pLayer = new FeatureLayerClass();
                pLayer = mainMapControl.get_Layer(0);
                IGeoFeatureLayer pGeoFeatLyr = pLayer as IGeoFeatureLayer;
                //设置点符号           
                IPictureMarkerSymbol pPictureMarkerSymbol = new PictureMarkerSymbolClass();
                string fileName = m_OperateMap.getPath(filepath) + "\\data\\Symbol\\city.bmp";
                pPictureMarkerSymbol.CreateMarkerSymbolFromFile(esriIPictureType.esriIPictureBitmap, fileName);//图片类型和图片来源               
                pPictureMarkerSymbol.Angle = 0;
                pPictureMarkerSymbol.Size = 10;
                pPictureMarkerSymbol.XOffset = 0;
                pPictureMarkerSymbol.YOffset = 0;
                //更改符号样式
                ISimpleRenderer pSimpleRenderer = new SimpleRendererClass();
                pSimpleRenderer.Symbol = pPictureMarkerSymbol as ISymbol;
                pGeoFeatLyr.Renderer = pSimpleRenderer as IFeatureRenderer;
                mainMapControl.Refresh();
                mainTOCControl.Update();
            }
            catch
            {
                MessageBox.Show("请输入有效图层", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region 叠加型点符号化
        private void MultiLayerMarker_Click(object sender, EventArgs e)
        {
            try
            {
                //获取目标图层
                ILayer pLayer = new FeatureLayerClass();
                pLayer = mainMapControl.get_Layer(0);
                IGeoFeatureLayer pGeoFeatLyr = pLayer as IGeoFeatureLayer;
                //设置点符号
                IMultiLayerMarkerSymbol pMultiLayerMarkerSymbol = new MultiLayerMarkerSymbolClass();
                IPictureMarkerSymbol pPictureMarkerSymbol = new PictureMarkerSymbolClass();
                ICharacterMarkerSymbol pCharacterMarkerSymbol = new CharacterMarkerSymbol();
                stdole.IFontDisp fontDisp = (stdole.IFontDisp)(new stdole.StdFontClass());
                IRgbColor pGgbColor = new RgbColor();
                pGgbColor = GetRgbColor(0, 0, 0);
                fontDisp.Name = "arial";
                fontDisp.Size = 12;
                fontDisp.Italic = true;
                //创建字符符号
                pCharacterMarkerSymbol.Angle = 0;
                pCharacterMarkerSymbol.CharacterIndex = 97;//字母a
                pCharacterMarkerSymbol.Color = pGgbColor;
                pCharacterMarkerSymbol.Font = fontDisp;
                pCharacterMarkerSymbol.Size = 24;
                //创建图片符号           
                string fileName = m_OperateMap.getPath(filepath) + "\\data\\Symbol\\city.bmp"; ;
                pPictureMarkerSymbol.CreateMarkerSymbolFromFile(esriIPictureType.esriIPictureBitmap, fileName);
                pPictureMarkerSymbol.Angle = 0;
                pPictureMarkerSymbol.BitmapTransparencyColor = pGgbColor;
                pPictureMarkerSymbol.Size = 10;
                //添加图片、字符符号到组合符号中
                pMultiLayerMarkerSymbol.AddLayer(pCharacterMarkerSymbol);
                pMultiLayerMarkerSymbol.AddLayer(pPictureMarkerSymbol);
                pMultiLayerMarkerSymbol.Angle = 0;
                pMultiLayerMarkerSymbol.Size = 20;
                pMultiLayerMarkerSymbol.XOffset = 5;
                pMultiLayerMarkerSymbol.YOffset = 5;
                //更改符号样式
                ISimpleRenderer pSimpleRenderer = new SimpleRendererClass();
                pSimpleRenderer.Symbol = pMultiLayerMarkerSymbol as ISymbol;
                pGeoFeatLyr.Renderer = pSimpleRenderer as IFeatureRenderer;
                mainMapControl.Refresh();
                mainTOCControl.Update();
            }
            catch
            {
                MessageBox.Show("请输入有效图层", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #endregion
        #region 线符号化
        #region 简单线符号
        private void SimpleLine_Click(object sender, EventArgs e)
        {
            try
            {
                //获取目标图层
                ILayer pLayer = new FeatureLayerClass();
                pLayer = mainMapControl.get_Layer(1);
                IGeoFeatureLayer pGeoFeatLyr = pLayer as IGeoFeatureLayer;
                //设置线符号
                ISimpleLineSymbol simpleLineSymbol = new SimpleLineSymbolClass();
                simpleLineSymbol.Width = 0;//定义线的宽度 
                simpleLineSymbol.Style = esriSimpleLineStyle.esriSLSInsideFrame; //定义线的样式                               
                simpleLineSymbol.Color = GetRgbColor(255, 100, 0);//定义线的颜色
                ISymbol symbol = simpleLineSymbol as ISymbol;
                //更改符号样式
                ISimpleRenderer pSimpleRenderer = new SimpleRendererClass();
                pSimpleRenderer.Symbol = symbol;
                pGeoFeatLyr.Renderer = pSimpleRenderer as IFeatureRenderer;
                mainMapControl.Refresh();
                mainTOCControl.Update();
            }
            catch (Exception ex)
            {
                
            }
        }
        #endregion
        #region 制图线符号化
        private void CartographicLine_Click(object sender, EventArgs e)
        {
            try
            {
                //获取目标图层
                ILayer pLayer = new FeatureLayerClass();
                pLayer = mainMapControl.get_Layer(1);
                IGeoFeatureLayer pGeoFeatLyr = pLayer as IGeoFeatureLayer;
                //设置线符号
                ICartographicLineSymbol pCartographicLineSymbol = new CartographicLineSymbolClass();
                pCartographicLineSymbol.Cap = esriLineCapStyle.esriLCSRound;//设置线要素首尾端点形状为圆形
                pCartographicLineSymbol.Join = esriLineJoinStyle.esriLJSRound; //设置线要素转折点出的样式为圆滑    
                pCartographicLineSymbol.Width = 2;
                //设置线要素符号模板
                ILineProperties pLineProperties;
                pLineProperties = pCartographicLineSymbol as ILineProperties;
                pLineProperties.Offset = 0;
                double[] dob = new double[6];
                dob[0] = 0;
                dob[1] = 1;
                dob[2] = 2;
                dob[3] = 3;
                dob[4] = 4;
                dob[5] = 5;
                ITemplate pTemplate = new TemplateClass();
                pTemplate.Interval = 1;
                for (int i = 0; i < dob.Length; i += 2)
                {
                    pTemplate.AddPatternElement(dob[i], dob[i + 1]);
                }
                pLineProperties.Template = pTemplate;
                IRgbColor pRgbColor = GetRgbColor(0, 255, 0);
                pCartographicLineSymbol.Color = pRgbColor;
                //更改符号样式
                ISimpleRenderer pSimpleRenderer = new SimpleRendererClass();
                pSimpleRenderer.Symbol = pCartographicLineSymbol as ISymbol;
                pGeoFeatLyr.Renderer = pSimpleRenderer as IFeatureRenderer;
                mainMapControl.Refresh();
                mainTOCControl.Update();
            }
            catch
            { }
        }
        #endregion 多图层线符号化
        #region 多图层线符号
        private void MultiLayerLine_Click(object sender, EventArgs e)
        {
            try
            {
                //获取目标图层
                ILayer pLayer = new FeatureLayerClass();
                pLayer = mainMapControl.get_Layer(1);
                IGeoFeatureLayer pGeoFeatLyr = pLayer as IGeoFeatureLayer;
                //设置线符号
                IMultiLayerLineSymbol pMultiLayerLineSymbol = new MultiLayerLineSymbolClass();
                ISimpleLineSymbol pSimpleLineSymbol = new SimpleLineSymbolClass();
                pSimpleLineSymbol.Style = esriSimpleLineStyle.esriSLSDashDotDot;
                pSimpleLineSymbol.Width = 2;
                IRgbColor pRgbColor = GetRgbColor(255, 0, 0);
                pSimpleLineSymbol.Color = pRgbColor;
                //ISymbol pSymbol = pSimpleLineSymbol as ISymbol;
                //pSymbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen; //设置线要素的颜色为

                ICartographicLineSymbol pCartographicLineSymbol = new CartographicLineSymbolClass();
                pCartographicLineSymbol.Cap = esriLineCapStyle.esriLCSRound;
                pCartographicLineSymbol.Join = esriLineJoinStyle.esriLJSRound;
                pCartographicLineSymbol.Width = 2;
                ILineProperties pLineProperties;
                pLineProperties = pCartographicLineSymbol as ILineProperties;
                pLineProperties.Offset = 0;
                double[] dob = new double[6];
                dob[0] = 0;
                dob[1] = 1;
                dob[2] = 2;
                dob[3] = 3;
                dob[4] = 4;
                dob[5] = 5;
                ITemplate pTemplate = new TemplateClass();
                pTemplate.Interval = 1;
                for (int i = 0; i < dob.Length; i += 2)
                {
                    pTemplate.AddPatternElement(dob[i], dob[i + 1]);
                }
                pLineProperties.Template = pTemplate;

                pRgbColor = GetRgbColor(0, 255, 0);
                pCartographicLineSymbol.Color = pRgbColor;
                pMultiLayerLineSymbol.AddLayer(pSimpleLineSymbol);
                pMultiLayerLineSymbol.AddLayer(pCartographicLineSymbol);
                //更改符号样式
                ISimpleRenderer pSimpleRenderer = new SimpleRendererClass();
                pSimpleRenderer.Symbol = pMultiLayerLineSymbol as ISymbol;
                pGeoFeatLyr.Renderer = pSimpleRenderer as IFeatureRenderer;
                mainMapControl.Refresh();
                mainTOCControl.Update();
            }
            catch { }
        }
        #endregion
        #region 图片线符号化
        private void PictureLine_Click(object sender, EventArgs e)
        {
            try
            {
                //获取目标图层
                ILayer pLayer = new FeatureLayerClass();
                pLayer = mainMapControl.get_Layer(1);
                IGeoFeatureLayer pGeoFeatLyr = pLayer as IGeoFeatureLayer;
                //设置线符号
                IPictureLineSymbol pictureLineSymbol = new PictureLineSymbolClass();
                //创建图片符号                                
                string fileName = m_OperateMap.getPath(filepath) + "\\data\\Symbol\\border.bmp";
                pictureLineSymbol.CreateLineSymbolFromFile(esriIPictureType.esriIPictureBitmap, fileName);
                IRgbColor rgbColor = GetRgbColor(255, 0, 0);
                pictureLineSymbol.Color = rgbColor;
                pictureLineSymbol.Offset = 0;
                pictureLineSymbol.Width = 3;
                pictureLineSymbol.Rotate = false;
                //更改符号样式
                ISimpleRenderer pSimpleRenderer = new SimpleRendererClass();
                pSimpleRenderer.Symbol = pictureLineSymbol as ISymbol;
                pGeoFeatLyr.Renderer = pSimpleRenderer as IFeatureRenderer;
                mainMapControl.Refresh();
                mainTOCControl.Update();
            }
            catch { }
        }
        #endregion
        #region 离散型符号
        private void HashLine_Click(object sender, EventArgs e)
        {
            try
            {
                //获取目标图层
                ILayer pLayer = new FeatureLayerClass();
                pLayer = mainMapControl.get_Layer(1);
                IGeoFeatureLayer pGeoFeatLyr = pLayer as IGeoFeatureLayer;
                //设置线符号
                IHashLineSymbol pHashLineSymbol = new HashLineSymbolClass();
                ILineProperties pLineProperties = pHashLineSymbol as ILineProperties;
                pLineProperties.Offset = 0;
                double[] dob = new double[6];
                dob[0] = 0;
                dob[1] = 1;
                dob[2] = 2;
                dob[3] = 3;
                dob[4] = 4;
                dob[5] = 5;
                ITemplate pTemplate = new TemplateClass();
                pTemplate.Interval = 1;
                for (int i = 0; i < dob.Length; i += 2)
                {
                    pTemplate.AddPatternElement(dob[i], dob[i + 1]);
                }
                pLineProperties.Template = pTemplate;
                pHashLineSymbol.Width = 2;
                pHashLineSymbol.Angle = 45;//设置单一线段的倾斜角度
                IRgbColor pColor = new RgbColor();
                pColor = GetRgbColor(0, 0, 255);
                pHashLineSymbol.Color = pColor;
                //更改符号样式
                ISimpleRenderer pSimpleRenderer = new SimpleRendererClass();
                pSimpleRenderer.Symbol = pHashLineSymbol as ISymbol;
                pGeoFeatLyr.Renderer = pSimpleRenderer as IFeatureRenderer;
                mainMapControl.Refresh();
                mainTOCControl.Update();
            }
            catch { }
        }
        #endregion
        #endregion 
        #region 面符号化
        #region 简单填充符号
        private void SimpleFill_Click(object sender, EventArgs e)
        {
            try
            {
                //获取目标图层
                ILayer pLayer = new FeatureLayerClass();
                pLayer = mainMapControl.get_Layer(2);
                IGeoFeatureLayer pGeoFeatLyr = pLayer as IGeoFeatureLayer;
                //设置面填充符号           
                ISimpleFillSymbol pSimpleFillSymbol = new SimpleFillSymbolClass();
                pSimpleFillSymbol.Style = esriSimpleFillStyle.esriSFSVertical;//设置面填充为垂直线填充
                pSimpleFillSymbol.Color = GetRgbColor(150, 150, 150);
                //更改符号样式
                ISimpleRenderer pSimpleRenderer = new SimpleRendererClass();
                pSimpleRenderer.Symbol = pSimpleFillSymbol as ISymbol;
                pGeoFeatLyr.Renderer = pSimpleRenderer as IFeatureRenderer;
                mainMapControl.Refresh();
                mainTOCControl.Update();
            }
            catch { }
        }    
        #endregion
        #region 线填充符号
        private void LineFill_Click(object sender, EventArgs e)
        {
            try
            {
                //获取目标图层
                ILayer pLayer = new FeatureLayerClass();
                pLayer = mainMapControl.get_Layer(2);
                IGeoFeatureLayer pGeoFeatLyr = pLayer as IGeoFeatureLayer;
                //设置面填充符号                       
                ISimpleLineSymbol pSimpleLineSymbol = new SimpleLineSymbolClass();
                pSimpleLineSymbol.Style = esriSimpleLineStyle.esriSLSDashDotDot; //定义线的样式             
                pSimpleLineSymbol.Width = 2;//定义线的宽度
                IRgbColor pRgbColor = GetRgbColor(255, 0, 0);
                pSimpleLineSymbol.Color = pRgbColor;//定义线的颜色         
                ILineFillSymbol pLineFillSymbol = new LineFillSymbol();
                pLineFillSymbol.Angle = 45;
                pLineFillSymbol.Separation = 10;
                pLineFillSymbol.Offset = 5;
                pLineFillSymbol.LineSymbol = pSimpleLineSymbol;
                //更改符号样式
                ISimpleRenderer pSimpleRenderer = new SimpleRendererClass();
                pSimpleRenderer.Symbol = pLineFillSymbol as ISymbol;
                pGeoFeatLyr.Renderer = pSimpleRenderer as IFeatureRenderer;
                mainMapControl.Refresh();
                mainTOCControl.Update();
            }
            catch { }
        }
        #endregion
        #region 点填充符号
        private void MarkerFill_Click(object sender, EventArgs e)
        {
            try
            {
                //获取目标图层
                ILayer pLayer = new FeatureLayerClass();
                pLayer = mainMapControl.get_Layer(2);
                IGeoFeatureLayer pGeoFeatLyr = pLayer as IGeoFeatureLayer;
                //设置面填充符号          
                IArrowMarkerSymbol pArrowMarkerSymbol = new ArrowMarkerSymbolClass();//设置填充点点符号样式
                IRgbColor pRgbColor = GetRgbColor(255, 0, 0);
                pArrowMarkerSymbol.Color = pRgbColor as IColor;
                pArrowMarkerSymbol.Length = 2;
                pArrowMarkerSymbol.Width = 2;
                pArrowMarkerSymbol.Style = esriArrowMarkerStyle.esriAMSPlain;

                IMarkerFillSymbol pMarkerFillSymbol = new MarkerFillSymbolClass();
                pMarkerFillSymbol.MarkerSymbol = pArrowMarkerSymbol;
                pRgbColor = GetRgbColor(255, 0, 0);
                pMarkerFillSymbol.Color = pRgbColor;
                pMarkerFillSymbol.Style = esriMarkerFillStyle.esriMFSGrid;

                IFillProperties pFillProperties = pMarkerFillSymbol as IFillProperties;
                pFillProperties.XOffset = 2;
                pFillProperties.YOffset = 2;
                pFillProperties.XSeparation = 5;
                pFillProperties.YSeparation = 5;
                //更改符号样式
                ISimpleRenderer pSimpleRenderer = new SimpleRendererClass();
                pSimpleRenderer.Symbol = pFillProperties as ISymbol;
                pGeoFeatLyr.Renderer = pSimpleRenderer as IFeatureRenderer;
                mainMapControl.Refresh();
                mainTOCControl.Update();
            }
            catch { }
        }
        #endregion
        #region 渐变色填充符号
        private void GradientFill_Click(object sender, EventArgs e)
        {
            try
            {
                //获取目标图层
                ILayer pLayer = new FeatureLayerClass();
                pLayer = mainMapControl.get_Layer(2);
                IGeoFeatureLayer pGeoFeatLyr = pLayer as IGeoFeatureLayer;
                //设置面填充符号          
                IGradientFillSymbol pGradientFillSymbol = new GradientFillSymbolClass();
                IAlgorithmicColorRamp pAlgorithcColorRamp = new AlgorithmicColorRampClass();//设置颜色带
                pAlgorithcColorRamp.FromColor = GetRgbColor(255, 0, 0);//颜色带的起始颜色
                pAlgorithcColorRamp.ToColor = GetRgbColor(0, 255, 0);//颜色带的终点颜色
                pAlgorithcColorRamp.Algorithm = esriColorRampAlgorithm.esriHSVAlgorithm;
                pGradientFillSymbol.ColorRamp = pAlgorithcColorRamp;//填充颜色带
                pGradientFillSymbol.GradientAngle = 90;//设置填充方向
                pGradientFillSymbol.GradientPercentage = 1;//控制色彩饱和度
                pGradientFillSymbol.IntervalCount = 5;//设置填充颜色带的数目
                pGradientFillSymbol.Style = esriGradientFillStyle.esriGFSLinear;//设置颜色填充带样式为线性填充
                //更改符号样式
                ISimpleRenderer pSimpleRenderer = new SimpleRendererClass();
                pSimpleRenderer.Symbol = pGradientFillSymbol as ISymbol;
                pGeoFeatLyr.Renderer = pSimpleRenderer as IFeatureRenderer;
                mainMapControl.Refresh();
                mainTOCControl.Update();
            }
            catch { }
        }
        #endregion
        #region 图片填充符号
        private void PictureFill_Click(object sender, EventArgs e)
        {
            try
            {
                //获取目标图层
                ILayer pLayer = new FeatureLayerClass();
                pLayer = mainMapControl.get_Layer(2);
                IGeoFeatureLayer pGeoFeatLyr = pLayer as IGeoFeatureLayer;
                //设置面填充符号          
                IPictureFillSymbol pictureFillSymbol = new PictureFillSymbolClass();
                string fileName = m_OperateMap.getPath(filepath) + "\\data\\Symbol\\states.bmp";
                pictureFillSymbol.CreateFillSymbolFromFile(esriIPictureType.esriIPictureBitmap, fileName);

                ISimpleLineSymbol simpleLineSymbol = new SimpleLineSymbolClass();
                simpleLineSymbol.Style = esriSimpleLineStyle.esriSLSDashDotDot;
                simpleLineSymbol.Color = GetRgbColor(255, 0, 0);
                ISymbol symbol = pictureFillSymbol as ISymbol;

                pictureFillSymbol.Outline = simpleLineSymbol;//设置面要素边线颜色
                pictureFillSymbol.Angle = 0;//设置图片显示方向
                //更改符号样式
                ISimpleRenderer pSimpleRenderer = new SimpleRendererClass();
                pSimpleRenderer.Symbol = pictureFillSymbol as ISymbol;
                pGeoFeatLyr.Renderer = pSimpleRenderer as IFeatureRenderer;
                mainMapControl.Refresh();
                mainTOCControl.Update();
            }
            catch { }
        }
        #endregion
        #region 多图层填充
        private void MultiLayerFill_Click(object sender, EventArgs e)
        {
            try
            {
                //获取目标图层
                ILayer pLayer = new FeatureLayerClass();
                pLayer = mainMapControl.get_Layer(2);
                IGeoFeatureLayer pGeoFeatLyr = pLayer as IGeoFeatureLayer;
                //设置渐变色填充面符号    
                IMultiLayerFillSymbol pMultiLayerFillSymbol = new MultiLayerFillSymbolClass();
                IGradientFillSymbol pGradientFillSymbol = new GradientFillSymbolClass();
                IAlgorithmicColorRamp pAlgorithcColorRamp = new AlgorithmicColorRampClass();
                pAlgorithcColorRamp.FromColor = GetRgbColor(255, 0, 0);
                pAlgorithcColorRamp.ToColor = GetRgbColor(0, 255, 0);
                pAlgorithcColorRamp.Algorithm = esriColorRampAlgorithm.esriHSVAlgorithm;
                pGradientFillSymbol.ColorRamp = pAlgorithcColorRamp;
                pGradientFillSymbol.GradientAngle = 45;
                pGradientFillSymbol.GradientPercentage = 0.9;
                pGradientFillSymbol.Style = esriGradientFillStyle.esriGFSLinear;
                //设置线填充面符号
                ISimpleLineSymbol pSimpleLineSymbol = new SimpleLineSymbolClass();
                pSimpleLineSymbol.Style = esriSimpleLineStyle.esriSLSDashDotDot;
                pSimpleLineSymbol.Width = 2;
                IRgbColor pRgbColor = GetRgbColor(255, 0, 0);
                pSimpleLineSymbol.Color = pRgbColor;
                ILineFillSymbol pLineFillSymbol = new LineFillSymbol();
                pLineFillSymbol.Angle = 45;
                pLineFillSymbol.Separation = 10;
                pLineFillSymbol.Offset = 5;
                pLineFillSymbol.LineSymbol = pSimpleLineSymbol;
                //组合填充符号
                pMultiLayerFillSymbol.AddLayer(pGradientFillSymbol);
                pMultiLayerFillSymbol.AddLayer(pLineFillSymbol);
                //更改符号样式
                ISimpleRenderer pSimpleRenderer = new SimpleRendererClass();
                pSimpleRenderer.Symbol = pMultiLayerFillSymbol as ISymbol;
                pGeoFeatLyr.Renderer = pSimpleRenderer as IFeatureRenderer;
                mainMapControl.Refresh();
                mainTOCControl.Update();
            }
            catch { }
        }
        #endregion        
        #endregion
        #region 符号选择器
        //双击TOCControl控件时触发事件
        private void mainTOCControl_OnDoubleClick(object sender, ITOCControlEvents_OnDoubleClickEvent e)
        {
            esriTOCControlItem itemType = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap basicMap = null;
            ILayer layer = null;
            object unk = null;
            object data = null;
            mainTOCControl.HitTest(e.x, e.y, ref itemType, ref basicMap, ref layer, ref unk, ref data);
            if (e.button == 1)
            {
                if (itemType == esriTOCControlItem.esriTOCControlItemLegendClass)
                {
                    //取得图例
                    ILegendClass pLegendClass = ((ILegendGroup)unk).get_Class((int)data);
                    //创建符号选择器SymbolSelector实例
                    frmSymbolSelector SymbolSelectorFrm = new frmSymbolSelector(pLegendClass, layer);
                    if (SymbolSelectorFrm.ShowDialog() == DialogResult.OK)
                    {
                        //局部更新主Map控件
                        mainMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                        //设置新的符号
                        pLegendClass.Symbol = SymbolSelectorFrm.pSymbol;
                        //更新主Map控件和图层控件
                        this.mainMapControl.ActiveView.Refresh();
                        this.mainTOCControl.Refresh();
                    }
                }
            }
        }
        #endregion                      
        #region 文本符号化
        int flag=1;
        private void txtSymbol_Click(object sender, EventArgs e)
        {
            flag = 0;
        }
        /// <summary>
        /// 右键时添加文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainMapControl_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (flag == 0)
            {
                //右键时添加对象，左键时返回
                if (e.button != 2)
                {
                    return;
                }
                IPoint pPoint = new PointClass();
                pPoint = mainMapControl.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);
                //设置文本格式
                ITextSymbol pTextSymbol = new TextSymbolClass();
                StdFont myFont = new stdole.StdFontClass();
                myFont.Name = "宋体";
                myFont.Size = 24;
                pTextSymbol.Font = (IFontDisp)myFont;
                pTextSymbol.Angle = 0;
                pTextSymbol.RightToLeft = false;//文本由左向右排列
                pTextSymbol.VerticalAlignment = esriTextVerticalAlignment.esriTVABaseline;//垂直方向基线对齐
                pTextSymbol.HorizontalAlignment = esriTextHorizontalAlignment.esriTHAFull;//文本两端对齐
                pTextSymbol.Text = TextBox.Text;
                ITextElement pTextElement = new TextElementClass();
                pTextElement.Symbol = pTextSymbol;
                pTextElement.Text = pTextSymbol.Text;
                //获取一个图上坐标，且将文本添加到此位置           
                IElement pElement = (IElement)pTextElement;
                pElement.Geometry = pPoint;
                mainMapControl.ActiveView.GraphicsContainer.AddElement(pElement, 0);
                mainMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, pElement, null);
            }
            else
            {
                return;
            }           
        }
        #endregion
        #region TextElement标注
        private void txtElement_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmTextElement == null || frmTextElement.IsDisposed)
                {
                    frmTextElement = new frmTextElement();
                    frmTextElement.TextElement += new frmTextElement.TextElementLabelEventHandler(frmTextElement_TextElement);
                }
                frmTextElement.Map = mainMapControl.Map;
                frmTextElement.InitUI();
                frmTextElement.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void frmTextElement_TextElement(string sFeatClsName, string sFieldName)
        {
            IFeatureLayer pFeatLyr = m_OperateMap.GetFeatLyrByName(mainMapControl.Map, sFeatClsName);
            TextElementLabel(pFeatLyr, sFieldName);
        }
        private void TextElementLabel(IFeatureLayer pFeatLyr, string sFieldName)
        {
            try
            {
                IMap pMap = mainMapControl.Map;
                //获得图层所有要素
                IFeatureClass pFeatureClass = pFeatLyr.FeatureClass;
                IFeatureCursor pFeatCursor = pFeatureClass.Search(null, true);
                IFeature pFeature = pFeatCursor.NextFeature();
                while (pFeature != null)
                {
                    IFields pFields = pFeature.Fields;
                    //找出标注字段的索引号
                    int index = pFields.FindField(sFieldName);
                    //得到要素的Envelope
                    IEnvelope pEnve = pFeature.Extent;
                    IPoint pPoint = new PointClass();
                    pPoint.PutCoords(pEnve.XMin + pEnve.Width / 2, pEnve.YMin + pEnve.Height / 2);
                    //新建字体对象
                    stdole.IFontDisp pFont;
                    pFont = new stdole.StdFontClass() as stdole.IFontDisp;
                    pFont.Name = "arial";
                    //产生一个文本符号
                    ITextSymbol pTextSymbol = new TextSymbolClass();
                    //设置文本符号的大小
                    pTextSymbol.Size = 20;
                    pTextSymbol.Font = pFont;
                    pTextSymbol.Color = m_OperateMap.GetRgbColor(255, 0, 0);
                    //产生一个文本对象
                    ITextElement pTextElement = new TextElementClass();
                    pTextElement.Text = pFeature.get_Value(index).ToString();
                    pTextElement.ScaleText = true;
                    pTextElement.Symbol = pTextSymbol;
                    IElement pElement = pTextElement as IElement;
                    pElement.Geometry = pPoint;
                    IActiveView pActiveView = pMap as IActiveView;
                    IGraphicsContainer pGraphicsContainer = pMap as IGraphicsContainer;
                    //添加元素
                    pGraphicsContainer.AddElement(pElement, 0);
                    pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                    pPoint = null;
                    pElement = null;
                    pFeature = pFeatCursor.NextFeature();
                }
            }
            catch (Exception ex)
            {

            }

        }
        #endregion
        #region Annotation注记
        private void txtAnnotation_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmAnnotation == null || frmAnnotation.IsDisposed)
                {
                    frmAnnotation = new frmAnnotation();
                    frmAnnotation.Annotation += new frmAnnotation.AnnotationEventHandler(frmAnnotation_Annotation);
                }
                frmAnnotation.Map = mainMapControl.Map;
                frmAnnotation.InitUI();
                frmAnnotation.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        //注记
        void frmAnnotation_Annotation(string sFeatClsName, string sFieldName)
        {
            IFeatureLayer pFeatLyr = m_OperateMap.GetFeatLyrByName(mainMapControl.Map, sFeatClsName);
            Annotation(pFeatLyr, sFieldName);
        }
        /// <summary>
        /// 注记
        /// </summary>
        /// <param name="pFeatLyr">注记图层名称</param>
        /// <param name="sFieldName">注记字段</param>
        private void Annotation(IFeatureLayer pFeatLyr, string sFieldName)
        {
            try
            {
                IGeoFeatureLayer pGeoFeatLyer = pFeatLyr as IGeoFeatureLayer;
                IAnnotateLayerPropertiesCollection pAnnoProps = pGeoFeatLyer.AnnotationProperties;
                pAnnoProps.Clear();
                //设置标注记体格式                                                                     
                ITextSymbol pTextSymbol = new TextSymbolClass();
                stdole.StdFont pFont = new stdole.StdFontClass();
                pFont.Name = "verdana";
                pFont.Size = 10;
                pTextSymbol.Font = pFont as stdole.IFontDisp;
                //设置注记放置格式
                ILineLabelPosition pPosition = new LineLabelPositionClass();
                pPosition.Parallel = false;
                pPosition.Perpendicular = true;
                ILineLabelPlacementPriorities pPlacement = new LineLabelPlacementPrioritiesClass();
                IBasicOverposterLayerProperties pBasic = new BasicOverposterLayerPropertiesClass();
                pBasic.FeatureType = esriBasicOverposterFeatureType.esriOverposterPolyline;
                pBasic.LineLabelPlacementPriorities = pPlacement;//设置标注文本摆设路径权重
                pBasic.LineLabelPosition = pPosition;//控制文本的排放位置
                ILabelEngineLayerProperties pLableEngine = new LabelEngineLayerPropertiesClass();
                pLableEngine.Symbol = pTextSymbol;
                pLableEngine.BasicOverposterLayerProperties = pBasic;//设置标注文本的放置方式，以及处理文字间冲突的处理方式等
                pLableEngine.Expression = "[" + sFieldName + "]";//输入VBScript或JavaScript语言，设置要标注的字段
                IAnnotateLayerProperties pAnnoLayerProps = pLableEngine as IAnnotateLayerProperties;
                pAnnoProps.Add(pAnnoLayerProps);
                pGeoFeatLyer.DisplayAnnotation = true;
                mainMapControl.Refresh(esriViewDrawPhase.esriViewBackground, null, null);
                mainMapControl.Update();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region MapTips显示
        private void txtmapTips_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmMapTips == null || frmMapTips.IsDisposed)
                {
                    frmMapTips = new frmMapTips();
                    frmMapTips.MapTips += new frmMapTips.MapTipsEventHandler(frmMapTips_MapTips);
                }
                frmMapTips.Map = mainMapControl.Map;
                frmMapTips.InitUI();
                frmMapTips.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        void frmMapTips_MapTips(string sFeatClsName, string sFieldName)
        {
            IFeatureLayer pFeatLyr = m_OperateMap.GetFeatLyrByName(mainMapControl.Map, sFeatClsName);            
            for (int i = 0; i < mainMapControl.LayerCount; i++)
            {
                ILayer pLayers = mainMapControl.get_Layer(i);
                IFeatureLayer pFeatLyrs = pLayers as IFeatureLayer;
                pFeatLyrs.DisplayField = null;
            }
            MapTips(pFeatLyr, sFieldName);
        }
        /// <summary>
        /// MapTips显示
        /// </summary>
        /// <param name="pFeatLyr"></param>
        /// <param name="sFieldName"></param>
        private void MapTips(IFeatureLayer pFeatLyr, string sFieldName)
        {                    
            ILayer pLayer = new FeatureLayerClass();
            pLayer = pFeatLyr;
            pLayer.ShowTips = true;
            ILayerFields pLayerFields = (ILayerFields)pFeatLyr;
            for (int i = 0; i <= pLayerFields.FieldCount - 1; i++)
            {
                IField field = pLayerFields.get_Field(i);
                if (field.Name == sFieldName)
                {
                    pFeatLyr.DisplayField = field.Name;
                    break;
                }
            }
            mainMapControl.ShowMapTips = true;
        }
        #endregion       
        #region  文件打开、保存、另存为
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand Cmd = new ControlsOpenDocCommandClass();
            Cmd.OnCreate(mainMapControl.Object);
            Cmd.OnClick();
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveMap(mainMapControl.DocumentFilename, mainMapControl.Map);
        }
        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand Cmd = new ControlsSaveAsDocCommandClass();
            Cmd.OnCreate(mainMapControl.Object);
            Cmd.OnClick();
        }
        public void SaveMap(string m_FilePath, IMap m_SaveMap)
        {
            try
            {
                IMapDocument pMapDoc = new MapDocumentClass();
                IMxdContents pMxdC = m_SaveMap as IMxdContents;
                pMapDoc.New(m_FilePath);
                pMapDoc.ReplaceContents(pMxdC);
                if (pMapDoc.get_IsReadOnly(pMapDoc.DocumentFilename) == true)
                {
                    MessageBox.Show("本地图文档是只读的，不能保存!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);                  
                }
                pMapDoc.Save(pMapDoc.UsesRelativePaths, true);               
            }
            catch (Exception ex)
            { 
               
            }
        }
        #endregion                                                                                                                                            
       
    }
}

