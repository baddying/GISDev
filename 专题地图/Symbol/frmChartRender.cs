using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using System.Collections;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using 专题地图.Class;

namespace 专题地图.Symbol
{   
    public partial class frmChartRender : Form
    {
        List<IFeatureClass> _lstFeatCls = null;     
        public delegate void ChartRenderEventHandler(string sFeatClsName, Dictionary<string, IRgbColor> _dicFieldAndColor);
        public event ChartRenderEventHandler ChartRender = null;
        ArrayList fieldName1 = new ArrayList();     
        string item = "";
        private IMap _map;
        public IMap Map
        {
            get { return _map; }
            set { _map = value; }
        }
        public frmChartRender()
        {
            InitializeComponent();
        }
        public void InitUI()
        {
            string sClsName = string.Empty;
            IFeatureClass pFeatCls = null;
            cmbSelLayer.Items.Clear();
            OperateMap _OperateMap = new OperateMap();
            _lstFeatCls = _OperateMap.GetLstFeatCls(_map);
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
        bool Check()
        {
            if (cmbSelLayer.SelectedIndex == -1)
            {
                MessageBox.Show("请选择专题图层！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("请选择图层字段及所对应的颜色值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void cmbSelLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                IField pField = null;
                lstboxField.Items.Clear();              
                IFeatureClass pFeatCls = GetFeatClsByName(cmbSelLayer.SelectedItem.ToString());
                for (int i = 0; i < pFeatCls.Fields.FieldCount; i++)
                {
                    pField = pFeatCls.Fields.get_Field(i);
                    if (pField.Type == esriFieldType.esriFieldTypeDouble ||
                        pField.Type == esriFieldType.esriFieldTypeInteger ||
                        pField.Type == esriFieldType.esriFieldTypeSingle ||
                        pField.Type == esriFieldType.esriFieldTypeSmallInteger)
                    {
                        if (!lstboxField.Items.Contains(pField.Name))
                        {
                            lstboxField.Items.Add(pField.Name);                         
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }        
        /// <summary>
        /// 添加字段，并设置默认颜色为Blue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
          
        private void btnAddOne_Click(object sender, EventArgs e)
        {

            if (lstboxField.SelectedIndex == -1)
            {
                MessageBox.Show("请选择要添加字段！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            item = this.lstboxField.SelectedItem.ToString();
            lstboxField.Items.RemoveAt(lstboxField.SelectedIndex);
            string fName = item.ToString();
            fieldName1.Add(fName);
            dataGridView.Rows.Clear();
            for (int i = 0; i < fieldName1.Count; i = i + 1)
            {
                dataGridView.Rows.Add();
                dataGridView.Rows[i].Cells[0].Value = fieldName1[i];
                dataGridView.Rows[i].Cells[1].Value = fieldName1[i];
                dataGridView.Rows[i].Cells[2].Value = "Blue";
            }                    
        }
        /// <summary>
        /// 删除字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelOne_Click(object sender, EventArgs e)
        {
           
            int index = dataGridView.CurrentRow.Index;
            string fldname = dataGridView.Rows[index].Cells[0].Value.ToString();
            if (fieldName1.Contains(dataGridView.Rows[index].Cells[0].Value.ToString()))
            {
                fieldName1.Remove(dataGridView.Rows[index].Cells[0].Value.ToString());
            }
            lstboxField.Items.Add(fldname);
            dataGridView.Rows.RemoveAt(index);
            dataGridView.Refresh();
        }
        /// <summary>
        /// 添加多有字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddAll_Click(object sender, EventArgs e)
        {
            string item = string.Empty;
            for (int i = 0; i < lstboxField.Items.Count; i++)
            {
                fieldName1.Add(lstboxField.Items[i].ToString());
            }
            dataGridView.Rows.Clear();
            for (int i = 0; i < fieldName1.Count; i++)
            {
                item = fieldName1[i].ToString();
                dataGridView.Rows.Add();
                dataGridView.Rows[i].Cells[0].Value = item;
                dataGridView.Rows[i].Cells[1].Value = item;
                dataGridView.Rows[i].Cells[2].Value = "Blue";
            }
            lstboxField.Items.Clear();
        }
        /// <summary>
        /// 删除所有字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                if (!lstboxField.Items.Contains(dataGridView.Rows[i].Cells[0].Value.ToString()))
                {
                    lstboxField.Items.Add(dataGridView.Rows[i].Cells[0].Value.ToString());
                }
            }
            dataGridView.Rows.Clear();          
        }  
        /// <summary>
        /// 添加字段，并设置字段对应的颜色，存储在_dicFieldAndColor中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!Check()) return;
            Color pFrmColor;
            IRgbColor pRgbColor = null;
            OperateMap m_OperMap = new OperateMap();
            string sFieldName = string.Empty;
            Dictionary<string, IRgbColor> _dicFieldAndColor = null;
            _dicFieldAndColor = new Dictionary<string, IRgbColor>();
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                sFieldName = dataGridView.Rows[i].Cells[0].Value.ToString();
                switch (dataGridView.Rows[i].Cells[2].Value.ToString())
                {
                    case "Red":
                        pFrmColor = Color.Red;
                        break;
                    case "Blue":
                        pFrmColor = Color.Blue;
                        break;
                    case "Green":
                        pFrmColor = Color.Green;
                        break;
                    case "Brown":
                        pFrmColor = Color.Brown;
                        break;
                    default:
                        pFrmColor = Color.Yellow;
                        break;
                }
                pRgbColor = m_OperMap.GetRgbColor((int)pFrmColor.R, (int)pFrmColor.G, (int)pFrmColor.B); 
                if (!_dicFieldAndColor.ContainsKey(sFieldName))
                {
                    _dicFieldAndColor.Add(sFieldName, pRgbColor);
                }
            }
            ChartRender(cmbSelLayer.SelectedItem.ToString(), _dicFieldAndColor);
            fieldName1.Clear();
            cmbSelLayer.SelectedIndex = -1;
            cmbSelLayer.Text = "";
            dataGridView.Rows.Clear();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }                                         
    }
}
