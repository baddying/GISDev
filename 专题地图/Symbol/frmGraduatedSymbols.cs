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
    public partial class frmGraduatedSymbols : Form
    {
        List<IFeatureClass> _lstFeatCls = null;
        public delegate void GraduatedSymbolsEventHandler(string sFeatClsName, string sFieldName, int intnumclassess);
        public event GraduatedSymbolsEventHandler GraduatedSymbols = null;
        public frmGraduatedSymbols()
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
                MessageBox.Show("请选择分类数目！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 由图层名称获取该图层的字段
        /// </summary>
        /// <param name="sFeatClsName"></param>
        /// <returns></returns>
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
            IField pField = null;
            cmbSelField.Items.Clear();
            cmbSelField.Text = "";
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
            GraduatedSymbols(cmbSelLyr.SelectedItem.ToString(),
                cmbSelField.SelectedItem.ToString(),
                Convert.ToInt32(cmbnumclasses.SelectedItem.ToString()));
            cmbSelLyr.Items.Clear();
            cmbSelField.Items.Clear();
            cmbSelField.Text = "";
            cmbSelLyr.Text = "";
            cmbnumclasses.SelectedIndex = -1;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }       
    }
}
