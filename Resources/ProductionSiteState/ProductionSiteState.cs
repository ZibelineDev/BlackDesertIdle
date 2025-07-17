using Godot;

public partial class ProductionSiteState : Resource
{
        [Export] public ProductionSite productionSite = new ProductionSite();
        
        [Export] public bool isActive = false;
        [Export] public int workloadProgress = 0;

        [Export] public Worker assignedWorker = null;

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
