using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MonoMod;
using UnityEngine;

public class patch_FloorStartEvent : FloorStartEvent
{
        public extern void orig_Execute();

        [MonoModForceCall]
        public void Execute()
        {
                orig_Execute();
                int floor = this.app.model.characterSheet.currentFloor;
                GameObject gameObject = new GameObject();
                RoomDataToCSVApplication roomDataToCsvApplication = gameObject.AddComponent<RoomDataToCSVApplication>();
                roomDataToCsvApplication.model = gameObject.AddComponent<RoomDataModel>();
                roomDataToCsvApplication.model.importFileName = "layouts_floor_" + floor.ToString() + ".dat";
                roomDataToCsvApplication.model.exportFileName = "layouts_floor_" + floor.ToString() + ".csv";
                roomDataToCsvApplication.model.whatToDo = RoomDataModel.DataState.ExportCSV;
                RoomDataController roomDataController = gameObject.AddComponent<RoomDataController>();
                Console.WriteLine("[SpiderButt] Floor files dumped.");
        }

}
