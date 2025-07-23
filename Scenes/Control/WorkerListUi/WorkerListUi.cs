using Godot;
using System;

public partial class WorkerListUi : PanelContainer
{
        private VBoxContainer listContainer;

        public override void _Ready()
        {
                listContainer = GetNode<VBoxContainer>("%ListContainer");

                GetNode<Button>("%CreateWorker").Pressed += OnCreateWorkerPressed;

                WorkersHandler.Instance.workerCreated += OnWorkerCreated;
                WorkersHandler.Instance.workerAssigned += OnWorkerAssigned;
        }

        public override void _ExitTree()
        {
                WorkersHandler.Instance.workerCreated -= OnWorkerCreated;
                WorkersHandler.Instance.workerAssigned -= OnWorkerAssigned;
        }

        private void OnCreateWorkerPressed()
        {
                WorkersHandler.DebugCreateRandomWorker();
        }

        private void OnWorkerCreated()
        {
                Worker worker = WorkersHandler.GetLastWorkerCreated();
                CreateWorkerUi(worker);
        }

        private void OnWorkerAssigned()
        {
                UpdateWorkers();
        }

        private void CreateWorkerUi(Worker worker)
        {
                WorkerUi node = WorkerUi.Create(worker);
                listContainer.AddChild(node);
        }

        private void UpdateWorkers()
        {
                foreach (Node node in listContainer.GetChildren())
                {
                        if (node is WorkerUi workerUi)
                        {
                                workerUi.UpdateNodes();
                        }
                }
        }
}
