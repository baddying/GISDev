namespace 交通网络分析
{
    partial class frmODCostMatrixSolver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmODCostMatrixSolver));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoadMap = new System.Windows.Forms.Button();
            this.txtInputDestinations = new System.Windows.Forms.TextBox();
            this.txtInputOrigins = new System.Windows.Forms.TextBox();
            this.txtFeatureDataset = new System.Windows.Forms.TextBox();
            this.txtNetworkDataset = new System.Windows.Forms.TextBox();
            this.txtWorkspacePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbODCostMatrixSolver = new System.Windows.Forms.GroupBox();
            this.btnSolve = new System.Windows.Forms.Button();
            this.lstOutput = new System.Windows.Forms.ListBox();
            this.chkUseRestriction = new System.Windows.Forms.CheckBox();
            this.txtCutOff = new System.Windows.Forms.TextBox();
            this.txtTargetFacility = new System.Windows.Forms.TextBox();
            this.cboCostAttribute = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbODCostMatrixSolver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLoadMap);
            this.groupBox1.Controls.Add(this.txtInputDestinations);
            this.groupBox1.Controls.Add(this.txtInputOrigins);
            this.groupBox1.Controls.Add(this.txtFeatureDataset);
            this.groupBox1.Controls.Add(this.txtNetworkDataset);
            this.groupBox1.Controls.Add(this.txtWorkspacePath);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(657, 159);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "地图结构";
            // 
            // btnLoadMap
            // 
            this.btnLoadMap.Location = new System.Drawing.Point(537, 71);
            this.btnLoadMap.Name = "btnLoadMap";
            this.btnLoadMap.Size = new System.Drawing.Size(75, 23);
            this.btnLoadMap.TabIndex = 10;
            this.btnLoadMap.Text = "加载";
            this.btnLoadMap.UseVisualStyleBackColor = true;
            this.btnLoadMap.Click += new System.EventHandler(this.btnLoadMap_Click);
            // 
            // txtInputDestinations
            // 
            this.txtInputDestinations.Location = new System.Drawing.Point(111, 123);
            this.txtInputDestinations.Name = "txtInputDestinations";
            this.txtInputDestinations.Size = new System.Drawing.Size(398, 21);
            this.txtInputDestinations.TabIndex = 9;
            // 
            // txtInputOrigins
            // 
            this.txtInputOrigins.Location = new System.Drawing.Point(111, 98);
            this.txtInputOrigins.Name = "txtInputOrigins";
            this.txtInputOrigins.Size = new System.Drawing.Size(398, 21);
            this.txtInputOrigins.TabIndex = 8;
            // 
            // txtFeatureDataset
            // 
            this.txtFeatureDataset.Location = new System.Drawing.Point(111, 73);
            this.txtFeatureDataset.Name = "txtFeatureDataset";
            this.txtFeatureDataset.Size = new System.Drawing.Size(398, 21);
            this.txtFeatureDataset.TabIndex = 7;
            // 
            // txtNetworkDataset
            // 
            this.txtNetworkDataset.Location = new System.Drawing.Point(111, 47);
            this.txtNetworkDataset.Name = "txtNetworkDataset";
            this.txtNetworkDataset.Size = new System.Drawing.Size(398, 21);
            this.txtNetworkDataset.TabIndex = 6;
            // 
            // txtWorkspacePath
            // 
            this.txtWorkspacePath.Location = new System.Drawing.Point(111, 20);
            this.txtWorkspacePath.Name = "txtWorkspacePath";
            this.txtWorkspacePath.Size = new System.Drawing.Size(398, 21);
            this.txtWorkspacePath.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "输入目的地：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "输入源：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "要素数据集：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "网络数据集：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "工作空间路径：";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 159);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbODCostMatrixSolver);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.axMapControl1);
            this.splitContainer1.Size = new System.Drawing.Size(657, 339);
            this.splitContainer1.SplitterDistance = 282;
            this.splitContainer1.TabIndex = 1;
            // 
            // gbODCostMatrixSolver
            // 
            this.gbODCostMatrixSolver.Controls.Add(this.btnSolve);
            this.gbODCostMatrixSolver.Controls.Add(this.lstOutput);
            this.gbODCostMatrixSolver.Controls.Add(this.chkUseRestriction);
            this.gbODCostMatrixSolver.Controls.Add(this.txtCutOff);
            this.gbODCostMatrixSolver.Controls.Add(this.txtTargetFacility);
            this.gbODCostMatrixSolver.Controls.Add(this.cboCostAttribute);
            this.gbODCostMatrixSolver.Controls.Add(this.label8);
            this.gbODCostMatrixSolver.Controls.Add(this.label7);
            this.gbODCostMatrixSolver.Controls.Add(this.label6);
            this.gbODCostMatrixSolver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbODCostMatrixSolver.Location = new System.Drawing.Point(0, 0);
            this.gbODCostMatrixSolver.Name = "gbODCostMatrixSolver";
            this.gbODCostMatrixSolver.Size = new System.Drawing.Size(282, 339);
            this.gbODCostMatrixSolver.TabIndex = 0;
            this.gbODCostMatrixSolver.TabStop = false;
            this.gbODCostMatrixSolver.Text = "OD成本矩阵分析";
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(89, 304);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 8;
            this.btnSolve.Text = "解决";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // lstOutput
            // 
            this.lstOutput.FormattingEnabled = true;
            this.lstOutput.HorizontalScrollbar = true;
            this.lstOutput.ItemHeight = 12;
            this.lstOutput.Location = new System.Drawing.Point(6, 140);
            this.lstOutput.Name = "lstOutput";
            this.lstOutput.ScrollAlwaysVisible = true;
            this.lstOutput.Size = new System.Drawing.Size(265, 148);
            this.lstOutput.TabIndex = 7;
            // 
            // chkUseRestriction
            // 
            this.chkUseRestriction.AutoSize = true;
            this.chkUseRestriction.Location = new System.Drawing.Point(77, 118);
            this.chkUseRestriction.Name = "chkUseRestriction";
            this.chkUseRestriction.Size = new System.Drawing.Size(108, 16);
            this.chkUseRestriction.TabIndex = 6;
            this.chkUseRestriction.Text = "使用单行线限制";
            this.chkUseRestriction.UseVisualStyleBackColor = true;
            // 
            // txtCutOff
            // 
            this.txtCutOff.Location = new System.Drawing.Point(120, 84);
            this.txtCutOff.Name = "txtCutOff";
            this.txtCutOff.Size = new System.Drawing.Size(121, 21);
            this.txtCutOff.TabIndex = 5;
            // 
            // txtTargetFacility
            // 
            this.txtTargetFacility.Location = new System.Drawing.Point(120, 57);
            this.txtTargetFacility.Name = "txtTargetFacility";
            this.txtTargetFacility.Size = new System.Drawing.Size(121, 21);
            this.txtTargetFacility.TabIndex = 4;
            // 
            // cboCostAttribute
            // 
            this.cboCostAttribute.FormattingEnabled = true;
            this.cboCostAttribute.Location = new System.Drawing.Point(120, 28);
            this.cboCostAttribute.Name = "cboCostAttribute";
            this.cboCostAttribute.Size = new System.Drawing.Size(121, 20);
            this.cboCostAttribute.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(61, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "默认中断：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "目标设施点的个数：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "代价类型：";
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(0, 0);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(371, 339);
            this.axMapControl1.TabIndex = 0;
            // 
            // frmODCostMatrixSolver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 498);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmODCostMatrixSolver";
            this.Text = "OD成本矩阵分析";
            this.Load += new System.EventHandler(this.frmODCostMatrixSolver_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbODCostMatrixSolver.ResumeLayout(false);
            this.gbODCostMatrixSolver.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLoadMap;
        private System.Windows.Forms.TextBox txtInputDestinations;
        private System.Windows.Forms.TextBox txtInputOrigins;
        private System.Windows.Forms.TextBox txtFeatureDataset;
        private System.Windows.Forms.TextBox txtNetworkDataset;
        private System.Windows.Forms.TextBox txtWorkspacePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbODCostMatrixSolver;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.ListBox lstOutput;
        private System.Windows.Forms.CheckBox chkUseRestriction;
        private System.Windows.Forms.TextBox txtCutOff;
        private System.Windows.Forms.TextBox txtTargetFacility;
        private System.Windows.Forms.ComboBox cboCostAttribute;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
    }
}