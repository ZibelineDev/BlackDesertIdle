using Godot;
using System.Collections.Generic;

public partial class ProductionSitesHandler : Node
{
        public static ProductionSitesHandler Instance { get; private set; }

        private Dictionary<ProductionSite.Enum, ProductionSiteState> productionSiteStates = new Dictionary<ProductionSite.Enum, ProductionSiteState>();

        public override void _Ready()
        {
                if (Instance != null)
                {
                        GD.PrintErr("New instance of a Singleton detected.");
                }

                Instance = this;

                LoadProductionSites();

                Clock.Instance.clockTick += OnClockTick;
        }
        private void LoadProductionSites()
        {
                productionSiteStates[ProductionSite.Enum.WheatFarm] = InitialiseProductionSite(ProductionSite.Enum.WheatFarm);
                productionSiteStates[ProductionSite.Enum.PotatoFarm] = InitialiseProductionSite(ProductionSite.Enum.PotatoFarm);
        }

        private ProductionSiteState InitialiseProductionSite(ProductionSite.Enum productionSiteEnum)
        {
                ProductionSiteState productionSiteState = new ProductionSiteState();

                productionSiteState.productionSite = ProductionSite.Load(productionSiteEnum);

                return productionSiteState;
        }

        private void OnClockTick()
        {
                foreach (ProductionSiteState productionSiteState in productionSiteStates.Values)
                {
                        productionSiteState.ProgressWork();
                }
        }
}
