using UnityEngine;
using System;

namespace MapBuilder
{
    [Serializable]
    public class MapPiece
    {
        [SerializeField] private Vector2Int location;
        [SerializeField] private Piece piece;

        public MapPiece(Vector2Int newLocation, Piece newPiece)
        {
            location = newLocation;
            piece = newPiece;
        }

        public void Instantiate(float gridUnitSize)
        {
            
        }
    }
}
