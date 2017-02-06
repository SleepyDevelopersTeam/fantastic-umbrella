using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Pool : MonoBehaviour
{
    public GameObject Prefab;
    public int MaxPoolSize;
    public bool InstantiateAtStartup;

    private GameObject[] pool;

    private void Start()
    {
        pool = new GameObject[MaxPoolSize];
        if (InstantiateAtStartup)
        {
            for (int i = 0; i < pool.Length; i++)
            {
                pool[i] = Instantiate(Prefab, this.transform, true);
                pool[i].SetActive(false);
            }
        }
    }

    public GameObject GetNew()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i] == null)
            {
                return pool[i] = Instantiate(Prefab, this.transform);
            }
            if (pool[i].activeSelf)
            {
                continue;
            }
            else
            {
                return pool[i];
            }
        }
        // no free objects left
        // TODO: mb free old objects?
        return null;
    }
}
