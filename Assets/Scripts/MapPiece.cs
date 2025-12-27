using UnityEngine;
using System;

namespace MapBuilder
{
    [Serializable]
    public class MapPiece
    {
        [SerializeField] private Vector2Int _location;
        [SerializeField] private uint _orientation;
        [SerializeField] private Piece _piece;

        public Vector2Int location { get { return _location; } }
        public uint orientation { get { return _orientation; } }
        public Piece piece { get { return _piece; } }

        public MapPiece(Vector2Int newLocation, Piece newPiece, uint newOrientation)
        {
            _location = newLocation;
            _piece = newPiece;
            _orientation = newOrientation;
        }
    }
}
