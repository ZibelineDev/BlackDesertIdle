using Godot;
using System;

public partial class InventoryItemUi : PanelContainer
{
        private static string scenePath = "uid://c173ll7mxamai";

        public static InventoryItemUi Create(int index)
        {
                InventoryItemUi node = ResourceLoader.Load<PackedScene>(scenePath).Instantiate<InventoryItemUi>();

                node.index = index;

                return node;
        }

        private TextureRect textureRect;
        private Label quantityLabel;
        private PanelContainer quantityPanel;

        public int index = -1;

        public override void _Ready()
        {
                if (index == -1)
                {
                        GD.PrintErr($"Inventory Item Index not set : {this}");
                }

                textureRect = GetNode<TextureRect>("%TextureRect");
                quantityLabel = GetNode<Label>("%QuantityLabel");
                quantityPanel = GetNode<PanelContainer>("%QuantityPanel");

                UpdateItem(null);
        }

        public void UpdateItem(ItemStack itemStack)
        {
                if (itemStack == null)
                {
                        Visible = false;
                        return;
                }

                if (itemStack.quantity == 0)
                {
                        Visible = false;
                        return;
                }

                Visible = true;
                textureRect.Texture = ResourceLoader.Load<Texture2D>(itemStack.item.texturePath);

                if (itemStack.quantity > 1)
                {
                        quantityLabel.Text = itemStack.quantity.ToString();
                        quantityPanel.Visible = true;
                }
                else
                {
                        quantityPanel.Visible = false;
                }
        }
}
