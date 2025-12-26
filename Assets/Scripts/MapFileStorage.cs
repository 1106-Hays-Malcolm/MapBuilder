using UnityEngine;
using System.IO;

namespace MapBuilder
{
    public class MapFileStorage : MonoBehaviour
    {
        private string mapStoragePath = "Assets/Map/";

        public void WriteMapToFile(Map map, string fileName)
        {
            string json = JsonUtility.ToJson(map);
            StreamWriter fileWriter = new StreamWriter(mapStoragePath + fileName, append:false);

            fileWriter.Write(json);
        }

        public Map ReadMapFromFile(string fileName)
        {
            StreamReader fileReader = new StreamReader(mapStoragePath + fileName);
            string json = fileReader.ReadToEnd();

            return JsonUtility.FromJson<Map>(json);
        }
    }
}
