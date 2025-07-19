using Godot;
using System;

public partial class MapNodeBillboard : Area3D
{
        [Export] private MapNode.Enum mapNodeEnum;

        private bool isHovered = false;

        public override void _Ready()
        {
                MouseEntered += OnMouseEntered;
                MouseExited += OnMouseExited;
        }

        public override void _Input(InputEvent @event)
        {
                if (!isHovered)
                {
                        return;
                }

                if (@event is InputEventMouseButton inputEventMouseButton)
                {
                        if (inputEventMouseButton.ButtonIndex == MouseButton.Left && inputEventMouseButton.Pressed)
                        {
                                MapNodeUi.SetMapNode(mapNodeEnum);
                        }
                }
        }

        private void OnMouseEntered()
        {
                isHovered = true;
        }

        private void OnMouseExited()
        {
                isHovered = false;
        }
}
