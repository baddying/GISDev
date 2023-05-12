using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArcMapAddin4Z
{
    public partial class FrmAddPara : Form
    {
        List<ILayer> lyrLst=new List<ILayer>();
        public FrmAddPara(List<ILayer> lyrs)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;//允许跨线程
            lyrLst = lyrs;
        }

        private void FrmAddPara_Load(object sender, EventArgs e)
        {
            foreach (var item in lyrLst)
            {
                cBoxLyr.Items.Add(item.Name);
            }
          
            cBoxLyr.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnOk.Enabled = false;
            backgroundWorker.RunWorkerAsync();
            progressBar.Visible = true;

        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int id = cBoxLyr.SelectedIndex;
            IFeatureLayer fLyr = lyrLst[id] as IFeatureLayer;
            IFeatureClass fc = fLyr.FeatureClass;

            string minxFN = tb_minx.Text.Trim();
            if (fc.Fields.FindField(minxFN) < 0)
            {
                IField newField = new FieldClass();
                IFieldEdit fieldEdit = (IFieldEdit)newField;
                fieldEdit.Name_2 = minxFN;
                //数据类型，这里以字符型为例
                fieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
                //字段是否允许为空
                fieldEdit.IsNullable_2 = false;
                fc.AddField(newField);
            }

            string maxxFN = tb_maxx.Text.Trim();
            if (fc.Fields.FindField(maxxFN) < 0)
            {
                IField newField = new FieldClass();
                IFieldEdit fieldEdit = (IFieldEdit)newField;
                fieldEdit.Name_2 = maxxFN;
                //数据类型，这里以字符型为例
                fieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
                //字段是否允许为空
                fieldEdit.IsNullable_2 = false;
                fc.AddField(newField);
            }

            string maxyFN = tb_maxy.Text.Trim();
            if (fc.Fields.FindField(maxyFN) < 0)
            {
                IField newField = new FieldClass();
                IFieldEdit fieldEdit = (IFieldEdit)newField;
                fieldEdit.Name_2 = maxyFN;
                //数据类型，这里以字符型为例
                fieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
                //字段是否允许为空
                fieldEdit.IsNullable_2 = false;
                fc.AddField(newField);
            }
            string minyFN = tb_miny.Text.Trim();

            if (fc.Fields.FindField(minyFN) < 0)
            {
                IField newField = new FieldClass();
                IFieldEdit fieldEdit = (IFieldEdit)newField;
                fieldEdit.Name_2 = minyFN;
                //数据类型，这里以字符型为例
                fieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
                //字段是否允许为空
                fieldEdit.IsNullable_2 = false;
                fc.AddField(newField);
            }

            int fid_minx = fc.FindField(minxFN);
            int fid_maxx = fc.FindField(maxxFN);
            int fid_miny = fc.FindField(minyFN);
            int fid_maxy = fc.FindField(maxyFN);

            int featCount = fc.FeatureCount(null);
            IFeatureCursor fCur = fc.Update(null, false);
            IFeature feat = fCur.NextFeature();

            int curid = 0;

            while (feat != null)//遍历要素
            {
                IGeometry geo = feat.Shape;
                double maxx = feat.Extent.XMax;
                double minx = feat.Extent.XMin;
                double maxy = feat.Extent.YMax;
                double miny = feat.Extent.YMin;
                //写入四至坐标
                feat.set_Value(fid_minx, minx);
                feat.set_Value(fid_maxx, maxx);
                feat.set_Value(fid_miny, miny);
                feat.set_Value(fid_maxy, maxy);

                fCur.UpdateFeature(feat);
                curid++;
                backgroundWorker.ReportProgress((int)(100.0d * (double)curid / (double)featCount));

                feat = fCur.NextFeature();
           
            }

        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnOk.Enabled = true;
            progressBar.Visible = false;
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
            this.Close();
        }
    }
}
