using UnityEngine;
using System.Collections.Generic;
using System;

namespace MapBuilder
{
    [Serializable]
    public class Map : MonoBehaviour
    {
        [SerializeField] private List<MapPiece> _pieces;
        [SerializeField] private float _gridUnitSize;

        public Map(float newGridUnitSize)
        {
            _gridUnitSize = newGridUnitSize;
        }

        public void Instantiate()
        {
            foreach(MapPiece piece in _pieces)
            {
                piece.Instantiate(_gridUnitSize);
            }
        }
    }
}
