using UnityEngine;
using System.Collections.Generic;
using System;

namespace MapBuilder
{
    [Serializable]
    public class Map
    {
        [SerializeField] private float _gridUnitSize;
        [SerializeField] private List<MapPiece> _pieces;

        public float gridUnitSize { get => _gridUnitSize; }
        public List<MapPiece> pieces { get => _pieces; }

        public Map(float newGridUnitSize)
        {
            _gridUnitSize = newGridUnitSize;
        }

        public Map(float newGridUnitSize, List<MapPiece> newMapPieces)
        {
            _gridUnitSize = newGridUnitSize;
            _pieces = new List<MapPiece>();
            _pieces = newMapPieces;
        }
    }
}
