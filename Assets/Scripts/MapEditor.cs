using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace MapBuilder
{
    public class MapEditor : MonoBehaviour
    {
        private static MapEditor _instance;
        public static MapEditor Instance { get { return _instance; } }

        private List<string> keys = new List<string> {
            "wall",
            "ceiling",
            "floor"
        };

        private Dictionary<string, MapPiece> mapPieceDictionary;
        private Dictionary<string, AsyncOperationHandle<GameObject>> operationDictionary;
        public UnityEvent Ready;

        private bool _assetsLoaded = false;
        public bool assetsLoaded { get { return _assetsLoaded; } }

        void Awake()
        {
            _instance = this;
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Ready.AddListener(OnAssetsReady);
        }

        private void OnAssetsReady()
        {
            _assetsLoaded = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (_assetsLoaded)
            {

            }
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

        private void OnDestroy()
        {
            foreach (var item in operationDictionary) {
                Addressables.Release(item.Value);
            }
        }
    }
}
