namespace EditSDELayerDemo
{
    partial class MainFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrom));
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuFileOperate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemOpenMxd = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAddData = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSaveMxd = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExportJPEG = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemCloseMap = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.空间拓扑分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBufferAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGetFeatureBoundary = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemFeaAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.btnQueryNearFeature = new System.Windows.Forms.ToolStripMenuItem();
            this.叠加分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClipAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDataConvert = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShapeToFileGeodatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemShapeToCAD = new System.Windows.Forms.ToolStripMenuItem();
            this.添加XY数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExcelXYToPoint = new System.Windows.Forms.ToolStripMenuItem();
            this.gP工具调用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGPBuffer = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGPShapeaToCAD = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.MessageLable = new System.Windows.Forms.ToolStripLabel();
            this.Blank = new System.Windows.Forms.ToolStripLabel();
            this.ScaleLabel = new System.Windows.Forms.ToolStripLabel();
            this.CoordinateLabel = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip5.SuspendLayout();
            this.SuspendLayout();
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 25);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(845, 28);
            this.axToolbarControl1.TabIndex = 1;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(286, 225);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 2;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.axTOCControl1.Location = new System.Drawing.Point(0, 53);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(170, 379);
            this.axTOCControl1.TabIndex = 3;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(170, 53);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(675, 379);
            this.axMapControl1.TabIndex = 4;
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFileOperate,
            this.空间拓扑分析ToolStripMenuItem,
            this.MenuItemFeaAnalysis,
            this.叠加分析ToolStripMenuItem,
            this.MenuItemDataConvert,
            this.添加XY数据ToolStripMenuItem,
            this.gP工具调用ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(845, 25);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuFileOperate
            // 
            this.MenuFileOperate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemOpenMxd,
            this.MenuItemAddData,
            this.MenuItemSaveMxd,
            this.MenuItemExportJPEG,
            this.toolStripSeparator2,
            this.MenuItemCloseMap,
            this.MenuItemExit});
            this.MenuFileOperate.Name = "MenuFileOperate";
            this.MenuFileOperate.Size = new System.Drawing.Size(68, 21);
            this.MenuFileOperate.Text = "文件操作";
            // 
            // MenuItemOpenMxd
            // 
            this.MenuItemOpenMxd.Name = "MenuItemOpenMxd";
            this.MenuItemOpenMxd.Size = new System.Drawing.Size(129, 22);
            this.MenuItemOpenMxd.Text = "打开MXD";
            this.MenuItemOpenMxd.Click += new System.EventHandler(this.MenuItemOpenMxd_Click);
            // 
            // MenuItemAddData
            // 
            this.MenuItemAddData.Name = "MenuItemAddData";
            this.MenuItemAddData.Size = new System.Drawing.Size(129, 22);
            this.MenuItemAddData.Text = "图层加载";
            this.MenuItemAddData.Click += new System.EventHandler(this.MenuItemAddData_Click);
            // 
            // MenuItemSaveMxd
            // 
            this.MenuItemSaveMxd.Name = "MenuItemSaveMxd";
            this.MenuItemSaveMxd.Size = new System.Drawing.Size(129, 22);
            this.MenuItemSaveMxd.Text = "保存MXD";
            this.MenuItemSaveMxd.Click += new System.EventHandler(this.MenuItemSaveMxd_Click);
            // 
            // MenuItemExportJPEG
            // 
            this.MenuItemExportJPEG.Name = "MenuItemExportJPEG";
            this.MenuItemExportJPEG.Size = new System.Drawing.Size(129, 22);
            this.MenuItemExportJPEG.Text = "导出JPEG";
            this.MenuItemExportJPEG.Click += new System.EventHandler(this.MenuItemExportJPEG_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(126, 6);
            // 
            // MenuItemCloseMap
            // 
            this.MenuItemCloseMap.Name = "MenuItemCloseMap";
            this.MenuItemCloseMap.Size = new System.Drawing.Size(129, 22);
            this.MenuItemCloseMap.Text = "关闭图层";
            this.MenuItemCloseMap.Click += new System.EventHandler(this.MenuItemCloseMap_Click);
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.Size = new System.Drawing.Size(129, 22);
            this.MenuItemExit.Text = "退出系统";
            this.MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // 空间拓扑分析ToolStripMenuItem
            // 
            this.空间拓扑分析ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBufferAnalysis,
            this.btnGetFeatureBoundary});
            this.空间拓扑分析ToolStripMenuItem.Name = "空间拓扑分析ToolStripMenuItem";
            this.空间拓扑分析ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.空间拓扑分析ToolStripMenuItem.Text = "空间拓扑分析";
            // 
            // btnBufferAnalysis
            // 
            this.btnBufferAnalysis.Name = "btnBufferAnalysis";
            this.btnBufferAnalysis.Size = new System.Drawing.Size(148, 22);
            this.btnBufferAnalysis.Text = "缓冲区分析";
            this.btnBufferAnalysis.Click += new System.EventHandler(this.btnBufferAnalysis_Click);
            // 
            // btnGetFeatureBoundary
            // 
            this.btnGetFeatureBoundary.Name = "btnGetFeatureBoundary";
            this.btnGetFeatureBoundary.Size = new System.Drawing.Size(148, 22);
            this.btnGetFeatureBoundary.Text = "获取要素边界";
            this.btnGetFeatureBoundary.Click += new System.EventHandler(this.btnFeatureBoundary_Click);
            // 
            // MenuItemFeaAnalysis
            // 
            this.MenuItemFeaAnalysis.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQueryNearFeature});
            this.MenuItemFeaAnalysis.Name = "MenuItemFeaAnalysis";
            this.MenuItemFeaAnalysis.Size = new System.Drawing.Size(92, 21);
            this.MenuItemFeaAnalysis.Text = "空间关系运算";
            // 
            // btnQueryNearFeature
            // 
            this.btnQueryNearFeature.Name = "btnQueryNearFeature";
            this.btnQueryNearFeature.Size = new System.Drawing.Size(148, 22);
            this.btnQueryNearFeature.Text = "邻接要素查询";
            this.btnQueryNearFeature.Click += new System.EventHandler(this.btnQueryNearFeature_Click);
            // 
            // 叠加分析ToolStripMenuItem
            // 
            this.叠加分析ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClipAnalysis});
            this.叠加分析ToolStripMenuItem.Name = "叠加分析ToolStripMenuItem";
            this.叠加分析ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.叠加分析ToolStripMenuItem.Text = "叠加分析";
            // 
            // btnClipAnalysis
            // 
            this.btnClipAnalysis.Name = "btnClipAnalysis";
            this.btnClipAnalysis.Size = new System.Drawing.Size(124, 22);
            this.btnClipAnalysis.Text = "裁剪分析";
            this.btnClipAnalysis.Click += new System.EventHandler(this.btnClipAnalysis_Click);
            // 
            // MenuItemDataConvert
            // 
            this.MenuItemDataConvert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShapeToFileGeodatabase,
            this.MenuItemShapeToCAD});
            this.MenuItemDataConvert.Name = "MenuItemDataConvert";
            this.MenuItemDataConvert.Size = new System.Drawing.Size(92, 21);
            this.MenuItemDataConvert.Text = "数据格式转换";
            // 
            // btnShapeToFileGeodatabase
            // 
            this.btnShapeToFileGeodatabase.Name = "btnShapeToFileGeodatabase";
            this.btnShapeToFileGeodatabase.Size = new System.Drawing.Size(221, 22);
            this.btnShapeToFileGeodatabase.Text = "Shape转FileGeodatabase";
            this.btnShapeToFileGeodatabase.Click += new System.EventHandler(this.MenuItemShapeToFeaCla_Click);
            // 
            // MenuItemShapeToCAD
            // 
            this.MenuItemShapeToCAD.Name = "MenuItemShapeToCAD";
            this.MenuItemShapeToCAD.Size = new System.Drawing.Size(221, 22);
            this.MenuItemShapeToCAD.Text = "Shape转为CAD";
            this.MenuItemShapeToCAD.Click += new System.EventHandler(this.MenuItemShapeToCAD_Click);
            // 
            // 添加XY数据ToolStripMenuItem
            // 
            this.添加XY数据ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExcelXYToPoint});
            this.添加XY数据ToolStripMenuItem.Name = "添加XY数据ToolStripMenuItem";
            this.添加XY数据ToolStripMenuItem.Size = new System.Drawing.Size(88, 21);
            this.添加XY数据ToolStripMenuItem.Text = "添加X/Y数据";
            // 
            // btnExcelXYToPoint
            // 
            this.btnExcelXYToPoint.Name = "btnExcelXYToPoint";
            this.btnExcelXYToPoint.Size = new System.Drawing.Size(189, 22);
            this.btnExcelXYToPoint.Text = "Excel转为空间点数据";
            this.btnExcelXYToPoint.Click += new System.EventHandler(this.btnExcelXYToPoint_Click);
            // 
            // gP工具调用ToolStripMenuItem
            // 
            this.gP工具调用ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGPBuffer,
            this.btnGPShapeaToCAD});
            this.gP工具调用ToolStripMenuItem.Name = "gP工具调用ToolStripMenuItem";
            this.gP工具调用ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.gP工具调用ToolStripMenuItem.Text = "GP工具调用";
            // 
            // btnGPBuffer
            // 
            this.btnGPBuffer.Name = "btnGPBuffer";
            this.btnGPBuffer.Size = new System.Drawing.Size(168, 22);
            this.btnGPBuffer.Text = "缓冲区分析";
            this.btnGPBuffer.Click += new System.EventHandler(this.btnGPBuffer_Click);
            // 
            // btnGPShapeaToCAD
            // 
            this.btnGPShapeaToCAD.Name = "btnGPShapeaToCAD";
            this.btnGPShapeaToCAD.Size = new System.Drawing.Size(168, 22);
            this.btnGPShapeaToCAD.Text = "ShapeFile转CAD";
            this.btnGPShapeaToCAD.Click += new System.EventHandler(this.btnGPShapeaToCAD_Click);
            // 
            // toolStrip5
            // 
            this.toolStrip5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MessageLable,
            this.Blank,
            this.ScaleLabel,
            this.CoordinateLabel});
            this.toolStrip5.Location = new System.Drawing.Point(0, 432);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.Size = new System.Drawing.Size(845, 25);
            this.toolStrip5.TabIndex = 9;
            this.toolStrip5.Text = "toolStrip5";
            // 
            // MessageLable
            // 
            this.MessageLable.Name = "MessageLable";
            this.MessageLable.Size = new System.Drawing.Size(32, 22);
            this.MessageLable.Text = "就绪";
            // 
            // Blank
            // 
            this.Blank.Name = "Blank";
            this.Blank.Size = new System.Drawing.Size(40, 22);
            this.Blank.Text = "        ";
            // 
            // ScaleLabel
            // 
            this.ScaleLabel.Name = "ScaleLabel";
            this.ScaleLabel.Size = new System.Drawing.Size(44, 22);
            this.ScaleLabel.Text = "比例尺";
            // 
            // CoordinateLabel
            // 
            this.CoordinateLabel.Name = "CoordinateLabel";
            this.CoordinateLabel.Size = new System.Drawing.Size(56, 22);
            this.CoordinateLabel.Text = "当前坐标";
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 457);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.toolStrip5);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFrom";
            this.Text = "矢量分析示例程序";
            this.Load += new System.EventHandler(this.MainFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuFileOperate;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOpenMxd;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAddData;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSaveMxd;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExportJPEG;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCloseMap;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripLabel MessageLable;
        private System.Windows.Forms.ToolStripLabel Blank;
        private System.Windows.Forms.ToolStripLabel ScaleLabel;
        private System.Windows.Forms.ToolStripLabel CoordinateLabel;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFeaAnalysis;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDataConvert;
        private System.Windows.Forms.ToolStripMenuItem MenuItemShapeToCAD;
        private System.Windows.Forms.ToolStripMenuItem btnShapeToFileGeodatabase;
        private System.Windows.Forms.ToolStripMenuItem 空间拓扑分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnBufferAnalysis;
        private System.Windows.Forms.ToolStripMenuItem btnGetFeatureBoundary;
        private System.Windows.Forms.ToolStripMenuItem 叠加分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gP工具调用ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnQueryNearFeature;
        private System.Windows.Forms.ToolStripMenuItem btnClipAnalysis;
        private System.Windows.Forms.ToolStripMenuItem btnGPBuffer;
        private System.Windows.Forms.ToolStripMenuItem 添加XY数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnExcelXYToPoint;
        private System.Windows.Forms.ToolStripMenuItem btnGPShapeaToCAD;
    }
}

