using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRB : MonoBehaviour
{
    //Keybind
    public KeyCode sprint, jump, croush, spect;

    //Movement
    public float movespeed;
    private float hor, vert;
    public Vector3 moveV3;

    //Rotation
    public float sens;
    private float mousex, mousey;
    private Vector3 mouseV3;
    private GameObject cam;

    //Sprint   
    private float speedlock;

    //Jump
    public float jumphight;
    private bool grounded;
    private RaycastHit ground;
    private Rigidbody rb;
    private Vector3 jumpV3;

    //Spectaiter
    public bool spectate;

    private void Start()
    {
        speedlock = movespeed;
        jumpV3.y = jumphight;
        mouseV3.z = 0;

        cam = GameObject.Find("Main Camera");
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Rotation();
        Sprint();
        Movement();


        if (spectate == true)
        {
            Spectate();

            if (Input.GetKeyDown(spect))
            {
                spectate = false;
            }
        }

        else
        {
            rb.useGravity = true;
            Jump();

            if (Input.GetKeyDown(spect))
            {
                spectate = true;
            }
        }
    }

    private void Movement()
    {
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        if (grounded)
        {
            moveV3.x = hor;
        }

        moveV3.z = vert;
                                      
        rb.velocity = (transform.forward * vert) * Time.deltaTime * movespeed * 250;
        rb.velocity = (transform.right * hor) * Time.deltaTime * movespeed * 250;
    }

    private void Rotation()
    {
        mousex = Input.GetAxis("Mouse X") * sens;
        mousey = Input.GetAxis("Mouse Y") * sens;

        mouseV3.x = mousex;
        mouseV3.y = mousey;

        cam.transform.Rotate(-mouseV3.y, 0, 0 * Time.deltaTime);
        transform.Rotate(0, mouseV3.x, 0 * Time.deltaTime);
    }

    private void Sprint()
    {
        if (Input.GetKey(sprint))
        {
            movespeed = speedlock * 1.5f;
        }

        else
        {
            movespeed = speedlock;
        }
    }

    private void Jump()
    {
        Debug.DrawRay(transform.position, -transform.up * 1.01f, Color.blue);
        int layerMask = 1 << 7;

        if (Physics.Raycast(transform.position, -transform.up, out ground , 2 , layerMask))
        {
            grounded = true;

            if (Input.GetKeyDown(jump))
            {
                rb.AddForce(jumpV3 * jumphight, ForceMode.Impulse);
            }
        }

        else
        {
            grounded = false;
        }
    }

    private void Spectate()
    {
        rb.useGravity = false;

        if (Input.GetKey(jump))
        {
            moveV3.y = 1;
        }

        else if (Input.GetKey(croush))
        {
            moveV3.y = -1;
        }

        else
        {
            moveV3.y = 0;
        }
    }
}
