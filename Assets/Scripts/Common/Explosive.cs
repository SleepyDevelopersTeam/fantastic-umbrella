using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public GameObject Explosion;

    private void OnDestroy()
    {
        Instantiate(Explosion, transform.position, transform.rotation);
    }
}
