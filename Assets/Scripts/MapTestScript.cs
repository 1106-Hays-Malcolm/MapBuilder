using UnityEngine;
using MapBuilder;
using System.Collections.Generic;

public class MapTestScript : MonoBehaviour
{
    void Awake()
    {
        Vector2Int occupiedSpace1 = new Vector2Int(0, 0);
        List<Vector2Int> occupiedSpaces = new List<Vector2Int>();
        occupiedSpaces.Add(occupiedSpace1);

        Piece testPiece = new Piece("Assets/Prefabs/floor.prefab", occupiedSpaces);
        MapPiece testMapPiece1 = new MapPiece(new Vector2Int(0, 0), testPiece, 0);
        MapPiece testMapPiece2 = new MapPiece(new Vector2Int(0, 1), testPiece, 0);
        
        List<MapPiece> testMapPieces = new List<MapPiece>();
        testMapPieces.Add(testMapPiece1);
        testMapPieces.Add(testMapPiece2);

        Map testMap = new Map(5, testMapPieces);

        MapFileStorage mapFileStorage = new MapFileStorage();
        mapFileStorage.WriteMapToFile(testMap, "TestMap");

        Map mapFromFile = mapFileStorage.ReadMapFromFile("TestMap");
    }
}
