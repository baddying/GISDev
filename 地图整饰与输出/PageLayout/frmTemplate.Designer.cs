namespace 地图整饰与输出.PageLayout
{
    partial class frmTemplate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTemplate));
            this.tlstTemplate = new System.Windows.Forms.TreeView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pageLayoutCtrlMxt = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            ((System.ComponentModel.ISupportInitialize)(this.pageLayoutCtrlMxt)).BeginInit();
            this.SuspendLayout();
            // 
            // tlstTemplate
            // 
            this.tlstTemplate.Location = new System.Drawing.Point(1, 12);
            this.tlstTemplate.Name = "tlstTemplate";
            this.tlstTemplate.Size = new System.Drawing.Size(133, 333);
            this.tlstTemplate.TabIndex = 1;
            this.tlstTemplate.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tlstTemplate_NodeMouseClick);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(190, 353);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "应用";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(316, 353);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pageLayoutCtrlMxt
            // 
            this.pageLayoutCtrlMxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pageLayoutCtrlMxt.Location = new System.Drawing.Point(140, 12);
            this.pageLayoutCtrlMxt.Name = "pageLayoutCtrlMxt";
            this.pageLayoutCtrlMxt.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pageLayoutCtrlMxt.OcxState")));
            this.pageLayoutCtrlMxt.Size = new System.Drawing.Size(299, 333);
            this.pageLayoutCtrlMxt.TabIndex = 0;
            // 
            // frmTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 388);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tlstTemplate);
            this.Controls.Add(this.pageLayoutCtrlMxt);
            this.Name = "frmTemplate";
            this.Text = "模板预览";
            ((System.ComponentModel.ISupportInitialize)(this.pageLayoutCtrlMxt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxPageLayoutControl pageLayoutCtrlMxt;
        private System.Windows.Forms.TreeView tlstTemplate;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
    }
}