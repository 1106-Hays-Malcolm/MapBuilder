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

            // GetPlaceGridPosition(100f, cameraScript.playerCamera.transform.forward, cameraScript.playerCamera.transform.position);

            Vector3 floatingTargetPosition = transform.position + (reachDistance * cameraScript.playerCamera.transform.forward);
            // Vector3Int newGridPosition = GetGridPositionFromWorldPosition(floatingTargetPosition);
            Vector3Int newGridPosition = GetPlaceGridPosition(100f, reachDistance, cameraScript.playerCamera.transform.forward, cameraScript.playerCamera.transform.position);

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

        private Vector3Int GetPlaceGridPosition(float maxHitDisance, float maxFloatingDistance, Vector3 forward, Vector3 origin)
        {
            RaycastHit hit;
            Vector3Int normal;
            Vector3Int gridPositionHit;

            if (Physics.Raycast(origin, forward, out hit, maxHitDisance))
            {
                normal = new Vector3Int(Mathf.RoundToInt(hit.normal.x), Mathf.RoundToInt(hit.normal.y), Mathf.RoundToInt(hit.normal.z));
                Vector3 positionHit = hit.collider.transform.position;
                gridPositionHit = GetGridPositionFromWorldPosition(positionHit);
                gridPositionHit.y--;
                return gridPositionHit + normal;
            }
            else
            {
                return GetGridPositionFromWorldPosition(origin + (maxFloatingDistance * forward));
            }
        }

        private Vector3Int GetGridPositionFromWorldPosition(Vector3 position)
        {
            return new Vector3Int(
                    Mathf.RoundToInt(position.x / gridUnitSize),
                    Mathf.RoundToInt(position.y / gridUnitSize),
                    Mathf.RoundToInt(position.z / gridUnitSize));
        }
    }
}
