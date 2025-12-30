using UnityEngine;

namespace MapBuilder
{
    public class EditorPiecePreview : MonoBehaviour
    {
        MapPiece piece;
        GameObject piecePrefab;
        GameObject pieceObject;
        bool pieceInstantiated = false;

        private float gridUnitSize = 6.4f;

        [SerializeField] private CreativePlayerCamera cameraScript;
        
        void Awake()
        {
            cameraScript = GetComponentInChildren<CreativePlayerCamera>();
        }

        void LateUpdate()
        {
            if (!MapEditor.Instance.assetsLoaded)
                return;

            if (!pieceInstantiated)
            {
                piecePrefab = MapEditor.Instance.mapPiecePrefabs["wall"];
                pieceObject = Instantiate(piecePrefab);
                pieceInstantiated = true;
            }

            if (pieceInstantiated)
            {
                Vector3 targetPosition = transform.position + (10f * cameraScript.playerCamera.transform.forward);
                Vector3Int newGridPosition = new Vector3Int((int) (targetPosition.x / gridUnitSize), (int) (targetPosition.y / gridUnitSize), (int) (targetPosition.z / gridUnitSize));
                pieceObject.transform.position = new Vector3(newGridPosition.x * gridUnitSize, newGridPosition.y * gridUnitSize, newGridPosition.z * gridUnitSize);
            }
        }
    }
}
