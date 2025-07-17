using Godot;
using Godot.Collections;

public partial class ProductionSiteContainerUi : TabContainer
{
        private static string productionUiScenePath = "uid://cxx5dn51ofhkr";

        public void AddProductionSite(ProductionSite.Enum productionSiteEnum)
        {
                ProductionSiteUi productionSiteUi = ResourceLoader.Load<PackedScene>(productionUiScenePath).Instantiate<ProductionSiteUi>();

                productionSiteUi.productionSiteToLoad = productionSiteEnum;

                productionSiteUi.previousScrollRequested += OnPreviousRequested;
                productionSiteUi.nextScrollRequested += OnNextRequested;

                AddChild(productionSiteUi);
        }

        public void CleanProductionSites()
        {
                Array<Node> children = GetChildren();

                foreach (Node node in children)
                {
                        if (node is ProductionSiteUi productionSiteUi)
                        {
                                productionSiteUi.previousScrollRequested -= OnPreviousRequested;
                                productionSiteUi.nextScrollRequested -= OnNextRequested;

                                productionSiteUi.QueueFree();
                        }
                }
        }

        private void OnPreviousRequested()
        {
                int newTab = CurrentTab - 1;
                
                if (newTab < 0)
                {
                        newTab = (sbyte)(GetTabCount() - 1);
                }

                CurrentTab = newTab;
        }

        private void OnNextRequested()
        {
                int newTab = CurrentTab + 1;

                if (newTab >= GetTabCount())
                {
                        newTab = 0;
                }

                CurrentTab = newTab;
        }
}
