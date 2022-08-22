using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeMonster : MonoBehaviour
{
    private bool moveRight;

    Rigidbody2D rb;
    Vector2 position;
    Vector2 initPosition;

    private Checkpoint checkpoint;
    private SavePoint sp;
    private PlayerController player;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveRight = true;
        position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        initPosition = position;
        checkpoint = GameObject.FindGameObjectWithTag("Checkpoint").GetComponent<Checkpoint>();
        sp = GameObject.FindGameObjectWithTag("SP").GetComponent<SavePoint>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        if (moveRight == true)
            MoveRight();

        if (moveRight == false)
            MoveLeft();

    }

    void MoveRight()
    {
        rb.MovePosition(position);
        //rb.MoveRotation(position.x * 72);
        position.x += 0.05f;
        //position.y += 0.5f*Mathf.Sin(2*Mathf.PI*position.x);
        if (position.x >= initPosition.x + 1)
        {
            moveRight = false;
            Flip();
        }
    }
    void MoveLeft()
    {
        rb.MovePosition(position);
        //rb.MoveRotation(position.x * 72);
        position.x -= 0.05f;
        //position.y -= 0.5f*Mathf.Sin(2*Mathf.PI*position.x);
        if (position.x <= initPosition.x - 1 )
        {
            moveRight = true;
            Flip();
        }
    }
    void Flip()
    {
        if (moveRight == true)
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        if (moveRight == false)
            gameObject.transform.localScale = new Vector3(1, 1, 1);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {


        if (other.gameObject.CompareTag("Player"))
        {
            Vector2 direction = other.GetContact(0).normal;
            if (direction.y == -1 || direction.y == 1)
            {
                
                //player.EnemyKill();
                //GetComponent<Collider2D>().enabled = false;
                Score.Instance.AddHundoPeice();
                Destroy(this.gameObject, 0.1f);

            }
            else
            {
                other.gameObject.transform.position = sp.lastCheckPointPos;
                checkpoint.dead = true;
            }
        }
    }
}