using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactivateAfterAwake : MonoBehaviour
{
    public float Delay;

    private void Awake()
    {
        StartCoroutine(deactivate());
    }

    private IEnumerator deactivate()
    {
        yield return new WaitForSeconds(Delay);
        gameObject.SetActive(false);
    }
}
