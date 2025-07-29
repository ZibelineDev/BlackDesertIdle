using Godot;
using System;

public partial class MapNodeBillboard : Area3D
{
        private Sprite3D sprite3D;

        private bool isHovered = false;
        private bool isRotating = false;

        public event Action nodePressed;

        private static Color ownedColor = new Color(0.736f, 0.514f, 0.0f);
        private static Color notOwnedColor = new Color(1f, 1f, 1f);

        public override void _Ready()
        {
                sprite3D = GetNode<Sprite3D>("Sprite3D");

                MouseEntered += OnMouseEntered;
                MouseExited += OnMouseExited;
        }

        public override void _Process(double delta)
        {
                LookAt(CameraPole.Instance.camera.GlobalPosition, Vector3.Up);

                if (!isRotating)
                {
                        return;
                }

                sprite3D.RotateZ((float)delta);
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
                                nodePressed?.Invoke();
                        }
                }
        }

        public void InitialiseLabel(string name)
        {
                GetNode<Label3D>("Label3D").Text = name;
        }

        private void OnMouseEntered()
        {
                isHovered = true;
        }

        private void OnMouseExited()
        {
                isHovered = false;
        }

        public void StartRotation()
        {
                isRotating = true;
        }

        public void StopRotation()
        {
                isRotating = false;
        }

        public void SetColourToOwned()
        {
                sprite3D.Modulate = ownedColor;
        }

        public void SetColourToNotOwned()
        {
                sprite3D.Modulate = notOwnedColor;
        }
}
