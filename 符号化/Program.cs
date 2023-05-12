using ESRI.ArcGIS.esriSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using 点线面符号化;

namespace 符号化
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
            IAoInitialize aoInit = new AoInitializeClass();
            aoInit.Initialize(esriLicenseProductCode.esriLicenseProductCodeArcServer);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMainUI());
        }
    }
}
