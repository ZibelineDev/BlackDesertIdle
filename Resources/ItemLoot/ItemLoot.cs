using Godot;
using System;

[GlobalClass]
public partial class ItemLoot : Resource
{
        private static Random random = new Random();

        public Item item = new Item();
        public float rate = 1.0f;
        public byte minQuantity = 1;
        public byte maxQuantity = 1;

        public byte Roll()
        {
                if (RollSuccessful())
                {
                        return RollQuantity();
                }

                return 0;
        }

        private bool RollSuccessful()
        {
                if (rate >= 1.0f)
                {
                        return true;
                }

                return rate >= random.NextSingle();
        }

        private byte RollQuantity()
        {
                return (byte) random.Next(minQuantity, maxQuantity + 1);
        }
}
