using UnityEngine;
using MapBuilder;
using System.Collections.Generic;

public class MapTestScript : MonoBehaviour
{
    void Awake()
    {
        Vector2Int occupiedSpace1 = new Vector2Int(0, 0);
        Vector2Int occupiedSpace2 = new Vector2Int(1, 0);
        List<Vector2Int> occupiedSpaces = new List<Vector2Int>();
        occupiedSpaces.Add(occupiedSpace1);
        occupiedSpaces.Add(occupiedSpace2);

        Piece testPiece = new Piece("TestPrefabName", occupiedSpaces, 1);
        MapPiece testMapPiece1 = new MapPiece(new Vector2Int(0, 0), testPiece);
        MapPiece testMapPiece2 = new MapPiece(new Vector2Int(0, 1), testPiece);
        
        List<MapPiece> testMapPieces = new List<MapPiece>();
        testMapPieces.Add(testMapPiece1);
        testMapPieces.Add(testMapPiece2);

        Map testMap = new Map(5, testMapPieces);

        MapFileStorage mapFileStorage = new MapFileStorage();
        mapFileStorage.WriteMapToFile(testMap, "TestMap");
    }
}
