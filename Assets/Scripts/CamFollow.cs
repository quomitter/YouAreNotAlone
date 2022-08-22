using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private PlayerController  controller;
    public Transform[] player;
    public float xPos, yPos, zPos;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        player[0] = controller.activePlayer[0].transform;
        player[1] = controller.activePlayer[1].transform;
        player[2] = controller.activePlayer[2].transform;
        player[3] = controller.activePlayer[3].transform;
        player[4] = controller.activePlayer[4].transform;
        player[5] = controller.activePlayer[5].transform;
        player[6] = controller.activePlayer[6].transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player[controller.bumperCounter].transform.position + new Vector3(xPos, yPos, zPos);
    }
}