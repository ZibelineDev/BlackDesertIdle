using Godot;
using System;

public partial class Worker : Resource
{
        private static Random random = new Random();

        [Export] public string name = "Worker Debug";

        [Export] public byte workSpeed = 10;
        [Export] public string assignedProductionSite = null;
        //↓ Placeholder property for future content. ↓
        [Export] public string residenceNodeKey = "node_debug";

        public static Worker GenerateRandomWorker()
        {
                Worker worker = new Worker();

                worker.name = "Randomised Worker";

                worker.workSpeed = (byte)random.Next(9, 15);

                Logger.Log($"Worker created (Work speed : {worker.workSpeed})");

                return worker;
        }
}
