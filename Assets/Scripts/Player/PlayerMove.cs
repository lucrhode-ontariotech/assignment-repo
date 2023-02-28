using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    Rigidbody2D rb2D;
    Collider2D col2D;
    float inVer;
    float inHor;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        col2D= GetComponent<Collider2D>();
    }


    void FixedUpdate()
    {
        inVer = Input.GetAxis("Vertical");
        inHor = Input.GetAxis("Horizontal");
        Move(inHor);
        Jump(inVer);
    }

    void Move(float axisIn)
    {
        //run
    }

    void Jump(float axisIn)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Ground");
        foreach (GameObject obj in objects)
        {
            Collider2D collider = obj.GetComponent<Collider2D>();
            if (rb2D.IsTouching(collider))
            {
                //jump
                break;
            }
        }
    }
}
