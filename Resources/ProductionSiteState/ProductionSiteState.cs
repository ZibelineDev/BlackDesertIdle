using Godot;

public partial class ProductionSiteState : Resource
{
        public ProductionSite productionSite;
        [Export] public ProductionSite.Enum productionSiteEnum;
        
        [Export] public bool isActive = false;
        [Export] public int workloadProgress = 0;

        [Export] public Worker assignedWorker = null;

        public static ProductionSiteState Initialise(ProductionSite.Enum productionSiteEnum)
        {
                ProductionSiteState productionSiteState = new ProductionSiteState();

                productionSiteState.productionSite = ProductionSite.Load(productionSiteEnum);
                productionSiteState.productionSiteEnum = productionSiteEnum;

                return productionSiteState;
        }

        public void ProgressWork()
        {
                workloadProgress += 10;

                if (workloadProgress >= productionSite.workload)
                {
                        workloadProgress = 0;
                        Produce();
                }
        }

        private void Produce()
        {
                foreach (ItemLoot itemLoot in productionSite.output)
                {
                        byte quantity = itemLoot.Roll();

                        if (quantity <= 0)
                        {
                                continue;
                        }

                        Logger.Log($"Produced : {itemLoot.item.name} x{quantity}");
                }
        }
}
