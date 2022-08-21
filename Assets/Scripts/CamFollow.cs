using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform player;
    public float xPos, yPos, zPos;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(xPos, yPos, zPos);
    }
}