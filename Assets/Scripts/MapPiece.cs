using UnityEngine;
using System;

namespace MapBuilder
{
    [Serializable]
    public class MapPiece
    {
        [SerializeField] private Vector3Int _location;
        [SerializeField] private uint _orientation;
        [SerializeField] private Piece _piece;

        public Vector3Int location { get { return _location; } }
        public uint orientation { get { return _orientation; } }
        public Piece piece { get { return _piece; } }

        public MapPiece(Vector3Int newLocation, Piece newPiece, uint newOrientation)
        {
            _location = newLocation;
            _piece = newPiece;
            _orientation = newOrientation;
        }
    }
}
