using Godot;
using Godot.Collections;
using System;

public partial class Inventory : Resource
{
        [Export] public Array<ItemStack> items = new Array<ItemStack>();

        public void AddItem(Item item, int quantity)
        {
                ItemStack itemStack = FindItemStack(item);

                if (itemStack != null)
                {
                        itemStack.AddToStack(quantity);
                }
                else
                {
                        items.Add(ItemStack.Create(item, quantity));
                }
        }

        private ItemStack FindItemStack(Item item)
        {
                ItemStack itemStack = null;

                foreach(ItemStack listItemStack in items)
                {
                        if (listItemStack != null)
                        {
                                if (listItemStack.item.key == item.key)
                                {
                                        itemStack = listItemStack;
                                        break;
                                }
                        }
                }

                return itemStack;
        }
}
