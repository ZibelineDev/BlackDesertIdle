using Godot;
using System;

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

                SetMapNode(MapNode.Load(MapNode.Enum.BartaliFarm));
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
        }

        public static void SetMapNode(MapNode.Enum mapNodeEnum)
        {
                MapNode mapNode = MapNode.Load(mapNodeEnum);

                DebugInstance.SetMapNode(mapNode);
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

                productionSitesTabContainer.CurrentTab = 0;

                foreach (ProductionSite.Enum productionSiteEnum in mapNode.productionSites)
                {
                        productionSiteContainerUi.AddProductionSite(productionSiteEnum);
                }
        }

        private void CleanProductionSites()
        {
                productionSiteContainerUi.CleanProductionSites();
        }
}
