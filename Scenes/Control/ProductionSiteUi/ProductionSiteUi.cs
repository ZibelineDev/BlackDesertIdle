using Godot;
using System;

public partial class ProductionSiteUi : PanelContainer
{
        [Export] private ProductionSite.Enum productionSiteToLoad;

        private ProductionSite productionSite;

        public event Action previousScrollRequested;
        public event Action nextScrollRequested;

        public void SetProductionSite(ProductionSite productionSite)
        {
                this.productionSite = productionSite;

                GetNode<Label>("%NameLabel").Text = productionSite.name;
                GetNode<Label>("%WorkloadLabel").Text = $"Workload required : {productionSite.workload}";
        }

        public override void _Ready()
        {
                GetNode<Button>("%PreviousButton").Pressed += OnPreviousPressed;
                GetNode<Button>("%NextButton").Pressed += OnNextPressed;

                SetProductionSite(ProductionSite.Load(productionSiteToLoad));
        }

        private void OnPreviousPressed()
        {
                previousScrollRequested?.Invoke();
        }

        private void OnNextPressed()
        {
                nextScrollRequested?.Invoke();
        }
}
