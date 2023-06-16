using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using GISEditor.EditTool.BasicClass;
using GISEditor.EditTool.Tool;
using GISEditor.EditTool.Command;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;

namespace GISEditor
{
    public partial class frmMain : Form
    {

        #region 变量定义        
        private string sMxdPath = Application.StartupPath ;
        private IMap pMap = null;
        private IActiveView pActiveView = null;
        private List<ILayer> plstLayers = null;
        private IFeatureLayer pCurrentLyr = null;      
        private IEngineEditor pEngineEditor = null;
        private IEngineEditTask pEngineEditTask = null;
        private IEngineEditLayers pEngineEditLayers = null;

        #endregion

        #region 初始化


        public frmMain()
        {
            InitializeComponent();
            InitObject();
        }

        private void InitObject()
        {
            try
            {
                ChangeButtonState(false);
                pEngineEditor = new EngineEditorClass();
                MapManager.EngineEditor = pEngineEditor;
                pEngineEditTask = pEngineEditor as IEngineEditTask;
                pEngineEditLayers = pEngineEditor as IEngineEditLayers;
                pMap = mainMapControl.Map;
                pActiveView = pMap as IActiveView;
                plstLayers = MapManager.GetLayers(pMap);
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message, "InitObject fial");
            }
        }

        #endregion

        #region 编辑操作

