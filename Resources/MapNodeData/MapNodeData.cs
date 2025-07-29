using Godot;
using System;

public partial class MapNodeData : Resource
{
        [Export] public MapNode.Enum mapNodeEnum;
        [Export] public bool isPurchased = false;

        public MapNodeData(MapNode.Enum mapNodeEnum)
        {
                this.mapNodeEnum = mapNodeEnum;
        }
}
