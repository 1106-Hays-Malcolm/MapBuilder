using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace MapBuilder
{
    public class MapInitializer : MonoBehaviour
    {
        private Map map;

        private Dictionary<string, AsyncOperationHandle<GameObject>> operationDictionary;
        private List<string> keys;
        private Dictionary<string, MapPiece> mapPieceDictionary;
        public UnityEvent Ready;

        private bool _editMode = false;

        public void Initialize(Map newMap, bool editMode)
        {
            _editMode = editMode;
            map = newMap;
            keys = GetAllMapPrefabNames();
            Debug.Log($"Num keys: {keys.Count}");
            mapPieceDictionary = GetMapPieceDictionary();
            StartCoroutine(LoadAndAssociateResultWithKey(keys));
        }

        public void Initialize(Map newMap)
        {
            this.Initialize(newMap, false);
        }

        void Start()
        {
            Ready.AddListener(OnAssetsReady);
        }

        private void OnAssetsReady()
        {
            var op = Addressables.LoadAssetAsync<GameObject>("MapPieceCollider");
            GameObject mapPieceColliderPrefab = op.WaitForCompletion();

            foreach (var mapPiece in map.pieces)
            {
                Vector3 position = new Vector3(mapPiece.location.x * map.gridUnitSize, mapPiece.location.y * map.gridUnitSize, mapPiece.location.z * map.gridUnitSize);
                Quaternion rotation = new Quaternion();
                rotation.eulerAngles = new Vector3(0, mapPiece.orientation * 90, 0);

                GameObject newPiece = Instantiate(operationDictionary[mapPiece.piece.prefabName].Result, position, rotation);

                if (_editMode)
                {
                    GameObject mapPieceCollider = Instantiate(mapPieceColliderPrefab);
                    mapPieceCollider.transform.parent = newPiece.transform;

                    mapPieceCollider.transform.position = new Vector3(
                            newPiece.transform.position.x,
                            newPiece.transform.position.y + map.gridUnitSize / 2,
                            newPiece.transform.position.z);

                    mapPieceCollider.GetComponent<BoxCollider>().size = new Vector3(map.gridUnitSize, map.gridUnitSize, map.gridUnitSize);
                }
            }

            Addressables.Release(op);
        }
    

        // From: https://docs.unity3d.com/Packages/com.unity.addressables@1.19/manual/LoadingAddressableAssets.html#correlating-loaded-assets-to-their-keys
        IEnumerator LoadAndAssociateResultWithKey(IList<string> keys) {
            if (operationDictionary == null)
                operationDictionary = new Dictionary<string, AsyncOperationHandle<GameObject>>();

            AsyncOperationHandle<IList<IResourceLocation>> locations
                = Addressables.LoadResourceLocationsAsync(keys,
                    Addressables.MergeMode.Union, typeof(GameObject));

            yield return locations;

            var loadOps = new List<AsyncOperationHandle>(locations.Result.Count);

            foreach (IResourceLocation location in locations.Result) {
                AsyncOperationHandle<GameObject> handle =
                    Addressables.LoadAssetAsync<GameObject>(location);
                handle.Completed += obj => operationDictionary.Add(location.PrimaryKey, obj);
                loadOps.Add(handle);
            }

            yield return Addressables.ResourceManager.CreateGenericGroupOperation(loadOps, true);

            Ready.Invoke();
        }

        private List<string> GetAllMapPrefabNames()
        {
            List<string> listOfNames = new List<string>();

            foreach (MapPiece mapPiece in map.pieces)
            {
                listOfNames.Add(mapPiece.piece.prefabName);
            }

            return listOfNames;
        }

        private Dictionary<string, MapPiece> GetMapPieceDictionary()
        {
            Dictionary<string, MapPiece> mapPieceDictionary = new Dictionary<string, MapPiece>();

            foreach (MapPiece mapPiece in map.pieces)
            {
                mapPieceDictionary[mapPiece.piece.prefabName] = mapPiece;
            }

            return mapPieceDictionary;
        }
        private void OnDestroy()
        {
            foreach (var item in operationDictionary) {
                Addressables.Release(item.Value);
            }
        }
    }
}
