namespace QueryAndStatistics
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemQueryByAttribute = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemQueryBySpatial = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemQueryByGraphics = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemMapSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.axLicenseControl = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axToolbarControl = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axTOCControl = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.ToolStripMenuItemQueryByAttribute,
            this.ToolStripMenuItemQueryBySpatial,
            this.ToolStripMenuItemQueryByGraphics,
            this.ToolStripMenuItemMapSelection,
            this.ToolStripMenuItemStatistics,
            this.ToolStripMenuItemOptions});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(586, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemOpen});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // ToolStripMenuItemOpen
            // 
            this.ToolStripMenuItemOpen.Name = "ToolStripMenuItemOpen";
            this.ToolStripMenuItemOpen.Size = new System.Drawing.Size(100, 22);
            this.ToolStripMenuItemOpen.Text = "打开";
            this.ToolStripMenuItemOpen.Click += new System.EventHandler(this.ToolStripMenuItemOpen_Click);
            // 
            // ToolStripMenuItemQueryByAttribute
            // 
            this.ToolStripMenuItemQueryByAttribute.Name = "ToolStripMenuItemQueryByAttribute";
            this.ToolStripMenuItemQueryByAttribute.Size = new System.Drawing.Size(68, 21);
            this.ToolStripMenuItemQueryByAttribute.Text = "属性查询";
            this.ToolStripMenuItemQueryByAttribute.Click += new System.EventHandler(this.ToolStripMenuItemQueryByAttribute_Click);
            // 
            // ToolStripMenuItemQueryBySpatial
            // 
            this.ToolStripMenuItemQueryBySpatial.Name = "ToolStripMenuItemQueryBySpatial";
            this.ToolStripMenuItemQueryBySpatial.Size = new System.Drawing.Size(68, 21);
            this.ToolStripMenuItemQueryBySpatial.Text = "空间查询";
            this.ToolStripMenuItemQueryBySpatial.Click += new System.EventHandler(this.ToolStripMenuItemQueryBySpatial_Click);
            // 
            // ToolStripMenuItemQueryByGraphics
            // 
            this.ToolStripMenuItemQueryByGraphics.Name = "ToolStripMenuItemQueryByGraphics";
            this.ToolStripMenuItemQueryByGraphics.Size = new System.Drawing.Size(68, 21);
            this.ToolStripMenuItemQueryByGraphics.Text = "图形查询";
            this.ToolStripMenuItemQueryByGraphics.Click += new System.EventHandler(this.ToolStripMenuItemQueryByGraphics_Click);
            // 
            // ToolStripMenuItemMapSelection
            // 
            this.ToolStripMenuItemMapSelection.Name = "ToolStripMenuItemMapSelection";
            this.ToolStripMenuItemMapSelection.Size = new System.Drawing.Size(80, 21);
            this.ToolStripMenuItemMapSelection.Text = "地图选择集";
            this.ToolStripMenuItemMapSelection.Click += new System.EventHandler(this.ToolStripMenuItemMapSelection_Click);
            // 
            // ToolStripMenuItemStatistics
            // 
            this.ToolStripMenuItemStatistics.Name = "ToolStripMenuItemStatistics";
            this.ToolStripMenuItemStatistics.Size = new System.Drawing.Size(44, 21);
            this.ToolStripMenuItemStatistics.Text = "统计";
            this.ToolStripMenuItemStatistics.Click += new System.EventHandler(this.ToolStripMenuItemStatistics_Click);
            // 
            // ToolStripMenuItemOptions
            // 
            this.ToolStripMenuItemOptions.Name = "ToolStripMenuItemOptions";
            this.ToolStripMenuItemOptions.Size = new System.Drawing.Size(92, 21);
            this.ToolStripMenuItemOptions.Text = "选择操作选项";
            this.ToolStripMenuItemOptions.Click += new System.EventHandler(this.ToolStripMenuItemOptions_Click);
            // 
            // axLicenseControl
            // 
            this.axLicenseControl.Enabled = true;
            this.axLicenseControl.Location = new System.Drawing.Point(600, 150);
            this.axLicenseControl.Name = "axLicenseControl";
            this.axLicenseControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl.OcxState")));
            this.axLicenseControl.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl.TabIndex = 1;
            // 
            // axToolbarControl
            // 
            this.axToolbarControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axToolbarControl.Location = new System.Drawing.Point(0, 25);
            this.axToolbarControl.Name = "axToolbarControl";
            this.axToolbarControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl.OcxState")));
            this.axToolbarControl.Size = new System.Drawing.Size(574, 28);
            this.axToolbarControl.TabIndex = 2;
            // 
            // axTOCControl
            // 
            this.axTOCControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.axTOCControl.Location = new System.Drawing.Point(0, 59);
            this.axTOCControl.Name = "axTOCControl";
            this.axTOCControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl.OcxState")));
            this.axTOCControl.Size = new System.Drawing.Size(159, 380);
            this.axTOCControl.TabIndex = 3;
            this.axTOCControl.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl_OnMouseDown);
            // 
            // axMapControl
            // 
            this.axMapControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axMapControl.Location = new System.Drawing.Point(165, 59);
            this.axMapControl.Name = "axMapControl";
            this.axMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl.OcxState")));
            this.axMapControl.Size = new System.Drawing.Size(409, 380);
            this.axMapControl.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 444);
            this.Controls.Add(this.axMapControl);
            this.Controls.Add(this.axTOCControl);
            this.Controls.Add(this.axToolbarControl);
            this.Controls.Add(this.axLicenseControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "空间数据查询统计";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemQueryByAttribute;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemMapSelection;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemQueryBySpatial;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOptions;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemQueryByGraphics;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemStatistics;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOpen;
    }
}

