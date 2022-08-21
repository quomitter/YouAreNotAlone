using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject projectile;
    public Transform firePoint;
    public float fireForce;
    [SerializeField] private AudioSource myAudioSource;
    [SerializeField] private AudioClip bulletShot;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        InvokeRepeating("FireProjectile", 0, 2f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireProjectile()
    {
        fireForce = Random.Range(150.0f, 1650.0f);
        GameObject clone = Instantiate(projectile, firePoint.transform.position,firePoint.transform.rotation, firePoint);
        rb = clone.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(-1, 0)*fireForce);
        myAudioSource.PlayOneShot(bulletShot, 0.7f);
    }
}
