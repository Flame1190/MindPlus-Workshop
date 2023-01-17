using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyCoroutine(3));
    }

    IEnumerator DestroyCoroutine(int time)
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
}
