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
        private float gridUnitSize;

        [SerializeField] private CreativePlayerCamera cameraScript;
        
        private bool alreadyRotated = false;
        private bool alreadyPlaced = false;
        
        void Awake()
        {
            cameraScript = GetComponentInChildren<CreativePlayerCamera>();
        }

        void Start()
        {
            gridUnitSize = MapEditor.Instance.map.gridUnitSize;
        }

        void Update()
        {
            if (!MapEditor.Instance.assetsLoaded)
                return;

            if (!pieceInstantiated)
            {
                piecePrefab = MapEditor.Instance.mapPiecePrefabs["floor"];
                piece = new MapPiece(new Vector3Int(0, 0, 0), new Piece("floor"), 0);
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

                piece.location = newGridPosition;
                pieceObject.transform.position = new Vector3(newGridPosition.x * gridUnitSize, newGridPosition.y * gridUnitSize, newGridPosition.z * gridUnitSize);
            

                if (MapEditorInputManager.Instance.rotateAction.inProgress && alreadyRotated == false)
                {
                    alreadyRotated = true;
                    piece.orientation++;
                    Quaternion newRotation = new Quaternion();
                    newRotation.eulerAngles = new Vector3(0, piece.orientation * 90, 0);
                    pieceObject.transform.rotation = newRotation;

                }
                else if (!MapEditorInputManager.Instance.rotateAction.inProgress && alreadyRotated == true)
                {
                    alreadyRotated = false;
                }

                if (MapEditorInputManager.Instance.placeAction.inProgress && !alreadyPlaced)
                {
                    alreadyPlaced = true;
                    Debug.Log(piece.location);
                    MapEditor.Instance.map.AddMapPiece(piece);
                    Instantiate(pieceObject);
                }
                else if (!MapEditorInputManager.Instance.placeAction.inProgress && alreadyPlaced)
                {
                    alreadyPlaced = false;
                }
            }
        }
    }
}
