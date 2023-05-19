namespace DensityAnalysis
{
    partial class FrmDensityAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDensityAnalysis));
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.TOCAndMap = new System.Windows.Forms.SplitContainer();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.functions = new System.Windows.Forms.Panel();
            this.btnPoint = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.paramSet = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbFields = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNbType = new System.Windows.Forms.ComboBox();
            this.txtRadioDis = new System.Windows.Forms.TextBox();
            this.txtCellSize = new System.Windows.Forms.TextBox();
            this.cmbLayer = new System.Windows.Forms.ComboBox();
            this.btnKernel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.TOCAndMap.Panel1.SuspendLayout();
            this.TOCAndMap.Panel2.SuspendLayout();
            this.TOCAndMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.functions.SuspendLayout();
            this.paramSet.SuspendLayout();
            this.SuspendLayout();
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 0);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(852, 28);
            this.axToolbarControl1.TabIndex = 1;
            // 
            // TOCAndMap
            // 
            this.TOCAndMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TOCAndMap.Location = new System.Drawing.Point(0, 28);
            this.TOCAndMap.Name = "TOCAndMap";
            // 
            // TOCAndMap.Panel1
            // 
            this.TOCAndMap.Panel1.Controls.Add(this.axTOCControl1);
            // 
            // TOCAndMap.Panel2
            // 
            this.TOCAndMap.Panel2.Controls.Add(this.axLicenseControl1);
            this.TOCAndMap.Panel2.Controls.Add(this.axMapControl1);
            this.TOCAndMap.Panel2.Controls.Add(this.functions);
            this.TOCAndMap.Size = new System.Drawing.Size(852, 419);
            this.TOCAndMap.SplitterDistance = 197;
            this.TOCAndMap.TabIndex = 2;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl1.Location = new System.Drawing.Point(0, 0);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(197, 419);
            this.axTOCControl1.TabIndex = 0;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(331, 387);
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
            this.axMapControl1.Size = new System.Drawing.Size(391, 419);
            this.axMapControl1.TabIndex = 1;
            // 
            // functions
            // 
            this.functions.Controls.Add(this.btnPoint);
            this.functions.Controls.Add(this.btnLine);
            this.functions.Controls.Add(this.paramSet);
            this.functions.Controls.Add(this.btnKernel);
            this.functions.Dock = System.Windows.Forms.DockStyle.Right;
            this.functions.Location = new System.Drawing.Point(391, 0);
            this.functions.Name = "functions";
            this.functions.Size = new System.Drawing.Size(260, 419);
            this.functions.TabIndex = 0;
            // 
            // btnPoint
            // 
            this.btnPoint.Location = new System.Drawing.Point(172, 363);
            this.btnPoint.Name = "btnPoint";
            this.btnPoint.Size = new System.Drawing.Size(79, 31);
            this.btnPoint.TabIndex = 3;
            this.btnPoint.Text = "点密度分析";
            this.btnPoint.UseVisualStyleBackColor = true;
            this.btnPoint.Click += new System.EventHandler(this.btnPoint_Click);
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(90, 363);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(79, 31);
            this.btnLine.TabIndex = 2;
            this.btnLine.Text = "线密度分析";
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // paramSet
            // 
            this.paramSet.Controls.Add(this.label5);
            this.paramSet.Controls.Add(this.cmbFields);
            this.paramSet.Controls.Add(this.label4);
            this.paramSet.Controls.Add(this.label3);
            this.paramSet.Controls.Add(this.label2);
            this.paramSet.Controls.Add(this.label1);
            this.paramSet.Controls.Add(this.cmbNbType);
            this.paramSet.Controls.Add(this.txtRadioDis);
            this.paramSet.Controls.Add(this.txtCellSize);
            this.paramSet.Controls.Add(this.cmbLayer);
            this.paramSet.Location = new System.Drawing.Point(8, 39);
            this.paramSet.Name = "paramSet";
            this.paramSet.Size = new System.Drawing.Size(252, 294);
            this.paramSet.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Population：";
            // 
            // cmbFields
            // 
            this.cmbFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFields.FormattingEnabled = true;
            this.cmbFields.Location = new System.Drawing.Point(97, 81);
            this.cmbFields.Name = "cmbFields";
            this.cmbFields.Size = new System.Drawing.Size(114, 20);
            this.cmbFields.TabIndex = 8;
            this.cmbFields.SelectedIndexChanged += new System.EventHandler(this.cmbFields_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "邻域分析(用于点密度分析)：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "搜索半径(不用于点密度)：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "输出像元大小：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "输入：";
            // 
            // cmbNbType
            // 
            this.cmbNbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNbType.FormattingEnabled = true;
            this.cmbNbType.Items.AddRange(new object[] {
            "圆形",
            "矩形",
            "环形"});
            this.cmbNbType.Location = new System.Drawing.Point(122, 237);
            this.cmbNbType.Name = "cmbNbType";
            this.cmbNbType.Size = new System.Drawing.Size(89, 20);
            this.cmbNbType.TabIndex = 3;
            this.cmbNbType.SelectedIndexChanged += new System.EventHandler(this.cmbNbType_SelectedIndexChanged);
            // 
            // txtRadioDis
            // 
            this.txtRadioDis.Location = new System.Drawing.Point(166, 170);
            this.txtRadioDis.Name = "txtRadioDis";
            this.txtRadioDis.Size = new System.Drawing.Size(45, 21);
            this.txtRadioDis.TabIndex = 2;
            this.txtRadioDis.TextChanged += new System.EventHandler(this.txtRadioDis_TextChanged);
            // 
            // txtCellSize
            // 
            this.txtCellSize.Location = new System.Drawing.Point(166, 129);
            this.txtCellSize.Name = "txtCellSize";
            this.txtCellSize.Size = new System.Drawing.Size(45, 21);
            this.txtCellSize.TabIndex = 1;
            this.txtCellSize.TextChanged += new System.EventHandler(this.txtCellSize_TextChanged);
            // 
            // cmbLayer
            // 
            this.cmbLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLayer.FormattingEnabled = true;
            this.cmbLayer.Location = new System.Drawing.Point(61, 33);
            this.cmbLayer.Name = "cmbLayer";
            this.cmbLayer.Size = new System.Drawing.Size(150, 20);
            this.cmbLayer.TabIndex = 0;
            this.cmbLayer.SelectedIndexChanged += new System.EventHandler(this.cmbLayer_SelectedIndexChanged);
            this.cmbLayer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbLayer_MouseClick);
            // 
            // btnKernel
            // 
            this.btnKernel.Location = new System.Drawing.Point(6, 363);
            this.btnKernel.Name = "btnKernel";
            this.btnKernel.Size = new System.Drawing.Size(79, 31);
            this.btnKernel.TabIndex = 0;
            this.btnKernel.Text = "核密度分析";
            this.btnKernel.UseVisualStyleBackColor = true;
            this.btnKernel.Click += new System.EventHandler(this.btnKernel_Click);
            // 
            // FrmDensityAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 447);
            this.Controls.Add(this.TOCAndMap);
            this.Controls.Add(this.axToolbarControl1);
            this.Name = "FrmDensityAnalysis";
            this.Text = "密度分析";
            this.Load += new System.EventHandler(this.FrmDensityAnalysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.TOCAndMap.Panel1.ResumeLayout(false);
            this.TOCAndMap.Panel2.ResumeLayout(false);
            this.TOCAndMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.functions.ResumeLayout(false);
            this.paramSet.ResumeLayout(false);
            this.paramSet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.SplitContainer TOCAndMap;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.Panel functions;
        private System.Windows.Forms.Button btnKernel;
        private System.Windows.Forms.Panel paramSet;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.TextBox txtRadioDis;
        private System.Windows.Forms.TextBox txtCellSize;
        private System.Windows.Forms.ComboBox cmbLayer;
        private System.Windows.Forms.Button btnPoint;
        private System.Windows.Forms.ComboBox cmbNbType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFields;
        private System.Windows.Forms.Label label5;
    }
}

