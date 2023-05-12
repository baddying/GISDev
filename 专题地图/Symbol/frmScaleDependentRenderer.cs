using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using 专题地图.Class;
using ESRI.ArcGIS.Carto;

namespace 专题地图.Symbol
{
    public partial class frmScaleDependentRenderer : Form
    {
        List<IFeatureClass> _lstFeatCls = null;
        public delegate void ScaleDependentRendererEventHandler(string sFeatClsName, string sFieldName, int numclasses);
        public event ScaleDependentRendererEventHandler ScaleDependentRenderer = null;
        public frmScaleDependentRenderer()
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
            IFeatureClass pFeatCls = null;
            cmbSelLyr.Items.Clear();
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
            return true;
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!check()) return;
            ScaleDependentRenderer(cmbSelLyr.SelectedItem.ToString(), cmbSelField.SelectedItem.ToString(), Convert.ToInt32(cmbnumclasses.SelectedItem.ToString()));
            cmbSelField.Items.Clear();
            cmbSelField.Text = "";
            cmbSelLyr.Items.Clear();
            cmbSelLyr.Text = "";
            cmbnumclasses.SelectedIndex = -1;
            Close();  
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            Close(); 
        }

    }
}
