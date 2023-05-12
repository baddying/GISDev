// Copyright 2010 ESRI
// 
// All rights reserved under the copyright laws of the United States
// and applicable international laws, treaties, and conventions.
// 
// You may freely redistribute and use this sample code, with or
// without modification, provided you include the original copyright
// notice and use restrictions.
// 
// See the use restrictions at &lt;your ArcGIS install location&gt;/DeveloperKit10.0/userestrictions.txt.
// 

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using ESRI.ArcGIS.Display;

namespace TextSymbols
{

	public class frmSymbol : System.Windows.Forms.Form
	{
		private ESRI.ArcGIS.Controls.AxSymbologyControl mainSymbologyControl;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.ComponentModel.Container components = null;
		private IStyleGalleryItem m_StyleGalleryItem; 

		public frmSymbol()
		{
			InitializeComponent();
		}
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSymbol));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.mainSymbologyControl = new ESRI.ArcGIS.Controls.AxSymbologyControl();
            ((System.ComponentModel.ISupportInitialize)(this.mainSymbologyControl)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(144, 310);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(249, 310);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // mainSymbologyControl
            // 
            this.mainSymbologyControl.Location = new System.Drawing.Point(10, 9);
            this.mainSymbologyControl.Name = "mainSymbologyControl";
            this.mainSymbologyControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mainSymbologyControl.OcxState")));
            this.mainSymbologyControl.Size = new System.Drawing.Size(318, 293);
            this.mainSymbologyControl.TabIndex = 0;
            this.mainSymbologyControl.OnItemSelected += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnItemSelectedEventHandler(this.mainSymbologyControl_OnItemSelected);
            // 
            // frmSymbol
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(336, 337);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.mainSymbologyControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmSymbol";
            this.Text = "文本符号选择器";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainSymbologyControl)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion             
        /// <summary>
        /// 当窗体载入的时候在SymbologyControl载入文本样式符号库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Load(object sender, System.EventArgs e)
        {                   
            string path = Application.StartupPath + "\\ESRI.ServerStyle";
            //载入文本样式符号库           
            mainSymbologyControl.LoadStyleFile(path);
            #region 不同的方式载入系统符号
            //string sInstall = ESRI.ArcGIS.RuntimeManager.ActiveRuntime.Path;
            ////mainSymbologyControl.LoadStyleFile(sInstall + "\\Styles\\ESRI.ServerStyle");
            #endregion
        }
        /// <summary>
        /// 获取在SymbologyControl中选择的文本样式
        /// </summary>
        /// <param name="styleClass"></param>
        /// <returns></returns>
        public IStyleGalleryItem GetItem(ESRI.ArcGIS.Controls.esriSymbologyStyleClass styleClass)
        {
            m_StyleGalleryItem = null;
            btnOK.Enabled = false;

            mainSymbologyControl.StyleClass = styleClass;
            mainSymbologyControl.GetStyleClass(styleClass).UnselectItem();


            this.ShowDialog();
            //返回值为已选择的文本样式
            return m_StyleGalleryItem;
        }
        /// <summary>
        /// 获取在SymbologyControl中选择的文本样式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainSymbologyControl_OnItemSelected(object sender, ESRI.ArcGIS.Controls.ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            //获取以选择的字体样式
            m_StyleGalleryItem = mainSymbologyControl.GetStyleClass(mainSymbologyControl.StyleClass).GetSelectedItem();
            //Enable ok button
            btnOK.Enabled = true; 
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_StyleGalleryItem = null;
            Close();
        }              
	}
}
