namespace 专题地图
{
    partial class frmMainUI
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainUI));
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Openfile = new System.Windows.Forms.ToolStripMenuItem();
            this.Savefile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.SingleSymbol = new System.Windows.Forms.ToolStripMenuItem();
            this.Categories = new System.Windows.Forms.ToolStripMenuItem();
            this.UniqueValue = new System.Windows.Forms.ToolStripMenuItem();
            this.UniqueValuesManyFileds = new System.Windows.Forms.ToolStripMenuItem();
            this.Quantitatives = new System.Windows.Forms.ToolStripMenuItem();
            this.Graduatedcolor = new System.Windows.Forms.ToolStripMenuItem();
            this.Graduatedsymbol = new System.Windows.Forms.ToolStripMenuItem();
            this.Proportionalsymbol = new System.Windows.Forms.ToolStripMenuItem();
            this.Dotdensitys = new System.Windows.Forms.ToolStripMenuItem();
            this.Charts = new System.Windows.Forms.ToolStripMenuItem();
            this.Pie = new System.Windows.Forms.ToolStripMenuItem();
            this.Bar = new System.Windows.Forms.ToolStripMenuItem();
            this.Stacked = new System.Windows.Forms.ToolStripMenuItem();
            this.Bivariate = new System.Windows.Forms.ToolStripMenuItem();
            this.ScaleDependent = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.mainTOCControl = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainMapControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainTOCControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(12, 94);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.SingleSymbol,
            this.Categories,
            this.Quantitatives,
            this.Charts,
            this.Bivariate,
            this.ScaleDependent});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(593, 25);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Openfile,
            this.Savefile,
            this.SaveAs});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // Openfile
            // 
            this.Openfile.Name = "Openfile";
            this.Openfile.Size = new System.Drawing.Size(112, 22);
            this.Openfile.Text = "打开";
            this.Openfile.Click += new System.EventHandler(this.Openfile_Click);
            // 
            // Savefile
            // 
            this.Savefile.Name = "Savefile";
            this.Savefile.Size = new System.Drawing.Size(112, 22);
            this.Savefile.Text = "保存";
            this.Savefile.Click += new System.EventHandler(this.Savefile_Click);
            // 
            // SaveAs
            // 
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.Size = new System.Drawing.Size(112, 22);
            this.SaveAs.Text = "另存为";
            this.SaveAs.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // SingleSymbol
            // 
            this.SingleSymbol.Name = "SingleSymbol";
            this.SingleSymbol.Size = new System.Drawing.Size(80, 21);
            this.SingleSymbol.Text = "单一符号化";
            this.SingleSymbol.Click += new System.EventHandler(this.SingleSymbol_Click);
            // 
            // Categories
            // 
            this.Categories.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UniqueValue,
            this.UniqueValuesManyFileds});
            this.Categories.Name = "Categories";
            this.Categories.Size = new System.Drawing.Size(80, 21);
            this.Categories.Text = "类别符号化";
            // 
            // UniqueValue
            // 
            this.UniqueValue.Name = "UniqueValue";
            this.UniqueValue.Size = new System.Drawing.Size(152, 22);
            this.UniqueValue.Text = "唯一值符号化";
            this.UniqueValue.Click += new System.EventHandler(this.UniqueValue_Click);
            // 
            // UniqueValuesManyFileds
            // 
            this.UniqueValuesManyFileds.Name = "UniqueValuesManyFileds";
            this.UniqueValuesManyFileds.Size = new System.Drawing.Size(152, 22);
            this.UniqueValuesManyFileds.Text = "唯一值多字段";
            this.UniqueValuesManyFileds.Click += new System.EventHandler(this.UniqueValuesManyFileds_Click);
            // 
            // Quantitatives
            // 
            this.Quantitatives.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Graduatedcolor,
            this.Graduatedsymbol,
            this.Proportionalsymbol,
            this.Dotdensitys});
            this.Quantitatives.Name = "Quantitatives";
            this.Quantitatives.Size = new System.Drawing.Size(80, 21);
            this.Quantitatives.Text = "定量符号化";
            // 
            // Graduatedcolor
            // 
            this.Graduatedcolor.Name = "Graduatedcolor";
            this.Graduatedcolor.Size = new System.Drawing.Size(152, 22);
            this.Graduatedcolor.Text = "分级色彩";
            this.Graduatedcolor.Click += new System.EventHandler(this.Graduatedcolor_Click);
            // 
            // Graduatedsymbol
            // 
            this.Graduatedsymbol.Name = "Graduatedsymbol";
            this.Graduatedsymbol.Size = new System.Drawing.Size(152, 22);
            this.Graduatedsymbol.Text = "分级符号";
            this.Graduatedsymbol.Click += new System.EventHandler(this.Graduatedsymbol_Click);
            // 
            // Proportionalsymbol
            // 
            this.Proportionalsymbol.Name = "Proportionalsymbol";
            this.Proportionalsymbol.Size = new System.Drawing.Size(152, 22);
            this.Proportionalsymbol.Text = "比例符号";
            this.Proportionalsymbol.Click += new System.EventHandler(this.Proportionalsymbol_Click);
            // 
            // Dotdensitys
            // 
            this.Dotdensitys.Name = "Dotdensitys";
            this.Dotdensitys.Size = new System.Drawing.Size(152, 22);
            this.Dotdensitys.Text = "点密度";
            this.Dotdensitys.Click += new System.EventHandler(this.Dotdensitys_Click);
            // 
            // Charts
            // 
            this.Charts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Pie,
            this.Bar,
            this.Stacked});
            this.Charts.Name = "Charts";
            this.Charts.Size = new System.Drawing.Size(104, 21);
            this.Charts.Text = "统计图表符号化";
            // 
            // Pie
            // 
            this.Pie.Name = "Pie";
            this.Pie.Size = new System.Drawing.Size(152, 22);
            this.Pie.Text = "饼图";
            this.Pie.Click += new System.EventHandler(this.Pie_Click);
            // 
            // Bar
            // 
            this.Bar.Name = "Bar";
            this.Bar.Size = new System.Drawing.Size(152, 22);
            this.Bar.Text = "条形图";
            this.Bar.Click += new System.EventHandler(this.Bar_Click);
            // 
            // Stacked
            // 
            this.Stacked.Name = "Stacked";
            this.Stacked.Size = new System.Drawing.Size(152, 22);
            this.Stacked.Text = "堆叠图";
            this.Stacked.Click += new System.EventHandler(this.Stacked_Click);
            // 
            // Bivariate
            // 
            this.Bivariate.Name = "Bivariate";
            this.Bivariate.Size = new System.Drawing.Size(80, 21);
            this.Bivariate.Text = "双值符号化";
            this.Bivariate.Click += new System.EventHandler(this.Bivariate_Click);
            // 
            // ScaleDependent
            // 
            this.ScaleDependent.Name = "ScaleDependent";
            this.ScaleDependent.Size = new System.Drawing.Size(104, 21);
            this.ScaleDependent.Text = "多比例尺符号化";
            this.ScaleDependent.Click += new System.EventHandler(this.ScaleDependent_Click);
            // 
            // mainMapControl
            // 
            this.mainMapControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainMapControl.Location = new System.Drawing.Point(152, 66);
            this.mainMapControl.Name = "mainMapControl";
            this.mainMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mainMapControl.OcxState")));
            this.mainMapControl.Size = new System.Drawing.Size(441, 323);
            this.mainMapControl.TabIndex = 0;
            // 
            // mainTOCControl
            // 
            this.mainTOCControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.mainTOCControl.Location = new System.Drawing.Point(0, 66);
            this.mainTOCControl.Name = "mainTOCControl";
            this.mainTOCControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mainTOCControl.OcxState")));
            this.mainTOCControl.Size = new System.Drawing.Size(150, 323);
            this.mainTOCControl.TabIndex = 26;
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 31);
            this.axToolbarControl1.Margin = new System.Windows.Forms.Padding(2);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(782, 28);
            this.axToolbarControl1.TabIndex = 28;
            // 
            // frmMainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 391);
            this.Controls.Add(this.mainMapControl);
            this.Controls.Add(this.mainTOCControl);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMainUI";
            this.Text = "地图制图—专题地图";
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainMapControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainTOCControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxMapControl mainMapControl;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private ESRI.ArcGIS.Controls.AxTOCControl mainTOCControl;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Openfile;
        private System.Windows.Forms.ToolStripMenuItem Savefile;
        private System.Windows.Forms.ToolStripMenuItem SaveAs;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.ToolStripMenuItem SingleSymbol;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Categories;
        private System.Windows.Forms.ToolStripMenuItem UniqueValue;
        private System.Windows.Forms.ToolStripMenuItem UniqueValuesManyFileds;
        private System.Windows.Forms.ToolStripMenuItem Quantitatives;
        private System.Windows.Forms.ToolStripMenuItem Graduatedcolor;
        private System.Windows.Forms.ToolStripMenuItem Graduatedsymbol;
        private System.Windows.Forms.ToolStripMenuItem Proportionalsymbol;
        private System.Windows.Forms.ToolStripMenuItem Dotdensitys;
        private System.Windows.Forms.ToolStripMenuItem Charts;
        private System.Windows.Forms.ToolStripMenuItem Pie;
        private System.Windows.Forms.ToolStripMenuItem Bar;
        private System.Windows.Forms.ToolStripMenuItem Stacked;
        private System.Windows.Forms.ToolStripMenuItem Bivariate;
        private System.Windows.Forms.ToolStripMenuItem ScaleDependent;
    }
}

