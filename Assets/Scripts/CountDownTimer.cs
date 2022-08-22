using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    float timeCounter;

    // Start is called before the first frame update
    void Start()
    {
        timeCounter = 10f; 
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter -= Time.deltaTime;
        if(timeCounter <= 0)
        {
            Destroy(gameObject);  
        }
    }
}
