using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using 地图整饰与输出.Class;

namespace 地图整饰与输出.PageLayout
{
    public partial class frmTemplate : Form
    {
        private string sExtention = ".mxt";
        AxPageLayoutControl pPageLayoutControl;

        public static string filepath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;       
        string spath = OperatePageLayout.getPath(filepath) + "\\data\\Symbol\\Templates";//载入系统模板       
        private string sTemplatePath = string.Empty;

        public frmTemplate(AxPageLayoutControl axPLC)
        {
            InitializeComponent();
            pPageLayoutControl = axPLC;
            InitUI();
        }
        /// <summary>
        /// 向 tlstTemplate中添加各类模板名称
        /// </summary>
        private void InitUI()
        {
           try
            {
                List<string> plstDirName = null;
                List<string> plstFileName = null;


                string sFileName = string.Empty;
                string sParentName = string.Empty;

                plstDirName = OperatePageLayout.GetChildDirectoryName(spath);//获取指定路径文件夹下子文件夹名称
                for (int i = 0; i < plstDirName.Count; i++)
                {
                    sParentName = plstDirName[i];
                    TreeNode pParentNode = new TreeNode();
                    pParentNode.Text = sParentName;
                    pParentNode.ExpandAll();
                    plstFileName = OperatePageLayout.GetFiles(spath + "\\" + sParentName);
                    for (int j = 0; j < plstFileName.Count; j++)
                    {
                        sFileName = plstFileName[j];
                        //获取除后缀类型外的样式名
                        sFileName = sFileName.Substring(0, sFileName.LastIndexOf('.'));
                        TreeNode pSsan = new TreeNode();
                        pSsan.Text = sFileName;
                        pParentNode.Nodes.Add(pSsan);
                    }
                    tlstTemplate.Nodes.Add(pParentNode);
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
       /// <summary>
        /// 单击tlstTemplate中节点，载入相应的模板预览
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void tlstTemplate_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                tlstTemplate.SelectedNode = e.Node;//鼠标获取的节点
                TreeNode pFocusedNode = tlstTemplate.SelectedNode;//当前节点
                TreeNode pParentNode = new TreeNode();
                if (pFocusedNode != null)
                {

                    string sDirName = string.Empty;
                    string sFileName = string.Empty;
                    string sFilePath = string.Empty;
                    pParentNode = pFocusedNode.Parent;
                    sFileName = pFocusedNode.Text + sExtention;

                    if (pParentNode != null)//有父节点
                    {
                        sDirName = pParentNode.Text;
                        sFilePath = spath + "\\" + sDirName + "\\" + sFileName;
                    }
                    else//没有父节点，即第一级目录的样式
                    {
                        sFilePath = spath + "\\" + sFileName;
                    }

                    if (pageLayoutCtrlMxt.CheckMxFile(sFilePath))
                    {
                        pageLayoutCtrlMxt.LoadMxFile(sFilePath);
                        sTemplatePath = sFilePath;
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
              if (!string.IsNullOrEmpty(sTemplatePath))
            {
                  //类中的界面控件也可以控制主界面
                OperatePageLayout.UseTemplateMxtToPageLayout(pPageLayoutControl, sTemplatePath);
                this.Close();
            }
            else
            {
                MessageBox.Show("请选择要应用模板！", "提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
        }

        }
    }


