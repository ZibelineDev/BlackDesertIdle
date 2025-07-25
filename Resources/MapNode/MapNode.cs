using Godot;
using System.Collections.Generic;

[GlobalClass]
public partial class MapNode : Resource
{
        public Enum key = Enum.Debug;

        public string name = "Debug Node";

        public List<ProductionSite.Enum> productionSites = new List<ProductionSite.Enum>();
        
        // INSERT 
        // → Buildings

        public static Dictionary<Enum, MapNode> dictionary = new Dictionary<Enum, MapNode>();

        public enum Enum
        {
                Debug = -1,
                BartaliFarm,
                EmptyNode,
        }

        public static MapNode Load(Enum mapNodeEnum)
        {
                if (dictionary.ContainsKey(mapNodeEnum))
                {
                        return dictionary[mapNodeEnum];
                }

                return new MapNode();
        }

        public bool IsActive()
        {
                if (productionSites.Count == 0) { return false; }

                foreach (ProductionSite.Enum productionSiteEnum in productionSites)
                {
                        ProductionSiteState productionSiteState = ProductionSitesHandler.GetProductionSiteState(productionSiteEnum);
                        if (productionSiteState.assignedWorker != null) { return true; }
                }

                return false;
        }

        static MapNode()
        {
                dictionary[Enum.BartaliFarm] = GetBartaliFarm();
                dictionary[Enum.EmptyNode] = GetEmptyNode();
        }

        public static MapNode GetBartaliFarm()
        {
                MapNode bartaliFarm = new MapNode();

                bartaliFarm.key = Enum.BartaliFarm;

                bartaliFarm.name = "Bartali Farm";

                bartaliFarm.productionSites = new List<ProductionSite.Enum> { ProductionSite.Enum.WheatFarm, ProductionSite.Enum.PotatoFarm };

                return bartaliFarm;
        }

        private static MapNode GetEmptyNode()
        {
                MapNode mapNode = new MapNode();

                mapNode.key = Enum.EmptyNode;

                mapNode.name = "Empty Node";

                mapNode.productionSites = new List<ProductionSite.Enum> { };

                return mapNode;
        }
}
