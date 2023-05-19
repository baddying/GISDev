namespace ReClass
{
    partial class FrmReClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReClass));
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.apcTOCAndMap = new System.Windows.Forms.SplitContainer();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.panFunction = new System.Windows.Forms.Panel();
            this.chkNoData = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.cmbSliceType = new System.Windows.Forms.ComboBox();
            this.btnSlice = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnASCII = new System.Windows.Forms.Button();
            this.btnASCIIPath = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtASCIIPath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReclass = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbOutField = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbToField = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbFromField = new System.Windows.Forms.ComboBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.cmbLayers = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.apcTOCAndMap.Panel1.SuspendLayout();
            this.apcTOCAndMap.Panel2.SuspendLayout();
            this.apcTOCAndMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.panFunction.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 0);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(834, 28);
            this.axToolbarControl1.TabIndex = 0;
            // 
            // apcTOCAndMap
            // 
            this.apcTOCAndMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.apcTOCAndMap.Location = new System.Drawing.Point(0, 28);
            this.apcTOCAndMap.Name = "apcTOCAndMap";
            // 
            // apcTOCAndMap.Panel1
            // 
            this.apcTOCAndMap.Panel1.Controls.Add(this.axTOCControl1);
            // 
            // apcTOCAndMap.Panel2
            // 
            this.apcTOCAndMap.Panel2.Controls.Add(this.axLicenseControl1);
            this.apcTOCAndMap.Panel2.Controls.Add(this.axMapControl1);
            this.apcTOCAndMap.Panel2.Controls.Add(this.panFunction);
            this.apcTOCAndMap.Size = new System.Drawing.Size(834, 482);
            this.apcTOCAndMap.SplitterDistance = 261;
            this.apcTOCAndMap.TabIndex = 1;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl1.Location = new System.Drawing.Point(0, 0);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(261, 482);
            this.axTOCControl1.TabIndex = 0;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(184, 288);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 3;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(0, 0);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(301, 482);
            this.axMapControl1.TabIndex = 2;
            // 
            // panFunction
            // 
            this.panFunction.Controls.Add(this.chkNoData);
            this.panFunction.Controls.Add(this.label1);
            this.panFunction.Controls.Add(this.groupBox3);
            this.panFunction.Controls.Add(this.groupBox2);
            this.panFunction.Controls.Add(this.groupBox1);
            this.panFunction.Controls.Add(this.cmbLayers);
            this.panFunction.Dock = System.Windows.Forms.DockStyle.Right;
            this.panFunction.Location = new System.Drawing.Point(301, 0);
            this.panFunction.Name = "panFunction";
            this.panFunction.Size = new System.Drawing.Size(268, 482);
            this.panFunction.TabIndex = 1;
            // 
            // chkNoData
            // 
            this.chkNoData.AutoSize = true;
            this.chkNoData.Location = new System.Drawing.Point(109, 53);
            this.chkNoData.Name = "chkNoData";
            this.chkNoData.Size = new System.Drawing.Size(150, 16);
            this.chkNoData.TabIndex = 21;
            this.chkNoData.Text = "将缺失值更改为NoData ";
            this.chkNoData.UseVisualStyleBackColor = true;
            this.chkNoData.CheckedChanged += new System.EventHandler(this.chkNoData_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "输入栅格：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtCount);
            this.groupBox3.Controls.Add(this.cmbSliceType);
            this.groupBox3.Controls.Add(this.btnSlice);
            this.groupBox3.Location = new System.Drawing.Point(6, 365);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(259, 114);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "分割";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "分割方法：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(80, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "输出区域的个数：";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(187, 20);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(63, 21);
            this.txtCount.TabIndex = 18;
            this.txtCount.TextChanged += new System.EventHandler(this.txtCount_TextChanged);
            // 
            // cmbSliceType
            // 
            this.cmbSliceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSliceType.FormattingEnabled = true;
            this.cmbSliceType.Items.AddRange(new object[] {
            "EQUAL_INTERVAL",
            "EQUAL_AREA",
            "NATURAL_BREAKS"});
            this.cmbSliceType.Location = new System.Drawing.Point(100, 56);
            this.cmbSliceType.Name = "cmbSliceType";
            this.cmbSliceType.Size = new System.Drawing.Size(153, 20);
            this.cmbSliceType.TabIndex = 17;
            this.cmbSliceType.SelectedIndexChanged += new System.EventHandler(this.cmbSliceType_SelectedIndexChanged);
            // 
            // btnSlice
            // 
            this.btnSlice.Location = new System.Drawing.Point(170, 82);
            this.btnSlice.Name = "btnSlice";
            this.btnSlice.Size = new System.Drawing.Size(83, 23);
            this.btnSlice.TabIndex = 3;
            this.btnSlice.Text = "分割";
            this.btnSlice.UseVisualStyleBackColor = true;
            this.btnSlice.Click += new System.EventHandler(this.btnSlice_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnASCII);
            this.groupBox2.Controls.Add(this.btnASCIIPath);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtASCIIPath);
            this.groupBox2.Location = new System.Drawing.Point(6, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 100);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "使用ASCII文件重分类";
            // 
            // btnASCII
            // 
            this.btnASCII.Location = new System.Drawing.Point(121, 71);
            this.btnASCII.Name = "btnASCII";
            this.btnASCII.Size = new System.Drawing.Size(129, 23);
            this.btnASCII.TabIndex = 17;
            this.btnASCII.Text = "使用ASCII文件重分类";
            this.btnASCII.UseVisualStyleBackColor = true;
            this.btnASCII.Click += new System.EventHandler(this.btnASCII_Click);
            // 
            // btnASCIIPath
            // 
            this.btnASCIIPath.Image = global::ReClass.Properties.Resources.Folder16;
            this.btnASCIIPath.Location = new System.Drawing.Point(225, 26);
            this.btnASCIIPath.Name = "btnASCIIPath";
            this.btnASCIIPath.Size = new System.Drawing.Size(28, 24);
            this.btnASCIIPath.TabIndex = 16;
            this.btnASCIIPath.UseVisualStyleBackColor = true;
            this.btnASCIIPath.Click += new System.EventHandler(this.btnASCIIPath_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "ASCII文件：";
            // 
            // txtASCIIPath
            // 
            this.txtASCIIPath.Location = new System.Drawing.Point(83, 29);
            this.txtASCIIPath.Name = "txtASCIIPath";
            this.txtASCIIPath.ReadOnly = true;
            this.txtASCIIPath.Size = new System.Drawing.Size(135, 21);
            this.txtASCIIPath.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReclass);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbOutField);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbToField);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbFromField);
            this.groupBox1.Controls.Add(this.btnBrowser);
            this.groupBox1.Controls.Add(this.cmbTables);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Location = new System.Drawing.Point(6, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 178);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "使用表重分类";
            // 
            // btnReclass
            // 
            this.btnReclass.Location = new System.Drawing.Point(154, 144);
            this.btnReclass.Name = "btnReclass";
            this.btnReclass.Size = new System.Drawing.Size(99, 23);
            this.btnReclass.TabIndex = 21;
            this.btnReclass.Text = "使用表重分类";
            this.btnReclass.UseVisualStyleBackColor = true;
            this.btnReclass.Click += new System.EventHandler(this.btnReclass_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(185, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "输出值字段";
            // 
            // cmbOutField
            // 
            this.cmbOutField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutField.FormattingEnabled = true;
            this.cmbOutField.Location = new System.Drawing.Point(187, 105);
            this.cmbOutField.Name = "cmbOutField";
            this.cmbOutField.Size = new System.Drawing.Size(63, 20);
            this.cmbOutField.TabIndex = 18;
            this.cmbOutField.SelectedIndexChanged += new System.EventHandler(this.cmbOutField_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(103, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "到值字段";
            // 
            // cmbToField
            // 
            this.cmbToField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToField.FormattingEnabled = true;
            this.cmbToField.Location = new System.Drawing.Point(105, 105);
            this.cmbToField.Name = "cmbToField";
            this.cmbToField.Size = new System.Drawing.Size(58, 20);
            this.cmbToField.TabIndex = 16;
            this.cmbToField.SelectedIndexChanged += new System.EventHandler(this.cmbToField_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "来自值字段";
            // 
            // cmbFromField
            // 
            this.cmbFromField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromField.FormattingEnabled = true;
            this.cmbFromField.Location = new System.Drawing.Point(18, 105);
            this.cmbFromField.Name = "cmbFromField";
            this.cmbFromField.Size = new System.Drawing.Size(59, 20);
            this.cmbFromField.TabIndex = 14;
            this.cmbFromField.SelectedIndexChanged += new System.EventHandler(this.cmbFromField_SelectedIndexChanged);
            // 
            // btnBrowser
            // 
            this.btnBrowser.Image = global::ReClass.Properties.Resources.Folder16;
            this.btnBrowser.Location = new System.Drawing.Point(225, 17);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(28, 24);
            this.btnBrowser.TabIndex = 13;
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // cmbTables
            // 
            this.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTables.FormattingEnabled = true;
            this.cmbTables.Location = new System.Drawing.Point(97, 55);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(121, 20);
            this.cmbTables.TabIndex = 12;
            this.cmbTables.SelectedIndexChanged += new System.EventHandler(this.cmbTables_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "选择表：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "输入数据库：";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(83, 20);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(135, 21);
            this.txtPath.TabIndex = 0;
            // 
            // cmbLayers
            // 
            this.cmbLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLayers.FormattingEnabled = true;
            this.cmbLayers.Location = new System.Drawing.Point(81, 20);
            this.cmbLayers.Name = "cmbLayers";
            this.cmbLayers.Size = new System.Drawing.Size(175, 20);
            this.cmbLayers.TabIndex = 5;
            this.cmbLayers.SelectedIndexChanged += new System.EventHandler(this.cmbLayers_SelectedIndexChanged);
            this.cmbLayers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbLayers_MouseClick);
            // 
            // FrmReClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 510);
            this.Controls.Add(this.apcTOCAndMap);
            this.Controls.Add(this.axToolbarControl1);
            this.Name = "FrmReClass";
            this.Text = "重分类";
            this.Load += new System.EventHandler(this.FrmReClass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.apcTOCAndMap.Panel1.ResumeLayout(false);
            this.apcTOCAndMap.Panel2.ResumeLayout(false);
            this.apcTOCAndMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.panFunction.ResumeLayout(false);
            this.panFunction.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.SplitContainer apcTOCAndMap;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private System.Windows.Forms.Panel panFunction;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.Button btnSlice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbLayers;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbFromField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbOutField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbToField;
        private System.Windows.Forms.Button btnReclass;
        private System.Windows.Forms.Button btnASCIIPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtASCIIPath;
        private System.Windows.Forms.Button btnASCII;
        private System.Windows.Forms.CheckBox chkNoData;
        private System.Windows.Forms.ComboBox cmbSliceType;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

