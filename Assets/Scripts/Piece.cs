using UnityEngine;
using System.Collections.Generic;
using System;

namespace MapBuilder
{
    [Serializable]
    public class Piece
    {
        [SerializeField] private string _prefabName;
        [SerializeField] private List<Vector3Int> _occupiedSpaces;

        public string prefabName { get => _prefabName; }
        public List<Vector3Int> occupiedSpaces { get => _occupiedSpaces; }

        public Piece(string newPrefabName, List<Vector3Int> newOccupiedSpaces)
        {
            _prefabName = newPrefabName;
            _occupiedSpaces = newOccupiedSpaces;
        }

        public Piece(string newPrefabName)
        {
            _prefabName = newPrefabName;
            _occupiedSpaces = new List<Vector3Int> { new Vector3Int(0, 0, 0), };
        }

        public Piece()
        {
            _prefabName = "default";
            _occupiedSpaces = new List<Vector3Int> { new Vector3Int(0, 0, 0), };
        }
    }
}
