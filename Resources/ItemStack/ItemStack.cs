using Godot;
using System;

public partial class ItemStack : Resource
{
        [Export] public Item item = new Item();
        [Export] public int quantity = 1;

        public static ItemStack Create(Item item, int quantity)
        {
                ItemStack itemStack = new ItemStack();

                itemStack.item = item;
                itemStack.quantity = quantity;

                return itemStack;
        }

        public void AddToStack(int quantity)
        {
                this.quantity += quantity;
        }

        public int RemoveFromStack(int quantity)
        {
                int leftover = 0;

                if (this.quantity > quantity)
                {
                        this.quantity -= quantity;
                }
                else
                {
                        leftover = quantity -= this.quantity;
                        this.quantity = 0;
                }

                return leftover;
        }
}
