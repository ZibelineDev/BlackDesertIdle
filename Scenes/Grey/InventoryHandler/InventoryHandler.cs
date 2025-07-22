using Godot;
using System;
using System.Collections.Generic;

public partial class InventoryHandler : Node
{
        public static InventoryHandler Instance { get; private set; }

        private Inventory inventory = new Inventory();

        public event Action inventoryUpdated;

        public override void _Ready()
        {
                if (Instance != null)
                {
                        GD.PrintErr("New instance of a Singleton detected.");
                }

                Instance = this;
        }

        public static void AddItem(Item item, int quantity)
        {
                Instance.inventory.AddItem(item, quantity);
                Instance.inventoryUpdated?.Invoke();
        }

        public static int GetInventorySize()
        {
                return Instance.inventory.items.Count;
        }

        public static ItemStack GetItemStack(int index)
        {
                ItemStack itemStack = null;

                if (index >= Instance.inventory.items.Count)
                {
                        return itemStack;
                }

                itemStack = Instance.inventory.items[index];

                return itemStack;
        }
}
