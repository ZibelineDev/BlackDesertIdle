using Godot;
using System;
using System.Runtime.InteropServices.Marshalling;

public partial class MapNodeUi : PanelContainer
{
        public static MapNodeUi DebugInstance { get; private set; }

        private MapNode mapNode;

        private TabContainer productionSitesTabContainer;

        private ProductionSiteContainerUi productionSiteContainerUi;

        public override void _Ready()
        {
                DebugInstance = this;

                productionSitesTabContainer = GetNode<TabContainer>("%ProductionSitesTabContainer");
                productionSiteContainerUi = GetNode<ProductionSiteContainerUi>("%ProductionSiteContainerUi");

                WorkersHandler.Instance.workerAssigned += OnWorkerAssigned;

                Visible = false;
        }

        public override void _ExitTree()
        {
                WorkersHandler.Instance.workerAssigned -= OnWorkerAssigned;
        }

        public static void StaticHide()
        {
                DebugInstance.Hide();
                DebugInstance.mapNode = null;
        }

        public void SetMapNode(MapNode mapNode)
        {
                if (mapNode == this.mapNode)
                {
                        return;
                }

                this.mapNode = mapNode;

                GetNode<Label>("%NameLabel").Text = mapNode.name;

                CleanProductionSites();
                InitialiseProductionSites();

                Visible = true;
        }

        public static void SetMapNode(MapNode.Enum mapNodeEnum)
        {
                MapNode mapNode = MapNode.Load(mapNodeEnum);

                DebugInstance.SetMapNode(mapNode);
        }

        public static void SetProductionSite(int index)
        {
                DebugInstance.productionSitesTabContainer.CurrentTab = 0;
                DebugInstance.productionSiteContainerUi.SetTab(index);
        }

        private void InitialiseProductionSites()
        {
                if (mapNode.productionSites == null)
                {
                        productionSitesTabContainer.CurrentTab = 1;
                        return;
                }

                if (mapNode.productionSites.Count == 0)
                {
                        productionSitesTabContainer.CurrentTab = 1;
                        return;
                }

                productionSitesTabContainer.CurrentTab = 2;

                foreach (ProductionSite.Enum productionSiteEnum in mapNode.productionSites)
                {
                        productionSiteContainerUi.AddProductionSite(productionSiteEnum);
                }
        }

        private void CleanProductionSites()
        {
                productionSiteContainerUi.CleanProductionSites();
        }

        private void OnWorkerAssigned()
        {
                if (mapNode.IsActive()) {  }
        }

        private void Activate()
        {
                
        }
}
