using Godot;
using Godot.Collections;

public partial class ProductionSiteContainerUi : TabContainer
{
        public override void _Ready()
        {
                ConnectSignals();
        }

        private void ConnectSignals()
        {
                Array<Node> children = GetChildren();

                foreach (Node node in children)
                {
                        if (node is ProductionSiteUi productionSite)
                        {
                                productionSite.previousScrollRequested += OnPreviousRequested;
                                productionSite.nextScrollRequested += OnNextRequested;
                        }
                }
        }

        private void OnPreviousRequested()
        {
                int newTab = CurrentTab - 1;
                
                if (newTab < 0)
                {
                        newTab = (sbyte)(GetTabCount() - 1);
                }

                CurrentTab = newTab;
        }

        private void OnNextRequested()
        {
                int newTab = CurrentTab + 1;

                if (newTab >= GetTabCount())
                {
                        newTab = 0;
                }

                CurrentTab = newTab;
        }
}
