namespace 地图整饰与输出
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
            this.file = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MapSurround = new System.Windows.Forms.ToolStripMenuItem();
            this.AddLegend = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNorthArrows = new System.Windows.Forms.ToolStripMenuItem();
            this.AddScaleBar = new System.Windows.Forms.ToolStripMenuItem();
            this.MapGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.AddGraticule = new System.Windows.Forms.ToolStripMenuItem();
            this.AddMeasuredGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.AddIndexGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportMap = new System.Windows.Forms.ToolStripMenuItem();
            this.Print = new System.Windows.Forms.ToolStripMenuItem();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.TOCControl = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.mainPagelayoutControl = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TOCControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPagelayoutControl)).BeginInit();
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
            this.file,
            this.MapSurround,
            this.MapGrid,
            this.SelectTemplate,
            this.ExportMap,
            this.Print});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(520, 25);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // file
            // 
            this.file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFile});
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(44, 21);
            this.file.Text = "文件";
            // 
            // OpenFile
            // 
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(100, 22);
            this.OpenFile.Text = "打开";
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // MapSurround
            // 
            this.MapSurround.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddLegend,
            this.AddNorthArrows,
            this.AddScaleBar});
            this.MapSurround.Name = "MapSurround";
            this.MapSurround.Size = new System.Drawing.Size(68, 21);
            this.MapSurround.Text = "地图要素";
            // 
            // AddLegend
            // 
            this.AddLegend.Name = "AddLegend";
            this.AddLegend.Size = new System.Drawing.Size(136, 22);
            this.AddLegend.Text = "添加图例";
            this.AddLegend.Click += new System.EventHandler(this.AddLegend_Click);
            // 
            // AddNorthArrows
            // 
            this.AddNorthArrows.Name = "AddNorthArrows";
            this.AddNorthArrows.Size = new System.Drawing.Size(136, 22);
            this.AddNorthArrows.Text = "添加指北针";
            this.AddNorthArrows.Click += new System.EventHandler(this.AddNorthArrows_Click);
            // 
            // AddScaleBar
            // 
            this.AddScaleBar.Name = "AddScaleBar";
            this.AddScaleBar.Size = new System.Drawing.Size(136, 22);
            this.AddScaleBar.Text = "添加比例尺";
            this.AddScaleBar.Click += new System.EventHandler(this.AddScaleBar_Click);
            // 
            // MapGrid
            // 
            this.MapGrid.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddGraticule,
            this.AddMeasuredGrid,
            this.AddIndexGrid});
            this.MapGrid.Name = "MapGrid";
            this.MapGrid.Size = new System.Drawing.Size(68, 21);
            this.MapGrid.Text = "地图格网";
            // 
            // AddGraticule
            // 
            this.AddGraticule.Name = "AddGraticule";
            this.AddGraticule.Size = new System.Drawing.Size(184, 22);
            this.AddGraticule.Text = "Graticule格网";
            this.AddGraticule.Click += new System.EventHandler(this.AddGraticuleh_Click);
            // 
            // AddMeasuredGrid
            // 
            this.AddMeasuredGrid.Name = "AddMeasuredGrid";
            this.AddMeasuredGrid.Size = new System.Drawing.Size(184, 22);
            this.AddMeasuredGrid.Text = "MeasuredGrid格网";
            this.AddMeasuredGrid.Click += new System.EventHandler(this.AddMeasuredGrid_Click);
            // 
            // AddIndexGrid
            // 
            this.AddIndexGrid.Name = "AddIndexGrid";
            this.AddIndexGrid.Size = new System.Drawing.Size(184, 22);
            this.AddIndexGrid.Text = "IndexGrid格网";
            this.AddIndexGrid.Click += new System.EventHandler(this.AddIndexGrid_Click);
            // 
            // SelectTemplate
            // 
            this.SelectTemplate.Name = "SelectTemplate";
            this.SelectTemplate.Size = new System.Drawing.Size(68, 21);
            this.SelectTemplate.Text = "制图模板";
            this.SelectTemplate.Click += new System.EventHandler(this.SelectTemplate_Click);
            // 
            // ExportMap
            // 
            this.ExportMap.Name = "ExportMap";
            this.ExportMap.Size = new System.Drawing.Size(44, 21);
            this.ExportMap.Text = "输出";
            this.ExportMap.Click += new System.EventHandler(this.ExportMap_Click);
            // 
            // Print
            // 
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(44, 21);
            this.Print.Text = "打印";
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Location = new System.Drawing.Point(3, 22);
            this.axToolbarControl1.Margin = new System.Windows.Forms.Padding(2);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(517, 28);
            this.axToolbarControl1.TabIndex = 28;
            // 
            // TOCControl
            // 
            this.TOCControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.TOCControl.Location = new System.Drawing.Point(0, 54);
            this.TOCControl.Margin = new System.Windows.Forms.Padding(2);
            this.TOCControl.Name = "TOCControl";
            this.TOCControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("TOCControl.OcxState")));
            this.TOCControl.Size = new System.Drawing.Size(139, 336);
            this.TOCControl.TabIndex = 29;
            // 
            // mainPagelayoutControl
            // 
            this.mainPagelayoutControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPagelayoutControl.Location = new System.Drawing.Point(144, 56);
            this.mainPagelayoutControl.Name = "mainPagelayoutControl";
            this.mainPagelayoutControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mainPagelayoutControl.OcxState")));
            this.mainPagelayoutControl.Size = new System.Drawing.Size(376, 334);
            this.mainPagelayoutControl.TabIndex = 30;
            this.mainPagelayoutControl.OnMouseDown += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseDownEventHandler(this.mainPagelayoutControl_OnMouseDown);
            this.mainPagelayoutControl.OnMouseUp += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseUpEventHandler(this.mainPagelayoutControl_OnMouseUp);
            this.mainPagelayoutControl.OnMouseMove += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseMoveEventHandler(this.mainPagelayoutControl_OnMouseMove);
            // 
            // frmMainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 391);
            this.Controls.Add(this.mainPagelayoutControl);
            this.Controls.Add(this.TOCControl);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMainUI";
            this.Text = "地图制图—地图整饰与输出";
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TOCControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPagelayoutControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem file;
        private System.Windows.Forms.ToolStripMenuItem OpenFile;
        private System.Windows.Forms.ToolStripMenuItem MapSurround;
        private System.Windows.Forms.ToolStripMenuItem AddLegend;
        private System.Windows.Forms.ToolStripMenuItem AddNorthArrows;
        private System.Windows.Forms.ToolStripMenuItem AddScaleBar;
        private System.Windows.Forms.ToolStripMenuItem SelectTemplate;
        private System.Windows.Forms.ToolStripMenuItem MapGrid;
        private System.Windows.Forms.ToolStripMenuItem AddMeasuredGrid;
        private System.Windows.Forms.ToolStripMenuItem AddIndexGrid;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.ToolStripMenuItem AddGraticule;
        private ESRI.ArcGIS.Controls.AxTOCControl TOCControl;
        private System.Windows.Forms.ToolStripMenuItem ExportMap;
        private System.Windows.Forms.ToolStripMenuItem Print;
        public ESRI.ArcGIS.Controls.AxPageLayoutControl mainPagelayoutControl;
    }
}

