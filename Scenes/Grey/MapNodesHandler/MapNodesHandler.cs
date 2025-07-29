using Godot;
using System;

public partial class MapNodesHandler : Node
{
        public static MapNodesHandler Instance { get; private set; }

        public static event Action mapNodeOwnStatusChanged;

        public override void _Ready()
        {
                if (Instance != null ) { GD.PrintErr("MapNodesHandler instance duplicate."); }

                Instance = this;
        }

        public static bool GetOwnStatus(MapNode.Enum mapNodeEnum)
        {
                MapNodeData mapNodeData = Data.Instance.resource.mapNodeData[mapNodeEnum];

                return mapNodeData.isPurchased;
        }

        public static void InvestIn(MapNode.Enum mapNodeEnum)
        {
                bool isOwned = GetOwnStatus(mapNodeEnum);

                if (isOwned)
                {
                        GD.PrintErr("Trying to purchase a node, already owned.");
                }

                Data.Instance.resource.mapNodeData[mapNodeEnum].isPurchased = true;
                mapNodeOwnStatusChanged?.Invoke();
        }
        public static void ReturnInvestFrom(MapNode.Enum mapNodeEnum)
        {
                bool isOwned = GetOwnStatus(mapNodeEnum);

                if (!isOwned)
                {
                        GD.PrintErr("Trying to return a node, not owned.");
                }

                Data.Instance.resource.mapNodeData[mapNodeEnum].isPurchased = false;
                mapNodeOwnStatusChanged?.Invoke();
        }
}
