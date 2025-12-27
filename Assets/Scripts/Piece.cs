using UnityEngine;
using System.Collections.Generic;
using System;

namespace MapBuilder
{
    [Serializable]
    public class Piece
    {
        [SerializeField] private string _prefabName;
        [SerializeField] private List<Vector2Int> _occupiedSpaces;

        public Piece(string newPrefabName, List<Vector2Int> newOccupiedSpaces)
        {
            _prefabName = newPrefabName;
            _occupiedSpaces = newOccupiedSpaces;
        }
    }
}
