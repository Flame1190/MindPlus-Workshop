using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject Explosion;

    private void Start()
    {
        transform.LookAt(new Vector3(0, transform.position.y, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody?.GetComponent<Projectile>())
        {
            if (GameManager.Main.Targets.Contains(gameObject))
            {
                GameManager.Main.AddScore();
                GameManager.Main.Targets.Remove(gameObject);
                GameManager.Main.SpawnTarget();

                Explosion.SetActive(true);
                Explosion.transform.parent = null;

                Destroy(gameObject);
            }
        }
    }
}
