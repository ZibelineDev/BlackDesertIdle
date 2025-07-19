using Godot;
using System;

public partial class CameraPole : Node3D
{
        private Camera3D camera;

        private Vector3[] cameraPositions = 
                [
                        new Vector3(0, 6, -10),
                        new Vector3(0, 9, -14),
                        new Vector3(0, 12, -22),
                ];
        private sbyte[] cameraRotations =
                [
                        -20,
                        -20,
                        -30,
                ];
        private byte cameraPositionIndex;

        private bool cameraIsDragged = false;
        private bool cameraIsRotating = false;

        public override void _Ready()
        {
                camera = GetNode<Camera3D>("%Camera3D");

                ChangeCameraPosition(0);
        }

        public override void _Input(InputEvent @event)
        {
                CatchMouseMotion(@event);
        }

        public override void _UnhandledInput(InputEvent @event)
        {
                CatchZoom(@event);
                CatchClicks(@event);
        }

        private void CatchZoom(InputEvent @event)
        {
                if (@event.IsActionPressed("ZoomIn"))
                {
                        ChangeCameraPosition((byte)(cameraPositionIndex - 1));
                }

                if (@event.IsActionPressed("ZoomOut"))
                {
                        ChangeCameraPosition((byte)(cameraPositionIndex + 1));
                }
        }

        private void CatchClicks(InputEvent @event)
        {
                if (@event is InputEventMouseButton inputEventMouseButton)
                {
                        if (inputEventMouseButton.ButtonIndex == MouseButton.Left)
                        {
                                if (inputEventMouseButton.Pressed)
                                {
                                        cameraIsDragged = true;
                                }

                                if (inputEventMouseButton.IsReleased())
                                {
                                        cameraIsDragged = false;
                                }

                                return;
                        }

                        if (inputEventMouseButton.ButtonIndex == MouseButton.Right)
                        {
                                if (inputEventMouseButton.Pressed)
                                {
                                        cameraIsRotating = true;
                                }

                                if (inputEventMouseButton.IsReleased())
                                {
                                        cameraIsRotating = false;
                                }
                        }
                }
        }

        private void CatchMouseMotion(InputEvent @event)
        {
                if (cameraIsDragged)
                {
                        if (@event is InputEventMouseMotion inputEventMouseMotion)
                        {
                                Vector3 direction =
                                        (
                                               (Transform.Basis.X * inputEventMouseMotion.Relative.X * 0.05f) +
                                               (Transform.Basis.Z * inputEventMouseMotion.Relative.Y * 0.05f)
                                        );

                                Position = new Vector3
                                        (
                                                Position.X + direction.X,
                                                Position.Y,
                                                Position.Z + direction.Z
                                        );
                        }
                }

                if (cameraIsRotating)
                {
                        if (@event is InputEventMouseMotion inputEventMouseMotion)
                        {
                                Rotation = new Vector3
                                        (
                                                Rotation.X,
                                                Rotation.Y + Mathf.DegToRad(inputEventMouseMotion.Relative.X * -0.25f),
                                                Rotation.Z
                                        );
                        }
                }
        }

        private void ChangeCameraPosition(byte cameraPositionIndex)
        {
                if (cameraPositionIndex < 0 || cameraPositionIndex >= cameraPositions.Length || cameraPositionIndex == this.cameraPositionIndex)
                {
                        return;
                }

                this.cameraPositionIndex = cameraPositionIndex;

                camera.Position = cameraPositions[cameraPositionIndex];
                camera.Rotation = new Vector3
                        (
                                Mathf.DegToRad(cameraRotations[cameraPositionIndex]),
                                camera.Rotation.Y,
                                camera.Rotation.Z
                        );
        }
}
