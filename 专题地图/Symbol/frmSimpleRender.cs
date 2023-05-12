using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 专题地图.Class;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;

namespace 专题地图.Symbol
{
     
    public partial class frmSimpleRender : Form
    {
        int r, g, b;
        List<IFeatureClass> _lstFeatCls = null;
        public delegate void SimpleRenderEventHandler(string sFeatClsName, IRgbColor pRgbColr);
        public event SimpleRenderEventHandler SimpleRender = null;
        public frmSimpleRender()
        {
            InitializeComponent();
        }
        private IMap _pMap;
        public IMap PMap
        {
            get { return _pMap; }
            set { _pMap = value; }
        }

        public void InitUI()
        {
            string sClsName = string.Empty;
            IFeatureClass pFeatCls = null;
            cmbSelLayer.Items.Clear();
            OperateMap _OperateMap = new OperateMap();
            _lstFeatCls = _OperateMap.GetLstFeatCls(_pMap);
            for (int i = 0; i < _lstFeatCls.Count; i++)
            {
                pFeatCls = _lstFeatCls[i];
                sClsName = pFeatCls.AliasName;
                if (!cmbSelLayer.Items.Contains(sClsName))
                {
                    cmbSelLayer.Items.Add(sClsName);
                }
            }
        }

        private bool check()
        {
            if (cmbSelLayer.SelectedIndex == -1)
            {
                MessageBox.Show("请选择符号化图层！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!check()) return;
            //System.Drawing.Color m_Color;           
            int m_Red = r;
            int m_Green = g;
            int m_Blue = b;
            OperateMap m_OperMap = new OperateMap();
            IRgbColor pRgbColor = m_OperMap.GetRgbColor(m_Red, m_Green, m_Blue);
            SimpleRender(cmbSelLayer.SelectedItem.ToString(), pRgbColor);
            cmbSelLayer.Items.Clear();
            cmbSelLayer.Text = "";
            Close();                      
        }        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormSimpleRender_Load(object sender, EventArgs e)
        {
            colorEditSimple.Items.Clear();
            colorEditSimple.Items.Add("Black");
            colorEditSimple.Items.Add("Red");
            colorEditSimple.Items.Add("Green");
            colorEditSimple.Items.Add("IndianRed");
            colorEditSimple.Items.Add("LightBlue");
        }

        private void colorEditSimple_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                SolidBrush brush = new SolidBrush(Color.FromName(colorEditSimple.Items[e.Index].ToString()));
                Rectangle rect = e.Bounds;
                rect.Inflate(-2, -2);
                Rectangle rectColor = new Rectangle(rect.Location, new Size(10, rect.Height));
                Rectangle rectColor1 = new Rectangle(rect.Location.X + 30, rect.Location.Y, 18, rect.Height);
                e.Graphics.FillRectangle(brush, rectColor);
                System.Drawing.Font font = new Font("宋体", 10, FontStyle.Bold);
                e.Graphics.DrawString(colorEditSimple.Items[e.Index].ToString(), font, Brushes.Blue, (rect.X + 30), rect.Y);
            }
        }

        private void colorEditSimple_SelectedIndexChanged(object sender, EventArgs e)
        {            
              r = Color.FromName(colorEditSimple.SelectedItem.ToString()).R;
              g = Color.FromName(colorEditSimple.SelectedItem.ToString()).G;
              b = Color.FromName(colorEditSimple.SelectedItem.ToString()).B;
        }     
    }
}
