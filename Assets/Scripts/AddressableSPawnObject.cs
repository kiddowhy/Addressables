using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;

[System.Serializable]
public class AssetReferenceAudioClip : AssetReferenceT<AudioClip> 
{
    public AssetReferenceAudioClip(string guid) : base(guid)
    {

    }
}
public class AddressableSPawnObject : MonoBehaviour
{
    [SerializeField] private AssetReference assetReference;
    [SerializeField] private AssetReferenceGameObject assetReferenceGameObject;
    [SerializeField] private AssetReferenceAudioClip audioClip;
    // Start is called before the first frame update

    private GameObject spawnedGO;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.T))
        {
            //Addressables.LoadAssetAsync<GameObject>("Assets/Prefab/Sphere.prefab").Completed +=  //assestLabelReference instead of string

            assetReferenceGameObject.InstantiateAsync().Completed += (asyncOperation) => spawnedGO = asyncOperation.Result;

            

            /*
             * assetReference.LoadAssetAsync<GameObject>().Completed +=
                (asyncOperationHandle) =>
                {
                    if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                    {
                        Instantiate(asyncOperationHandle.Result);
                        Debug.Log("loaded addressables");
                    }
                    else
                    {
                        Debug.Log("failed addressables");
                    }
                };
            */
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            assetReferenceGameObject.ReleaseInstance(spawnedGO);
        }

    }

    private void AddressableSPawnObject_Completed(AsyncOperationHandle<GameObject> obj)
    {
        throw new System.NotImplementedException();
    }
}
