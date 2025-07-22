using Godot;
using System;

public partial class InventoryUi : PanelContainer
{
        private GridContainer gridContainer;

        public override void _Ready()
        {
                gridContainer = GetNode<GridContainer>("%GridContainer");

                CreateInventoryItem(0);

                InventoryHandler.Instance.inventoryUpdated += OnInventoryUpdated;
        }

        public override void _ExitTree()
        {
                InventoryHandler.Instance.inventoryUpdated -= OnInventoryUpdated;
        }

        private void OnInventoryUpdated()
        {
                CheckGridContainerChildren();
                UpdateInventoryItems();
        }

        private void CheckGridContainerChildren()
        {
                int childCount = gridContainer.GetChildCount();
                int inventoryCount = InventoryHandler.GetInventorySize();

                if (childCount < inventoryCount)
                {
                        int difference = inventoryCount - childCount;
                        int startingIndex = childCount - 1;
                        int finalIndex = startingIndex + difference - 1;

                        for (int index = startingIndex; index < finalIndex + 1 ; index += 1)
                        {
                                CreateInventoryItem(index);
                        }
                }
        }

        private void CreateInventoryItem(int index)
        {
                InventoryItemUi node = InventoryItemUi.Create(index);
                gridContainer.AddChild(node);
        }

        private void UpdateInventoryItems()
        {
                int inventorySize = InventoryHandler.GetInventorySize();

                for (int index = 0;  index < inventorySize; index += 1)
                {
                        gridContainer.GetChild<InventoryItemUi>(index).UpdateItem(InventoryHandler.GetItemStack(index));
                }
        }
}
