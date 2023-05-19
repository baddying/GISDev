using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;

namespace EditSDELayerDemo
{
    public class EditCommonClass
    {
        //编辑工作空间
        public static IWorkspaceEdit workSpaceEdit;
        //编辑目标图层
        public static IFeatureLayer focusFeatureLayer;
    }
}
