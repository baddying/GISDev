namespace Extraction
{
    partial class FrmConditional
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConditional));
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.spcTOCAndMap = new System.Windows.Forms.SplitContainer();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.panFunction = new System.Windows.Forms.Panel();
            this.cmbCon = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbtrueRaster = new System.Windows.Forms.ComboBox();
            this.cmbLayers = new System.Windows.Forms.ComboBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtField = new System.Windows.Forms.TextBox();
            this.btnCon = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.spcTOCAndMap.Panel1.SuspendLayout();
            this.spcTOCAndMap.Panel2.SuspendLayout();
            this.spcTOCAndMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.panFunction.SuspendLayout();
            this.SuspendLayout();
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 0);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(786, 28);
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
            this.spcTOCAndMap.Size = new System.Drawing.Size(786, 454);
            this.spcTOCAndMap.SplitterDistance = 205;
            this.spcTOCAndMap.TabIndex = 1;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl1.Location = new System.Drawing.Point(0, 0);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(205, 454);
            this.axTOCControl1.TabIndex = 0;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(176, 255);
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
            this.axMapControl1.Size = new System.Drawing.Size(334, 454);
            this.axMapControl1.TabIndex = 1;
            // 
            // panFunction
            // 
            this.panFunction.Controls.Add(this.label2);
            this.panFunction.Controls.Add(this.cmbCon);
            this.panFunction.Controls.Add(this.label4);
            this.panFunction.Controls.Add(this.label3);
            this.panFunction.Controls.Add(this.cmbtrueRaster);
            this.panFunction.Controls.Add(this.cmbLayers);
            this.panFunction.Controls.Add(this.txtValue);
            this.panFunction.Controls.Add(this.label1);
            this.panFunction.Controls.Add(this.txtField);
            this.panFunction.Controls.Add(this.btnCon);
            this.panFunction.Dock = System.Windows.Forms.DockStyle.Right;
            this.panFunction.Location = new System.Drawing.Point(334, 0);
            this.panFunction.Name = "panFunction";
            this.panFunction.Size = new System.Drawing.Size(243, 454);
            this.panFunction.TabIndex = 0;
            // 
            // cmbCon
            // 
            this.cmbCon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCon.FormattingEnabled = true;
            this.cmbCon.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            ">=",
            "<=",
            "<>"});
            this.cmbCon.Location = new System.Drawing.Point(92, 98);
            this.cmbCon.Name = "cmbCon";
            this.cmbCon.Size = new System.Drawing.Size(44, 20);
            this.cmbCon.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "输入条件为True时所取栅格数据：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "输入栅格：";
            // 
            // cmbtrueRaster
            // 
            this.cmbtrueRaster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtrueRaster.FormattingEnabled = true;
            this.cmbtrueRaster.Location = new System.Drawing.Point(78, 174);
            this.cmbtrueRaster.Name = "cmbtrueRaster";
            this.cmbtrueRaster.Size = new System.Drawing.Size(151, 20);
            this.cmbtrueRaster.TabIndex = 7;
            this.cmbtrueRaster.SelectedIndexChanged += new System.EventHandler(this.cmbtrueRaster_SelectedIndexChanged);
            this.cmbtrueRaster.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbLayers_MouseClick);
            // 
            // cmbLayers
            // 
            this.cmbLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLayers.FormattingEnabled = true;
            this.cmbLayers.Location = new System.Drawing.Point(74, 28);
            this.cmbLayers.Name = "cmbLayers";
            this.cmbLayers.Size = new System.Drawing.Size(157, 20);
            this.cmbLayers.TabIndex = 1;
            this.cmbLayers.SelectedIndexChanged += new System.EventHandler(this.cmbLayers_SelectedIndexChanged);
            this.cmbLayers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbLayers_MouseClick);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(142, 98);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(78, 21);
            this.txtValue.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "表达式：";
            // 
            // txtField
            // 
            this.txtField.Location = new System.Drawing.Point(19, 98);
            this.txtField.Name = "txtField";
            this.txtField.Size = new System.Drawing.Size(66, 21);
            this.txtField.TabIndex = 2;
            // 
            // btnCon
            // 
            this.btnCon.Location = new System.Drawing.Point(151, 224);
            this.btnCon.Name = "btnCon";
            this.btnCon.Size = new System.Drawing.Size(78, 23);
            this.btnCon.TabIndex = 3;
            this.btnCon.Text = "条件分析";
            this.btnCon.UseVisualStyleBackColor = true;
            this.btnCon.Click += new System.EventHandler(this.btnCon_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(38, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "value";
            // 
            // FrmConditional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 482);
            this.Controls.Add(this.spcTOCAndMap);
            this.Controls.Add(this.axToolbarControl1);
            this.Name = "FrmConditional";
            this.Text = "条件分析";
            this.Load += new System.EventHandler(this.FrmExtraction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.spcTOCAndMap.Panel1.ResumeLayout(false);
            this.spcTOCAndMap.Panel2.ResumeLayout(false);
            this.spcTOCAndMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.panFunction.ResumeLayout(false);
            this.panFunction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.SplitContainer spcTOCAndMap;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.Panel panFunction;
        private System.Windows.Forms.ComboBox cmbLayers;
        private System.Windows.Forms.TextBox txtField;
        private System.Windows.Forms.Button btnCon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbtrueRaster;
        private System.Windows.Forms.ComboBox cmbCon;
        private System.Windows.Forms.Label label2;
    }
}

