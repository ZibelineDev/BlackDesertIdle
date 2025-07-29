using Godot;
using System;

namespace MapNodeUiGroup
{
        public partial class PurchasePanel : TabContainer
        {
                private Label purchaseLabel;
                private Label sellLabel;

                public override void _Ready()
                {
                        purchaseLabel = GetNode<Label>("%PurchaseLabel");
                        sellLabel = GetNode<Label>("%SellLabel");
                }

                public void SetToOwned(byte cost = 0)
                {
                        sellLabel.Text = $"Return for : {cost} Influence";
                        CurrentTab = 1;
                }

                public void SetToNotOwned(byte cost = 0)
                {
                        purchaseLabel.Text = $"Invest for : {cost} Influence";
                        CurrentTab = 0;
                }
        }
}

