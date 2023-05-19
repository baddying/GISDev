namespace 交通网络分析
{
    partial class frmClosestFacilitySolver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClosestFacilitySolver));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoadMap = new System.Windows.Forms.Button();
            this.txtInputIncidents = new System.Windows.Forms.TextBox();
            this.txtInputFacilities = new System.Windows.Forms.TextBox();
            this.txtFeatureDataset = new System.Windows.Forms.TextBox();
            this.txtNetworkDataset = new System.Windows.Forms.TextBox();
            this.txtWorkspacePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbFacilitySolverSolver = new System.Windows.Forms.GroupBox();
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
            this.gbFacilitySolverSolver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLoadMap);
            this.groupBox1.Controls.Add(this.txtInputIncidents);
            this.groupBox1.Controls.Add(this.txtInputFacilities);
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
            this.groupBox1.Size = new System.Drawing.Size(717, 168);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "地图结构";
            // 
            // btnLoadMap
            // 
            this.btnLoadMap.Location = new System.Drawing.Point(549, 84);
            this.btnLoadMap.Name = "btnLoadMap";
            this.btnLoadMap.Size = new System.Drawing.Size(75, 23);
            this.btnLoadMap.TabIndex = 10;
            this.btnLoadMap.Text = "加载";
            this.btnLoadMap.UseVisualStyleBackColor = true;
            this.btnLoadMap.Click += new System.EventHandler(this.btnLoadMap_Click);
            // 
            // txtInputIncidents
            // 
            this.txtInputIncidents.Location = new System.Drawing.Point(102, 138);
            this.txtInputIncidents.Name = "txtInputIncidents";
            this.txtInputIncidents.Size = new System.Drawing.Size(400, 21);
            this.txtInputIncidents.TabIndex = 9;
            // 
            // txtInputFacilities
            // 
            this.txtInputFacilities.Location = new System.Drawing.Point(102, 111);
            this.txtInputFacilities.Name = "txtInputFacilities";
            this.txtInputFacilities.Size = new System.Drawing.Size(400, 21);
            this.txtInputFacilities.TabIndex = 8;
            // 
            // txtFeatureDataset
            // 
            this.txtFeatureDataset.Location = new System.Drawing.Point(102, 84);
            this.txtFeatureDataset.Name = "txtFeatureDataset";
            this.txtFeatureDataset.Size = new System.Drawing.Size(400, 21);
            this.txtFeatureDataset.TabIndex = 7;
            // 
            // txtNetworkDataset
            // 
            this.txtNetworkDataset.Location = new System.Drawing.Point(102, 57);
            this.txtNetworkDataset.Name = "txtNetworkDataset";
            this.txtNetworkDataset.Size = new System.Drawing.Size(400, 21);
            this.txtNetworkDataset.TabIndex = 6;
            // 
            // txtWorkspacePath
            // 
            this.txtWorkspacePath.Location = new System.Drawing.Point(102, 29);
            this.txtWorkspacePath.Name = "txtWorkspacePath";
            this.txtWorkspacePath.Size = new System.Drawing.Size(400, 21);
            this.txtWorkspacePath.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "输入事件点：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "输入设施点：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "要素数据集：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "网络数据集：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "工作空间路径：";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 168);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbFacilitySolverSolver);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.axMapControl1);
            this.splitContainer1.Size = new System.Drawing.Size(717, 357);
            this.splitContainer1.SplitterDistance = 330;
            this.splitContainer1.TabIndex = 1;
            // 
            // gbFacilitySolverSolver
            // 
            this.gbFacilitySolverSolver.Controls.Add(this.btnSolve);
            this.gbFacilitySolverSolver.Controls.Add(this.lstOutput);
            this.gbFacilitySolverSolver.Controls.Add(this.chkUseRestriction);
            this.gbFacilitySolverSolver.Controls.Add(this.txtCutOff);
            this.gbFacilitySolverSolver.Controls.Add(this.txtTargetFacility);
            this.gbFacilitySolverSolver.Controls.Add(this.cboCostAttribute);
            this.gbFacilitySolverSolver.Controls.Add(this.label8);
            this.gbFacilitySolverSolver.Controls.Add(this.label7);
            this.gbFacilitySolverSolver.Controls.Add(this.label6);
            this.gbFacilitySolverSolver.Location = new System.Drawing.Point(12, 6);
            this.gbFacilitySolverSolver.Name = "gbFacilitySolverSolver";
            this.gbFacilitySolverSolver.Size = new System.Drawing.Size(301, 356);
            this.gbFacilitySolverSolver.TabIndex = 0;
            this.gbFacilitySolverSolver.TabStop = false;
            this.gbFacilitySolverSolver.Text = "最近设施点分析";
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(102, 316);
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
            this.lstOutput.Location = new System.Drawing.Point(19, 150);
            this.lstOutput.Name = "lstOutput";
            this.lstOutput.ScrollAlwaysVisible = true;
            this.lstOutput.Size = new System.Drawing.Size(238, 148);
            this.lstOutput.TabIndex = 7;
            // 
            // chkUseRestriction
            // 
            this.chkUseRestriction.AutoSize = true;
            this.chkUseRestriction.Location = new System.Drawing.Point(56, 126);
            this.chkUseRestriction.Name = "chkUseRestriction";
            this.chkUseRestriction.Size = new System.Drawing.Size(108, 16);
            this.chkUseRestriction.TabIndex = 6;
            this.chkUseRestriction.Text = "使用单行线限制";
            this.chkUseRestriction.UseVisualStyleBackColor = true;
            // 
            // txtCutOff
            // 
            this.txtCutOff.Location = new System.Drawing.Point(116, 90);
            this.txtCutOff.Name = "txtCutOff";
            this.txtCutOff.Size = new System.Drawing.Size(154, 21);
            this.txtCutOff.TabIndex = 5;
            // 
            // txtTargetFacility
            // 
            this.txtTargetFacility.Location = new System.Drawing.Point(116, 57);
            this.txtTargetFacility.Name = "txtTargetFacility";
            this.txtTargetFacility.Size = new System.Drawing.Size(154, 21);
            this.txtTargetFacility.TabIndex = 4;
            // 
            // cboCostAttribute
            // 
            this.cboCostAttribute.FormattingEnabled = true;
            this.cboCostAttribute.Location = new System.Drawing.Point(116, 25);
            this.cboCostAttribute.Name = "cboCostAttribute";
            this.cboCostAttribute.Size = new System.Drawing.Size(154, 20);
            this.cboCostAttribute.TabIndex = 3;
            this.cboCostAttribute.SelectedIndexChanged += new System.EventHandler(this.cboCostAttribute_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "默认中断：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "目标设施点的个数：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 28);
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
            this.axMapControl1.Size = new System.Drawing.Size(383, 357);
            this.axMapControl1.TabIndex = 0;
            // 
            // frmClosestFacilitySolver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 525);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmClosestFacilitySolver";
            this.Text = "最近设施点分析";
            this.Load += new System.EventHandler(this.frmClosestFacilitySolver_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbFacilitySolverSolver.ResumeLayout(false);
            this.gbFacilitySolverSolver.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLoadMap;
        private System.Windows.Forms.TextBox txtInputIncidents;
        private System.Windows.Forms.TextBox txtInputFacilities;
        private System.Windows.Forms.TextBox txtFeatureDataset;
        private System.Windows.Forms.TextBox txtNetworkDataset;
        private System.Windows.Forms.TextBox txtWorkspacePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbFacilitySolverSolver;
        private System.Windows.Forms.ListBox lstOutput;
        private System.Windows.Forms.CheckBox chkUseRestriction;
        private System.Windows.Forms.TextBox txtCutOff;
        private System.Windows.Forms.TextBox txtTargetFacility;
        private System.Windows.Forms.ComboBox cboCostAttribute;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.Button btnSolve;
    }
}