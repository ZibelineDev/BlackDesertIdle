using Godot;
using System;

public partial class WorkerUi : PanelContainer
{
        private static string scenePath = "uid://do33gbq8wwoqx";

        public static WorkerUi Create(Worker worker)
        {
                WorkerUi node = ResourceLoader.Load<PackedScene>(scenePath).Instantiate<WorkerUi>();

                node.worker = worker;

                return node;
        }

        private Worker worker;

        private Label nameLabel;
        private Label occupationLabel;
        private Label workSpeedLabel;

        public override void _Ready()
        {
                nameLabel = GetNode<Label>("%Name");
                occupationLabel = GetNode<Label>("%Occupation");
                workSpeedLabel = GetNode<Label>("%WorkSpeed");

                UpdateNodes();
        }

        public void SetWorker(Worker worker)
        {
                this.worker = worker;
                UpdateNodes();
        }

        public void UpdateNodes()
        {
                if (worker == null)
                {
                        GD.PrintErr("Worker Ui has no Worker Resource.");
                        return;
                }

                string occupationText;

                if (worker.assignedProductionSite == null)
                {
                        occupationText = "idle";
                }
                else
                {
                         string productionSiteName = ProductionSitesHandler.GetProductionSiteState(ProductionSite.GetEnum(worker.assignedProductionSite)).productionSite.name;
                        occupationText = $"Working at {productionSiteName}";
                }

                nameLabel.Text = worker.name;
                occupationLabel.Text = occupationText;
                workSpeedLabel.Text = $"Work Speed : {worker.workSpeed}";
        }
}
