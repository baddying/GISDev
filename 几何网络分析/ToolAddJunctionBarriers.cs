using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.NetworkAnalysis;
using System.Collections.Generic;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Display;

namespace UtilityNetwork
{
    /// <summary>
    /// Summary description for ToolAddJunctionBarriers.
    /// </summary>
    [Guid("f0a63ddc-5dcc-40f8-a6c6-d565c25560b2")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("UtilityNetwork.ToolAddJunctionBarriers")]
    public sealed class ToolAddJunctionBarriers : BaseTool
    {
        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Register(regKey);

        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Unregister(regKey);

        }

        #endregion
        #endregion

        private IHookHelper m_hookHelper;
        /// <summary>
        /// ��ǰ�ļ�������
        /// </summary>
        private IGeometricNetwork geometricNetwork;
        /// <summary>
        /// �ܵ��ϰ���ʶ���б���������������ӵĹܵ��ϰ�
        /// </summary>
        private List<int> listJunctionBarrierEIDs;

        /// <summary>
        /// ���õ�ǰ�����ļ�������
        /// </summary>
        public IGeometricNetwork GeometricNetwork
        {
            set
            {
                geometricNetwork = value;
            }
        }

        /// <summary>
        /// ���ñ������йܵ��ϰ���ʶ���б�
        /// </summary>
        public List<int> ListJunctionBarrierEIDs
        {
            set
            {
                listJunctionBarrierEIDs = value;
            }
        }

        public ToolAddJunctionBarriers()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "�����������"; //localizable text 
            base.m_caption = "��ӹܵ��ϰ�";  //localizable text 
            base.m_message = "�ڵ�ͼ�ϵ���ܵ㣬�������Ϊ��������ĵ�Ҫ�ء�";  //localizable text
            base.m_toolTip = "��ӹܵ��ϰ�";  //localizable text
            base.m_name = "AddJunctionBarrierTool";   //unique id, non-localizable (e.g. "MyCategory_MyTool")
            try
            {
                //
                // TODO: change resource name if necessary
                //
                //ʹ����Դ����ȡ��ǰ���ߵ�ͼ�꣬��Դ����Ϊ����Ŀ����.ͼ���ļ�����
                base.m_bitmap = new System.Drawing.Bitmap(
                   GetType().Assembly.GetManifestResourceStream("UtilityNetwork." + "UtilityNetworkBarrierJunctionAddTool16.png"));
                base.m_cursor = new System.Windows.Forms.Cursor(GetType(), GetType().Name + ".cur");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this tool is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            if (m_hookHelper == null)
                m_hookHelper = new HookHelperClass();

            m_hookHelper.Hook = hook;

            // TODO:  Add ToolAddJunctionBarriers.OnCreate implementation
        }

        /// <summary>
        /// Occurs when this tool is clicked
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add ToolAddJunctionBarriers.OnClick implementation
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            //��ȡ�����λ�õĿռ��
            IPoint point = new PointClass();
            IActiveView activeView = m_hookHelper.ActiveView;
            point = activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
            IMap map = m_hookHelper.FocusMap;
            //IPointToEID�ӿ�����ͨ���ռ���ȡ��λ�õļ�������Ԫ��
            IPointToEID pointToEID = new PointToEIDClass();
            pointToEID.GeometricNetwork = geometricNetwork;
            pointToEID.SourceMap = map;
            pointToEID.SnapTolerance = 10;
            //ͨ��IPointToEID�ӿڵ�GetNearestJunction������ȡ���λ�����ڽ��Ĺܵ�Ԫ��
            int nearestJunctionEID = -1;
            IPoint outPoint = new PointClass();
            pointToEID.GetNearestJunction(point, out nearestJunctionEID, out outPoint);
            //�����ȡ�õ��ܵ�Ԫ��
            if (outPoint != null)
            {
                //���ùܵ��ϰ���ʶ�����������ܵ��ϰ���ʶ�б���
                listJunctionBarrierEIDs.Add(nearestJunctionEID);
                //���Ʋ���ʾ�ܵ��ϰ���ʶ
                ISimpleMarkerSymbol simpleMarkerSymbol = new SimpleMarkerSymbolClass();
                simpleMarkerSymbol.Color = FormMain.GetColorByRGBValue(255, 0, 0);
                simpleMarkerSymbol.Size = 12;
                simpleMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSX;
                IElement element = new MarkerElementClass();
                element.Geometry = outPoint;
                ((IMarkerElement)element).Symbol = simpleMarkerSymbol;
                ((IElementProperties)element).Name = "Barriers";
                ((IGraphicsContainer)activeView).AddElement(element, 0);
                activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, activeView.Extent);
            }
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ToolAddJunctionBarriers.OnMouseMove implementation
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ToolAddJunctionBarriers.OnMouseUp implementation
        }
        #endregion
    }
}
