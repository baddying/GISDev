namespace 交通网络分析
{
    partial class frmServiceAreaSolver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServiceAreaSolver));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoadMap = new System.Windows.Forms.Button();
            this.txtInputFacilities = new System.Windows.Forms.TextBox();
            this.txtFeatureDataset = new System.Windows.Forms.TextBox();
            this.txtNetworkDataset = new System.Windows.Forms.TextBox();
            this.txtWorkspacePath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbServiceAreaSolver = new System.Windows.Forms.GroupBox();
            this.btnSolve = new System.Windows.Forms.Button();
            this.lbOutput = new System.Windows.Forms.ListBox();
            this.chkShowLines = new System.Windows.Forms.CheckBox();
            this.chkUseRestriction = new System.Windows.Forms.CheckBox();
            this.txtCutOff = new System.Windows.Forms.TextBox();
            this.cbCostAttribute = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbServiceAreaSolver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLoadMap);
            this.groupBox1.Controls.Add(this.txtInputFacilities);
            this.groupBox1.Controls.Add(this.txtFeatureDataset);
            this.groupBox1.Controls.Add(this.txtNetworkDataset);
            this.groupBox1.Controls.Add(this.txtWorkspacePath);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(709, 171);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "地图结构";
            // 
            // btnLoadMap
            // 
            this.btnLoadMap.Location = new System.Drawing.Point(524, 77);
            this.btnLoadMap.Name = "btnLoadMap";
            this.btnLoadMap.Size = new System.Drawing.Size(75, 23);
            this.btnLoadMap.TabIndex = 8;
            this.btnLoadMap.Text = "加载";
            this.btnLoadMap.UseVisualStyleBackColor = true;
            this.btnLoadMap.Click += new System.EventHandler(this.btnLoadMap_Click);
            // 
            // txtInputFacilities
            // 
            this.txtInputFacilities.Location = new System.Drawing.Point(106, 130);
            this.txtInputFacilities.Name = "txtInputFacilities";
            this.txtInputFacilities.Size = new System.Drawing.Size(376, 21);
            this.txtInputFacilities.TabIndex = 7;
            // 
            // txtFeatureDataset
            // 
            this.txtFeatureDataset.Location = new System.Drawing.Point(106, 95);
            this.txtFeatureDataset.Name = "txtFeatureDataset";
            this.txtFeatureDataset.Size = new System.Drawing.Size(376, 21);
            this.txtFeatureDataset.TabIndex = 6;
            // 
            // txtNetworkDataset
            // 
            this.txtNetworkDataset.Location = new System.Drawing.Point(106, 57);
            this.txtNetworkDataset.Name = "txtNetworkDataset";
            this.txtNetworkDataset.Size = new System.Drawing.Size(376, 21);
            this.txtNetworkDataset.TabIndex = 5;
            // 
            // txtWorkspacePath
            // 
            this.txtWorkspacePath.Location = new System.Drawing.Point(106, 25);
            this.txtWorkspacePath.Name = "txtWorkspacePath";
            this.txtWorkspacePath.Size = new System.Drawing.Size(376, 21);
            this.txtWorkspacePath.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "输入设施点：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "要素数据集：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "网络数据集：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "工作空间路径：";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 171);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbServiceAreaSolver);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.axMapControl1);
            this.splitContainer1.Size = new System.Drawing.Size(709, 374);
            this.splitContainer1.SplitterDistance = 242;
            this.splitContainer1.TabIndex = 1;
            // 
            // gbServiceAreaSolver
            // 
            this.gbServiceAreaSolver.Controls.Add(this.btnSolve);
            this.gbServiceAreaSolver.Controls.Add(this.lbOutput);
            this.gbServiceAreaSolver.Controls.Add(this.chkShowLines);
            this.gbServiceAreaSolver.Controls.Add(this.chkUseRestriction);
            this.gbServiceAreaSolver.Controls.Add(this.txtCutOff);
            this.gbServiceAreaSolver.Controls.Add(this.cbCostAttribute);
            this.gbServiceAreaSolver.Controls.Add(this.label7);
            this.gbServiceAreaSolver.Controls.Add(this.label8);
            this.gbServiceAreaSolver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbServiceAreaSolver.Location = new System.Drawing.Point(0, 0);
            this.gbServiceAreaSolver.Name = "gbServiceAreaSolver";
            this.gbServiceAreaSolver.Size = new System.Drawing.Size(242, 374);
            this.gbServiceAreaSolver.TabIndex = 2;
            this.gbServiceAreaSolver.TabStop = false;
            this.gbServiceAreaSolver.Text = "服务区分析";
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(68, 326);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 7;
            this.btnSolve.Text = "解决";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // lbOutput
            // 
            this.lbOutput.FormattingEnabled = true;
            this.lbOutput.HorizontalScrollbar = true;
            this.lbOutput.ItemHeight = 12;
            this.lbOutput.Location = new System.Drawing.Point(12, 167);
            this.lbOutput.Name = "lbOutput";
            this.lbOutput.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbOutput.ScrollAlwaysVisible = true;
            this.lbOutput.Size = new System.Drawing.Size(212, 124);
            this.lbOutput.TabIndex = 6;
            // 
            // chkShowLines
            // 
            this.chkShowLines.AutoSize = true;
            this.chkShowLines.Location = new System.Drawing.Point(22, 134);
            this.chkShowLines.Name = "chkShowLines";
            this.chkShowLines.Size = new System.Drawing.Size(72, 16);
            this.chkShowLines.TabIndex = 5;
            this.chkShowLines.Text = "显示路径";
            this.chkShowLines.UseVisualStyleBackColor = true;
            // 
            // chkUseRestriction
            // 
            this.chkUseRestriction.AutoSize = true;
            this.chkUseRestriction.Location = new System.Drawing.Point(22, 101);
            this.chkUseRestriction.Name = "chkUseRestriction";
            this.chkUseRestriction.Size = new System.Drawing.Size(108, 16);
            this.chkUseRestriction.TabIndex = 4;
            this.chkUseRestriction.Text = "使用单行线限制";
            this.chkUseRestriction.UseVisualStyleBackColor = true;
            // 
            // txtCutOff
            // 
            this.txtCutOff.Location = new System.Drawing.Point(81, 62);
            this.txtCutOff.Name = "txtCutOff";
            this.txtCutOff.Size = new System.Drawing.Size(121, 21);
            this.txtCutOff.TabIndex = 3;
            // 
            // cbCostAttribute
            // 
            this.cbCostAttribute.FormattingEnabled = true;
            this.cbCostAttribute.Location = new System.Drawing.Point(81, 26);
            this.cbCostAttribute.Name = "cbCostAttribute";
            this.cbCostAttribute.Size = new System.Drawing.Size(121, 20);
            this.cbCostAttribute.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "默认中断：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "代价类型：";
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(0, 0);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(463, 374);
            this.axMapControl1.TabIndex = 0;
            // 
            // frmServiceAreaSolver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 545);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmServiceAreaSolver";
            this.Text = "服务区分析";
            this.Load += new System.EventHandler(this.frmServiceAreaSolver_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbServiceAreaSolver.ResumeLayout(false);
            this.gbServiceAreaSolver.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtInputFacilities;
        private System.Windows.Forms.TextBox txtFeatureDataset;
        private System.Windows.Forms.TextBox txtNetworkDataset;
        private System.Windows.Forms.TextBox txtWorkspacePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadMap;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbServiceAreaSolver;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.ListBox lbOutput;
        private System.Windows.Forms.CheckBox chkShowLines;
        private System.Windows.Forms.CheckBox chkUseRestriction;
        private System.Windows.Forms.TextBox txtCutOff;
        private System.Windows.Forms.ComboBox cbCostAttribute;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
    }
}