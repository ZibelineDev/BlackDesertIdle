using Godot;
using System;
using System.Collections.Generic;

public partial class WorkersHandler : Node
{
        public static WorkersHandler Instance { get; private set; }

        private WorkerData workerData = new WorkerData();
        private Worker lastWorkerCreated;

        public event Action workerCreated;
        public event Action workerAssigned;

        public override void _Ready()
        {
                if (Instance != null)
                {
                        GD.PrintErr("New instance of a Singleton detected.");
                }

                Instance = this;
        }

        public void AddWorker(Worker worker)
        {
                workerData.AddWorker(worker);
                lastWorkerCreated = worker;
                workerCreated?.Invoke();
        }

        public static void AssignWorker(ProductionSite.Enum productionSiteEnum, Worker worker)
        {
                worker.assignedProductionSite = ProductionSitesHandler.GetProductionSiteState(productionSiteEnum).productionSite.key;
                ProductionSitesHandler.AssignWorker(productionSiteEnum, worker);
                Instance.workerAssigned?.Invoke();
        }

        public static void DebugCreateRandomWorker()
        {
                Worker worker = Worker.GenerateRandomWorker();
                Instance.AddWorker(worker);
        }

        public static Worker GetLastWorkerCreated()
        {
                return Instance.lastWorkerCreated;
        }

        public static List<Worker> GetIdleWorkers()
        {
                return Instance.workerData.GetIdleWorkers();
        }
}
