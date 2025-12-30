using UnityEngine;
using System.Collections.Generic;
using System;

namespace MapBuilder
{
    [Serializable]
    public class Map
    {
        [SerializeField] private Vector3 _rootWorldPosition;
        [SerializeField] private float _gridUnitSize;
        [SerializeField] private List<MapPiece> _pieces;

        public float gridUnitSize { get => _gridUnitSize; }
        public List<MapPiece> pieces { get => _pieces; }

        public void AddMapPiece(MapPiece newMapPiece)
        {
            _pieces.Add(newMapPiece);
        }

        public Map(float newGridUnitSize)
        {
            _gridUnitSize = newGridUnitSize;
        }

        public Map()
        {
            _gridUnitSize = 0f;
            _rootWorldPosition = new Vector3();
            _pieces = new List<MapPiece>();
        }

        public Map(float newGridUnitSize, List<MapPiece> newMapPieces)
        {
            _gridUnitSize = newGridUnitSize;
            _pieces = new List<MapPiece>();
            _pieces = newMapPieces;
        }
    }
}
