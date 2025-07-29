using Godot;
using Godot.Collections;
using System;

public partial class DataResource : Resource
{
        [Export] public Dictionary<MapNode.Enum, MapNodeData> mapNodeData;
        [Export] public Array<ProductionSiteState> productionSitesStates;
        [Export] public Currencies currencies;

        public static DataResource CreateNewSave()
        {
                DataResource data = new DataResource();

                data.currencies = new Currencies();
                InitialiseMapNodeData(data);

                return data;
        }

        private static void InitialiseMapNodeData(DataResource data)
        {
                data.mapNodeData = new Dictionary<MapNode.Enum, MapNodeData>();

                foreach (MapNode.Enum mapNodeEnum in Enum.GetValues<MapNode.Enum>())
                {
                        data.mapNodeData[mapNodeEnum] = new MapNodeData(mapNodeEnum);
                }
        }
}
