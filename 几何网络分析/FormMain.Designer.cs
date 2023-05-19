namespace UtilityNetwork
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.axLicenseControl = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axToolbarControl = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxNetworksName = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonShowFlow = new System.Windows.Forms.ToolStripButton();
            this.axTOCControl = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButtonNetworkAnalysis = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripMenuItemClearFlags = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemClearBarriers = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemClearResults = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonAddJunctionFlag = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddEdgeFlag = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddJunctionBarrier = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddEdgeBarrier = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxTraceTasks = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonSolver = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonAddBGFlag = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripMenuItemBurstAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAffectArea = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemClearBurstAnalysisResults = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonClearFlow = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl)).BeginInit();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axLicenseControl
            // 
            this.axLicenseControl.Enabled = true;
            this.axLicenseControl.Location = new System.Drawing.Point(637, 287);
            this.axLicenseControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.axLicenseControl.Name = "axLicenseControl";
            this.axLicenseControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl.OcxState")));
            this.axLicenseControl.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl.TabIndex = 0;
            // 
            // axToolbarControl
            // 
            this.axToolbarControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axToolbarControl.Location = new System.Drawing.Point(0, 86);
            this.axToolbarControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.axToolbarControl.Name = "axToolbarControl";
            this.axToolbarControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl.OcxState")));
            this.axToolbarControl.Size = new System.Drawing.Size(882, 28);
            this.axToolbarControl.TabIndex = 1;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripComboBoxNetworksName,
            this.toolStripButtonShowFlow,
            this.toolStripButtonClearFlow});
            this.toolStrip.Location = new System.Drawing.Point(0, 28);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(882, 28);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(54, 25);
            this.toolStripLabel1.Text = "网络：";
            // 
            // toolStripComboBoxNetworksName
            // 
            this.toolStripComboBoxNetworksName.Name = "toolStripComboBoxNetworksName";
            this.toolStripComboBoxNetworksName.Size = new System.Drawing.Size(165, 28);
            // 
            // toolStripButtonShowFlow
            // 
            this.toolStripButtonShowFlow.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonShowFlow.Image")));
            this.toolStripButtonShowFlow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowFlow.Name = "toolStripButtonShowFlow";
            this.toolStripButtonShowFlow.Size = new System.Drawing.Size(89, 25);
            this.toolStripButtonShowFlow.Text = "显示流向";
            this.toolStripButtonShowFlow.Click += new System.EventHandler(this.toolStripButtonShowFlow_Click);
            // 
            // axTOCControl
            // 
            this.axTOCControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.axTOCControl.Location = new System.Drawing.Point(0, 114);
            this.axTOCControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.axTOCControl.Name = "axTOCControl";
            this.axTOCControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl.OcxState")));
            this.axTOCControl.Size = new System.Drawing.Size(180, 568);
            this.axTOCControl.TabIndex = 5;
            // 
            // axMapControl
            // 
            this.axMapControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axMapControl.Location = new System.Drawing.Point(180, 114);
            this.axMapControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.axMapControl.Name = "axMapControl";
            this.axMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl.OcxState")));
            this.axMapControl.Size = new System.Drawing.Size(702, 568);
            this.axMapControl.TabIndex = 6;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 683);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip.Size = new System.Drawing.Size(882, 22);
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // ToolStripMenuItemFile
            // 
            this.ToolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemOpen});
            this.ToolStripMenuItemFile.Name = "ToolStripMenuItemFile";
            this.ToolStripMenuItemFile.Size = new System.Drawing.Size(69, 24);
            this.ToolStripMenuItemFile.Text = "文件(&F)";
            // 
            // ToolStripMenuItemOpen
            // 
            this.ToolStripMenuItemOpen.Name = "ToolStripMenuItemOpen";
            this.ToolStripMenuItemOpen.Size = new System.Drawing.Size(130, 24);
            this.ToolStripMenuItemOpen.Text = "打开(&O)";
            this.ToolStripMenuItemOpen.Click += new System.EventHandler(this.ToolStripMenuItemOpen_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemFile});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(882, 28);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButtonNetworkAnalysis,
            this.toolStripButtonAddJunctionFlag,
            this.toolStripButtonAddEdgeFlag,
            this.toolStripButtonAddJunctionBarrier,
            this.toolStripButtonAddEdgeBarrier,
            this.toolStripLabel2,
            this.toolStripComboBoxTraceTasks,
            this.toolStripButtonSolver,
            this.toolStripSeparator2,
            this.toolStripButtonAddBGFlag,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 56);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(882, 28);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButtonNetworkAnalysis
            // 
            this.toolStripDropDownButtonNetworkAnalysis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonNetworkAnalysis.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemClearFlags,
            this.ToolStripMenuItemClearBarriers,
            this.ToolStripMenuItemClearResults});
            this.toolStripDropDownButtonNetworkAnalysis.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonNetworkAnalysis.Image")));
            this.toolStripDropDownButtonNetworkAnalysis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonNetworkAnalysis.Name = "toolStripDropDownButtonNetworkAnalysis";
            this.toolStripDropDownButtonNetworkAnalysis.Size = new System.Drawing.Size(82, 25);
            this.toolStripDropDownButtonNetworkAnalysis.Text = "网络分析";
            // 
            // ToolStripMenuItemClearFlags
            // 
            this.ToolStripMenuItemClearFlags.Name = "ToolStripMenuItemClearFlags";
            this.ToolStripMenuItemClearFlags.Size = new System.Drawing.Size(168, 24);
            this.ToolStripMenuItemClearFlags.Text = "清除分析位置";
            this.ToolStripMenuItemClearFlags.Click += new System.EventHandler(this.ToolStripMenuItemClearFlags_Click);
            // 
            // ToolStripMenuItemClearBarriers
            // 
            this.ToolStripMenuItemClearBarriers.Name = "ToolStripMenuItemClearBarriers";
            this.ToolStripMenuItemClearBarriers.Size = new System.Drawing.Size(168, 24);
            this.ToolStripMenuItemClearBarriers.Text = "清除障碍";
            this.ToolStripMenuItemClearBarriers.Click += new System.EventHandler(this.ToolStripMenuItemClearBarriers_Click);
            // 
            // ToolStripMenuItemClearResults
            // 
            this.ToolStripMenuItemClearResults.Name = "ToolStripMenuItemClearResults";
            this.ToolStripMenuItemClearResults.Size = new System.Drawing.Size(168, 24);
            this.ToolStripMenuItemClearResults.Text = "清除分析结果";
            this.ToolStripMenuItemClearResults.Click += new System.EventHandler(this.ToolStripMenuItemClearResults_Click);
            // 
            // toolStripButtonAddJunctionFlag
            // 
            this.toolStripButtonAddJunctionFlag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddJunctionFlag.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddJunctionFlag.Image")));
            this.toolStripButtonAddJunctionFlag.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddJunctionFlag.Name = "toolStripButtonAddJunctionFlag";
            this.toolStripButtonAddJunctionFlag.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonAddJunctionFlag.Text = "添加分析管点";
            this.toolStripButtonAddJunctionFlag.Click += new System.EventHandler(this.toolStripButtonAddJunctionFlag_Click);
            // 
            // toolStripButtonAddEdgeFlag
            // 
            this.toolStripButtonAddEdgeFlag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddEdgeFlag.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddEdgeFlag.Image")));
            this.toolStripButtonAddEdgeFlag.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddEdgeFlag.Name = "toolStripButtonAddEdgeFlag";
            this.toolStripButtonAddEdgeFlag.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonAddEdgeFlag.Text = "添加分析管线";
            this.toolStripButtonAddEdgeFlag.Click += new System.EventHandler(this.toolStripButtonAddEdgeFlag_Click);
            // 
            // toolStripButtonAddJunctionBarrier
            // 
            this.toolStripButtonAddJunctionBarrier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddJunctionBarrier.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddJunctionBarrier.Image")));
            this.toolStripButtonAddJunctionBarrier.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddJunctionBarrier.Name = "toolStripButtonAddJunctionBarrier";
            this.toolStripButtonAddJunctionBarrier.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonAddJunctionBarrier.Text = "添加管点障碍";
            this.toolStripButtonAddJunctionBarrier.Click += new System.EventHandler(this.toolStripButtonAddJunctionBarrier_Click);
            // 
            // toolStripButtonAddEdgeBarrier
            // 
            this.toolStripButtonAddEdgeBarrier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddEdgeBarrier.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddEdgeBarrier.Image")));
            this.toolStripButtonAddEdgeBarrier.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddEdgeBarrier.Name = "toolStripButtonAddEdgeBarrier";
            this.toolStripButtonAddEdgeBarrier.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonAddEdgeBarrier.Text = "添加管线障碍";
            this.toolStripButtonAddEdgeBarrier.Click += new System.EventHandler(this.toolStripButtonAddEdgeBarrier_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(114, 25);
            this.toolStripLabel2.Text = "网络追踪任务：";
            // 
            // toolStripComboBoxTraceTasks
            // 
            this.toolStripComboBoxTraceTasks.Items.AddRange(new object[] {
            "查找共同祖先",
            "查找相连接的网络要素",
            "查找网络中的环",
            "查找未连接的网络要素",
            "查找上游路径",
            "查找路径",
            "下游追踪",
            "查找上游路径累积消耗",
            "上游追踪"});
            this.toolStripComboBoxTraceTasks.Name = "toolStripComboBoxTraceTasks";
            this.toolStripComboBoxTraceTasks.Size = new System.Drawing.Size(199, 28);
            // 
            // toolStripButtonSolver
            // 
            this.toolStripButtonSolver.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSolver.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSolver.Image")));
            this.toolStripButtonSolver.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSolver.Name = "toolStripButtonSolver";
            this.toolStripButtonSolver.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonSolver.Text = "执行几何网络分析任务";
            this.toolStripButtonSolver.Click += new System.EventHandler(this.toolStripButtonSolver_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripButtonAddBGFlag
            // 
            this.toolStripButtonAddBGFlag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddBGFlag.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddBGFlag.Image")));
            this.toolStripButtonAddBGFlag.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddBGFlag.Name = "toolStripButtonAddBGFlag";
            this.toolStripButtonAddBGFlag.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonAddBGFlag.Text = "选择爆管位置";
            this.toolStripButtonAddBGFlag.Click += new System.EventHandler(this.toolStripButtonAddBGFlag_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemBurstAnalysis,
            this.ToolStripMenuItemAffectArea,
            this.ToolStripMenuItemClearBurstAnalysisResults});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(82, 25);
            this.toolStripDropDownButton1.Text = "爆管分析";
            // 
            // ToolStripMenuItemBurstAnalysis
            // 
            this.ToolStripMenuItemBurstAnalysis.Name = "ToolStripMenuItemBurstAnalysis";
            this.ToolStripMenuItemBurstAnalysis.Size = new System.Drawing.Size(198, 24);
            this.ToolStripMenuItemBurstAnalysis.Text = "爆管关阀分析";
            this.ToolStripMenuItemBurstAnalysis.Click += new System.EventHandler(this.ToolStripMenuItemBurstAnalysis_Click);
            // 
            // ToolStripMenuItemAffectArea
            // 
            this.ToolStripMenuItemAffectArea.Name = "ToolStripMenuItemAffectArea";
            this.ToolStripMenuItemAffectArea.Size = new System.Drawing.Size(198, 24);
            this.ToolStripMenuItemAffectArea.Text = "影响范围分析";
            this.ToolStripMenuItemAffectArea.Click += new System.EventHandler(this.ToolStripMenuItemAffectArea_Click);
            // 
            // ToolStripMenuItemClearBurstAnalysisResults
            // 
            this.ToolStripMenuItemClearBurstAnalysisResults.Name = "ToolStripMenuItemClearBurstAnalysisResults";
            this.ToolStripMenuItemClearBurstAnalysisResults.Size = new System.Drawing.Size(198, 24);
            this.ToolStripMenuItemClearBurstAnalysisResults.Text = "清除爆管分析结果";
            this.ToolStripMenuItemClearBurstAnalysisResults.Click += new System.EventHandler(this.ToolStripMenuItemClearBurstAnalysisResults_Click);
            // 
            // toolStripButtonClearFlow
            // 
            this.toolStripButtonClearFlow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonClearFlow.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClearFlow.Image")));
            this.toolStripButtonClearFlow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClearFlow.Name = "toolStripButtonClearFlow";
            this.toolStripButtonClearFlow.Size = new System.Drawing.Size(103, 25);
            this.toolStripButtonClearFlow.Text = "清除流向显示";
            this.toolStripButtonClearFlow.Click += new System.EventHandler(this.toolStripButtonClearFlow_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 705);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.axMapControl);
            this.Controls.Add(this.axTOCControl);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.axToolbarControl);
            this.Controls.Add(this.axLicenseControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管网几何网络分析";
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl;
        private System.Windows.Forms.ToolStrip toolStrip;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxNetworksName;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowFlow;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFile;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOpen;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonNetworkAnalysis;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClearFlags;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClearBarriers;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClearResults;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddJunctionFlag;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddEdgeFlag;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddJunctionBarrier;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddEdgeBarrier;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxTraceTasks;
        private System.Windows.Forms.ToolStripButton toolStripButtonSolver;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddBGFlag;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemBurstAnalysis;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAffectArea;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClearBurstAnalysisResults;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearFlow;
    }
}

