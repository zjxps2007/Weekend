using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private bool isJumping;
    private Rigidbody rb;
    private float speed;

    virtual public void Start()
    {
        isJumping = false;
        rb = GetComponent<Rigidbody>();
        speed = 50;
    }

    protected void move(Vector3 velocity)
    {
        transform.Translate(velocity * Time.deltaTime * speed);
    }

    protected void jump()
    {
        if (isJumping == false)
        {
            isJumping = true;
            rb.AddForce(0, 200, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }
}
