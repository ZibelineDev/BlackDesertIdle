using Godot;
using System.Collections.Generic;

[GlobalClass]
public partial class ProductionSite : Resource
{
        public string key = "production_site_debug";

        public string name = "Production Site Debug";

        public int workload = 10;
        public List<ItemLoot> output = new List<ItemLoot>() { new ItemLoot() };

        public static ProductionSite GetWheatFarm()
        {
                ProductionSite wheatFarm = new ProductionSite();

                wheatFarm.key = "production_site_wheat_farm";

                wheatFarm.name = "Wheat Farm";

                wheatFarm.workload = 30;

                ItemLoot wheatLoot = new ItemLoot();
                wheatLoot.item = Item.GetWheat();
                wheatLoot.minQuantity = 2;
                wheatLoot.maxQuantity = 5;

                ItemLoot critWheatLoot = new ItemLoot();
                critWheatLoot.item = Item.GetWheat();
                critWheatLoot.rate = 0.1f;
                critWheatLoot.minQuantity = 10;
                critWheatLoot.maxQuantity = 15;

                wheatFarm.output = new List<ItemLoot> { wheatLoot, critWheatLoot };

                return wheatFarm;
        }
}
