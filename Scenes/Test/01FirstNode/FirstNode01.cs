using Godot;
using System;

public partial class FirstNode01 : Node
{
        private ProductionSite productionSite = ProductionSite.GetWheatFarm();

        private int workloadProgress = 0;

        private double timeProgress = 0.0;

        public override void _Process(double delta)
        {
                timeProgress += delta;
                
                if (timeProgress >= 1.0)
                {
                        timeProgress -= 1.0;
                        ProgressWorkload();
                }
        }

        private void ProgressWorkload()
        {
                workloadProgress += 9;

                if (workloadProgress >= productionSite.workload)
                {
                        workloadProgress -= productionSite.workload;
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
