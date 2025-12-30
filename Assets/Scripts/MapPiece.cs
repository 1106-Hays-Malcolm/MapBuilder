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

        public Vector3Int location { get => _location; set => _location = value; }
        public uint orientation { get => _orientation; set => _orientation = value % 4; }
        public Piece piece { get => _piece; set => _piece = value; }

        public MapPiece(Vector3Int newLocation, Piece newPiece, uint newOrientation)
        {
            _location = newLocation;
            _piece = newPiece;
            _orientation = newOrientation;
        }

        public MapPiece(MapPiece otherPiece)
        {
            _location = new Vector3Int(otherPiece.location.x, otherPiece.location.y, otherPiece.location.z);
            _piece = otherPiece.piece;
            _orientation = otherPiece.orientation;
        }

        public MapPiece()
        {
            _location = new Vector3Int();
            _orientation = 0;
            _piece = new Piece();
        }
    }
}
