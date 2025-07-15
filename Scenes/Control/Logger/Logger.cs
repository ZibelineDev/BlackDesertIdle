using Godot;

public partial class Logger : PanelContainer
{
        public static Logger Instance { get; private set; }

        private VBoxContainer container;

        public override void _Ready()
        {
                Instance = this;

                container = GetNode<VBoxContainer>("%VBoxContainer");
        }

        public static void Log(string message)
        {
                Label label = new Label();

                label.Text = message;

                Instance.container.AddChild(label);
        }
}
