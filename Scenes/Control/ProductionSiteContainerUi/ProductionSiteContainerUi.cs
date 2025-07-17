using Godot;

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
