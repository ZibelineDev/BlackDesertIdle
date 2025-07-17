using Godot;
using System;

public partial class ProductionSiteUi : PanelContainer
{
        [Export] private ProductionSite.Enum productionSiteToLoad;

        private Label workloadLabel;

        private ProductionSiteState productionSiteState;

        public event Action previousScrollRequested;
        public event Action nextScrollRequested;

        public void SetProductionSite(ProductionSite.Enum productionSiteEnum)
        {
                this.productionSiteState = ProductionSitesHandler.Instance.GetProductionSiteState(productionSiteToLoad);

                GetNode<Label>("%NameLabel").Text = productionSiteState.productionSite.name;

                UpdateLabels();
        }

        public override void _Ready()
        {
                workloadLabel = GetNode<Label>("%WorkloadLabel");

                GetNode<Button>("%PreviousButton").Pressed += OnPreviousPressed;
                GetNode<Button>("%NextButton").Pressed += OnNextPressed;

                ProductionSitesHandler.Instance.productionSiteStatesUpdated += OnProductionSiteStatesUpdated;

                SetProductionSite(productionSiteToLoad);
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
}
