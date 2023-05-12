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
using System.Collections;

namespace 专题地图.Symbol
{
    public partial class frmUniqueValueMany_fields : Form
    {
        private IMap _map;
        List<IFeatureClass> _lstFeatCls = null;
        public delegate void UniqueValueRenderEventHandler(string sFeatClsName, string[] sFieldName);
        public event UniqueValueRenderEventHandler UniqueValueRender = null;
        public frmUniqueValueMany_fields()
        {
            InitializeComponent();
        }
        public IMap Map
        {
            get { return _map; }
            set { _map = value; }
        }
        public void InitUI()
        {
            dataGridView.Rows.Clear();            
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
                    //以下代码为判断该图层所含数值字段的个数，如果小于等于2，则将该字段从
                    //cmbSelLyr中移除
                    int m = 0;
                    IFeatureClass pFeatureClass = GetFeatClsByName(sClsName);
                    for (int n = 0; n< pFeatCls.Fields.FieldCount; n++)
                    {
                        IField  pField = pFeatCls.Fields.get_Field(n);
                        //判断字段的数据类型是否为数字类型
                        if (pField.Type == esriFieldType.esriFieldTypeDouble ||
                            pField.Type == esriFieldType.esriFieldTypeInteger ||
                            pField.Type == esriFieldType.esriFieldTypeSingle ||
                            pField.Type == esriFieldType.esriFieldTypeSmallInteger)
                        {                            
                            m++;                           
                        }
                    }
                    if (m <= 1)
                    {
                        cmbSelLyr.Items.Remove(sClsName);
                    }                
                }
            }
        }
        IFeatureClass pFeatCls;      
        private void cmbSelLyr_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                IField pField = null;
                lstboxField.Items.Clear();              
                pFeatCls = GetFeatClsByName(cmbSelLyr.SelectedItem.ToString());
                for (int i = 0; i < pFeatCls.Fields.FieldCount; i++)
                {
                    pField = pFeatCls.Fields.get_Field(i);
                    //判断字段的数据类型是否为数字类型
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
        /// 由图层名称，获取该图层
        /// </summary>
        /// <param name="sFeatClsName">图层名称</param>
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
        string item = "";
        ArrayList fieldName = new ArrayList();//定义一个数组，用来存储lstboxField选中的值

        private void btnAddOne_Click(object sender, EventArgs e)
        {          
            if (lstboxField.SelectedIndex == -1)
            {
                MessageBox.Show("请选择要添加字段！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            item = this.lstboxField.SelectedItem.ToString();
            lstboxField.Items.RemoveAt(lstboxField.SelectedIndex);
            string fName = item;          
            fieldName.Add(fName);
            dataGridView.Rows.Clear();
            for (int i = 0; i < fieldName.Count; i++)
            {               
                dataGridView.Rows.Add();
                dataGridView.Rows[i].Cells[0].Value = fieldName[i];
            }         
        }
        private void btnDelOne_Click(object sender, EventArgs e)
        {
            
            int index = dataGridView.CurrentRow.Index;                
            string fldname = dataGridView.Rows[index].Cells[0].Value.ToString();
            if (fieldName.Contains(dataGridView.Rows[index].Cells[0].Value.ToString()))
            {              
                fieldName.Remove(dataGridView.Rows[index].Cells[0].Value.ToString());
            }
            lstboxField.Items.Add(fldname);           
            dataGridView.Rows.RemoveAt(index);           
            dataGridView.Refresh();
        }             
        private void btnOK_Click(object sender, EventArgs e)
        {
            string[] add;
            if (dataGridView.Rows.Count <= 2)//因为dataGridView1包含一个空行
            {
                MessageBox.Show("所选的字段数不能少于2个");
                dataGridView.Rows.Clear();
                fieldName.Clear();              
                lstboxField.Items.Clear();
                cmbSelLyr.Items.Clear();
            }
            else if (dataGridView.Rows.Count >= 5)
            {
                MessageBox.Show("所选的字段数不能超过3个");
                dataGridView.Rows.Clear();
                fieldName.Clear();
                lstboxField.Items.Clear();
                cmbSelLyr.Items.Clear();             
            }
            if (dataGridView.Rows.Count == 3)
            {              
                add = new string[2];
                for (int i = 0; i < 2; i++)
                {
                    add[i] = dataGridView.Rows[i].Cells[0].Value.ToString();
                }
                UniqueValueRender(cmbSelLyr.SelectedItem.ToString(), add);
                fieldName.Clear();
            }
            else if (dataGridView.Rows.Count == 4)
            {              
                add = new string[3];
                for (int i = 0; i < 3; i++)
                {
                    add[i] = dataGridView.Rows[i].Cells[0].Value.ToString();
                }
                UniqueValueRender(cmbSelLyr.SelectedItem.ToString(), add);
                fieldName.Clear();
            }
            cmbSelLyr.Text = "";
            lstboxField.Items.Clear();
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            fieldName.Clear();
            this.Close();
        }

    }
}
