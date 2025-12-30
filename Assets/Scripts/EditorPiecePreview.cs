using UnityEngine;

namespace MapBuilder
{
    public class EditorPiecePreview : MonoBehaviour
    {
        MapPiece piece;
        GameObject piecePrefab;
        GameObject pieceObject;
        bool pieceInstantiated = false;

        [SerializeField] private float reachDistance = 10f;
        private float gridUnitSize = 6.4f;

        [SerializeField] private CreativePlayerCamera cameraScript;
        
        void Awake()
        {
            cameraScript = GetComponentInChildren<CreativePlayerCamera>();
        }

        void Update()
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
                Vector3 targetPosition = transform.position + (reachDistance * cameraScript.playerCamera.transform.forward);
                Vector3Int newGridPosition = new Vector3Int(
                        Mathf.RoundToInt(targetPosition.x / gridUnitSize),
                        Mathf.RoundToInt(targetPosition.y / gridUnitSize),
                        Mathf.RoundToInt(targetPosition.z / gridUnitSize));

                pieceObject.transform.position = new Vector3(newGridPosition.x * gridUnitSize, newGridPosition.y * gridUnitSize, newGridPosition.z * gridUnitSize);
            }
        }
    }
}
