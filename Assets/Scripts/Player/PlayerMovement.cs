using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speedWalk = 10f;
    [SerializeField] private float jumpForce = 5f;
    private Rigidbody rb;
    private Vector3 velocity;
    private bool onGround = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
        Jump();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direccion = (transform.forward * vertical + transform.right * horizontal);
        velocity = direccion * speedWalk;
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && onGround == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
}
