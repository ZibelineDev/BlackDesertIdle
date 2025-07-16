using Godot;

public partial class Logger : PanelContainer
{
        public static Logger Instance { get; private set; }

        private VBoxContainer container;
        private ScrollContainer scrollContainer;

        private ScrollBar scrollBar;
        private bool scrollRequested;

        public override void _Ready()
        {
                Instance = this;

                container = GetNode<VBoxContainer>("%VBoxContainer");
                scrollContainer = GetNode<ScrollContainer>("%ScrollContainer");

                scrollBar = scrollContainer.GetVScrollBar();
        }

        public override void _Process(double delta)
        {
                if (scrollRequested)
                {
                        UpdateScrollValue();
                }
        }

        public static void Log(string message)
        {
                Label label = new Label();

                label.Text = message;

                Instance.container.AddChild(label);
                Instance.scrollRequested = true;
                Instance.SetProcess(true);
        }

        public void UpdateScrollValue()
        {
                scrollContainer.ScrollVertical = (int)scrollBar.MaxValue;
                scrollRequested = false;
                SetProcess(false);
        }
}
