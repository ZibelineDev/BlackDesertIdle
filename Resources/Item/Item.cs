using Godot;

[GlobalClass]
public partial class Item : Resource
{
        public string key = "item_debug";

        public string name = "Item Debug";
        public string texturePath = "uid://djkr3xlnqf7x8";

        public static Item GetWheat()
        {
                Item wheat = new Item();

                wheat.key = "item_wheat";

                wheat.name = "Wheat";
                wheat.texturePath = "uid://xtiu60cqf6ly";

                return wheat;
        }

        public static Item GetPotato()
        {
                Item item = new Item();

                item.key = "item_potato";

                item.name = "Potato";
                item.texturePath = "uid://djkr3xlnqf7x8";

                return item;
        }
}
