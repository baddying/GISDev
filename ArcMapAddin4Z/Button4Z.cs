using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Carto;
using System.Windows.Forms;

namespace ArcMapAddin4Z
{
    public class Button4Z : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public Button4Z()
        {
        }

        protected override void OnClick()
        {
            //
            //  TODO: Sample code showing how to access button host
            //
            ArcMap.Application.CurrentTool = null;
            List<ILayer> lyrLst = new List<ILayer>();
            IMap pMap = ArcMap.Document.FocusMap;

            for (int i = 0; i < pMap.LayerCount; i++)
            {
                ILayer lyr = pMap.get_Layer(i);
                if (lyr is IFeatureLayer)
                {
                    lyrLst.Add(lyr);
                }
            }
            if (lyrLst.Count < 1)
            {
                MessageBox.Show("没有可用图层，请先加载矢量图层。");
                return;
            }


            new FrmAddPara(lyrLst).ShowDialog();
        }
        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }
    }

}
