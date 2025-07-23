using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;

public partial class ProductionSiteUi : PanelContainer
{
        [Export] public ProductionSite.Enum productionSiteToLoad;

        private Label workloadLabel;
        private VBoxContainer workerListContainer;
        private TabContainer workerTab;
        private WorkerUi workerUi;

        private ProductionSite.Enum productionSiteEnum;
        private ProductionSiteState productionSiteState;

        public event Action previousScrollRequested;
        public event Action nextScrollRequested;

        public void SetProductionSite(ProductionSite.Enum productionSiteEnum)
        {
                this.productionSiteEnum = productionSiteEnum;
                this.productionSiteState = ProductionSitesHandler.GetProductionSiteState(productionSiteToLoad);

                GetNode<Label>("%NameLabel").Text = productionSiteState.productionSite.name;

                UpdateLabels();
        }

        public override void _Ready()
        {
                workloadLabel = GetNode<Label>("%WorkloadLabel");
                workerListContainer = GetNode<VBoxContainer>("%WorkerListContainer");
                workerTab = GetNode<TabContainer>("%WorkerTab");
                workerUi = GetNode<WorkerUi>("%WorkerUi");

                GetNode<Button>("%PreviousButton").Pressed += OnPreviousPressed;
                GetNode<Button>("%NextButton").Pressed += OnNextPressed;

                ProductionSitesHandler.Instance.productionSiteStatesUpdated += OnProductionSiteStatesUpdated;
                WorkersHandler.Instance.workerCreated += OnWorkerCreated;
                WorkersHandler.Instance.workerAssigned += OnWorkerAssigned;

                SetProductionSite(productionSiteToLoad);
                UpdateWorkerStatus();
        }

        public override void _ExitTree()
        {
                ProductionSitesHandler.Instance.productionSiteStatesUpdated -= OnProductionSiteStatesUpdated;
                WorkersHandler.Instance.workerCreated -= OnWorkerCreated;
                WorkersHandler.Instance.workerAssigned -= OnWorkerAssigned;
        }

        private void UpdateLabels()
        {
                workloadLabel.Text = $"Workload progress : {productionSiteState.workloadProgress} / {productionSiteState.productionSite.workload}";
        }

        private void OnPreviousPressed()
        {
                previousScrollRequested?.Invoke();
        }

        private void OnNextPressed()
        {
                nextScrollRequested?.Invoke();
        }

        private void OnProductionSiteStatesUpdated()
        {
                UpdateLabels();
        }

        private void CreateWorkerButtons()
        {
                Array<Node> nodes = workerListContainer.GetChildren();

                foreach (Node node in nodes) node.QueueFree();

                List<Worker> idleWorkers = WorkersHandler.GetIdleWorkers();

                foreach(Worker worker in idleWorkers)
                {
                        ProductionSiteWorkerButton node = ProductionSiteWorkerButton.Create(productionSiteEnum, worker);
                        workerListContainer.AddChild(node);
                }
        }

        private void OnWorkerCreated()
        {
                UpdateWorkerStatus();
        }

        private void OnWorkerAssigned()
        {
                UpdateWorkerStatus();
        }

        private void UpdateWorkerStatus()
        {
                if (productionSiteState.isActive)
                {
                        workerTab.CurrentTab = 1;
                        workerUi.SetWorker(productionSiteState.assignedWorker);
                }
                else
                {
                        workerTab.CurrentTab = 0;
                        CreateWorkerButtons();
                }
        }
}
