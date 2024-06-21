using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class ResourcesManager : SingleTon<ResourcesManager>
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Create(string path, Transform parent = null)
    {
        GameObject prefab = Resources.Load<GameObject>(path);

        if (prefab == null)
        {
            Debug.Log("Failed to load Prefab");

            return null;
        }
        
        return Instantiate(prefab, parent);
    }

    public void Release(GameObject prefab)
    {
        if(prefab == null)
        {
            return;
        }

        Destroy(prefab);
    }
}