        /// <summary>
        /// 开始编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (plstLayers == null || plstLayers.Count == 0)
                {
                    MessageBox.Show("请加载编辑图层！", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                pMap.ClearSelection();
                pActiveView.Refresh();
                InitComboBox(plstLayers);
                ChangeButtonState(true);
                //如果编辑已经开始，则直接退出
                if (pEngineEditor.EditState != esriEngineEditState.esriEngineStateNotEditing)
                    return;
                if (pCurrentLyr == null) return;               
                //获取当前编辑图层工作空间
                IDataset pDataSet = pCurrentLyr.FeatureClass as IDataset;
                IWorkspace pWs = pDataSet.Workspace;
                //设置编辑模式，如果是ArcSDE采用版本模式
                if (pWs.Type == esriWorkspaceType.esriRemoteDatabaseWorkspace)
                {
                    pEngineEditor.EditSessionMode = esriEngineEditSessionMode.esriEngineEditSessionModeVersioned;
                }
                else
                {
                    pEngineEditor.EditSessionMode = esriEngineEditSessionMode.esriEngineEditSessionModeNonVersioned;
                }
                //设置编辑任务
                pEngineEditTask = pEngineEditor.GetTaskByUniqueName("ControlToolsEditing_CreateNewFeatureTask");
                pEngineEditor.CurrentTask = pEngineEditTask;// 设置编辑任务
                pEngineEditor.EnableUndoRedo(true); //是否可以进行撤销、恢复操作
                pEngineEditor.StartEditing(pWs, pMap); //开始编辑操作
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 保存编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ICommand m_saveEditCom = new SaveEditCommandClass();
                m_saveEditCom.OnCreate(mainMapControl.Object);
                m_saveEditCom.OnClick();
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 结束编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ICommand m_stopEditCom = new StopEditCommandClass();
                m_stopEditCom.OnCreate(mainMapControl.Object);
                m_stopEditCom.OnClick();
                ChangeButtonState(false);
                mainMapControl.CurrentTool = null;
                mainMapControl.MousePointer = esriControlsMousePointer.esriPointerDefault;
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 添加选择框中内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSelLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sLyrName = cmbSelLayer.SelectedItem.ToString();
                pCurrentLyr = MapManager.GetLayerByName(pMap, sLyrName) as IFeatureLayer;
                //设置编辑目标图层
                pEngineEditLayers.SetTargetLayer(pCurrentLyr, 0);
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 选择要素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelFeat_Click(object sender, EventArgs e)
        {
            try
            {
                ICommand m_SelTool = new SelectFeatureToolClass();
                m_SelTool.OnCreate(mainMapControl.Object);
                m_SelTool.OnClick();
                mainMapControl.CurrentTool = m_SelTool as ITool;
                mainMapControl.MousePointer = esriControlsMousePointer.esriPointerArrow;
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 撤销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                mainMapControl.MousePointer = esriControlsMousePointer.esriPointerArrow;
                ICommand m_undoCommand = new UndoCommandClass();
                m_undoCommand.OnCreate(mainMapControl.Object);
                m_undoCommand.OnClick();
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 恢复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRedo_Click(object sender, EventArgs e)
        {
            try
            {
                mainMapControl.MousePointer = esriControlsMousePointer.esriPointerArrow;
                ICommand m_redoCommand = new RedoCommandClass();
                m_redoCommand.OnCreate(mainMapControl.Object);
                m_redoCommand.OnClick();
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 移动要素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelMove_Click(object sender, EventArgs e)
        {
            try
            {
                ICommand m_moveTool = new MoveFeatureToolClass();
                m_moveTool.OnCreate(mainMapControl.Object);
                m_moveTool.OnClick();
                mainMapControl.CurrentTool = m_moveTool as ITool;
                mainMapControl.MousePointer = esriControlsMousePointer.esriPointerArrow;
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 添加要素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFeature_Click(object sender, EventArgs e)
        {
            try
            {
                ICommand m_CreateFeatTool = new CreateFeatureToolClass();
                m_CreateFeatTool.OnCreate(mainMapControl.Object);
                m_CreateFeatTool.OnClick();
                mainMapControl.CurrentTool = m_CreateFeatTool as ITool;
                mainMapControl.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 删除要素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelFeature_Click(object sender, EventArgs e)
        {
            try
            {
                mainMapControl.MousePointer = esriControlsMousePointer.esriPointerArrow;
                ICommand m_delFeatCom = new DelFeatureCommandClass();
                m_delFeatCom.OnCreate(mainMapControl.Object);
                m_delFeatCom.OnClick();
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 属性编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAttributeEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ICommand m_AtrributeCom = new EditAtrributeToolClass();
                m_AtrributeCom.OnCreate(mainMapControl.Object);
                m_AtrributeCom.OnClick();
                mainMapControl.CurrentTool = m_AtrributeCom as ITool;
                mainMapControl.MousePointer = esriControlsMousePointer.esriPointerArrow;
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 移动节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveVertex_Click(object sender, EventArgs e)
        {
            try
            {
                ICommand m_MoveVertexTool = new MoveVertexToolClass();
                m_MoveVertexTool.OnCreate(mainMapControl.Object);                
                mainMapControl.CurrentTool = m_MoveVertexTool as ITool;
                mainMapControl.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddVertex_Click(object sender, EventArgs e)
        {
            try
            {
                ICommand m_AddVertexTool = new AddVertexToolClass();
                m_AddVertexTool.OnCreate(mainMapControl.Object);               
                mainMapControl.CurrentTool = m_AddVertexTool as ITool;
                mainMapControl.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelVertex_Click(object sender, EventArgs e)
        {
            try
            {
                ICommand m_DelVertexTool = new DelVertexToolClass();
                m_DelVertexTool.OnCreate(mainMapControl.Object);               
                mainMapControl.CurrentTool = m_DelVertexTool as ITool;
                mainMapControl.MousePointer = esriControlsMousePointer.esriPointerCrosshair;                
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region 操作函数

        private void ChangeButtonState(bool bEnable)
        {
            btnStartEdit.Enabled = !bEnable;
            btnSaveEdit.Enabled = bEnable;
            btnEndEdit.Enabled = bEnable;

            cmbSelLayer.Enabled = bEnable;

            btnSelFeat.Enabled = bEnable;
            btnSelMove.Enabled = bEnable;
            btnAddFeature.Enabled = bEnable;
            btnDelFeature.Enabled = bEnable;
            btnAttributeEdit.Enabled = bEnable;
            btnUndo.Enabled = bEnable;
            btnRedo.Enabled = bEnable;
            btnMoveVertex.Enabled = bEnable;
            btnAddVertex.Enabled = bEnable;
            btnDelVertex.Enabled = bEnable;
        }

        private void InitComboBox(List<ILayer> plstLyr)
        {
            cmbSelLayer.Items.Clear();
            for (int i = 0; i < plstLyr.Count; i++)
            {
                if (!cmbSelLayer.Items.Contains(plstLyr[i].Name))
                {
                    cmbSelLayer.Items.Add(plstLyr[i].Name);
                }
            }
            if (cmbSelLayer.Items.Count != 0) cmbSelLayer.SelectedIndex = 0;
        }

        #endregion

        #region 获取路径
        public string getPath(string path)
        {
            int t;
            for (t = 0; t < path.Length; t++)
            {
                if (path.Substring(t, 6) == "空间数据编辑")
                {
                    break;
                }
            }
            string name = path.Substring(0, t + 6);
            return name;
        }
        #endregion

        /// <summary>
        /// 实时获取图层列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainMapControl_OnViewRefreshed(object sender, IMapControlEvents2_OnViewRefreshedEvent e)
        {
            plstLayers = MapManager.GetLayers(pMap);
        }
    }
}
