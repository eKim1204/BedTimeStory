using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectRemover : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyCoroutine());
    }

    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
