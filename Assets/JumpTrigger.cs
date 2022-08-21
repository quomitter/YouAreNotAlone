using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{

    Rigidbody body;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            other.gameObject.GetComponent<Rigidbody2D>();
            other.attachedRigidbody.AddForce(new Vector2(0f, 400f));
        }
        if(other.gameObject.tag == "Buddy6")
        {
            Destroy(gameObject,2f);
        }
    }
}
