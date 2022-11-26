using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    [Serializable]
    public class Pool
    {
        public string Key;
        public GameObject GameObjectPrf;
        public int Size;
    }
    
    #region Singleton

    private static ObjectPoolManager _singleton;
    public static ObjectPoolManager Singleton => _singleton;

    #endregion

    private Dictionary<string, Queue<GameObject>> _poolsDictionary;
    [SerializeField] private Pool[] pools;


    private void Awake()
    {
        _singleton = this;
        _poolsDictionary = new Dictionary<string, Queue<GameObject>>();
        
        Transform poolsParent = new GameObject("Pools parent").transform;
        foreach (var pool in pools)
        {
            Transform poolParent = new GameObject($"{pool.Key} pool").transform;
            poolParent.SetParent(poolsParent);
            var poolQueue = new Queue<GameObject>();
            _poolsDictionary.Add(pool.Key, poolQueue);

            for (int i = 0; i < pool.Size; i++)
            {
                GameObject gameObject = Instantiate(pool.GameObjectPrf, poolParent);
                gameObject.transform.SetParent(poolParent);
                gameObject.SetActive(false);
                poolQueue.Enqueue(gameObject);
            }
        }
    }

    public GameObject SpawnFromPool(string key, Vector3 position, Quaternion rotation)
    {
        _poolsDictionary.TryGetValue(key, out var poolQueue);
        if (poolQueue == null)
            throw new ArgumentException($"{nameof(key)} doesn't exist in dictionary");

        GameObject pooledGO = poolQueue.Dequeue();
        pooledGO.SetActive(true);
        pooledGO.transform.position = position;
        pooledGO.transform.rotation = rotation;
        poolQueue.Enqueue(pooledGO);

        IPooledObject pooledObject = pooledGO.GetComponent<IPooledObject>();
        pooledObject.OnSpawned();

        return pooledGO;
    }
}