using Godot;
using System;

public partial class ProductionSite3D : Area3D
{
        public event Action<int> pressed;

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
                                pressed?.Invoke(GetIndex());
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
