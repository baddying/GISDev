using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 交通网络分析
{
    public partial class frmTrafficNetworkAnalysis : Form
    {
        public frmTrafficNetworkAnalysis()
        {
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
            InitializeComponent();
        }
        //查找服务区分析
        private void ServiceAreaSolver_Click(object sender, EventArgs e)
        {
            frmServiceAreaSolver frmSAS = new frmServiceAreaSolver();
            frmSAS.Show();
        }
        //最近设施点分析
        private void ClosestFacilitySolver_Click(object sender, EventArgs e)
        {
            frmClosestFacilitySolver frmCFS = new frmClosestFacilitySolver();
            frmCFS.Show();
        }
        //OD成本矩阵分析
        private void ODCostMatrixSolver_Click(object sender, EventArgs e)
        {
            frmODCostMatrixSolver frmODCMS = new frmODCostMatrixSolver();
            frmODCMS.Show();
        }
        //多路径配送分析
        private void VRPSolver_Click(object sender, EventArgs e)
        {
            frmVRPSolver frmVRPS = new frmVRPSolver();
            frmVRPS.Show();
        }
        //位置分配分析
        private void LocationAllocationSolver_Click(object sender, EventArgs e)
        {
            frmLocationAllocationSolver frmLAS = new frmLocationAllocationSolver();
            frmLAS.Show();
        }       
    }
}
