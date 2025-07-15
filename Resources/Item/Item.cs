using Godot;

[GlobalClass]
public partial class Item : Resource
{
        public string key = "item_debug";

        public string name = "Item Debug";
        public string texturePath = "uid://c656cfpwfjb8o";

        public static Item GetWheat()
        {
                Item wheat = new Item();

                wheat.key = "item_wheat";

                wheat.name = "Wheat";
                wheat.texturePath = "uid://xtiu60cqf6ly";

                return wheat;
        }
}
