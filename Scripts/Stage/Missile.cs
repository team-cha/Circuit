using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolSystem;

public class Missile : MonoBehaviour
{
    protected float speed;
    protected float shootDelay;

    public string poolName;
    List<GameObject> gameObjList = new List<GameObject>();

    public GameObject CreateFromPoolAction(Vector3 position, Quaternion rotation)
    {
        GameObject gameObject = PoolManager.instance.GetObjectFromPool(poolName, position, rotation);
        if (gameObject)
        {
            gameObjList.Add(gameObject);
        }

        return gameObject;
    }

    public void ReturnToPoolAction(GameObject gameObject)
    {
        PoolManager.instance.ReturnObjectToPool(gameObject);
    }
}
