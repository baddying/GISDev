namespace 交通网络分析
{
    partial class frmTrafficNetworkAnalysis
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrafficNetworkAnalysis));
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.ServiceAreaSolver = new System.Windows.Forms.Button();
            this.ClosestFacilitySolver = new System.Windows.Forms.Button();
            this.ODCostMatrixSolver = new System.Windows.Forms.Button();
            this.VRPSolver = new System.Windows.Forms.Button();
            this.LocationAllocationSolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(266, 361);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 0;
            // 
            // ServiceAreaSolver
            // 
            this.ServiceAreaSolver.Location = new System.Drawing.Point(84, 45);
            this.ServiceAreaSolver.Name = "ServiceAreaSolver";
            this.ServiceAreaSolver.Size = new System.Drawing.Size(159, 23);
            this.ServiceAreaSolver.TabIndex = 1;
            this.ServiceAreaSolver.Text = "查找服务区分析";
            this.ServiceAreaSolver.UseVisualStyleBackColor = true;
            this.ServiceAreaSolver.Click += new System.EventHandler(this.ServiceAreaSolver_Click);
            // 
            // ClosestFacilitySolver
            // 
            this.ClosestFacilitySolver.Location = new System.Drawing.Point(84, 114);
            this.ClosestFacilitySolver.Name = "ClosestFacilitySolver";
            this.ClosestFacilitySolver.Size = new System.Drawing.Size(159, 23);
            this.ClosestFacilitySolver.TabIndex = 2;
            this.ClosestFacilitySolver.Text = "最近设施点分析";
            this.ClosestFacilitySolver.UseVisualStyleBackColor = true;
            this.ClosestFacilitySolver.Click += new System.EventHandler(this.ClosestFacilitySolver_Click);
            // 
            // ODCostMatrixSolver
            // 
            this.ODCostMatrixSolver.Location = new System.Drawing.Point(84, 183);
            this.ODCostMatrixSolver.Name = "ODCostMatrixSolver";
            this.ODCostMatrixSolver.Size = new System.Drawing.Size(159, 23);
            this.ODCostMatrixSolver.TabIndex = 3;
            this.ODCostMatrixSolver.Text = "OD成本矩阵分析";
            this.ODCostMatrixSolver.UseVisualStyleBackColor = true;
            this.ODCostMatrixSolver.Click += new System.EventHandler(this.ODCostMatrixSolver_Click);
            // 
            // VRPSolver
            // 
            this.VRPSolver.Location = new System.Drawing.Point(84, 252);
            this.VRPSolver.Name = "VRPSolver";
            this.VRPSolver.Size = new System.Drawing.Size(159, 23);
            this.VRPSolver.TabIndex = 4;
            this.VRPSolver.Text = "多路径配送分析";
            this.VRPSolver.UseVisualStyleBackColor = true;
            this.VRPSolver.Click += new System.EventHandler(this.VRPSolver_Click);
            // 
            // LocationAllocationSolver
            // 
            this.LocationAllocationSolver.Location = new System.Drawing.Point(84, 321);
            this.LocationAllocationSolver.Name = "LocationAllocationSolver";
            this.LocationAllocationSolver.Size = new System.Drawing.Size(159, 23);
            this.LocationAllocationSolver.TabIndex = 5;
            this.LocationAllocationSolver.Text = "位置分配分析";
            this.LocationAllocationSolver.UseVisualStyleBackColor = true;
            this.LocationAllocationSolver.Click += new System.EventHandler(this.LocationAllocationSolver_Click);
            // 
            // frmTrafficNetworkAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 411);
            this.Controls.Add(this.LocationAllocationSolver);
            this.Controls.Add(this.VRPSolver);
            this.Controls.Add(this.ODCostMatrixSolver);
            this.Controls.Add(this.ClosestFacilitySolver);
            this.Controls.Add(this.ServiceAreaSolver);
            this.Controls.Add(this.axLicenseControl1);
            this.Name = "frmTrafficNetworkAnalysis";
            this.Text = "交通网络分析";
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.Button ServiceAreaSolver;
        private System.Windows.Forms.Button ClosestFacilitySolver;
        private System.Windows.Forms.Button ODCostMatrixSolver;
        private System.Windows.Forms.Button VRPSolver;
        private System.Windows.Forms.Button LocationAllocationSolver;
    }
}

