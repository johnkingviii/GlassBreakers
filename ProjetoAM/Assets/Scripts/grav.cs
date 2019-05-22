using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grav : MonoBehaviour {

    public float speed = 2f;
    public float sensitivity = 2f;
    CharacterController player;

    public GameObject eyes;

    float moveFB;
    float moveLR;


    float jumpDist = 5f;
    float rotX;
    float rotY;
    public static float vertVelocity;

    public bool canJump;

    //Is character on ground?
    public bool ground, hasJumped;


    void Start()
    {

        player = GetComponent<CharacterController>();
        vertVelocity += Physics.gravity.y * Time.deltaTime;

    }


    void Update()
    {
        moveFB = Input.GetAxis("Vertical") * speed;
        moveLR = Input.GetAxis("Horizontal") * speed;

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;

        rotY = Mathf.Clamp(rotY, -60f, 60f);

        Vector3 movement = new Vector3(moveLR, vertVelocity, moveFB);

        transform.Rotate(0, rotX, 0);
        eyes.transform.localRotation = Quaternion.Euler(rotY, 0, 0);




        movement = transform.rotation * movement;
        player.Move(movement * Time.deltaTime);

        if (canJump == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                hasJumped = true;
                print("pressed");
                vertVelocity = jumpDist;
                canJump = false;
            }
        }
    }

    void FixedUpdate()
    {

        if (canJump == false)
        {
            if (ground == true && hasJumped == false)
            {
                canJump = true;
            }
        }

        Vector3 feet = new Vector3(transform.position.x, transform.position.y - player.height / 2, transform.position.z);
        Debug.DrawRay(feet, Vector3.down);
        //Raycast, 0.1 below feet
        if (Physics.Raycast(feet, Vector3.down, 0.2f))
        {
            ground = true;
            print("is hitting");
        }
        else
        {
            ground = false;
            hasJumped = false;
        }

        //Apply gravity
        if (ground == false && hasJumped == false)
        {
            vertVelocity += Physics.gravity.y * Time.deltaTime;
        }
        else if (hasJumped == false)
        {
            vertVelocity = Physics.gravity.y;
        }



    }
}
