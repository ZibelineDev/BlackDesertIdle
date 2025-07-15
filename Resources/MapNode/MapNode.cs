using Godot;
using System.Collections.Generic;

[GlobalClass]
public partial class MapNode : Resource
{
        public string key = "node_debug";

        public string name = "Debug Node";

        public List<ProductionSite> productionSites = new List<ProductionSite>() { new ProductionSite() };
        
        // INSERT 
        // → Buildings

        public static MapNode GetBartaliFarm()
        {
                MapNode bartaliFarm = new MapNode();

                bartaliFarm.key = "node_bartali_farm";

                bartaliFarm.name = "Bartali Farm";

                bartaliFarm.productionSites = new List<ProductionSite> { ProductionSite.GetWheatFarm() };

                return bartaliFarm;
        }
}
