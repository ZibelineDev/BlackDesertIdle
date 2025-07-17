using Godot;
using System.Collections.Generic;
using System.Text.RegularExpressions;

[GlobalClass]
public partial class ProductionSite : Resource
{
        public string key = "production_site_debug";

        public string name = "Production Site Debug";

        public int workload = 10;
        public List<ItemLoot> output = new List<ItemLoot>() { new ItemLoot() };

        public enum Enum
        {
                WheatFarm,
                PotatoFarm,
        }

        public static ProductionSite Load(Enum enumKey)
        {
                switch (enumKey)
                {
                        case Enum.WheatFarm:
                                return GetWheatFarm();
                        case Enum.PotatoFarm:
                                return GetPotatoFarm();
                        default:
                                return new ProductionSite();
                }
        }

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
        
        public static ProductionSite GetPotatoFarm()
        {
                ProductionSite productionSite = new ProductionSite();

                productionSite.key = "production_site_potato_farm";

                productionSite.name = "Potato Farm";

                productionSite.workload = 60;

                ItemLoot potatoLoot = new ItemLoot();
                potatoLoot.item = Item.GetPotato();
                potatoLoot.minQuantity = 2;
                potatoLoot.maxQuantity = 5;

                ItemLoot critPotatoLoot = new ItemLoot();
                critPotatoLoot.item = Item.GetPotato();
                critPotatoLoot.rate = 0.1f;
                critPotatoLoot.minQuantity = 10;
                critPotatoLoot .maxQuantity = 15;

                productionSite.output = new List<ItemLoot> { potatoLoot, critPotatoLoot };

                return productionSite;
        }
}
