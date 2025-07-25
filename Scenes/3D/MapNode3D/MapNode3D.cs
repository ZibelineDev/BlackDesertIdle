using Godot;
using System;

public partial class MapNode3D : Node
{
        private static MapNode3D inspectedNode = null;

        [Export] private MapNode.Enum mapNodeEnum;
        private MapNodeBillboard mapNodeBillboard;
        private Node3D productionSites;

        public override void _Ready()
        {
                mapNodeBillboard = GetNode<MapNodeBillboard>("%MapNodeBillboard");
                productionSites = GetNode<Node3D>("%ProductionSites");

                mapNodeBillboard.nodePressed += OnNodePressed;
                ConnectProductionSitesSignals();

                productionSites.Visible = false;

                InitialiseBillboardLabel();
        }

        public override void _ExitTree()
        {
                mapNodeBillboard.nodePressed -= OnNodePressed;

                DisconnectProductionSitesSignals();
        }

        public override void _UnhandledInput(InputEvent @event)
        {
                if (@event.IsActionPressed("Escape"))
                {
                        ReleaseInspection();
                        MapNodeUi.StaticHide();
                }
        }

        private void OnNodePressed()
        {
                InspectNode();
        }

        private void InspectNode()
        {
                if (inspectedNode != null)
                {
                        if (inspectedNode == this)
                        {
                                return;
                        }

                        inspectedNode.ReleaseInspection();
                }

                Logger.Log($"Inspecting node {mapNodeEnum}");

                inspectedNode = this;
                productionSites.Visible = true;
                MapNodeUi.SetMapNode(mapNodeEnum);
        }

        private void ReleaseInspection()
        {
                Logger.Log($"Releasing Inspect on node {mapNodeEnum}");
                inspectedNode = null;
                productionSites.Visible = false;
        }

        private void InitialiseBillboardLabel()
        {
                string name = MapNode.Load(mapNodeEnum).name;
                mapNodeBillboard.InitialiseLabel(name);
        }

        private void ConnectProductionSitesSignals()
        {
                Godot.Collections.Array<Node> children = productionSites.GetChildren();

                foreach (Node node in children)
                {
                        if (node is ProductionSite3D productionSite3D)
                        {
                                productionSite3D.pressed += OnProductionSitePressed; 
                        }
                }
        }

        private void DisconnectProductionSitesSignals()
        {
                Godot.Collections.Array<Node> children = productionSites.GetChildren();

                foreach (Node node in children)
                {
                        if (node is ProductionSite3D productionSite3D)
                        {
                                productionSite3D.pressed -= OnProductionSitePressed;
                        }
                }
        }

        private void OnProductionSitePressed(int index)
        {
                MapNodeUi.SetProductionSite(index);
        }
}
