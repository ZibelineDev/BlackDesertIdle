using Godot;
using System.Collections.Generic;

[GlobalClass]
public partial class MapNode : Resource
{
        public string key = "node_debug";

        public string name = "Debug Node";

        public List<ProductionSite.Enum> productionSites = new List<ProductionSite.Enum>();
        
        // INSERT 
        // → Buildings

        public enum Enum
        {
                BartaliFarm,
                EmptyNode,
        }

        public static MapNode Load(Enum mapNodeEnum)
        {
                switch (mapNodeEnum)
                {
                        case Enum.BartaliFarm:
                                return GetBartaliFarm();
                        case Enum.EmptyNode:
                                return GetEmptyNode();
                        default:
                                return new MapNode();
                }
        }

        public static MapNode GetBartaliFarm()
        {
                MapNode bartaliFarm = new MapNode();

                bartaliFarm.key = "node_bartali_farm";

                bartaliFarm.name = "Bartali Farm";

                bartaliFarm.productionSites = new List<ProductionSite.Enum> { ProductionSite.Enum.WheatFarm, ProductionSite.Enum.PotatoFarm };

                return bartaliFarm;
        }

        private static MapNode GetEmptyNode()
        {
                MapNode mapNode = new MapNode();

                mapNode.key = "node_empty_node";

                mapNode.name = "Empty Node";

                mapNode.productionSites = new List<ProductionSite.Enum> { };

                return mapNode;
        }
}
