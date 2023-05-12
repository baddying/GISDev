namespace 点线面符号化
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
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.点状要素符号化 = new System.Windows.Forms.ToolStripMenuItem();
            this.SimpleMaker = new System.Windows.Forms.ToolStripMenuItem();
            this.ArrowMarker = new System.Windows.Forms.ToolStripMenuItem();
            this.CharacterMarker = new System.Windows.Forms.ToolStripMenuItem();
            this.PictureMarker = new System.Windows.Forms.ToolStripMenuItem();
            this.MultiLayerMarker = new System.Windows.Forms.ToolStripMenuItem();
            this.线状要素符号化 = new System.Windows.Forms.ToolStripMenuItem();
            this.SimpleLine = new System.Windows.Forms.ToolStripMenuItem();
            this.CartographicLine = new System.Windows.Forms.ToolStripMenuItem();
            this.MultiLayerLine = new System.Windows.Forms.ToolStripMenuItem();
            this.PictureLine = new System.Windows.Forms.ToolStripMenuItem();
            this.HashLine = new System.Windows.Forms.ToolStripMenuItem();
            this.面状要素符号化 = new System.Windows.Forms.ToolStripMenuItem();
            this.SimpleFill = new System.Windows.Forms.ToolStripMenuItem();
            this.LineFill = new System.Windows.Forms.ToolStripMenuItem();
            this.MarkerFill = new System.Windows.Forms.ToolStripMenuItem();
            this.GradientFill = new System.Windows.Forms.ToolStripMenuItem();
            this.PictureFill = new System.Windows.Forms.ToolStripMenuItem();
            this.MultiLayerFill = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSymbol = new System.Windows.Forms.ToolStripMenuItem();
            this.txtElementLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.txtElement = new System.Windows.Forms.ToolStripMenuItem();
            this.txtAnnotation = new System.Windows.Forms.ToolStripMenuItem();
            this.txtmapTips = new System.Windows.Forms.ToolStripMenuItem();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mainToolbarControl = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.mainTOCControl = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.mainMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainToolbarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainTOCControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMapControl)).BeginInit();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(152, 112);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.点状要素符号化,
            this.线状要素符号化,
            this.面状要素符号化,
            this.txtSymbol,
            this.txtElementLabel});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(688, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.另存为ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 另存为ToolStripMenuItem
            // 
            this.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            this.另存为ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.另存为ToolStripMenuItem.Text = "另存为";
            this.另存为ToolStripMenuItem.Click += new System.EventHandler(this.另存为ToolStripMenuItem_Click);
            // 
            // 点状要素符号化
            // 
            this.点状要素符号化.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SimpleMaker,
            this.ArrowMarker,
            this.CharacterMarker,
            this.PictureMarker,
            this.MultiLayerMarker});
            this.点状要素符号化.Name = "点状要素符号化";
            this.点状要素符号化.Size = new System.Drawing.Size(104, 21);
            this.点状要素符号化.Text = "点状要素符号化";
            // 
            // SimpleMaker
            // 
            this.SimpleMaker.Name = "SimpleMaker";
            this.SimpleMaker.Size = new System.Drawing.Size(160, 22);
            this.SimpleMaker.Text = "简单类型符号化";
            this.SimpleMaker.Click += new System.EventHandler(this.SimpleMaker_Click);
            // 
            // ArrowMarker
            // 
            this.ArrowMarker.Name = "ArrowMarker";
            this.ArrowMarker.Size = new System.Drawing.Size(160, 22);
            this.ArrowMarker.Text = "箭头类型符号化";
            this.ArrowMarker.Click += new System.EventHandler(this.ArrowMarker_Click);
            // 
            // CharacterMarker
            // 
            this.CharacterMarker.Name = "CharacterMarker";
            this.CharacterMarker.Size = new System.Drawing.Size(160, 22);
            this.CharacterMarker.Text = "字符型点符号化";
            this.CharacterMarker.Click += new System.EventHandler(this.CharacterMarker_Click);
            // 
            // PictureMarker
            // 
            this.PictureMarker.Name = "PictureMarker";
            this.PictureMarker.Size = new System.Drawing.Size(160, 22);
            this.PictureMarker.Text = "图片型点符号化";
            this.PictureMarker.Click += new System.EventHandler(this.PictureMarker_Click);
            // 
            // MultiLayerMarker
            // 
            this.MultiLayerMarker.Name = "MultiLayerMarker";
            this.MultiLayerMarker.Size = new System.Drawing.Size(160, 22);
            this.MultiLayerMarker.Text = "叠加型点符号化";
            this.MultiLayerMarker.Click += new System.EventHandler(this.MultiLayerMarker_Click);
            // 
            // 线状要素符号化
            // 
            this.线状要素符号化.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SimpleLine,
            this.CartographicLine,
            this.MultiLayerLine,
            this.PictureLine,
            this.HashLine});
            this.线状要素符号化.Name = "线状要素符号化";
            this.线状要素符号化.Size = new System.Drawing.Size(104, 21);
            this.线状要素符号化.Text = "线状要素符号化";
            // 
            // SimpleLine
            // 
            this.SimpleLine.Name = "SimpleLine";
            this.SimpleLine.Size = new System.Drawing.Size(160, 22);
            this.SimpleLine.Text = "简单线符号";
            this.SimpleLine.Click += new System.EventHandler(this.SimpleLine_Click);
            // 
            // CartographicLine
            // 
            this.CartographicLine.Name = "CartographicLine";
            this.CartographicLine.Size = new System.Drawing.Size(160, 22);
            this.CartographicLine.Text = "制图线符号化";
            this.CartographicLine.Click += new System.EventHandler(this.CartographicLine_Click);
            // 
            // MultiLayerLine
            // 
            this.MultiLayerLine.Name = "MultiLayerLine";
            this.MultiLayerLine.Size = new System.Drawing.Size(160, 22);
            this.MultiLayerLine.Text = "多图层线符号化";
            this.MultiLayerLine.Click += new System.EventHandler(this.MultiLayerLine_Click);
            // 
            // PictureLine
            // 
            this.PictureLine.Name = "PictureLine";
            this.PictureLine.Size = new System.Drawing.Size(160, 22);
            this.PictureLine.Text = "图片线符号化";
            this.PictureLine.Click += new System.EventHandler(this.PictureLine_Click);
            // 
            // HashLine
            // 
            this.HashLine.Name = "HashLine";
            this.HashLine.Size = new System.Drawing.Size(160, 22);
            this.HashLine.Text = "离散型符号";
            this.HashLine.Click += new System.EventHandler(this.HashLine_Click);
            // 
            // 面状要素符号化
            // 
            this.面状要素符号化.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SimpleFill,
            this.LineFill,
            this.MarkerFill,
            this.GradientFill,
            this.PictureFill,
            this.MultiLayerFill});
            this.面状要素符号化.Name = "面状要素符号化";
            this.面状要素符号化.Size = new System.Drawing.Size(104, 21);
            this.面状要素符号化.Text = "面状要素符号化";
            // 
            // SimpleFill
            // 
            this.SimpleFill.Name = "SimpleFill";
            this.SimpleFill.Size = new System.Drawing.Size(160, 22);
            this.SimpleFill.Text = "简单填充符号";
            this.SimpleFill.Click += new System.EventHandler(this.SimpleFill_Click);
            // 
            // LineFill
            // 
            this.LineFill.Name = "LineFill";
            this.LineFill.Size = new System.Drawing.Size(160, 22);
            this.LineFill.Text = "线填充符号";
            this.LineFill.Click += new System.EventHandler(this.LineFill_Click);
            // 
            // MarkerFill
            // 
            this.MarkerFill.Name = "MarkerFill";
            this.MarkerFill.Size = new System.Drawing.Size(160, 22);
            this.MarkerFill.Text = "点填充符号";
            this.MarkerFill.Click += new System.EventHandler(this.MarkerFill_Click);
            // 
            // GradientFill
            // 
            this.GradientFill.Name = "GradientFill";
            this.GradientFill.Size = new System.Drawing.Size(160, 22);
            this.GradientFill.Text = "渐变色填充符号";
            this.GradientFill.Click += new System.EventHandler(this.GradientFill_Click);
            // 
            // PictureFill
            // 
            this.PictureFill.Name = "PictureFill";
            this.PictureFill.Size = new System.Drawing.Size(160, 22);
            this.PictureFill.Text = "图片填充符号";
            this.PictureFill.Click += new System.EventHandler(this.PictureFill_Click);
            // 
            // MultiLayerFill
            // 
            this.MultiLayerFill.Name = "MultiLayerFill";
            this.MultiLayerFill.Size = new System.Drawing.Size(160, 22);
            this.MultiLayerFill.Text = "多层填充符号";
            this.MultiLayerFill.Click += new System.EventHandler(this.MultiLayerFill_Click);
            // 
            // txtSymbol
            // 
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(80, 21);
            this.txtSymbol.Text = "文本符号化";
            this.txtSymbol.Click += new System.EventHandler(this.txtSymbol_Click);
            // 
            // txtElementLabel
            // 
            this.txtElementLabel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtElement,
            this.txtAnnotation,
            this.txtmapTips});
            this.txtElementLabel.Name = "txtElementLabel";
            this.txtElementLabel.Size = new System.Drawing.Size(44, 21);
            this.txtElementLabel.Text = "标注";
            // 
            // txtElement
            // 
            this.txtElement.Name = "txtElement";
            this.txtElement.Size = new System.Drawing.Size(170, 22);
            this.txtElement.Text = "TextElement标注";
            this.txtElement.Click += new System.EventHandler(this.txtElement_Click);
            // 
            // txtAnnotation
            // 
            this.txtAnnotation.Name = "txtAnnotation";
            this.txtAnnotation.Size = new System.Drawing.Size(170, 22);
            this.txtAnnotation.Text = "Annotation注记";
            this.txtAnnotation.Click += new System.EventHandler(this.txtAnnotation_Click);
            // 
            // txtmapTips
            // 
            this.txtmapTips.Name = "txtmapTips";
            this.txtmapTips.Size = new System.Drawing.Size(170, 22);
            this.txtmapTips.Text = "MapTips显示";
            this.txtmapTips.Click += new System.EventHandler(this.txtmapTips_Click);
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(565, 4);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(123, 21);
            this.TextBox.TabIndex = 6;
            this.TextBox.Text = "输入想要添加的文字";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(506, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "文本内容";
            // 
            // mainToolbarControl
            // 
            this.mainToolbarControl.Location = new System.Drawing.Point(0, 32);
            this.mainToolbarControl.Name = "mainToolbarControl";
            this.mainToolbarControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mainToolbarControl.OcxState")));
            this.mainToolbarControl.Size = new System.Drawing.Size(688, 28);
            this.mainToolbarControl.TabIndex = 4;
            // 
            // mainTOCControl
            // 
            this.mainTOCControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.mainTOCControl.Location = new System.Drawing.Point(-7, 67);
            this.mainTOCControl.Name = "mainTOCControl";
            this.mainTOCControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mainTOCControl.OcxState")));
            this.mainTOCControl.Size = new System.Drawing.Size(132, 334);
            this.mainTOCControl.TabIndex = 2;
            this.mainTOCControl.OnDoubleClick += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnDoubleClickEventHandler(this.mainTOCControl_OnDoubleClick);
            // 
            // mainMapControl
            // 
            this.mainMapControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainMapControl.Location = new System.Drawing.Point(123, 67);
            this.mainMapControl.Name = "mainMapControl";
            this.mainMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mainMapControl.OcxState")));
            this.mainMapControl.Size = new System.Drawing.Size(565, 334);
            this.mainMapControl.TabIndex = 1;
            this.mainMapControl.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.mainMapControl_OnMouseDown);
            // 
            // frmMainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 399);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.mainToolbarControl);
            this.Controls.Add(this.mainTOCControl);
            this.Controls.Add(this.mainMapControl);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMainUI";
            this.Text = "地图制图—符号化";
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainToolbarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainTOCControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMapControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl mainMapControl;
        private ESRI.ArcGIS.Controls.AxTOCControl mainTOCControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 点状要素符号化;
        private System.Windows.Forms.ToolStripMenuItem SimpleMaker;
        private System.Windows.Forms.ToolStripMenuItem ArrowMarker;
        private System.Windows.Forms.ToolStripMenuItem CharacterMarker;
        private System.Windows.Forms.ToolStripMenuItem PictureMarker;
        private System.Windows.Forms.ToolStripMenuItem 线状要素符号化;
        private System.Windows.Forms.ToolStripMenuItem 面状要素符号化;
        private System.Windows.Forms.ToolStripMenuItem MultiLayerMarker;
        private ESRI.ArcGIS.Controls.AxToolbarControl mainToolbarControl;
        private System.Windows.Forms.ToolStripMenuItem CartographicLine;
        private System.Windows.Forms.ToolStripMenuItem SimpleLine;
        private System.Windows.Forms.ToolStripMenuItem MultiLayerLine;
        private System.Windows.Forms.ToolStripMenuItem PictureLine;
        private System.Windows.Forms.ToolStripMenuItem HashLine;
        private System.Windows.Forms.ToolStripMenuItem SimpleFill;
        private System.Windows.Forms.ToolStripMenuItem LineFill;
        private System.Windows.Forms.ToolStripMenuItem MarkerFill;
        private System.Windows.Forms.ToolStripMenuItem GradientFill;
        private System.Windows.Forms.ToolStripMenuItem PictureFill;
        private System.Windows.Forms.ToolStripMenuItem MultiLayerFill;
        private System.Windows.Forms.ToolStripMenuItem txtSymbol;
        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.ToolStripMenuItem txtElementLabel;
        private System.Windows.Forms.ToolStripMenuItem txtAnnotation;
        private System.Windows.Forms.ToolStripMenuItem txtmapTips;
        private System.Windows.Forms.ToolStripMenuItem txtElement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为ToolStripMenuItem;
    }
}

