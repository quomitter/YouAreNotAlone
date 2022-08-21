using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingCheckPoint : MonoBehaviour
{
    private SavePoint sp;

    void Start()
    {
        sp = GameObject.FindGameObjectWithTag("SP").GetComponent<SavePoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
            other.gameObject.transform.position = sp.lastCheckPointPos; 
    }
}
