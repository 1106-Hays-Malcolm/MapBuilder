using UnityEngine;
using System;

namespace MapBuilder
{
    [Serializable]
    public class MapPiece : MonoBehaviour
    {
        [SerializeField] private Vector2Int location;
        [SerializeField] private Piece piece;

        public void Instantiate(float gridUnitSize)
        {
            
        }
    }
}
