using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;

    public CameraShake cameraShake;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();

            StartCoroutine(cameraShake.Shake(0.1f, 0.1f));
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);

    }
}
