using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float acceleration = 10f;
    public float topSpeed = 10f;
    public float jumpForce = 10f;
    Rigidbody2D rb2D;
    Collider2D col;
    float inVer;
    float inHor;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
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
        // Add force to accellerate object to a specified max horizontal velocity (topSpeed)

        if (rb2D.velocity.x < topSpeed)
        {
            rb2D.AddForce(Vector2.right * axisIn * acceleration);
        }
    }

    void Jump(float axisIn)
    {
        // Add upward (jump) force when object is colliding with the top of a "Ground" tagged object

        if (axisIn > 0)
        {
            // Find "Ground" objects

            GameObject[] objects = GameObject.FindGameObjectsWithTag("Ground");
            foreach (GameObject obj in objects)
            {
                // Check for collision

                Collider2D collider = obj.GetComponent<Collider2D>();
                if (rb2D.IsTouching(collider))
                {
                    // Only add force if the bottom of the objects bounding box is not below the top of the "Ground" objects bounding box
                    // (Only jumps if the object is on top of the "Ground", ignore side collisions)

                    if (!(collider.bounds.max.y > col.bounds.min.y))
                    {
                        rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                        break;
                    }
                }
            }
        }
    }
}
