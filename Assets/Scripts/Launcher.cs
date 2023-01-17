using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject ProjectileTemplate;

    public float LaunchForce = 1;

    public OVRInput.Button button;

    void Update()
    {
        if (OVRInput.GetDown(button))
        {
            GameObject projectile = Instantiate(ProjectileTemplate, ProjectileTemplate.transform.position, ProjectileTemplate.transform.rotation);
            projectile.SetActive(true);

            projectile.GetComponent<Rigidbody>().velocity = transform.forward * LaunchForce;
        }
    }
}
