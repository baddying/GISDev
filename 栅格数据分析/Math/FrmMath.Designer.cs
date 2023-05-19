namespace Math
{
    partial class FrmMath
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMath));
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.spcTOCAndMap = new System.Windows.Forms.SplitContainer();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.panFunction = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBitwise = new System.Windows.Forms.GroupBox();
            this.btnNot = new System.Windows.Forms.Button();
            this.btnOr = new System.Windows.Forms.Button();
            this.btnAnd = new System.Windows.Forms.Button();
            this.grpTrig = new System.Windows.Forms.GroupBox();
            this.btnACos = new System.Windows.Forms.Button();
            this.btnAsin = new System.Windows.Forms.Button();
            this.btnTan = new System.Windows.Forms.Button();
            this.btnCos = new System.Windows.Forms.Button();
            this.btnSin = new System.Windows.Forms.Button();
            this.grpLogical = new System.Windows.Forms.GroupBox();
            this.btnEqualTo = new System.Windows.Forms.Button();
            this.btnNotEqual = new System.Windows.Forms.Button();
            this.btnLessThan = new System.Windows.Forms.Button();
            this.btnGreaterThan = new System.Windows.Forms.Button();
            this.grpMath = new System.Windows.Forms.GroupBox();
            this.btnAbs = new System.Windows.Forms.Button();
            this.btnDivide = new System.Windows.Forms.Button();
            this.btnTimes = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.cmbInputData2 = new System.Windows.Forms.ComboBox();
            this.cmbInputData1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.spcTOCAndMap.Panel1.SuspendLayout();
            this.spcTOCAndMap.Panel2.SuspendLayout();
            this.spcTOCAndMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.panFunction.SuspendLayout();
            this.grpBitwise.SuspendLayout();
            this.grpTrig.SuspendLayout();
            this.grpLogical.SuspendLayout();
            this.grpMath.SuspendLayout();
            this.SuspendLayout();
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 0);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(852, 28);
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
            this.spcTOCAndMap.Size = new System.Drawing.Size(852, 471);
            this.spcTOCAndMap.SplitterDistance = 232;
            this.spcTOCAndMap.TabIndex = 1;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl1.Location = new System.Drawing.Point(0, 0);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(232, 471);
            this.axTOCControl1.TabIndex = 0;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(125, 268);
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
            this.axMapControl1.Size = new System.Drawing.Size(332, 471);
            this.axMapControl1.TabIndex = 1;
            // 
            // panFunction
            // 
            this.panFunction.Controls.Add(this.label2);
            this.panFunction.Controls.Add(this.label1);
            this.panFunction.Controls.Add(this.grpBitwise);
            this.panFunction.Controls.Add(this.grpTrig);
            this.panFunction.Controls.Add(this.grpLogical);
            this.panFunction.Controls.Add(this.grpMath);
            this.panFunction.Controls.Add(this.cmbInputData2);
            this.panFunction.Controls.Add(this.cmbInputData1);
            this.panFunction.Dock = System.Windows.Forms.DockStyle.Right;
            this.panFunction.Location = new System.Drawing.Point(332, 0);
            this.panFunction.Name = "panFunction";
            this.panFunction.Size = new System.Drawing.Size(284, 471);
            this.panFunction.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "输入数据2：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "输入数据1：";
            // 
            // grpBitwise
            // 
            this.grpBitwise.Controls.Add(this.btnNot);
            this.grpBitwise.Controls.Add(this.btnOr);
            this.grpBitwise.Controls.Add(this.btnAnd);
            this.grpBitwise.Location = new System.Drawing.Point(20, 367);
            this.grpBitwise.Name = "grpBitwise";
            this.grpBitwise.Size = new System.Drawing.Size(252, 65);
            this.grpBitwise.TabIndex = 5;
            this.grpBitwise.TabStop = false;
            this.grpBitwise.Text = "按位运算";
            // 
            // btnNot
            // 
            this.btnNot.Location = new System.Drawing.Point(165, 20);
            this.btnNot.Name = "btnNot";
            this.btnNot.Size = new System.Drawing.Size(70, 23);
            this.btnNot.TabIndex = 2;
            this.btnNot.Text = "按位非";
            this.btnNot.UseVisualStyleBackColor = true;
            this.btnNot.Click += new System.EventHandler(this.btnNot_Click);
            // 
            // btnOr
            // 
            this.btnOr.Location = new System.Drawing.Point(89, 20);
            this.btnOr.Name = "btnOr";
            this.btnOr.Size = new System.Drawing.Size(70, 23);
            this.btnOr.TabIndex = 1;
            this.btnOr.Text = "按位或";
            this.btnOr.UseVisualStyleBackColor = true;
            this.btnOr.Click += new System.EventHandler(this.btnOr_Click);
            // 
            // btnAnd
            // 
            this.btnAnd.Location = new System.Drawing.Point(13, 20);
            this.btnAnd.Name = "btnAnd";
            this.btnAnd.Size = new System.Drawing.Size(70, 23);
            this.btnAnd.TabIndex = 0;
            this.btnAnd.Text = "按位与";
            this.btnAnd.UseVisualStyleBackColor = true;
            this.btnAnd.Click += new System.EventHandler(this.btnAnd_Click);
            // 
            // grpTrig
            // 
            this.grpTrig.Controls.Add(this.btnACos);
            this.grpTrig.Controls.Add(this.btnAsin);
            this.grpTrig.Controls.Add(this.btnTan);
            this.grpTrig.Controls.Add(this.btnCos);
            this.grpTrig.Controls.Add(this.btnSin);
            this.grpTrig.Location = new System.Drawing.Point(20, 285);
            this.grpTrig.Name = "grpTrig";
            this.grpTrig.Size = new System.Drawing.Size(252, 61);
            this.grpTrig.TabIndex = 4;
            this.grpTrig.TabStop = false;
            this.grpTrig.Text = "三角函数运算(只需输入数据1)";
            // 
            // btnACos
            // 
            this.btnACos.Location = new System.Drawing.Point(189, 20);
            this.btnACos.Name = "btnACos";
            this.btnACos.Size = new System.Drawing.Size(42, 23);
            this.btnACos.TabIndex = 8;
            this.btnACos.Text = "ACos";
            this.btnACos.UseVisualStyleBackColor = true;
            this.btnACos.Click += new System.EventHandler(this.btnACos_Click);
            // 
            // btnAsin
            // 
            this.btnAsin.Location = new System.Drawing.Point(140, 20);
            this.btnAsin.Name = "btnAsin";
            this.btnAsin.Size = new System.Drawing.Size(41, 23);
            this.btnAsin.TabIndex = 7;
            this.btnAsin.Text = "ASin";
            this.btnAsin.UseVisualStyleBackColor = true;
            this.btnAsin.Click += new System.EventHandler(this.btnAsin_Click);
            // 
            // btnTan
            // 
            this.btnTan.Location = new System.Drawing.Point(97, 20);
            this.btnTan.Name = "btnTan";
            this.btnTan.Size = new System.Drawing.Size(37, 23);
            this.btnTan.TabIndex = 6;
            this.btnTan.Text = "Tan";
            this.btnTan.UseVisualStyleBackColor = true;
            this.btnTan.Click += new System.EventHandler(this.btnTan_Click);
            // 
            // btnCos
            // 
            this.btnCos.Location = new System.Drawing.Point(56, 20);
            this.btnCos.Name = "btnCos";
            this.btnCos.Size = new System.Drawing.Size(35, 23);
            this.btnCos.TabIndex = 5;
            this.btnCos.Text = "Cos";
            this.btnCos.UseVisualStyleBackColor = true;
            this.btnCos.Click += new System.EventHandler(this.btnCos_Click);
            // 
            // btnSin
            // 
            this.btnSin.Location = new System.Drawing.Point(14, 20);
            this.btnSin.Name = "btnSin";
            this.btnSin.Size = new System.Drawing.Size(37, 23);
            this.btnSin.TabIndex = 4;
            this.btnSin.Text = "Sin";
            this.btnSin.UseVisualStyleBackColor = true;
            this.btnSin.Click += new System.EventHandler(this.btnSin_Click);
            // 
            // grpLogical
            // 
            this.grpLogical.Controls.Add(this.btnEqualTo);
            this.grpLogical.Controls.Add(this.btnNotEqual);
            this.grpLogical.Controls.Add(this.btnLessThan);
            this.grpLogical.Controls.Add(this.btnGreaterThan);
            this.grpLogical.Location = new System.Drawing.Point(20, 206);
            this.grpLogical.Name = "grpLogical";
            this.grpLogical.Size = new System.Drawing.Size(252, 58);
            this.grpLogical.TabIndex = 3;
            this.grpLogical.TabStop = false;
            this.grpLogical.Text = "逻辑运算";
            // 
            // btnEqualTo
            // 
            this.btnEqualTo.Location = new System.Drawing.Point(179, 21);
            this.btnEqualTo.Name = "btnEqualTo";
            this.btnEqualTo.Size = new System.Drawing.Size(49, 23);
            this.btnEqualTo.TabIndex = 3;
            this.btnEqualTo.Text = "等于";
            this.btnEqualTo.UseVisualStyleBackColor = true;
            this.btnEqualTo.Click += new System.EventHandler(this.btnEqualTo_Click);
            // 
            // btnNotEqual
            // 
            this.btnNotEqual.Location = new System.Drawing.Point(124, 21);
            this.btnNotEqual.Name = "btnNotEqual";
            this.btnNotEqual.Size = new System.Drawing.Size(49, 23);
            this.btnNotEqual.TabIndex = 2;
            this.btnNotEqual.Text = "差异";
            this.btnNotEqual.UseVisualStyleBackColor = true;
            this.btnNotEqual.Click += new System.EventHandler(this.btnNotEqual_Click);
            // 
            // btnLessThan
            // 
            this.btnLessThan.Location = new System.Drawing.Point(69, 21);
            this.btnLessThan.Name = "btnLessThan";
            this.btnLessThan.Size = new System.Drawing.Size(49, 23);
            this.btnLessThan.TabIndex = 1;
            this.btnLessThan.Text = "小于";
            this.btnLessThan.UseVisualStyleBackColor = true;
            this.btnLessThan.Click += new System.EventHandler(this.btnLessThan_Click);
            // 
            // btnGreaterThan
            // 
            this.btnGreaterThan.Location = new System.Drawing.Point(14, 21);
            this.btnGreaterThan.Name = "btnGreaterThan";
            this.btnGreaterThan.Size = new System.Drawing.Size(49, 23);
            this.btnGreaterThan.TabIndex = 0;
            this.btnGreaterThan.Text = "大于";
            this.btnGreaterThan.UseVisualStyleBackColor = true;
            this.btnGreaterThan.Click += new System.EventHandler(this.btnGreaterThan_Click);
            // 
            // grpMath
            // 
            this.grpMath.Controls.Add(this.btnAbs);
            this.grpMath.Controls.Add(this.btnDivide);
            this.grpMath.Controls.Add(this.btnTimes);
            this.grpMath.Controls.Add(this.btnMinus);
            this.grpMath.Controls.Add(this.btnPlus);
            this.grpMath.Location = new System.Drawing.Point(20, 123);
            this.grpMath.Name = "grpMath";
            this.grpMath.Size = new System.Drawing.Size(252, 61);
            this.grpMath.TabIndex = 2;
            this.grpMath.TabStop = false;
            this.grpMath.Text = "数学运算";
            // 
            // btnAbs
            // 
            this.btnAbs.Location = new System.Drawing.Point(186, 30);
            this.btnAbs.Name = "btnAbs";
            this.btnAbs.Size = new System.Drawing.Size(60, 25);
            this.btnAbs.TabIndex = 4;
            this.btnAbs.Text = "绝对值";
            this.btnAbs.UseVisualStyleBackColor = true;
            this.btnAbs.Click += new System.EventHandler(this.btnAbs_Click);
            // 
            // btnDivide
            // 
            this.btnDivide.Location = new System.Drawing.Point(134, 30);
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.Size = new System.Drawing.Size(34, 25);
            this.btnDivide.TabIndex = 3;
            this.btnDivide.Text = "除";
            this.btnDivide.UseVisualStyleBackColor = true;
            this.btnDivide.Click += new System.EventHandler(this.btnDivide_Click);
            // 
            // btnTimes
            // 
            this.btnTimes.Location = new System.Drawing.Point(94, 30);
            this.btnTimes.Name = "btnTimes";
            this.btnTimes.Size = new System.Drawing.Size(34, 25);
            this.btnTimes.TabIndex = 2;
            this.btnTimes.Text = "乘";
            this.btnTimes.UseVisualStyleBackColor = true;
            this.btnTimes.Click += new System.EventHandler(this.btnTimes_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Location = new System.Drawing.Point(54, 30);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(34, 25);
            this.btnMinus.TabIndex = 1;
            this.btnMinus.Text = "减";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Location = new System.Drawing.Point(14, 30);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(34, 25);
            this.btnPlus.TabIndex = 0;
            this.btnPlus.Text = "加";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // cmbInputData2
            // 
            this.cmbInputData2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInputData2.FormattingEnabled = true;
            this.cmbInputData2.Location = new System.Drawing.Point(109, 70);
            this.cmbInputData2.Name = "cmbInputData2";
            this.cmbInputData2.Size = new System.Drawing.Size(163, 20);
            this.cmbInputData2.TabIndex = 1;
            this.cmbInputData2.SelectedIndexChanged += new System.EventHandler(this.cmbInputData2_SelectedIndexChanged);
            this.cmbInputData2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbInputData1_MouseClick);
            // 
            // cmbInputData1
            // 
            this.cmbInputData1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInputData1.FormattingEnabled = true;
            this.cmbInputData1.Location = new System.Drawing.Point(109, 27);
            this.cmbInputData1.Name = "cmbInputData1";
            this.cmbInputData1.Size = new System.Drawing.Size(163, 20);
            this.cmbInputData1.TabIndex = 0;
            this.cmbInputData1.SelectedIndexChanged += new System.EventHandler(this.cmbInputData1_SelectedIndexChanged);
            this.cmbInputData1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbInputData1_MouseClick);
            // 
            // FrmMath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 499);
            this.Controls.Add(this.spcTOCAndMap);
            this.Controls.Add(this.axToolbarControl1);
            this.Name = "FrmMath";
            this.Text = "栅格计算";
            this.Load += new System.EventHandler(this.FrmMath_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.spcTOCAndMap.Panel1.ResumeLayout(false);
            this.spcTOCAndMap.Panel2.ResumeLayout(false);
            this.spcTOCAndMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.panFunction.ResumeLayout(false);
            this.panFunction.PerformLayout();
            this.grpBitwise.ResumeLayout(false);
            this.grpTrig.ResumeLayout(false);
            this.grpLogical.ResumeLayout(false);
            this.grpMath.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.SplitContainer spcTOCAndMap;
        private System.Windows.Forms.Panel panFunction;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.GroupBox grpBitwise;
        private System.Windows.Forms.GroupBox grpTrig;
        private System.Windows.Forms.GroupBox grpLogical;
        private System.Windows.Forms.GroupBox grpMath;
        private System.Windows.Forms.ComboBox cmbInputData2;
        private System.Windows.Forms.ComboBox cmbInputData1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAbs;
        private System.Windows.Forms.Button btnDivide;
        private System.Windows.Forms.Button btnTimes;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnACos;
        private System.Windows.Forms.Button btnAsin;
        private System.Windows.Forms.Button btnTan;
        private System.Windows.Forms.Button btnCos;
        private System.Windows.Forms.Button btnSin;
        private System.Windows.Forms.Button btnEqualTo;
        private System.Windows.Forms.Button btnNotEqual;
        private System.Windows.Forms.Button btnLessThan;
        private System.Windows.Forms.Button btnGreaterThan;
        private System.Windows.Forms.Button btnNot;
        private System.Windows.Forms.Button btnOr;
        private System.Windows.Forms.Button btnAnd;
    }
}

