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
            MapPiece mapPieceCopy = new MapPiece(newMapPiece);
            _pieces.Add(mapPieceCopy);
        }

        public void DeleteMapPieceByLocation(Vector3Int location)
        {
            foreach(MapPiece mapPiece in _pieces)
            {
                if (mapPiece.location == location)
                {
                    _pieces.Remove(mapPiece);
                }
            }
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
