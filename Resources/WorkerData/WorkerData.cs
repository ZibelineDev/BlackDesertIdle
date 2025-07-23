using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class WorkerData : Resource
{
        [Export] public Godot.Collections.Dictionary<string, Array<Worker>> workers = new Godot.Collections.Dictionary<string, Array<Worker>>();

        public WorkerData()
        {
                workers["node_debug"] = new Array<Worker>();
        }

        public void AddWorker(Worker worker)
        {
                workers["node_debug"].Add(worker);
        }

        public List<Worker> GetIdleWorkers()
        {
                List<Worker> workers = new List<Worker>();

                foreach (Array<Worker> workerList in this.workers.Values)
                {
                        foreach(Worker worker in workerList)
                        {
                                if (worker.assignedProductionSite == null)
                                {
                                        workers.Add(worker);
                                }
                        }
                }

                return workers;
        }
}
