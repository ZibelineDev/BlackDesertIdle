using Godot;
using System;
using System.Collections.Generic;

public partial class ProductionSitesHandler : Node
{
        public static ProductionSitesHandler Instance { get; private set; }

        public event Action productionSiteStatesUpdated;

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
                productionSiteStates[ProductionSite.Enum.WheatFarm] = ProductionSiteState.Initialise(ProductionSite.Enum.WheatFarm);
                productionSiteStates[ProductionSite.Enum.PotatoFarm] = ProductionSiteState.Initialise(ProductionSite.Enum.PotatoFarm);
        }

        public static ProductionSiteState GetProductionSiteState(ProductionSite.Enum productionSiteEnum)
        {
                return Instance.productionSiteStates[productionSiteEnum];
        }

        public static void AssignWorker(ProductionSite.Enum productionSiteEnum, Worker worker)
        {
                ProductionSiteState productionSiteState = Instance.productionSiteStates[productionSiteEnum];

                productionSiteState.assignedWorker = worker;
                productionSiteState.isActive = true;
                
        }

        private void OnClockTick()
        {
                foreach (ProductionSiteState productionSiteState in productionSiteStates.Values)
                {
                        if (productionSiteState.isActive)
                        {
                                productionSiteState.ProgressWork();
                        }
                }

                productionSiteStatesUpdated?.Invoke();
        }
}
