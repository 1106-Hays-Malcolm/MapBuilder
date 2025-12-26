using UnityEngine;
using System.Collections.Generic;
using System;

namespace MapBuilder
{
    [Serializable]
    public class Piece
    {
        [SerializeField] private string _prefabName;
        [SerializeField] private List<Vector2Int> occupiedSpaces;
        [SerializeField] private int orientation;

        public void Instantiate()
        {
            // Instantiate based on _prefabName
        }
    }
}
