namespace Interpolation
{
    partial class FrmInterpolation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInterpolation));
            this.spcTOCAndMap = new System.Windows.Forms.SplitContainer();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.panFunction = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbRadius = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCellSize = new System.Windows.Forms.TextBox();
            this.cmbFields = new System.Windows.Forms.ComboBox();
            this.cmbLayers = new System.Windows.Forms.ComboBox();
            this.tacFunction = new System.Windows.Forms.TabControl();
            this.tabIDW = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.btnIDW = new System.Windows.Forms.Button();
            this.txtPower = new System.Windows.Forms.TextBox();
            this.tabKrige = new System.Windows.Forms.TabPage();
            this.btnKrige = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSemiEnum = new System.Windows.Forms.ComboBox();
            this.tabSpline = new System.Windows.Forms.TabPage();
            this.btnSpline = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbSplineType = new System.Windows.Forms.ComboBox();
            this.tabTrend = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.txtorder = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTrendType = new System.Windows.Forms.ComboBox();
            this.cmdTrend = new System.Windows.Forms.Button();
            this.tabNaturalNeighbor = new System.Windows.Forms.TabPage();
            this.btnNaturalNeighbor = new System.Windows.Forms.Button();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            ((System.ComponentModel.ISupportInitialize)(this.spcTOCAndMap)).BeginInit();
            this.spcTOCAndMap.Panel1.SuspendLayout();
            this.spcTOCAndMap.Panel2.SuspendLayout();
            this.spcTOCAndMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.panFunction.SuspendLayout();
            this.tacFunction.SuspendLayout();
            this.tabIDW.SuspendLayout();
            this.tabKrige.SuspendLayout();
            this.tabSpline.SuspendLayout();
            this.tabTrend.SuspendLayout();
            this.tabNaturalNeighbor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // spcTOCAndMap
            // 
            this.spcTOCAndMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcTOCAndMap.Location = new System.Drawing.Point(0, 28);
            this.spcTOCAndMap.Name = "spcTOCAndMap";
            // 
            // spcTOCAndMap.Panel1
            // 
            this.spcTOCAndMap.Panel1.Controls.Add(this.axTOCControl1);
            // 
            // spcTOCAndMap.Panel2
            // 
            this.spcTOCAndMap.Panel2.Controls.Add(this.axLicenseControl1);
            this.spcTOCAndMap.Panel2.Controls.Add(this.axMapControl1);
            this.spcTOCAndMap.Panel2.Controls.Add(this.panFunction);
            this.spcTOCAndMap.Size = new System.Drawing.Size(828, 425);
            this.spcTOCAndMap.SplitterDistance = 214;
            this.spcTOCAndMap.TabIndex = 1;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(124, 267);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 2;
            // 
            // panFunction
            // 
            this.panFunction.Controls.Add(this.label4);
            this.panFunction.Controls.Add(this.cmbRadius);
            this.panFunction.Controls.Add(this.label3);
            this.panFunction.Controls.Add(this.label2);
            this.panFunction.Controls.Add(this.label1);
            this.panFunction.Controls.Add(this.txtCellSize);
            this.panFunction.Controls.Add(this.cmbFields);
            this.panFunction.Controls.Add(this.cmbLayers);
            this.panFunction.Controls.Add(this.tacFunction);
            this.panFunction.Dock = System.Windows.Forms.DockStyle.Right;
            this.panFunction.Location = new System.Drawing.Point(338, 0);
            this.panFunction.Name = "panFunction";
            this.panFunction.Size = new System.Drawing.Size(272, 425);
            this.panFunction.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "搜索半径(用于IDW和Krige)：";
            // 
            // cmbRadius
            // 
            this.cmbRadius.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRadius.FormattingEnabled = true;
            this.cmbRadius.Items.AddRange(new object[] {
            "固定",
            "变量"});
            this.cmbRadius.Location = new System.Drawing.Point(137, 177);
            this.cmbRadius.Name = "cmbRadius";
            this.cmbRadius.Size = new System.Drawing.Size(100, 20);
            this.cmbRadius.TabIndex = 10;
            this.cmbRadius.SelectedIndexChanged += new System.EventHandler(this.cmbRadius_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "输出栅格大小：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Z值：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "输入：";
            // 
            // txtCellSize
            // 
            this.txtCellSize.Location = new System.Drawing.Point(162, 117);
            this.txtCellSize.Name = "txtCellSize";
            this.txtCellSize.Size = new System.Drawing.Size(75, 21);
            this.txtCellSize.TabIndex = 3;
            this.txtCellSize.TextChanged += new System.EventHandler(this.txtCellSize_TextChanged);
            // 
            // cmbFields
            // 
            this.cmbFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFields.FormattingEnabled = true;
            this.cmbFields.Location = new System.Drawing.Point(126, 75);
            this.cmbFields.Name = "cmbFields";
            this.cmbFields.Size = new System.Drawing.Size(111, 20);
            this.cmbFields.TabIndex = 2;
            this.cmbFields.SelectedIndexChanged += new System.EventHandler(this.cmbFields_SelectedIndexChanged);
            // 
            // cmbLayers
            // 
            this.cmbLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLayers.FormattingEnabled = true;
            this.cmbLayers.Location = new System.Drawing.Point(69, 31);
            this.cmbLayers.Name = "cmbLayers";
            this.cmbLayers.Size = new System.Drawing.Size(168, 20);
            this.cmbLayers.TabIndex = 1;
            this.cmbLayers.SelectedIndexChanged += new System.EventHandler(this.cmbLayers_SelectedIndexChanged);
            this.cmbLayers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbLayers_MouseClick);
            // 
            // tacFunction
            // 
            this.tacFunction.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tacFunction.Controls.Add(this.tabIDW);
            this.tacFunction.Controls.Add(this.tabKrige);
            this.tacFunction.Controls.Add(this.tabSpline);
            this.tacFunction.Controls.Add(this.tabTrend);
            this.tacFunction.Controls.Add(this.tabNaturalNeighbor);
            this.tacFunction.Location = new System.Drawing.Point(0, 212);
            this.tacFunction.Name = "tacFunction";
            this.tacFunction.SelectedIndex = 0;
            this.tacFunction.Size = new System.Drawing.Size(272, 164);
            this.tacFunction.TabIndex = 0;
            // 
            // tabIDW
            // 
            this.tabIDW.Controls.Add(this.label5);
            this.tabIDW.Controls.Add(this.btnIDW);
            this.tabIDW.Controls.Add(this.txtPower);
            this.tabIDW.Location = new System.Drawing.Point(4, 4);
            this.tabIDW.Name = "tabIDW";
            this.tabIDW.Padding = new System.Windows.Forms.Padding(3);
            this.tabIDW.Size = new System.Drawing.Size(264, 138);
            this.tabIDW.TabIndex = 0;
            this.tabIDW.Text = "IDW";
            this.tabIDW.UseVisualStyleBackColor = true;
            this.tabIDW.Click += new System.EventHandler(this.tabIDW_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(120, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "幂：";
            // 
            // btnIDW
            // 
            this.btnIDW.Location = new System.Drawing.Point(164, 86);
            this.btnIDW.Name = "btnIDW";
            this.btnIDW.Size = new System.Drawing.Size(69, 24);
            this.btnIDW.TabIndex = 7;
            this.btnIDW.Text = "IDW";
            this.btnIDW.UseVisualStyleBackColor = true;
            this.btnIDW.Click += new System.EventHandler(this.btnIDW_Click);
            // 
            // txtPower
            // 
            this.txtPower.Location = new System.Drawing.Point(158, 29);
            this.txtPower.Name = "txtPower";
            this.txtPower.Size = new System.Drawing.Size(75, 21);
            this.txtPower.TabIndex = 4;
            this.txtPower.TextChanged += new System.EventHandler(this.txtPower_TextChanged);
            // 
            // tabKrige
            // 
            this.tabKrige.Controls.Add(this.btnKrige);
            this.tabKrige.Controls.Add(this.label6);
            this.tabKrige.Controls.Add(this.cmbSemiEnum);
            this.tabKrige.Location = new System.Drawing.Point(4, 4);
            this.tabKrige.Name = "tabKrige";
            this.tabKrige.Padding = new System.Windows.Forms.Padding(3);
            this.tabKrige.Size = new System.Drawing.Size(264, 138);
            this.tabKrige.TabIndex = 1;
            this.tabKrige.Text = "Krige";
            this.tabKrige.UseVisualStyleBackColor = true;
            // 
            // btnKrige
            // 
            this.btnKrige.Location = new System.Drawing.Point(148, 94);
            this.btnKrige.Name = "btnKrige";
            this.btnKrige.Size = new System.Drawing.Size(85, 28);
            this.btnKrige.TabIndex = 8;
            this.btnKrige.Text = "Krige";
            this.btnKrige.UseVisualStyleBackColor = true;
            this.btnKrige.Click += new System.EventHandler(this.btnKrige_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "半变异类型：";
            // 
            // cmbSemiEnum
            // 
            this.cmbSemiEnum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemiEnum.FormattingEnabled = true;
            this.cmbSemiEnum.Items.AddRange(new object[] {
            "球面",
            "圆",
            "指数",
            "高斯",
            "线性"});
            this.cmbSemiEnum.Location = new System.Drawing.Point(122, 38);
            this.cmbSemiEnum.Name = "cmbSemiEnum";
            this.cmbSemiEnum.Size = new System.Drawing.Size(111, 20);
            this.cmbSemiEnum.TabIndex = 3;
            this.cmbSemiEnum.SelectedIndexChanged += new System.EventHandler(this.cmbSemiEnum_SelectedIndexChanged);
            // 
            // tabSpline
            // 
            this.tabSpline.Controls.Add(this.btnSpline);
            this.tabSpline.Controls.Add(this.label7);
            this.tabSpline.Controls.Add(this.cmbSplineType);
            this.tabSpline.Location = new System.Drawing.Point(4, 4);
            this.tabSpline.Name = "tabSpline";
            this.tabSpline.Padding = new System.Windows.Forms.Padding(3);
            this.tabSpline.Size = new System.Drawing.Size(264, 138);
            this.tabSpline.TabIndex = 2;
            this.tabSpline.Text = "Spline";
            this.tabSpline.UseVisualStyleBackColor = true;
            // 
            // btnSpline
            // 
            this.btnSpline.Location = new System.Drawing.Point(158, 81);
            this.btnSpline.Name = "btnSpline";
            this.btnSpline.Size = new System.Drawing.Size(75, 23);
            this.btnSpline.TabIndex = 13;
            this.btnSpline.Text = "Spline";
            this.btnSpline.UseVisualStyleBackColor = true;
            this.btnSpline.Click += new System.EventHandler(this.btnSpline_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "样条函数类型：";
            // 
            // cmbSplineType
            // 
            this.cmbSplineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSplineType.FormattingEnabled = true;
            this.cmbSplineType.Items.AddRange(new object[] {
            "REGULARIZED",
            "TENSION"});
            this.cmbSplineType.Location = new System.Drawing.Point(122, 27);
            this.cmbSplineType.Name = "cmbSplineType";
            this.cmbSplineType.Size = new System.Drawing.Size(111, 20);
            this.cmbSplineType.TabIndex = 11;
            this.cmbSplineType.SelectedIndexChanged += new System.EventHandler(this.cmbSplineType_SelectedIndexChanged);
            // 
            // tabTrend
            // 
            this.tabTrend.Controls.Add(this.label9);
            this.tabTrend.Controls.Add(this.txtorder);
            this.tabTrend.Controls.Add(this.label8);
            this.tabTrend.Controls.Add(this.cmbTrendType);
            this.tabTrend.Controls.Add(this.cmdTrend);
            this.tabTrend.Location = new System.Drawing.Point(4, 4);
            this.tabTrend.Name = "tabTrend";
            this.tabTrend.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrend.Size = new System.Drawing.Size(264, 138);
            this.tabTrend.TabIndex = 3;
            this.tabTrend.Text = "Trend";
            this.tabTrend.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(75, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "多项式的阶：";
            // 
            // txtorder
            // 
            this.txtorder.Location = new System.Drawing.Point(158, 56);
            this.txtorder.Name = "txtorder";
            this.txtorder.Size = new System.Drawing.Size(75, 21);
            this.txtorder.TabIndex = 13;
            this.txtorder.TextChanged += new System.EventHandler(this.txtorder_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "回归类型：";
            // 
            // cmbTrendType
            // 
            this.cmbTrendType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrendType.FormattingEnabled = true;
            this.cmbTrendType.Items.AddRange(new object[] {
            "LINEAR",
            "LOGISTIC"});
            this.cmbTrendType.Location = new System.Drawing.Point(112, 10);
            this.cmbTrendType.Name = "cmbTrendType";
            this.cmbTrendType.Size = new System.Drawing.Size(121, 20);
            this.cmbTrendType.TabIndex = 1;
            this.cmbTrendType.SelectedIndexChanged += new System.EventHandler(this.cmbTrendType_SelectedIndexChanged);
            // 
            // cmdTrend
            // 
            this.cmdTrend.Location = new System.Drawing.Point(158, 102);
            this.cmdTrend.Name = "cmdTrend";
            this.cmdTrend.Size = new System.Drawing.Size(75, 23);
            this.cmdTrend.TabIndex = 0;
            this.cmdTrend.Text = "Trend";
            this.cmdTrend.UseVisualStyleBackColor = true;
            this.cmdTrend.Click += new System.EventHandler(this.cmdTrend_Click);
            // 
            // tabNaturalNeighbor
            // 
            this.tabNaturalNeighbor.Controls.Add(this.btnNaturalNeighbor);
            this.tabNaturalNeighbor.Location = new System.Drawing.Point(4, 4);
            this.tabNaturalNeighbor.Name = "tabNaturalNeighbor";
            this.tabNaturalNeighbor.Padding = new System.Windows.Forms.Padding(3);
            this.tabNaturalNeighbor.Size = new System.Drawing.Size(264, 138);
            this.tabNaturalNeighbor.TabIndex = 4;
            this.tabNaturalNeighbor.Text = "Natural Neighbor";
            this.tabNaturalNeighbor.UseVisualStyleBackColor = true;
            // 
            // btnNaturalNeighbor
            // 
            this.btnNaturalNeighbor.Location = new System.Drawing.Point(120, 41);
            this.btnNaturalNeighbor.Name = "btnNaturalNeighbor";
            this.btnNaturalNeighbor.Size = new System.Drawing.Size(113, 23);
            this.btnNaturalNeighbor.TabIndex = 0;
            this.btnNaturalNeighbor.Text = "NaturalNeighbor";
            this.btnNaturalNeighbor.UseVisualStyleBackColor = true;
            this.btnNaturalNeighbor.Click += new System.EventHandler(this.btnNaturalNeighbor_Click);
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl1.Location = new System.Drawing.Point(0, 0);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(214, 425);
            this.axTOCControl1.TabIndex = 0;
            this.axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl1_OnMouseDown);
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(0, 0);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(338, 425);
            this.axMapControl1.TabIndex = 1;
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 0);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(828, 28);
            this.axToolbarControl1.TabIndex = 0;
            // 
            // FrmInterpolation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 453);
            this.Controls.Add(this.spcTOCAndMap);
            this.Controls.Add(this.axToolbarControl1);
            this.Name = "FrmInterpolation";
            this.Text = "栅格插值";
            this.Load += new System.EventHandler(this.FrmInterpolation_Load);
            this.spcTOCAndMap.Panel1.ResumeLayout(false);
            this.spcTOCAndMap.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcTOCAndMap)).EndInit();
            this.spcTOCAndMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.panFunction.ResumeLayout(false);
            this.panFunction.PerformLayout();
            this.tacFunction.ResumeLayout(false);
            this.tabIDW.ResumeLayout(false);
            this.tabIDW.PerformLayout();
            this.tabKrige.ResumeLayout(false);
            this.tabKrige.PerformLayout();
            this.tabSpline.ResumeLayout(false);
            this.tabSpline.PerformLayout();
            this.tabTrend.ResumeLayout(false);
            this.tabTrend.PerformLayout();
            this.tabNaturalNeighbor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.SplitContainer spcTOCAndMap;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.Panel panFunction;
        private System.Windows.Forms.TabControl tacFunction;
        private System.Windows.Forms.TabPage tabIDW;
        private System.Windows.Forms.TabPage tabKrige;
        private System.Windows.Forms.TabPage tabSpline;
        private System.Windows.Forms.TabPage tabTrend;
        private System.Windows.Forms.TabPage tabNaturalNeighbor;
        private System.Windows.Forms.ComboBox cmbFields;
        private System.Windows.Forms.ComboBox cmbLayers;
        private System.Windows.Forms.TextBox txtCellSize;
        private System.Windows.Forms.TextBox txtPower;
        private System.Windows.Forms.Button btnIDW;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSemiEnum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbRadius;
        private System.Windows.Forms.Button btnKrige;
        private System.Windows.Forms.ComboBox cmbSplineType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSpline;
        private System.Windows.Forms.Button cmdTrend;
        private System.Windows.Forms.ComboBox cmbTrendType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtorder;
        private System.Windows.Forms.Button btnNaturalNeighbor;
    }
}

