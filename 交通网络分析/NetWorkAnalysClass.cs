using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.NetworkAnalyst;

namespace 交通网络分析
{
    class NetWorkAnalysClass
    {
        //打开工作空间
        public static IWorkspace OpenWorkspace(string strGDBName)
        {
            IWorkspaceFactory workspaceFactory = new AccessWorkspaceFactoryClass();
            IWorkspace workspace = workspaceFactory.OpenFromFile(strGDBName, 0);
            return workspace;
        }
        //打开网络数据集
        public static INetworkDataset OpenNetworkDataset(IWorkspace workspace, string featureDatasetName, string strNDSName)
        {
            if (workspace == null || strNDSName == "" || featureDatasetName == null)
            {
                return null;
            }
            IWorkspaceExtensionManager workspaceExtensionManager;
            IDatasetContainer2 datasetContainer2;
            IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;
            workspaceExtensionManager = workspace as IWorkspaceExtensionManager;
            IFeatureDataset featureDataset;
            featureDataset = featureWorkspace.OpenFeatureDataset(featureDatasetName);
            IFeatureDatasetExtensionContainer featureDatasetExtensionContainer = featureDataset as IFeatureDatasetExtensionContainer; // Dynamic Cast
            IFeatureDatasetExtension featureDatasetExtension = featureDatasetExtensionContainer.FindExtension(esriDatasetType.esriDTNetworkDataset);
            datasetContainer2 = featureDatasetExtension as IDatasetContainer2;
            if (datasetContainer2 == null)
                return null;
            IDataset dataset = datasetContainer2.get_DatasetByName(esriDatasetType.esriDTNetworkDataset, strNDSName);
            return dataset as INetworkDataset;
        }
        //创建分析上下文
        public static INAContext CreatePathSolverContext(INetworkDataset networkDataset, string type)
        {
            IDENetworkDataset deNDS = GetPathDENetworkDataset(networkDataset);
            INASolver naSolver;
            switch (type)
            {
                case "ShortPath":
                    naSolver = new NAClosestFacilitySolver();
                    break;
                case "ServiceArea":
                    naSolver = new NAServiceAreaSolverClass();
                    break;
                case "ClosestFacility":
                    naSolver = new NAClosestFacilitySolverClass();
                    break;
                case "ODCostMatrixSolver":
                    naSolver = new NAODCostMatrixSolverClass();
                    break;
                case "VRPSolver":
                    naSolver = new NAVRPSolverClass();
                    break;
                case "LocationAllocationSolver":
                    naSolver = new NALocationAllocationSolverClass();
                    break;
                default:
                    naSolver = new NAClosestFacilitySolver();
                    break;
            }
            INAContextEdit contextEdit = naSolver.CreateContext(deNDS, naSolver.Name) as INAContextEdit;
            contextEdit.Bind(networkDataset, new GPMessagesClass());
            return contextEdit as INAContext;
        }
        public static IDENetworkDataset GetPathDENetworkDataset(INetworkDataset networkDataset)
        {
            IDatasetComponent dsComponent;
            dsComponent = networkDataset as IDatasetComponent;
            return dsComponent.DataElement as IDENetworkDataset;
        }
        public static void LoadNANetworkLocations(INAContext m_NAContext, string strNAClassName, ITable inputTable)
        {
            INamedSet classes = m_NAContext.NAClasses;
            INAClass naClass = classes.get_ItemByName(strNAClassName) as INAClass;
            naClass.DeleteAllRows();
            INAClassLoader loader = new NAClassLoader();
            loader.Locator = m_NAContext.Locator;
            loader.Locator.SnapTolerance = 100;
            loader.NAClass = naClass;
            INAClassFieldMap fieldMap = new NAClassFieldMapClass();
            fieldMap.CreateMapping(naClass.ClassDefinition, inputTable.Fields);
            loader.FieldMap = fieldMap;
            INALocator3 locator = m_NAContext.Locator as INALocator3;
            locator.ExcludeRestrictedElements = false;//排除网络受限
            locator.CacheRestrictedElements(m_NAContext);
            int rowsIn = 0;
            int rowsLocated = 0;
            loader.Load(inputTable.Search(null, true), null, ref rowsIn, ref rowsLocated);
            INAContextEdit naContextEdit = m_NAContext as INAContextEdit;
            naContextEdit.ContextChanged();
        }

    }
}
