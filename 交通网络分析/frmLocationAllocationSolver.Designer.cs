namespace 交通网络分析
{
    partial class frmLocationAllocationSolver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocationAllocationSolver));
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
            this.gbLocationAllocationSolver = new System.Windows.Forms.GroupBox();
            this.btnSolver = new System.Windows.Forms.Button();
            this.lstOutput = new System.Windows.Forms.ListBox();
            this.txtTargetMarketShare = new System.Windows.Forms.TextBox();
            this.txtImpParameter = new System.Windows.Forms.TextBox();
            this.txtCutOff = new System.Windows.Forms.TextBox();
            this.txtFacilitiesToLocate = new System.Windows.Forms.TextBox();
            this.cboImpTransformation = new System.Windows.Forms.ComboBox();
            this.cboProblemType = new System.Windows.Forms.ComboBox();
            this.cboCostAttribute = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbLocationAllocationSolver.SuspendLayout();
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
            this.groupBox1.Size = new System.Drawing.Size(735, 148);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图层";
            // 
            // btnLoadMap
            // 
            this.btnLoadMap.Location = new System.Drawing.Point(582, 64);
            this.btnLoadMap.Name = "btnLoadMap";
            this.btnLoadMap.Size = new System.Drawing.Size(75, 23);
            this.btnLoadMap.TabIndex = 10;
            this.btnLoadMap.Text = "加载";
            this.btnLoadMap.UseVisualStyleBackColor = true;
            this.btnLoadMap.Click += new System.EventHandler(this.btnLoadMap_Click);
            // 
            // txtInputIncidents
            // 
            this.txtInputIncidents.Location = new System.Drawing.Point(117, 114);
            this.txtInputIncidents.Name = "txtInputIncidents";
            this.txtInputIncidents.Size = new System.Drawing.Size(385, 21);
            this.txtInputIncidents.TabIndex = 9;
            // 
            // txtInputFacilities
            // 
            this.txtInputFacilities.Location = new System.Drawing.Point(117, 90);
            this.txtInputFacilities.Name = "txtInputFacilities";
            this.txtInputFacilities.Size = new System.Drawing.Size(385, 21);
            this.txtInputFacilities.TabIndex = 8;
            // 
            // txtFeatureDataset
            // 
            this.txtFeatureDataset.Location = new System.Drawing.Point(117, 66);
            this.txtFeatureDataset.Name = "txtFeatureDataset";
            this.txtFeatureDataset.Size = new System.Drawing.Size(385, 21);
            this.txtFeatureDataset.TabIndex = 7;
            // 
            // txtNetworkDataset
            // 
            this.txtNetworkDataset.Location = new System.Drawing.Point(117, 42);
            this.txtNetworkDataset.Name = "txtNetworkDataset";
            this.txtNetworkDataset.Size = new System.Drawing.Size(385, 21);
            this.txtNetworkDataset.TabIndex = 6;
            // 
            // txtWorkspacePath
            // 
            this.txtWorkspacePath.Location = new System.Drawing.Point(117, 18);
            this.txtWorkspacePath.Name = "txtWorkspacePath";
            this.txtWorkspacePath.Size = new System.Drawing.Size(385, 21);
            this.txtWorkspacePath.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "输入需求点：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "输入设施点：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "要素数据集：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "网络数据集：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "工作空间路径：";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 148);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbLocationAllocationSolver);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.axMapControl1);
            this.splitContainer1.Size = new System.Drawing.Size(735, 395);
            this.splitContainer1.SplitterDistance = 327;
            this.splitContainer1.TabIndex = 1;
            // 
            // gbLocationAllocationSolver
            // 
            this.gbLocationAllocationSolver.Controls.Add(this.btnSolver);
            this.gbLocationAllocationSolver.Controls.Add(this.lstOutput);
            this.gbLocationAllocationSolver.Controls.Add(this.txtTargetMarketShare);
            this.gbLocationAllocationSolver.Controls.Add(this.txtImpParameter);
            this.gbLocationAllocationSolver.Controls.Add(this.txtCutOff);
            this.gbLocationAllocationSolver.Controls.Add(this.txtFacilitiesToLocate);
            this.gbLocationAllocationSolver.Controls.Add(this.cboImpTransformation);
            this.gbLocationAllocationSolver.Controls.Add(this.cboProblemType);
            this.gbLocationAllocationSolver.Controls.Add(this.cboCostAttribute);
            this.gbLocationAllocationSolver.Controls.Add(this.label12);
            this.gbLocationAllocationSolver.Controls.Add(this.label11);
            this.gbLocationAllocationSolver.Controls.Add(this.label10);
            this.gbLocationAllocationSolver.Controls.Add(this.label9);
            this.gbLocationAllocationSolver.Controls.Add(this.label8);
            this.gbLocationAllocationSolver.Controls.Add(this.label7);
            this.gbLocationAllocationSolver.Controls.Add(this.label6);
            this.gbLocationAllocationSolver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLocationAllocationSolver.Location = new System.Drawing.Point(0, 0);
            this.gbLocationAllocationSolver.Name = "gbLocationAllocationSolver";
            this.gbLocationAllocationSolver.Size = new System.Drawing.Size(327, 395);
            this.gbLocationAllocationSolver.TabIndex = 0;
            this.gbLocationAllocationSolver.TabStop = false;
            this.gbLocationAllocationSolver.Text = "位置分配分析";
            // 
            // btnSolver
            // 
            this.btnSolver.Location = new System.Drawing.Point(108, 360);
            this.btnSolver.Name = "btnSolver";
            this.btnSolver.Size = new System.Drawing.Size(75, 23);
            this.btnSolver.TabIndex = 15;
            this.btnSolver.Text = "解决";
            this.btnSolver.UseVisualStyleBackColor = true;
            this.btnSolver.Click += new System.EventHandler(this.btnSolver_Click);
            // 
            // lstOutput
            // 
            this.lstOutput.FormattingEnabled = true;
            this.lstOutput.HorizontalScrollbar = true;
            this.lstOutput.ItemHeight = 12;
            this.lstOutput.Location = new System.Drawing.Point(6, 196);
            this.lstOutput.Name = "lstOutput";
            this.lstOutput.ScrollAlwaysVisible = true;
            this.lstOutput.Size = new System.Drawing.Size(312, 148);
            this.lstOutput.TabIndex = 14;
            // 
            // txtTargetMarketShare
            // 
            this.txtTargetMarketShare.Location = new System.Drawing.Point(139, 169);
            this.txtTargetMarketShare.Name = "txtTargetMarketShare";
            this.txtTargetMarketShare.Size = new System.Drawing.Size(121, 21);
            this.txtTargetMarketShare.TabIndex = 13;
            // 
            // txtImpParameter
            // 
            this.txtImpParameter.Location = new System.Drawing.Point(139, 146);
            this.txtImpParameter.Name = "txtImpParameter";
            this.txtImpParameter.Size = new System.Drawing.Size(121, 21);
            this.txtImpParameter.TabIndex = 12;
            // 
            // txtCutOff
            // 
            this.txtCutOff.Location = new System.Drawing.Point(139, 100);
            this.txtCutOff.Name = "txtCutOff";
            this.txtCutOff.Size = new System.Drawing.Size(121, 21);
            this.txtCutOff.TabIndex = 11;
            // 
            // txtFacilitiesToLocate
            // 
            this.txtFacilitiesToLocate.Location = new System.Drawing.Point(139, 77);
            this.txtFacilitiesToLocate.Name = "txtFacilitiesToLocate";
            this.txtFacilitiesToLocate.Size = new System.Drawing.Size(121, 21);
            this.txtFacilitiesToLocate.TabIndex = 10;
            // 
            // cboImpTransformation
            // 
            this.cboImpTransformation.FormattingEnabled = true;
            this.cboImpTransformation.Location = new System.Drawing.Point(139, 123);
            this.cboImpTransformation.Name = "cboImpTransformation";
            this.cboImpTransformation.Size = new System.Drawing.Size(121, 20);
            this.cboImpTransformation.TabIndex = 9;
            this.cboImpTransformation.SelectedIndexChanged += new System.EventHandler(this.cboImpTransformation_SelectedIndexChanged);
            // 
            // cboProblemType
            // 
            this.cboProblemType.FormattingEnabled = true;
            this.cboProblemType.Location = new System.Drawing.Point(139, 54);
            this.cboProblemType.Name = "cboProblemType";
            this.cboProblemType.Size = new System.Drawing.Size(121, 20);
            this.cboProblemType.TabIndex = 8;
            this.cboProblemType.SelectedIndexChanged += new System.EventHandler(this.cboProblemType_SelectedIndexChanged);
            // 
            // cboCostAttribute
            // 
            this.cboCostAttribute.FormattingEnabled = true;
            this.cboCostAttribute.Location = new System.Drawing.Point(139, 31);
            this.cboCostAttribute.Name = "cboCostAttribute";
            this.cboCostAttribute.Size = new System.Drawing.Size(121, 20);
            this.cboCostAttribute.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(56, 172);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 6;
            this.label12.Text = "目标市场份额：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(80, 149);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 5;
            this.label11.Text = "阻抗参数：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(80, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "阻抗变换：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(80, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "阻抗中断：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "要选择的设施点的个数：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(80, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "问题类型：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(80, 34);
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
            this.axMapControl1.Size = new System.Drawing.Size(404, 395);
            this.axMapControl1.TabIndex = 0;
            // 
            // frmLocationAllocationSolver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 543);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmLocationAllocationSolver";
            this.Text = "位置分配分析";
            this.Load += new System.EventHandler(this.frmLocationAllocationSolver_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbLocationAllocationSolver.ResumeLayout(false);
            this.gbLocationAllocationSolver.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbLocationAllocationSolver;
        private System.Windows.Forms.Button btnSolver;
        private System.Windows.Forms.ListBox lstOutput;
        private System.Windows.Forms.TextBox txtTargetMarketShare;
        private System.Windows.Forms.TextBox txtImpParameter;
        private System.Windows.Forms.TextBox txtCutOff;
        private System.Windows.Forms.TextBox txtFacilitiesToLocate;
        private System.Windows.Forms.ComboBox cboImpTransformation;
        private System.Windows.Forms.ComboBox cboProblemType;
        private System.Windows.Forms.ComboBox cboCostAttribute;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
    }
}