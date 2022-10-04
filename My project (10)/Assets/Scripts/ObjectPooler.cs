using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject preFab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    #region Singleton
    public static ObjectPooler instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectsPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.preFab);
                obj.SetActive(false);
                objectsPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectsPool);
        }
    }
    
    public GameObject SpawnFromPool (string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exsist.");
            return null;
        }
       
        GameObject gameObject = poolDictionary[tag].Dequeue();
        gameObject.SetActive(true);
        return gameObject;
    }
}
