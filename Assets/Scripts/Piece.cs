using UnityEngine;
using System.Collections.Generic;
using System;

namespace MapBuilder
{
    [Serializable]
    public class Piece
    {
        [SerializeField] private string prefabName;
        [SerializeField] private List<Vector2Int> occupiedSpaces;
        [SerializeField] private int orientation;

        public Piece(string newPrefabName, List<Vector2Int> newOccupiedSpaces, int newOrientation)
        {
            prefabName = newPrefabName;
            occupiedSpaces = newOccupiedSpaces;
            orientation = newOrientation;
        }

        public void Instantiate()
        {
            // Instantiate based on _prefabName
        }
    }
}
