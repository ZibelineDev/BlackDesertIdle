using Godot;
using System;

public partial class Worker : Resource
{
        private static Random random = new Random();

        public string name = "Worker Debug";

        public byte workSpeed = 10;

        public static Worker GenerateRandomWorker()
        {
                Worker worker = new Worker();

                worker.name = "Randomised Worker";

                worker.workSpeed = (byte)random.Next(9, 15);

                Logger.Log($"Worker created (Work speed : {worker.workSpeed})");

                return worker;
        }
}
