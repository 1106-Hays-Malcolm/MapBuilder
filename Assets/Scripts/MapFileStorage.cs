using UnityEngine;
using System.IO;

namespace MapBuilder
{
    public class MapFileStorage
    {
        private string mapStoragePath = "Assets/Map/";

        public void WriteMapToFile(Map map, string fileName)
        {
            string json = JsonUtility.ToJson(map, prettyPrint:true);
            StreamWriter fileWriter = new StreamWriter(mapStoragePath + fileName, append:false);

            fileWriter.Write(json);
            fileWriter.Close();
        }

        public Map ReadMapFromFile(string fileName)
        {
            StreamReader fileReader = new StreamReader(mapStoragePath + fileName);
            string json = fileReader.ReadToEnd();
            fileReader.Close();

            return JsonUtility.FromJson<Map>(json);
        }
    }
}
