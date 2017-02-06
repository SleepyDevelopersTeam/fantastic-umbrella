using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAwake : MonoBehaviour
{
    public float Delay;

    private void Awake()
    {
        Destroy(this.gameObject, delay);
    }
}
