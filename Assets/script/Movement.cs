using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Keybind
    public KeyCode sprint, jump, croush;
    public KeyCode spect;

    //Movement
    public float movespeed;
    private float hor, vert;
    private Vector3 MoveV3;

    //Rotation
    public float sens;
    private float mousex, mousey;
    private Vector3 MouseV3;
    private GameObject cam;

    //Sprint   
    private float speedlock;

    //Jump
    public float jumphight;
    private bool grounded;
    private RaycastHit ground;
    private Rigidbody rb;
    private Vector3 JumpV3;

    //Spectaiter
    public bool spectate;

    private void Start()
    {
        speedlock = movespeed;
        JumpV3.y = jumphight;
        MouseV3.z = 0;

        cam = GameObject.Find("Main Camera");
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        movement();
        Rotation();
        Sprint();


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

    private void movement()
    {
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        MoveV3.x = hor;
        MoveV3.z = vert;

        transform.Translate(MoveV3* Time.deltaTime * movespeed);
    }

    private void Rotation()
    {
        mousex = Input.GetAxis("Mouse X") * sens;
        mousey = Input.GetAxis("Mouse Y") * sens;

        MouseV3.x = mousex;
        MouseV3.y = mousey;

        cam.transform.Rotate(-MouseV3.y, 0, 0 * Time.deltaTime);
        transform.Rotate(0, MouseV3.x, 0 * Time.deltaTime);
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

        if (Physics.Raycast(transform.position, -transform.up, out ground , 2) && Input.GetKeyDown(jump))
        {
            rb.AddForce(JumpV3 * jumphight, ForceMode.Impulse);
        }
    }

    private void Spectate()
    {
        rb.useGravity = false;

        if (Input.GetKey(jump))
        {
            MoveV3.y = 1;
        }

        else if (Input.GetKey(croush))
        {
            MoveV3.y = -1;
        }

        else
        {
            MoveV3.y = 0;
        }
    }
}
