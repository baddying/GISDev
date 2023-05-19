namespace Extraction
{
    partial class FrmExtraction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExtraction));
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.spcTOCAndMap = new System.Windows.Forms.SplitContainer();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.panFunction = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.grpByShape = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnByShape = new System.Windows.Forms.Button();
            this.grpByMask = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnByMask = new System.Windows.Forms.Button();
            this.cmbMaskLayer = new System.Windows.Forms.ComboBox();
            this.grpByAtt = new System.Windows.Forms.GroupBox();
            this.cmbLogical = new System.Windows.Forms.ComboBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExtByAtt = new System.Windows.Forms.Button();
            this.txtField = new System.Windows.Forms.TextBox();
            this.cmbLayers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.spcTOCAndMap.Panel1.SuspendLayout();
            this.spcTOCAndMap.Panel2.SuspendLayout();
            this.spcTOCAndMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.panFunction.SuspendLayout();
            this.grpByShape.SuspendLayout();
            this.grpByMask.SuspendLayout();
            this.grpByAtt.SuspendLayout();
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
            this.panFunction.Controls.Add(this.label3);
            this.panFunction.Controls.Add(this.grpByShape);
            this.panFunction.Controls.Add(this.grpByMask);
            this.panFunction.Controls.Add(this.grpByAtt);
            this.panFunction.Controls.Add(this.cmbLayers);
            this.panFunction.Dock = System.Windows.Forms.DockStyle.Right;
            this.panFunction.Location = new System.Drawing.Point(334, 0);
            this.panFunction.Name = "panFunction";
            this.panFunction.Size = new System.Drawing.Size(243, 454);
            this.panFunction.TabIndex = 0;
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
            // grpByShape
            // 
            this.grpByShape.Controls.Add(this.label5);
            this.grpByShape.Controls.Add(this.btnByShape);
            this.grpByShape.Location = new System.Drawing.Point(10, 334);
            this.grpByShape.Name = "grpByShape";
            this.grpByShape.Size = new System.Drawing.Size(225, 91);
            this.grpByShape.TabIndex = 5;
            this.grpByShape.TabStop = false;
            this.grpByShape.Text = "按形状提取";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "将地图的当前视图范围设为提取矩形";
            // 
            // btnByShape
            // 
            this.btnByShape.Location = new System.Drawing.Point(141, 52);
            this.btnByShape.Name = "btnByShape";
            this.btnByShape.Size = new System.Drawing.Size(75, 23);
            this.btnByShape.TabIndex = 0;
            this.btnByShape.Text = "按矩形提取";
            this.btnByShape.UseVisualStyleBackColor = true;
            this.btnByShape.Click += new System.EventHandler(this.btnByShape_Click);
            // 
            // grpByMask
            // 
            this.grpByMask.Controls.Add(this.label4);
            this.grpByMask.Controls.Add(this.btnByMask);
            this.grpByMask.Controls.Add(this.cmbMaskLayer);
            this.grpByMask.Location = new System.Drawing.Point(10, 204);
            this.grpByMask.Name = "grpByMask";
            this.grpByMask.Size = new System.Drawing.Size(225, 110);
            this.grpByMask.TabIndex = 4;
            this.grpByMask.TabStop = false;
            this.grpByMask.Text = "按掩膜提取";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "掩膜图层：";
            // 
            // btnByMask
            // 
            this.btnByMask.Location = new System.Drawing.Point(143, 68);
            this.btnByMask.Name = "btnByMask";
            this.btnByMask.Size = new System.Drawing.Size(75, 23);
            this.btnByMask.TabIndex = 3;
            this.btnByMask.Text = "按掩膜提取";
            this.btnByMask.UseVisualStyleBackColor = true;
            this.btnByMask.Click += new System.EventHandler(this.btnByMask_Click);
            // 
            // cmbMaskLayer
            // 
            this.cmbMaskLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaskLayer.FormattingEnabled = true;
            this.cmbMaskLayer.Location = new System.Drawing.Point(79, 29);
            this.cmbMaskLayer.Name = "cmbMaskLayer";
            this.cmbMaskLayer.Size = new System.Drawing.Size(140, 20);
            this.cmbMaskLayer.TabIndex = 2;
            this.cmbMaskLayer.SelectedIndexChanged += new System.EventHandler(this.cmbMaskLayer_SelectedIndexChanged);
            this.cmbMaskLayer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbLayers_MouseClick);
            // 
            // grpByAtt
            // 
            this.grpByAtt.Controls.Add(this.label2);
            this.grpByAtt.Controls.Add(this.cmbLogical);
            this.grpByAtt.Controls.Add(this.txtValue);
            this.grpByAtt.Controls.Add(this.label1);
            this.grpByAtt.Controls.Add(this.btnExtByAtt);
            this.grpByAtt.Controls.Add(this.txtField);
            this.grpByAtt.Location = new System.Drawing.Point(6, 75);
            this.grpByAtt.Name = "grpByAtt";
            this.grpByAtt.Size = new System.Drawing.Size(225, 112);
            this.grpByAtt.TabIndex = 3;
            this.grpByAtt.TabStop = false;
            this.grpByAtt.Text = "按属性提取";
            // 
            // cmbLogical
            // 
            this.cmbLogical.FormattingEnabled = true;
            this.cmbLogical.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            ">=",
            "<=",
            "<>"});
            this.cmbLogical.Location = new System.Drawing.Point(91, 48);
            this.cmbLogical.Name = "cmbLogical";
            this.cmbLogical.Size = new System.Drawing.Size(42, 20);
            this.cmbLogical.TabIndex = 7;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(139, 47);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(78, 21);
            this.txtValue.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "查询字符串：";
            // 
            // btnExtByAtt
            // 
            this.btnExtByAtt.Location = new System.Drawing.Point(141, 75);
            this.btnExtByAtt.Name = "btnExtByAtt";
            this.btnExtByAtt.Size = new System.Drawing.Size(78, 23);
            this.btnExtByAtt.TabIndex = 3;
            this.btnExtByAtt.Text = "按属性提取";
            this.btnExtByAtt.UseVisualStyleBackColor = true;
            this.btnExtByAtt.Click += new System.EventHandler(this.btnExtByAtt_Click);
            // 
            // txtField
            // 
            this.txtField.Location = new System.Drawing.Point(18, 48);
            this.txtField.Name = "txtField";
            this.txtField.Size = new System.Drawing.Size(66, 21);
            this.txtField.TabIndex = 2;
            // 
            // cmbLayers
            // 
            this.cmbLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLayers.FormattingEnabled = true;
            this.cmbLayers.Location = new System.Drawing.Point(91, 28);
            this.cmbLayers.Name = "cmbLayers";
            this.cmbLayers.Size = new System.Drawing.Size(140, 20);
            this.cmbLayers.TabIndex = 1;
            this.cmbLayers.SelectedIndexChanged += new System.EventHandler(this.cmbLayers_SelectedIndexChanged);
            this.cmbLayers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbLayers_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(32, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "value";
            // 
            // FrmExtraction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 482);
            this.Controls.Add(this.spcTOCAndMap);
            this.Controls.Add(this.axToolbarControl1);
            this.Name = "FrmExtraction";
            this.Text = "提取分析";
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
            this.grpByShape.ResumeLayout(false);
            this.grpByShape.PerformLayout();
            this.grpByMask.ResumeLayout(false);
            this.grpByMask.PerformLayout();
            this.grpByAtt.ResumeLayout(false);
            this.grpByAtt.PerformLayout();
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
        private System.Windows.Forms.GroupBox grpByAtt;
        private System.Windows.Forms.Button btnExtByAtt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.GroupBox grpByMask;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpByShape;
        private System.Windows.Forms.ComboBox cmbMaskLayer;
        private System.Windows.Forms.Button btnByMask;
        private System.Windows.Forms.Button btnByShape;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbLogical;
        private System.Windows.Forms.Label label2;
    }
}

