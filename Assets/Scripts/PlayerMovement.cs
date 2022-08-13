using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;
    public float jumpHeight = 4f;
    private float jumpMultiplier = 1f;
    Vector3 velocity;
    bool isGrounded;
    public GameObject portalA;
    public GameObject portalB;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            speed = 6f;
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        Jump();

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void Jump()
    {
        if ((Input.GetButtonDown("Jump")) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity * jumpMultiplier);
            jumpMultiplier = 1f;
        }
    }


    //Shoot Portal
    void Shoot()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, 1 << 9))
            {
                portalA.transform.position = hit.point;
                portalA.transform.rotation = Quaternion.FromToRotation(portalA.transform.forward, hit.normal) * portalA.transform.rotation;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, 1 << 9))
            {
                portalB.transform.position = hit.point;
                portalB.transform.rotation = Quaternion.FromToRotation(portalB.transform.forward, hit.normal) * portalB.transform.rotation;
            }
        }


    }
}
