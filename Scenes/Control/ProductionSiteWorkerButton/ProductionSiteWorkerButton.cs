using Godot;
using System;

public partial class ProductionSiteWorkerButton : Button
{
        private static string scenePath = "uid://cotoch1w72dw3";

        public static ProductionSiteWorkerButton Create(ProductionSite.Enum productionSiteEnum, Worker worker)
        {
                ProductionSiteWorkerButton node = ResourceLoader.Load<PackedScene>(scenePath).Instantiate<ProductionSiteWorkerButton>();

                node.productionSiteEnum = productionSiteEnum;
                node.worker = worker;

                return node;
        }

        public ProductionSite.Enum productionSiteEnum;
        public Worker worker;

        public override void _Ready()
        {
                Text = $"{worker.name} (speed : {worker.workSpeed})";

                Pressed += OnPressed;
        }

        private void OnPressed()
        {
                WorkersHandler.AssignWorker(productionSiteEnum, worker);
        }
}
