using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FireGun : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;

    public CameraShake cameraShake;

    public GameObject muzzleFlash;
    public GameObject muzzleLight;
    public float muzzleFlashTrue = 0.5f;

    AudioSource sound;

    public AudioClip shootSound;
    bool hasFired = false;
    private void Start()
    {
        muzzleFlash.SetActive(false);
        muzzleLight.SetActive(false);

        muzzleFlashTrue = 0.5f;

        sound = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        


        if (Input.GetButtonDown("Fire1") && hasFired == false)
        {
            Shoot();
            sound.PlayOneShot(shootSound);
            hasFired = true;
             
        }

        
        

        if ( Input.GetButtonUp("Fire1") && hasFired == true ) 
        {
            
            muzzleFlash.SetActive(false);
            muzzleLight.SetActive(false);

            hasFired = false;
        }

        
    }

    void Shoot()
    {
        
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        
        muzzleFlash.SetActive(true);
        muzzleLight.SetActive(true);

        StartCoroutine(cameraShake.Shake(0.1f, 0.1f));

        
    }

    
   

    
}
