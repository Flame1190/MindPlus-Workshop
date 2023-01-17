using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyCoroutine(10));
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(DestroyCoroutine(3));
    }

    private void OnCollisionStay(Collision collision)
    {
        Vector3 newVelocity = GetComponent<Rigidbody>().velocity;
        newVelocity.x *= 0.925f;
        newVelocity.z *= 0.925f;
        GetComponent<Rigidbody>().velocity = newVelocity;
    }

    IEnumerator DestroyCoroutine(int time)
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
}
