using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThinkKill : MonoBehaviour
{
    private SavePoint sp;
    private Checkpoint checkpoint;


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
        if(other.gameObject.tag == "Player") { 
            other.gameObject.transform.position = sp.lastCheckPointPos;
            checkpoint.dead = true;
        }
    }
}
