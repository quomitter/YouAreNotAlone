using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTheLeader : MonoBehaviour
{
    public GameObject player1;

    public float speed = 5.0f;

    void Start()
    {
        player1 = GameObject.Find("Player");
    }

    void Update()
    {
        if (player1 != null)
        {
            Quaternion rotation = Quaternion.LookRotation(player1.transform.position - transform.position, transform.TransformDirection(Vector3.forward * -1f));
            if (player1 != null)
                transform.position = Vector2.MoveTowards(transform.position, player1.transform.position, speed * Time.deltaTime);
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        }
    }
}