using UnityEngine;

namespace MapBuilder
{
    public class EditorPiecePreview : MonoBehaviour
    {
        MapPiece piece;
        GameObject piecePrefab;
        GameObject pieceObject;
        bool pieceInstantiated = false;

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
                pieceObject.transform.position = transform.position + (10f * cameraScript.playerCamera.transform.forward);
            }
        }
    }
}
