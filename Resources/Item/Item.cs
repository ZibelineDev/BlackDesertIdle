using Godot;

[GlobalClass]
public partial class Item : Resource
{
        public string key = "item_debug";

        public string name = "Item Debug";
        public string texturePath = "uid://djkr3xlnqf7x8";

        public enum Enum
        {
                Wheat,
                Potato,
        }

        public static Item Load(Enum itemEnum)
        {
                switch (itemEnum)
                {
                        case Enum.Wheat: return GetWheat();
                        case Enum.Potato: return GetPotato();
                        default: return new Item();
                }
        }

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
                item.texturePath = "uid://o807gky1pqkp";

                return item;
        }
}
