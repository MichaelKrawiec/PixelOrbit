using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Player : MonoBehaviour
{

    [SerializeField]
    GameObject bullet;

    float fireRate;
    public float nextFire;

    public Rigidbody Enemy_Laser;


    public Transform firePoint;
    public GameObject laserPrefab;
    public bool canShoot = true;
    public float timer;

    void Start()
    {
        fireRate = 1.5f;
        nextFire = Time.time;
    }

    void Update()
    {
        // Adds a small delay to shooting
        timer += 1.0f * Time.deltaTime;
        if (timer >= 0.2f)
        {
            canShoot = true;
        }
        if (canShoot == true)
        {
            if (Input.GetButtonDown("Fire1")) // Spacebar to shoot
            {

                //GetComponent<AudioSource>().Play();
                shoot();
            }
        }

        Instantiate(bullet, transform.position, Quaternion.identity);
        nextFire = Time.time + fireRate;
    }


    void shoot()
    {
        canShoot = false;
        timer = 0f;
        Instantiate(laserPrefab, firePoint.position, firePoint.rotation); // Laser fires right from the position of the firePoint object

    }
}
