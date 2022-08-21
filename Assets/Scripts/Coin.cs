using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip aCoin1;
    AudioSource audioSource2;

    private void Start()
    {
        audioSource2 = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Score.Instance.AddHundoPeice();
            audioSource2.PlayOneShot(aCoin1, 0.7F);
            Destroy(gameObject, 0.1f);
        }
    }
}
