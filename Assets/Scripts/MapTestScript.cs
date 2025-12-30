using UnityEngine;
using MapBuilder;
using System.Collections.Generic;

public class MapTestScript : MonoBehaviour
{
    void Awake()
    {
        // Vector3Int occupiedSpace1 = new Vector3Int(0, 0, 0);
        // List<Vector3Int> occupiedSpaces = new List<Vector3Int>();
        // occupiedSpaces.Add(occupiedSpace1);

        // Piece testPiece = new Piece("floor", occupiedSpaces);
        // MapPiece testMapPiece1 = new MapPiece(new Vector3Int(0, 0, 0), testPiece, 0);
        // MapPiece testMapPiece2 = new MapPiece(new Vector3Int(0, 0, 1), testPiece, 0);
        // 
        // List<MapPiece> testMapPieces = new List<MapPiece>();
        // testMapPieces.Add(testMapPiece1);
        // testMapPieces.Add(testMapPiece2);

        // Map testMap = new Map(6.4f, testMapPieces);

        // MapFileStorage mapFileStorage = new MapFileStorage();
        // mapFileStorage.WriteMapToFile(testMap, "TestMap");

        // Map mapFromFile = mapFileStorage.ReadMapFromFile("TestMap");

        // MapInitializer mapInitializer = GetComponent<MapInitializer>();
        // mapInitializer.Initialize(mapFromFile, editMode:true);
        
        MapEditor mapEditor = FindFirstObjectByType<MapEditor>();
        mapEditor.LoadMap("TestMap");
    }
}
