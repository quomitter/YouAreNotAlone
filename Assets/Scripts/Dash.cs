using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashspeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            direction = 1;
        } else if (Input.GetKeyDown(KeyCode.RightShift)){
            direction = 2;
        } else {
            if (dashTime < -0) {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            } else {
                dashTime -= Time.deltaTime;
                if(direction != 0){
                    if (direction == 1) {
                        rb.velocity = Vector2.left * dashspeed;
                    }
                    if (direction == 2) {
                        rb.velocity = Vector2.right * dashspeed;
                    }
                }
            }
        }
    }
}