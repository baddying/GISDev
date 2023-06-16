using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GISEditor.EditTool.BasicClass;

namespace GISEditor
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ESRI License Initializer generated code.
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
            ESRI.ArcGIS.RuntimeManager.BindLicense(ESRI.ArcGIS.ProductCode.EngineOrDesktop);

            frmMain frmMain = null;
            frmMain = new frmMain();
            MapManager.ToolPlatForm = frmMain;
            Application.Run(frmMain);
        }
    }
}
