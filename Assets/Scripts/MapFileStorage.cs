using UnityEngine;
using System.IO;

namespace MapBuilder
{
    public class MapFileStorage
    {
        private string mapStoragePath = "Assets/Map/";

        private System.Diagnostics.Stopwatch loadStopwatch;
        private System.Diagnostics.Stopwatch saveStopwatch;

        public void WriteMapToFile(Map map, string fileName)
        {
            saveStopwatch = System.Diagnostics.Stopwatch.StartNew();

            string json = JsonUtility.ToJson(map, prettyPrint:true);
            StreamWriter fileWriter = new StreamWriter(mapStoragePath + fileName, append:false);

            fileWriter.Write(json);
            fileWriter.Close();

            saveStopwatch.Stop();
            Debug.Log($"Map save time: {saveStopwatch.ElapsedMilliseconds}ms");
        }

        public Map ReadMapFromFile(string fileName)
        {
            loadStopwatch = System.Diagnostics.Stopwatch.StartNew();

            StreamReader fileReader = new StreamReader(mapStoragePath + fileName);
            string json = fileReader.ReadToEnd();
            fileReader.Close();

            loadStopwatch.Stop();
            Debug.Log($"Map file load time: {loadStopwatch.ElapsedMilliseconds}ms");

            Map mapFromFile = JsonUtility.FromJson<Map>(json);
            return mapFromFile;
        }
    }
}
