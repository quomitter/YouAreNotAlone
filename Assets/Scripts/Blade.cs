using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Rigidbody2D rb;
    private SavePoint sp;
    private Checkpoint checkpoint;
    [SerializeField] private float torqueForce;
    [SerializeField] private AudioSource myAudioSource;
    [SerializeField] private AudioClip bladeKill;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        sp = GameObject.FindGameObjectWithTag("SP").GetComponent<SavePoint>();
        checkpoint = GameObject.FindGameObjectWithTag("Checkpoint").GetComponent<Checkpoint>();
        //rb.AddTorque(torqueForce, ForceMode2D.Force);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, torqueForce);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            myAudioSource.PlayOneShot(bladeKill, 0.7f);
            other.gameObject.transform.position = sp.lastCheckPointPos;
            checkpoint.dead = true;
        }
    }

}
