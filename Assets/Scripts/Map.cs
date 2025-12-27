using UnityEngine;
using System.Collections.Generic;
using System;

namespace MapBuilder
{
    [Serializable]
    public class Map
    {
        [SerializeField] private float gridUnitSize;
        [SerializeField] private List<MapPiece> pieces;

        public Map(float newGridUnitSize)
        {
            gridUnitSize = newGridUnitSize;
        }

        public Map(float newGridUnitSize, List<MapPiece> newMapPieces)
        {
            gridUnitSize = newGridUnitSize;
            pieces = new List<MapPiece>();
            pieces = newMapPieces;
        }
    }
}
