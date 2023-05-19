namespace GISEditor
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.ToolGISEdit = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.btnStartEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEndEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbSelLayer = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSelFeat = new System.Windows.Forms.ToolStripButton();
            this.btnSelMove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.btnRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddFeature = new System.Windows.Forms.ToolStripButton();
            this.btnDelFeature = new System.Windows.Forms.ToolStripButton();
            this.btnAttributeEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMoveVertex = new System.Windows.Forms.ToolStripButton();
            this.btnAddVertex = new System.Windows.Forms.ToolStripButton();
            this.btnDelVertex = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mainTocControl = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.mainMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.imlEdit = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.ToolGISEdit.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainTocControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMapControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStripContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1333, 45);
            this.panel1.TabIndex = 0;
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.ToolGISEdit);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1333, 45);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(1333, 45);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // ToolGISEdit
            // 
            this.ToolGISEdit.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolGISEdit.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolGISEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripLabel1,
            this.cmbSelLayer,
            this.toolStripSeparator1,
            this.btnSelFeat,
            this.btnSelMove,
            this.toolStripSeparator2,
            this.btnUndo,
            this.btnRedo,
            this.toolStripSeparator3,
            this.btnAddFeature,
            this.btnDelFeature,
            this.btnAttributeEdit,
            this.toolStripSeparator4,
            this.btnMoveVertex,
            this.btnAddVertex,
            this.btnDelVertex});
            this.ToolGISEdit.Location = new System.Drawing.Point(12, 10);
            this.ToolGISEdit.Name = "ToolGISEdit";
            this.ToolGISEdit.Size = new System.Drawing.Size(1210, 28);
            this.ToolGISEdit.TabIndex = 0;
            this.ToolGISEdit.Text = "ToolEdit";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStartEdit,
            this.btnSaveEdit,
            this.btnEndEdit});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(58, 25);
            this.toolStripSplitButton1.Text = "编辑";
            // 
            // btnStartEdit
            // 
            this.btnStartEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnStartEdit.Image")));
            this.btnStartEdit.Name = "btnStartEdit";
            this.btnStartEdit.Size = new System.Drawing.Size(144, 26);
            this.btnStartEdit.Text = "开始编辑";
            this.btnStartEdit.Click += new System.EventHandler(this.btnStartEdit_Click);
            // 
            // btnSaveEdit
            // 
            this.btnSaveEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveEdit.Image")));
            this.btnSaveEdit.Name = "btnSaveEdit";
            this.btnSaveEdit.Size = new System.Drawing.Size(144, 26);
            this.btnSaveEdit.Text = "保存编辑";
            this.btnSaveEdit.Click += new System.EventHandler(this.btnSaveEdit_Click);
            // 
            // btnEndEdit
            // 
            this.btnEndEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEndEdit.Image")));
            this.btnEndEdit.Name = "btnEndEdit";
            this.btnEndEdit.Size = new System.Drawing.Size(144, 26);
            this.btnEndEdit.Text = "结束编辑";
            this.btnEndEdit.Click += new System.EventHandler(this.btnEndEdit_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(84, 25);
            this.toolStripLabel1.Text = "图层选择：";
            // 
            // cmbSelLayer
            // 
            this.cmbSelLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelLayer.Name = "cmbSelLayer";
            this.cmbSelLayer.Size = new System.Drawing.Size(160, 28);
            this.cmbSelLayer.SelectedIndexChanged += new System.EventHandler(this.cmbSelLayer_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // btnSelFeat
            // 
            this.btnSelFeat.Image = ((System.Drawing.Image)(resources.GetObject("btnSelFeat.Image")));
            this.btnSelFeat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelFeat.Name = "btnSelFeat";
            this.btnSelFeat.Size = new System.Drawing.Size(93, 25);
            this.btnSelFeat.Text = "选择要素";
            this.btnSelFeat.Click += new System.EventHandler(this.btnSelFeat_Click);
            // 
            // btnSelMove
            // 
            this.btnSelMove.Image = ((System.Drawing.Image)(resources.GetObject("btnSelMove.Image")));
            this.btnSelMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelMove.Name = "btnSelMove";
            this.btnSelMove.Size = new System.Drawing.Size(93, 25);
            this.btnSelMove.Text = "移动要素";
            this.btnSelMove.Click += new System.EventHandler(this.btnSelMove_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // btnUndo
            // 
            this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(63, 25);
            this.btnUndo.Text = "撤销";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Image = ((System.Drawing.Image)(resources.GetObject("btnRedo.Image")));
            this.btnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(63, 25);
            this.btnRedo.Text = "恢复";
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // btnAddFeature
            // 
            this.btnAddFeature.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFeature.Image")));
            this.btnAddFeature.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddFeature.Name = "btnAddFeature";
            this.btnAddFeature.Size = new System.Drawing.Size(93, 25);
            this.btnAddFeature.Text = "添加要素";
            this.btnAddFeature.Click += new System.EventHandler(this.btnAddFeature_Click);
            // 
            // btnDelFeature
            // 
            this.btnDelFeature.Image = ((System.Drawing.Image)(resources.GetObject("btnDelFeature.Image")));
            this.btnDelFeature.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelFeature.Name = "btnDelFeature";
            this.btnDelFeature.Size = new System.Drawing.Size(93, 25);
            this.btnDelFeature.Text = "删除要素";
            this.btnDelFeature.Click += new System.EventHandler(this.btnDelFeature_Click);
            // 
            // btnAttributeEdit
            // 
            this.btnAttributeEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnAttributeEdit.Image")));
            this.btnAttributeEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAttributeEdit.Name = "btnAttributeEdit";
            this.btnAttributeEdit.Size = new System.Drawing.Size(93, 25);
            this.btnAttributeEdit.Text = "属性编辑";
            this.btnAttributeEdit.Click += new System.EventHandler(this.btnAttributeEdit_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // btnMoveVertex
            // 
            this.btnMoveVertex.Image = global::GISEditor.Properties.Resources.MoveVertex;
            this.btnMoveVertex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveVertex.Name = "btnMoveVertex";
            this.btnMoveVertex.Size = new System.Drawing.Size(93, 25);
            this.btnMoveVertex.Text = "移动节点";
            this.btnMoveVertex.Click += new System.EventHandler(this.btnMoveVertex_Click);
            // 
            // btnAddVertex
            // 
            this.btnAddVertex.Image = global::GISEditor.Properties.Resources.AddVertex;
            this.btnAddVertex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddVertex.Name = "btnAddVertex";
            this.btnAddVertex.Size = new System.Drawing.Size(93, 25);
            this.btnAddVertex.Text = "添加节点";
            this.btnAddVertex.Click += new System.EventHandler(this.btnAddVertex_Click);
            // 
            // btnDelVertex
            // 
            this.btnDelVertex.Image = global::GISEditor.Properties.Resources.DelVertex;
            this.btnDelVertex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelVertex.Name = "btnDelVertex";
            this.btnDelVertex.Size = new System.Drawing.Size(93, 25);
            this.btnDelVertex.Text = "删除节点";
            this.btnDelVertex.Click += new System.EventHandler(this.btnDelVertex_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.mainTocControl);
            this.panel2.Controls.Add(this.axLicenseControl1);
            this.panel2.Controls.Add(this.mainMapControl);
            this.panel2.Controls.Add(this.axToolbarControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1333, 524);
            this.panel2.TabIndex = 1;
            // 
            // mainTocControl
            // 
            this.mainTocControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.mainTocControl.Location = new System.Drawing.Point(0, 29);
            this.mainTocControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainTocControl.Name = "mainTocControl";
            this.mainTocControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mainTocControl.OcxState")));
            this.mainTocControl.Size = new System.Drawing.Size(204, 484);
            this.mainTocControl.TabIndex = 3;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(368, 114);
            this.axLicenseControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 2;
            // 
            // mainMapControl
            // 
            this.mainMapControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainMapControl.Location = new System.Drawing.Point(211, 29);
            this.mainMapControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainMapControl.Name = "mainMapControl";
            this.mainMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mainMapControl.OcxState")));
            this.mainMapControl.Size = new System.Drawing.Size(1118, 482);
            this.mainMapControl.TabIndex = 1;
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 0);
            this.axToolbarControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(1333, 28);
            this.axToolbarControl1.TabIndex = 0;
            // 
            // imlEdit
            // 
            this.imlEdit.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlEdit.ImageStream")));
            this.imlEdit.TransparentColor = System.Drawing.Color.Silver;
            this.imlEdit.Images.SetKeyName(0, "");
            this.imlEdit.Images.SetKeyName(1, "");
            this.imlEdit.Images.SetKeyName(2, "");
            this.imlEdit.Images.SetKeyName(3, "");
            this.imlEdit.Images.SetKeyName(4, "");
            this.imlEdit.Images.SetKeyName(5, "");
            this.imlEdit.Images.SetKeyName(6, "");
            this.imlEdit.Images.SetKeyName(7, "");
            this.imlEdit.Images.SetKeyName(8, "");
            this.imlEdit.Images.SetKeyName(9, "");
            this.imlEdit.Images.SetKeyName(10, "");
            this.imlEdit.Images.SetKeyName(11, "");
            this.imlEdit.Images.SetKeyName(12, "");
            this.imlEdit.Images.SetKeyName(13, "");
            this.imlEdit.Images.SetKeyName(14, "");
            this.imlEdit.Images.SetKeyName(15, "");
            this.imlEdit.Images.SetKeyName(16, "");
            this.imlEdit.Images.SetKeyName(17, "");
            this.imlEdit.Images.SetKeyName(18, "");
            this.imlEdit.Images.SetKeyName(19, "");
            this.imlEdit.Images.SetKeyName(20, "");
            this.imlEdit.Images.SetKeyName(21, "");
            this.imlEdit.Images.SetKeyName(22, "");
            this.imlEdit.Images.SetKeyName(23, "");
            this.imlEdit.Images.SetKeyName(24, "");
            this.imlEdit.Images.SetKeyName(25, "");
            this.imlEdit.Images.SetKeyName(26, "");
            this.imlEdit.Images.SetKeyName(27, "");
            this.imlEdit.Images.SetKeyName(28, "");
            this.imlEdit.Images.SetKeyName(29, "");
            this.imlEdit.Images.SetKeyName(30, "");
            this.imlEdit.Images.SetKeyName(31, "");
            this.imlEdit.Images.SetKeyName(32, "");
            this.imlEdit.Images.SetKeyName(33, "");
            this.imlEdit.Images.SetKeyName(34, "");
            this.imlEdit.Images.SetKeyName(35, "");
            this.imlEdit.Images.SetKeyName(36, "");
            this.imlEdit.Images.SetKeyName(37, "");
            this.imlEdit.Images.SetKeyName(38, "");
            this.imlEdit.Images.SetKeyName(39, "");
            this.imlEdit.Images.SetKeyName(40, "");
            this.imlEdit.Images.SetKeyName(41, "");
            this.imlEdit.Images.SetKeyName(42, "");
            this.imlEdit.Images.SetKeyName(43, "");
            this.imlEdit.Images.SetKeyName(44, "");
            this.imlEdit.Images.SetKeyName(45, "");
            this.imlEdit.Images.SetKeyName(46, "");
            this.imlEdit.Images.SetKeyName(47, "");
            this.imlEdit.Images.SetKeyName(48, "");
            this.imlEdit.Images.SetKeyName(49, "");
            this.imlEdit.Images.SetKeyName(50, "");
            this.imlEdit.Images.SetKeyName(51, "");
            this.imlEdit.Images.SetKeyName(52, "");
            this.imlEdit.Images.SetKeyName(53, "");
            this.imlEdit.Images.SetKeyName(54, "");
            this.imlEdit.Images.SetKeyName(55, "");
            this.imlEdit.Images.SetKeyName(56, "");
            this.imlEdit.Images.SetKeyName(57, "");
            this.imlEdit.Images.SetKeyName(58, "");
            this.imlEdit.Images.SetKeyName(59, "");
            this.imlEdit.Images.SetKeyName(60, "");
            this.imlEdit.Images.SetKeyName(61, "");
            this.imlEdit.Images.SetKeyName(62, "");
            this.imlEdit.Images.SetKeyName(63, "");
            this.imlEdit.Images.SetKeyName(64, "");
            this.imlEdit.Images.SetKeyName(65, "比例缩放.bmp");
            this.imlEdit.Images.SetKeyName(66, "编辑设置.bmp");
            this.imlEdit.Images.SetKeyName(67, "错误列表.bmp");
            this.imlEdit.Images.SetKeyName(68, "打开拓扑.bmp");
            this.imlEdit.Images.SetKeyName(69, "点转.bmp");
            this.imlEdit.Images.SetKeyName(70, "继续编辑.bmp");
            this.imlEdit.Images.SetKeyName(71, "镜像.bmp");
            this.imlEdit.Images.SetKeyName(72, "零星删除.bmp");
            this.imlEdit.Images.SetKeyName(73, "零星新建.bmp");
            this.imlEdit.Images.SetKeyName(74, "面转.bmp");
            this.imlEdit.Images.SetKeyName(75, "添加矩形要素.bmp");
            this.imlEdit.Images.SetKeyName(76, "添加曲线要素.bmp");
            this.imlEdit.Images.SetKeyName(77, "添加三点圆要素.bmp");
            this.imlEdit.Images.SetKeyName(78, "添加椭圆要素.bmp");
            this.imlEdit.Images.SetKeyName(79, "添加圆要素.bmp");
            this.imlEdit.Images.SetKeyName(80, "添加自由要素.bmp");
            this.imlEdit.Images.SetKeyName(81, "线转.bmp");
            this.imlEdit.Images.SetKeyName(82, "相交.bmp");
            this.imlEdit.Images.SetKeyName(83, "相切.bmp");
            this.imlEdit.Images.SetKeyName(84, "要素曲线化.bmp");
            this.imlEdit.Images.SetKeyName(85, "自由缩放.bmp");
            this.imlEdit.Images.SetKeyName(86, "自由旋转要素.bmp");
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 569);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据编辑";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ToolGISEdit.ResumeLayout(false);
            this.ToolGISEdit.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainTocControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMapControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip ToolGISEdit;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem btnStartEdit;
        private System.Windows.Forms.ToolStripMenuItem btnSaveEdit;
        private System.Windows.Forms.ToolStripMenuItem btnEndEdit;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cmbSelLayer;
        private ESRI.ArcGIS.Controls.AxMapControl mainMapControl;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ImageList imlEdit;
        private System.Windows.Forms.ToolStripButton btnSelMove;
        private System.Windows.Forms.ToolStripButton btnAddFeature;
        private System.Windows.Forms.ToolStripButton btnDelFeature;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripButton btnRedo;
        private System.Windows.Forms.ToolStripButton btnAttributeEdit;
        private System.Windows.Forms.ToolStripButton btnSelFeat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnMoveVertex;
        private System.Windows.Forms.ToolStripButton btnAddVertex;
        private System.Windows.Forms.ToolStripButton btnDelVertex;
        private ESRI.ArcGIS.Controls.AxTOCControl mainTocControl;

    }
}

