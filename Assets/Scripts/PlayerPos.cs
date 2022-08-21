using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private SavePoint sp;


    private void Start()
    {
        sp = GameObject.FindGameObjectWithTag("SP").GetComponent<SavePoint>();
       

        transform.position = sp.lastCheckPointPos;
        

    }
  
}
