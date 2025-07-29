using Godot;
using System;

public partial class Data : Node
{
        public static Data Instance {  get; private set; }

        public DataResource resource;

        public override void _Ready()
        {
                if (Instance != null)
                {
                        GD.PrintErr("DataNode instance already set.");
                }

                Instance = this;

                resource = DataResource.CreateNewSave();
        }
}
