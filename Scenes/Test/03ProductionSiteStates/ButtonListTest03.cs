using Godot;

public partial class ButtonListTest03 : VBoxContainer
{
        public override void _Ready()
        {
                GetNode<Button>("EmptyNode").Pressed += OnEmptyNodePressed;
                GetNode<Button>("BartaliFarm").Pressed += OnBartaliFarmPressed;
        }

        private void OnEmptyNodePressed()
        {
                MapNodeUi.SetMapNode(MapNode.Enum.EmptyNode);
        }

        private void OnBartaliFarmPressed()
        {
                MapNodeUi.SetMapNode(MapNode.Enum.BartaliFarm);
        }
}
