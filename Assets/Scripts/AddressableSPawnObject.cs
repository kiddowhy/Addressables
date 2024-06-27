using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;

public class AddressableSPawnObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.T))
        {
            AsyncOperationHandle<GameObject> asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>("Assets/Prefab/Sphere.prefab");
            asyncOperationHandle.Completed += AsyncOperationHandle_Completed;
        }
        
    }

    private void AsyncOperationHandle_Completed(AsyncOperationHandle<GameObject> asyncOperationHandle)
    {
        if(asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(asyncOperationHandle.Result);
            Debug.Log("loaded addressables");
        }
        else
        {
            Debug.Log("failed addressables");
        }
    }
}
