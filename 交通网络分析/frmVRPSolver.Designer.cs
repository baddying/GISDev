namespace 交通网络分析
{
    partial class frmVRPSolver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVRPSolver));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoadMap = new System.Windows.Forms.Button();
            this.txtInputRoutes = new System.Windows.Forms.TextBox();
            this.txtInputDepots = new System.Windows.Forms.TextBox();
            this.txtInputStops = new System.Windows.Forms.TextBox();
            this.txtFeatureDataset = new System.Windows.Forms.TextBox();
            this.txtNetworkDataset = new System.Windows.Forms.TextBox();
            this.txtWorkspacePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbVRPSolver = new System.Windows.Forms.GroupBox();
            this.btnSolve = new System.Windows.Forms.Button();
            this.lstOutput = new System.Windows.Forms.ListBox();
            this.chkUseRestriction = new System.Windows.Forms.CheckBox();
            this.comboTWImportance = new System.Windows.Forms.ComboBox();
            this.comboDistUnits = new System.Windows.Forms.ComboBox();
            this.comboTimeUnits = new System.Windows.Forms.ComboBox();
            this.comboDistanceAttribute = new System.Windows.Forms.ComboBox();
            this.comboTimeAttribute = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbVRPSolver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLoadMap);
            this.groupBox1.Controls.Add(this.txtInputRoutes);
            this.groupBox1.Controls.Add(this.txtInputDepots);
            this.groupBox1.Controls.Add(this.txtInputStops);
            this.groupBox1.Controls.Add(this.txtFeatureDataset);
            this.groupBox1.Controls.Add(this.txtNetworkDataset);
            this.groupBox1.Controls.Add(this.txtWorkspacePath);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(706, 184);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "地图结构";
            // 
            // btnLoadMap
            // 
            this.btnLoadMap.Location = new System.Drawing.Point(563, 91);
            this.btnLoadMap.Name = "btnLoadMap";
            this.btnLoadMap.Size = new System.Drawing.Size(75, 23);
            this.btnLoadMap.TabIndex = 12;
            this.btnLoadMap.Text = "加载";
            this.btnLoadMap.UseVisualStyleBackColor = true;
            this.btnLoadMap.Click += new System.EventHandler(this.btnLoadMap_Click);
            // 
            // txtInputRoutes
            // 
            this.txtInputRoutes.Location = new System.Drawing.Point(103, 149);
            this.txtInputRoutes.Name = "txtInputRoutes";
            this.txtInputRoutes.Size = new System.Drawing.Size(397, 21);
            this.txtInputRoutes.TabIndex = 11;
            // 
            // txtInputDepots
            // 
            this.txtInputDepots.Location = new System.Drawing.Point(103, 124);
            this.txtInputDepots.Name = "txtInputDepots";
            this.txtInputDepots.Size = new System.Drawing.Size(397, 21);
            this.txtInputDepots.TabIndex = 10;
            // 
            // txtInputStops
            // 
            this.txtInputStops.Location = new System.Drawing.Point(103, 98);
            this.txtInputStops.Name = "txtInputStops";
            this.txtInputStops.Size = new System.Drawing.Size(397, 21);
            this.txtInputStops.TabIndex = 9;
            // 
            // txtFeatureDataset
            // 
            this.txtFeatureDataset.Location = new System.Drawing.Point(103, 72);
            this.txtFeatureDataset.Name = "txtFeatureDataset";
            this.txtFeatureDataset.Size = new System.Drawing.Size(397, 21);
            this.txtFeatureDataset.TabIndex = 8;
            // 
            // txtNetworkDataset
            // 
            this.txtNetworkDataset.Location = new System.Drawing.Point(103, 46);
            this.txtNetworkDataset.Name = "txtNetworkDataset";
            this.txtNetworkDataset.Size = new System.Drawing.Size(397, 21);
            this.txtNetworkDataset.TabIndex = 7;
            // 
            // txtWorkspacePath
            // 
            this.txtWorkspacePath.Location = new System.Drawing.Point(103, 20);
            this.txtWorkspacePath.Name = "txtWorkspacePath";
            this.txtWorkspacePath.Size = new System.Drawing.Size(397, 21);
            this.txtWorkspacePath.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "输入路径：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "输入仓库点：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "输入站点：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "要素数据集：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "网络数据集：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "工作空间路径：";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 184);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbVRPSolver);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.axMapControl1);
            this.splitContainer1.Size = new System.Drawing.Size(706, 360);
            this.splitContainer1.SplitterDistance = 314;
            this.splitContainer1.TabIndex = 1;
            // 
            // gbVRPSolver
            // 
            this.gbVRPSolver.Controls.Add(this.btnSolve);
            this.gbVRPSolver.Controls.Add(this.lstOutput);
            this.gbVRPSolver.Controls.Add(this.chkUseRestriction);
            this.gbVRPSolver.Controls.Add(this.comboTWImportance);
            this.gbVRPSolver.Controls.Add(this.comboDistUnits);
            this.gbVRPSolver.Controls.Add(this.comboTimeUnits);
            this.gbVRPSolver.Controls.Add(this.comboDistanceAttribute);
            this.gbVRPSolver.Controls.Add(this.comboTimeAttribute);
            this.gbVRPSolver.Controls.Add(this.label11);
            this.gbVRPSolver.Controls.Add(this.label10);
            this.gbVRPSolver.Controls.Add(this.label9);
            this.gbVRPSolver.Controls.Add(this.label8);
            this.gbVRPSolver.Controls.Add(this.label7);
            this.gbVRPSolver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbVRPSolver.Location = new System.Drawing.Point(0, 0);
            this.gbVRPSolver.Name = "gbVRPSolver";
            this.gbVRPSolver.Size = new System.Drawing.Size(314, 360);
            this.gbVRPSolver.TabIndex = 0;
            this.gbVRPSolver.TabStop = false;
            this.gbVRPSolver.Text = "多路径配送分析";
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(121, 320);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 12;
            this.btnSolve.Text = "解决";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // lstOutput
            // 
            this.lstOutput.FormattingEnabled = true;
            this.lstOutput.HorizontalScrollbar = true;
            this.lstOutput.ItemHeight = 12;
            this.lstOutput.Location = new System.Drawing.Point(22, 170);
            this.lstOutput.Name = "lstOutput";
            this.lstOutput.ScrollAlwaysVisible = true;
            this.lstOutput.Size = new System.Drawing.Size(280, 124);
            this.lstOutput.TabIndex = 11;
            // 
            // chkUseRestriction
            // 
            this.chkUseRestriction.AutoSize = true;
            this.chkUseRestriction.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkUseRestriction.Location = new System.Drawing.Point(88, 147);
            this.chkUseRestriction.Name = "chkUseRestriction";
            this.chkUseRestriction.Size = new System.Drawing.Size(108, 16);
            this.chkUseRestriction.TabIndex = 10;
            this.chkUseRestriction.Text = "使用单行线限制";
            this.chkUseRestriction.UseVisualStyleBackColor = true;
            // 
            // comboTWImportance
            // 
            this.comboTWImportance.FormattingEnabled = true;
            this.comboTWImportance.Location = new System.Drawing.Point(146, 121);
            this.comboTWImportance.Name = "comboTWImportance";
            this.comboTWImportance.Size = new System.Drawing.Size(121, 20);
            this.comboTWImportance.TabIndex = 9;
            // 
            // comboDistUnits
            // 
            this.comboDistUnits.FormattingEnabled = true;
            this.comboDistUnits.Location = new System.Drawing.Point(146, 99);
            this.comboDistUnits.Name = "comboDistUnits";
            this.comboDistUnits.Size = new System.Drawing.Size(121, 20);
            this.comboDistUnits.TabIndex = 8;
            // 
            // comboTimeUnits
            // 
            this.comboTimeUnits.FormattingEnabled = true;
            this.comboTimeUnits.Location = new System.Drawing.Point(146, 76);
            this.comboTimeUnits.Name = "comboTimeUnits";
            this.comboTimeUnits.Size = new System.Drawing.Size(121, 20);
            this.comboTimeUnits.TabIndex = 7;
            // 
            // comboDistanceAttribute
            // 
            this.comboDistanceAttribute.FormattingEnabled = true;
            this.comboDistanceAttribute.Location = new System.Drawing.Point(146, 52);
            this.comboDistanceAttribute.Name = "comboDistanceAttribute";
            this.comboDistanceAttribute.Size = new System.Drawing.Size(121, 20);
            this.comboDistanceAttribute.TabIndex = 6;
            // 
            // comboTimeAttribute
            // 
            this.comboTimeAttribute.FormattingEnabled = true;
            this.comboTimeAttribute.Location = new System.Drawing.Point(146, 30);
            this.comboTimeAttribute.Name = "comboTimeAttribute";
            this.comboTimeAttribute.Size = new System.Drawing.Size(121, 20);
            this.comboTimeAttribute.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(38, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "时间窗冲突重要性：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(62, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "距离字段单位：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "时间字段单位：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(86, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "距离属性：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(86, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "时间属性：";
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(0, 0);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(388, 360);
            this.axMapControl1.TabIndex = 0;
            // 
            // frmVRPSolver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 544);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmVRPSolver";
            this.Text = "多路径配送分析";
            this.Load += new System.EventHandler(this.frmVRPSolver_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbVRPSolver.ResumeLayout(false);
            this.gbVRPSolver.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLoadMap;
        private System.Windows.Forms.TextBox txtInputRoutes;
        private System.Windows.Forms.TextBox txtInputDepots;
        private System.Windows.Forms.TextBox txtInputStops;
        private System.Windows.Forms.TextBox txtFeatureDataset;
        private System.Windows.Forms.TextBox txtNetworkDataset;
        private System.Windows.Forms.TextBox txtWorkspacePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbVRPSolver;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.ListBox lstOutput;
        private System.Windows.Forms.CheckBox chkUseRestriction;
        private System.Windows.Forms.ComboBox comboTWImportance;
        private System.Windows.Forms.ComboBox comboDistUnits;
        private System.Windows.Forms.ComboBox comboTimeUnits;
        private System.Windows.Forms.ComboBox comboDistanceAttribute;
        private System.Windows.Forms.ComboBox comboTimeAttribute;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
    }
}