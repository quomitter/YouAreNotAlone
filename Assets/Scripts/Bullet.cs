using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private SavePoint sp;
    private Checkpoint checkpoint;

    public float speed = 20f;
    public Rigidbody2D rb; 

    // Start is called before the first frame update
    void Start()
    {
       
        sp = GameObject.FindGameObjectWithTag("SP").GetComponent<SavePoint>();
        checkpoint = GameObject.FindGameObjectWithTag("Checkpoint").GetComponent<Checkpoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        if (other.gameObject.CompareTag("Player")) 
        { 
            other.gameObject.transform.position = sp.lastCheckPointPos;
            checkpoint.dead = true;
        }
    }
}
