namespace Surface
{
    partial class FrmSurface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSurface));
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.spcTOCAndMap = new System.Windows.Forms.SplitContainer();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.panFunction = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAspect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCurvature = new System.Windows.Forms.Button();
            this.grpVisibility = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbVisibilityType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbObserverLayer = new System.Windows.Forms.ComboBox();
            this.btnVisibility = new System.Windows.Forms.Button();
            this.grpHillShade = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAltitude = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtaZimuth = new System.Windows.Forms.TextBox();
            this.btnHillShade = new System.Windows.Forms.Button();
            this.grpSlope = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSlopeType = new System.Windows.Forms.ComboBox();
            this.btnSlope = new System.Windows.Forms.Button();
            this.grpCutFill = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbAfter = new System.Windows.Forms.ComboBox();
            this.cmbBefore = new System.Windows.Forms.ComboBox();
            this.btnCutFill = new System.Windows.Forms.Button();
            this.grpContour = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.btnContour = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLayers = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.spcTOCAndMap.Panel1.SuspendLayout();
            this.spcTOCAndMap.Panel2.SuspendLayout();
            this.spcTOCAndMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.panFunction.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpVisibility.SuspendLayout();
            this.grpHillShade.SuspendLayout();
            this.grpSlope.SuspendLayout();
            this.grpCutFill.SuspendLayout();
            this.grpContour.SuspendLayout();
            this.SuspendLayout();
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 0);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(902, 28);
            this.axToolbarControl1.TabIndex = 0;
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
            this.spcTOCAndMap.Size = new System.Drawing.Size(902, 524);
            this.spcTOCAndMap.SplitterDistance = 238;
            this.spcTOCAndMap.TabIndex = 1;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl1.Location = new System.Drawing.Point(0, 0);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(238, 524);
            this.axTOCControl1.TabIndex = 0;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(93, 152);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 2;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(0, 0);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(382, 524);
            this.axMapControl1.TabIndex = 1;
            // 
            // panFunction
            // 
            this.panFunction.Controls.Add(this.groupBox2);
            this.panFunction.Controls.Add(this.groupBox1);
            this.panFunction.Controls.Add(this.grpVisibility);
            this.panFunction.Controls.Add(this.grpHillShade);
            this.panFunction.Controls.Add(this.grpSlope);
            this.panFunction.Controls.Add(this.grpCutFill);
            this.panFunction.Controls.Add(this.grpContour);
            this.panFunction.Controls.Add(this.label1);
            this.panFunction.Controls.Add(this.cmbLayers);
            this.panFunction.Dock = System.Windows.Forms.DockStyle.Right;
            this.panFunction.Location = new System.Drawing.Point(382, 0);
            this.panFunction.Name = "panFunction";
            this.panFunction.Size = new System.Drawing.Size(278, 524);
            this.panFunction.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAspect);
            this.groupBox2.Location = new System.Drawing.Point(142, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(120, 65);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Aspect";
            // 
            // btnAspect
            // 
            this.btnAspect.Location = new System.Drawing.Point(20, 23);
            this.btnAspect.Name = "btnAspect";
            this.btnAspect.Size = new System.Drawing.Size(75, 23);
            this.btnAspect.TabIndex = 2;
            this.btnAspect.Text = "Aspect";
            this.btnAspect.UseVisualStyleBackColor = true;
            this.btnAspect.Click += new System.EventHandler(this.btnAspect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCurvature);
            this.groupBox1.Location = new System.Drawing.Point(148, 329);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(116, 61);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Curvature";
            // 
            // btnCurvature
            // 
            this.btnCurvature.Location = new System.Drawing.Point(3, 23);
            this.btnCurvature.Name = "btnCurvature";
            this.btnCurvature.Size = new System.Drawing.Size(75, 23);
            this.btnCurvature.TabIndex = 0;
            this.btnCurvature.Text = "Curvature";
            this.btnCurvature.UseVisualStyleBackColor = true;
            this.btnCurvature.Click += new System.EventHandler(this.btnCurvature_Click);
            // 
            // grpVisibility
            // 
            this.grpVisibility.Controls.Add(this.label8);
            this.grpVisibility.Controls.Add(this.cmbVisibilityType);
            this.grpVisibility.Controls.Add(this.label9);
            this.grpVisibility.Controls.Add(this.cmbObserverLayer);
            this.grpVisibility.Controls.Add(this.btnVisibility);
            this.grpVisibility.Location = new System.Drawing.Point(16, 396);
            this.grpVisibility.Name = "grpVisibility";
            this.grpVisibility.Size = new System.Drawing.Size(248, 120);
            this.grpVisibility.TabIndex = 8;
            this.grpVisibility.TabStop = false;
            this.grpVisibility.Text = "Visibility";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "分析类型：";
            // 
            // cmbVisibilityType
            // 
            this.cmbVisibilityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVisibilityType.FormattingEnabled = true;
            this.cmbVisibilityType.Items.AddRange(new object[] {
            "视域分析",
            "视点分析"});
            this.cmbVisibilityType.Location = new System.Drawing.Point(118, 20);
            this.cmbVisibilityType.Name = "cmbVisibilityType";
            this.cmbVisibilityType.Size = new System.Drawing.Size(116, 20);
            this.cmbVisibilityType.TabIndex = 7;
            this.cmbVisibilityType.SelectedIndexChanged += new System.EventHandler(this.cmbVisibilityType_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "观察点数据：";
            // 
            // cmbObserverLayer
            // 
            this.cmbObserverLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbObserverLayer.FormattingEnabled = true;
            this.cmbObserverLayer.Location = new System.Drawing.Point(119, 60);
            this.cmbObserverLayer.Name = "cmbObserverLayer";
            this.cmbObserverLayer.Size = new System.Drawing.Size(116, 20);
            this.cmbObserverLayer.TabIndex = 1;
            this.cmbObserverLayer.SelectedIndexChanged += new System.EventHandler(this.cmbObserverLayer_SelectedIndexChanged);
            this.cmbObserverLayer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbObserverLayer_MouseClick);
            // 
            // btnVisibility
            // 
            this.btnVisibility.Location = new System.Drawing.Point(159, 91);
            this.btnVisibility.Name = "btnVisibility";
            this.btnVisibility.Size = new System.Drawing.Size(75, 23);
            this.btnVisibility.TabIndex = 0;
            this.btnVisibility.Text = "Visibility";
            this.btnVisibility.UseVisualStyleBackColor = true;
            this.btnVisibility.Click += new System.EventHandler(this.btnVisibility_Click);
            // 
            // grpHillShade
            // 
            this.grpHillShade.Controls.Add(this.label7);
            this.grpHillShade.Controls.Add(this.txtAltitude);
            this.grpHillShade.Controls.Add(this.label6);
            this.grpHillShade.Controls.Add(this.txtaZimuth);
            this.grpHillShade.Controls.Add(this.btnHillShade);
            this.grpHillShade.Location = new System.Drawing.Point(16, 257);
            this.grpHillShade.Name = "grpHillShade";
            this.grpHillShade.Size = new System.Drawing.Size(122, 133);
            this.grpHillShade.TabIndex = 7;
            this.grpHillShade.TabStop = false;
            this.grpHillShade.Text = "HillShade";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "高度(0-90)：";
            // 
            // txtAltitude
            // 
            this.txtAltitude.Location = new System.Drawing.Point(70, 73);
            this.txtAltitude.Name = "txtAltitude";
            this.txtAltitude.Size = new System.Drawing.Size(46, 21);
            this.txtAltitude.TabIndex = 6;
            this.txtAltitude.TextChanged += new System.EventHandler(this.txtAltitude_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "方位角：";
            // 
            // txtaZimuth
            // 
            this.txtaZimuth.Location = new System.Drawing.Point(70, 36);
            this.txtaZimuth.Name = "txtaZimuth";
            this.txtaZimuth.Size = new System.Drawing.Size(46, 21);
            this.txtaZimuth.TabIndex = 1;
            this.txtaZimuth.TextChanged += new System.EventHandler(this.txtaZimuth_TextChanged);
            // 
            // btnHillShade
            // 
            this.btnHillShade.Location = new System.Drawing.Point(10, 104);
            this.btnHillShade.Name = "btnHillShade";
            this.btnHillShade.Size = new System.Drawing.Size(75, 23);
            this.btnHillShade.TabIndex = 0;
            this.btnHillShade.Text = "HillShade";
            this.btnHillShade.UseVisualStyleBackColor = true;
            this.btnHillShade.Click += new System.EventHandler(this.btnHillShade_Click);
            // 
            // grpSlope
            // 
            this.grpSlope.Controls.Add(this.label2);
            this.grpSlope.Controls.Add(this.cmbSlopeType);
            this.grpSlope.Controls.Add(this.btnSlope);
            this.grpSlope.Location = new System.Drawing.Point(16, 49);
            this.grpSlope.Name = "grpSlope";
            this.grpSlope.Size = new System.Drawing.Size(122, 96);
            this.grpSlope.TabIndex = 6;
            this.grpSlope.TabStop = false;
            this.grpSlope.Text = "Slope";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "输出量测单位：";
            // 
            // cmbSlopeType
            // 
            this.cmbSlopeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSlopeType.FormattingEnabled = true;
            this.cmbSlopeType.Items.AddRange(new object[] {
            "DEGREE",
            "PERCENT_RISE"});
            this.cmbSlopeType.Location = new System.Drawing.Point(42, 41);
            this.cmbSlopeType.Name = "cmbSlopeType";
            this.cmbSlopeType.Size = new System.Drawing.Size(78, 20);
            this.cmbSlopeType.TabIndex = 1;
            this.cmbSlopeType.SelectedIndexChanged += new System.EventHandler(this.cmbSlopeType_SelectedIndexChanged);
            // 
            // btnSlope
            // 
            this.btnSlope.Location = new System.Drawing.Point(6, 67);
            this.btnSlope.Name = "btnSlope";
            this.btnSlope.Size = new System.Drawing.Size(75, 23);
            this.btnSlope.TabIndex = 0;
            this.btnSlope.Text = "Slope";
            this.btnSlope.UseVisualStyleBackColor = true;
            this.btnSlope.Click += new System.EventHandler(this.btnSlope_Click);
            // 
            // grpCutFill
            // 
            this.grpCutFill.Controls.Add(this.label5);
            this.grpCutFill.Controls.Add(this.label4);
            this.grpCutFill.Controls.Add(this.cmbAfter);
            this.grpCutFill.Controls.Add(this.cmbBefore);
            this.grpCutFill.Controls.Add(this.btnCutFill);
            this.grpCutFill.Location = new System.Drawing.Point(144, 157);
            this.grpCutFill.Name = "grpCutFill";
            this.grpCutFill.Size = new System.Drawing.Size(122, 133);
            this.grpCutFill.TabIndex = 5;
            this.grpCutFill.TabStop = false;
            this.grpCutFill.Text = "CutFill";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "填挖之后数据：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "填挖之前数据：";
            // 
            // cmbAfter
            // 
            this.cmbAfter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAfter.FormattingEnabled = true;
            this.cmbAfter.Location = new System.Drawing.Point(47, 74);
            this.cmbAfter.Name = "cmbAfter";
            this.cmbAfter.Size = new System.Drawing.Size(69, 20);
            this.cmbAfter.TabIndex = 2;
            this.cmbAfter.SelectedIndexChanged += new System.EventHandler(this.cmbAfter_SelectedIndexChanged);
            this.cmbAfter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbAfter_MouseClick);
            // 
            // cmbBefore
            // 
            this.cmbBefore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBefore.FormattingEnabled = true;
            this.cmbBefore.Location = new System.Drawing.Point(47, 36);
            this.cmbBefore.Name = "cmbBefore";
            this.cmbBefore.Size = new System.Drawing.Size(69, 20);
            this.cmbBefore.TabIndex = 1;
            this.cmbBefore.SelectedIndexChanged += new System.EventHandler(this.cmbBefore_SelectedIndexChanged);
            this.cmbBefore.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbBefore_MouseClick);
            // 
            // btnCutFill
            // 
            this.btnCutFill.Location = new System.Drawing.Point(6, 104);
            this.btnCutFill.Name = "btnCutFill";
            this.btnCutFill.Size = new System.Drawing.Size(75, 23);
            this.btnCutFill.TabIndex = 0;
            this.btnCutFill.Text = "CutFill";
            this.btnCutFill.UseVisualStyleBackColor = true;
            this.btnCutFill.Click += new System.EventHandler(this.btnCutFill_Click);
            // 
            // grpContour
            // 
            this.grpContour.Controls.Add(this.label3);
            this.grpContour.Controls.Add(this.txtInterval);
            this.grpContour.Controls.Add(this.btnContour);
            this.grpContour.Location = new System.Drawing.Point(16, 155);
            this.grpContour.Name = "grpContour";
            this.grpContour.Size = new System.Drawing.Size(122, 96);
            this.grpContour.TabIndex = 4;
            this.grpContour.TabStop = false;
            this.grpContour.Text = "Contour";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "等值线间距：";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(70, 40);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(46, 21);
            this.txtInterval.TabIndex = 1;
            this.txtInterval.TextChanged += new System.EventHandler(this.txtInterval_TextChanged);
            // 
            // btnContour
            // 
            this.btnContour.Location = new System.Drawing.Point(6, 67);
            this.btnContour.Name = "btnContour";
            this.btnContour.Size = new System.Drawing.Size(75, 23);
            this.btnContour.TabIndex = 0;
            this.btnContour.Text = "Contour";
            this.btnContour.UseVisualStyleBackColor = true;
            this.btnContour.Click += new System.EventHandler(this.btnContour_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "输入栅格：";
            // 
            // cmbLayers
            // 
            this.cmbLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLayers.FormattingEnabled = true;
            this.cmbLayers.Location = new System.Drawing.Point(95, 14);
            this.cmbLayers.Name = "cmbLayers";
            this.cmbLayers.Size = new System.Drawing.Size(155, 20);
            this.cmbLayers.TabIndex = 1;
            this.cmbLayers.SelectedIndexChanged += new System.EventHandler(this.cmbLayers_SelectedIndexChanged);
            this.cmbLayers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbLayers_MouseClick);
            // 
            // FrmSurface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 552);
            this.Controls.Add(this.spcTOCAndMap);
            this.Controls.Add(this.axToolbarControl1);
            this.Name = "FrmSurface";
            this.Text = "栅格表面分析";
            this.Load += new System.EventHandler(this.FrmSurface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.spcTOCAndMap.Panel1.ResumeLayout(false);
            this.spcTOCAndMap.Panel2.ResumeLayout(false);
            this.spcTOCAndMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.panFunction.ResumeLayout(false);
            this.panFunction.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.grpVisibility.ResumeLayout(false);
            this.grpVisibility.PerformLayout();
            this.grpHillShade.ResumeLayout(false);
            this.grpHillShade.PerformLayout();
            this.grpSlope.ResumeLayout(false);
            this.grpSlope.PerformLayout();
            this.grpCutFill.ResumeLayout(false);
            this.grpCutFill.PerformLayout();
            this.grpContour.ResumeLayout(false);
            this.grpContour.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.SplitContainer spcTOCAndMap;
        private System.Windows.Forms.Panel panFunction;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.ComboBox cmbLayers;
        private System.Windows.Forms.Button btnAspect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpContour;
        private System.Windows.Forms.Button btnContour;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.GroupBox grpCutFill;
        private System.Windows.Forms.Button btnCurvature;
        private System.Windows.Forms.Button btnCutFill;
        private System.Windows.Forms.ComboBox cmbAfter;
        private System.Windows.Forms.ComboBox cmbBefore;
        private System.Windows.Forms.GroupBox grpSlope;
        private System.Windows.Forms.Button btnSlope;
        private System.Windows.Forms.ComboBox cmbSlopeType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpHillShade;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtaZimuth;
        private System.Windows.Forms.Button btnHillShade;
        private System.Windows.Forms.TextBox txtAltitude;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpVisibility;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbObserverLayer;
        private System.Windows.Forms.Button btnVisibility;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbVisibilityType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

