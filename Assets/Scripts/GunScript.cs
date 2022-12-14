using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    //[SerializeField] private ParticleSystem MuzzleFlash;
    //[SerializeField] private AudioSource GunSoundSource;
   // [SerializeField] private AudioClip GunSound;
    
    [SerializeField] private float Firerate;
    private float TimeBeforeShooting;

    private Camera PlayerCamera;

    public ParticleSystem muzzleFlash;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        TimeBeforeShooting = 1 / Firerate;
        
        PlayerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        /* if(Input.GetMouseButtonDown(0))
        {
            //GunSoundSource.PlayOneShot(GunSound);
            //MuzzleFlash.Play();

            Ray gunray = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);

            if(Physics.Raycast(gunray, out RaycastHit hitInfo, 100f, Target))
            {
                if(hitInfo.collider.gameObject.TryGetComponent(out TargetScript TargetHit))
                {
                    TargetHit.SubtractHealth(Damage);
                    Debug.Log(TargetHit.Health);
                }
            }
        } */

        if(Input.GetMouseButton(0))
        {
            if(TimeBeforeShooting <= 0f)
            {
                muzzleFlash.Play();

                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;

                /* Ray gunray = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);

                if(Physics.Raycast(gunray, out RaycastHit hitInfo, 100f, Target))
                {
                    if(hitInfo.collider.gameObject.TryGetComponent(out TargetScript TargetHit))
                    {
                        TargetHit.SubtractHealth(Damage);
                        Debug.Log(TargetHit.Health);
                    }
                } */

                TimeBeforeShooting = 1 / Firerate;
            }
            else
            {
                TimeBeforeShooting -= Time.deltaTime;
            }
        }
        else
        {
            TimeBeforeShooting = 0f;
        }
    }
}
