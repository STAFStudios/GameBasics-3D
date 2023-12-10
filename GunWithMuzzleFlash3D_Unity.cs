using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;

    public CameraShake cameraShake;

    public GameObject muzzleFlash;
    public GameObject muzzleLight;
    public float muzzleFlashTrue = 0.5f;

    private void Start()
    {
        muzzleFlash.SetActive(false);
        muzzleLight.SetActive(false);

        muzzleFlashTrue = 0.5f;
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && muzzleFlashTrue >0f)
        {
            Shoot();
           
            muzzleFlash.SetActive(true);
            muzzleLight.SetActive(true);
            

            StartCoroutine(cameraShake.Shake(0.1f, 0.1f));

            
        }
        if (Input.GetButtonUp("Fire1") && muzzleFlashTrue <=0f)
        {
            muzzleFlash.SetActive(false);
            muzzleLight.SetActive(false);

            muzzleFlashTrue = 0.5f;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            muzzle();
        }
    }

    void Shoot()
    {

        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
    }

    
    void muzzle()
    {
        muzzleFlashTrue -= 0.5f;
    }
}
