using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using 专题地图.Class;

namespace 专题地图.Symbol
{
    public partial class frmGraduatedcolors : Form
    {
        List<IFeatureClass> _lstFeatCls = null;
        public delegate void GraduatedcolorsEventHandler(string sFeatClsName, string sFieldName, int intnumclassess);
        public event GraduatedcolorsEventHandler Graduatedcolors = null;
        public frmGraduatedcolors()
        {
            InitializeComponent();
        }
        private IMap _map;
        public IMap Map
        {
            get { return _map; }
            set { _map = value; }
        }
        public void InitUI()
        {
            string sClsName = string.Empty;
            cmbSelLyr.Items.Clear();
            IFeatureClass pFeatCls = null;         
            OperateMap _OperateMap = new OperateMap();
            _lstFeatCls = _OperateMap.GetLstFeatCls(_map);
            for (int i = 0; i < _lstFeatCls.Count; i++)
            {
                pFeatCls = _lstFeatCls[i];
                sClsName = pFeatCls.AliasName;
                if (!cmbSelLyr.Items.Contains(sClsName))
                {
                    cmbSelLyr.Items.Add(sClsName);
                }
            }
        }
        private bool check()
        {
            if (cmbSelLyr.SelectedIndex == -1)
            {
                MessageBox.Show("请选择符号化图层！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cmbSelField.SelectedIndex == -1)
            {
                MessageBox.Show("请选择符号化字段！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cmbnumclasses.SelectedIndex == -1)
            {
                MessageBox.Show("请选择颜色分级数目！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private IFeatureClass GetFeatClsByName(string sFeatClsName)
        {
            IFeatureClass pFeatCls = null;
            for (int i = 0; i < _lstFeatCls.Count; i++)
            {
                pFeatCls = _lstFeatCls[i];
                if (pFeatCls.AliasName == sFeatClsName)
                {
                    break;
                }
            }
            return pFeatCls;
        }

        private void cmbSelLyr_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSelField.Items.Clear();
            cmbSelField.Text = "";
            IField pField = null;
            IFeatureClass pFeatCls = GetFeatClsByName(cmbSelLyr.SelectedItem.ToString());
            for (int i = 0; i < pFeatCls.Fields.FieldCount; i++)
            {
                pField = pFeatCls.Fields.get_Field(i);
                if (pField.Type == esriFieldType.esriFieldTypeDouble ||
                    pField.Type == esriFieldType.esriFieldTypeInteger ||
                    pField.Type == esriFieldType.esriFieldTypeSingle ||
                    pField.Type == esriFieldType.esriFieldTypeSmallInteger)
                {
                    if (!cmbSelField.Items.Contains(pField.Name))
                    {
                        cmbSelField.Items.Add(pField.Name);
                    }
                }
            }             
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //GraduatedColors
            if (!check()) return;           
            Graduatedcolors(cmbSelLyr.SelectedItem.ToString(), 
                cmbSelField.SelectedItem.ToString(), 
                Convert.ToInt32(cmbnumclasses.SelectedItem.ToString()));
            cmbSelLyr.Items.Clear();
            cmbSelField.Items.Clear();
            cmbSelLyr.Text = "";
            cmbSelField.Text = "";
            cmbnumclasses.SelectedIndex = -1;
            Close();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Close();
        }            
       
    }
}
