using Godot;
using System;

public partial class Clock : Node
{
        public static Clock Instance { get; private set; }

        public event Action clockTick;

        private double clockProgress = 0.0;
        private const double cycleDuration = 5.0;

        public override void _Ready()
        {
                if (Instance != null)
                {
                        GD.PrintErr("New instance of a Singleton detected.");
                }

                Instance = this;
        }

        public override void _Process(double delta)
        {
                ProgressClock(delta);
        }

        private void ProgressClock(double delta)
        {
                clockProgress += delta;

                if (clockProgress >= cycleDuration)
                {
                        clockProgress -= cycleDuration;
                        clockTick?.Invoke();
                }
        }
}
