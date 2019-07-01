using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour {

    public float speed = 3f, sensitivity = 3f, jumpForce = 4f;

    CharacterController player;
    public GameObject eyes;
    public GameObject shot;

    public float fireRate, nextFire;
    private float moveFB, moveLR, rotX, rotY, vertVelocity;
    
    private bool hasJumped;
    public Transform shotSpawn;
    

    // Use this for initialization
    void Start () {

        player = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {

        Movement();
        ApplyGravity();

        if (Input.GetButtonDown("Jump"))
        {
            hasJumped = true;
        }

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            var bullet = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 15;
            Destroy(bullet, 2.0f);

            
        }

    }

    void Movement()
    {
        //WASD Input
        moveFB = Input.GetAxis("Vertical") * speed;
        moveLR = Input.GetAxis("Horizontal") * speed;

        //mouse Input
        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;
        //limitar a rotação
        rotY = Mathf.Clamp(rotY, -90f, 90f);

        //controlar o movimento do Character Controller
        Vector3 movement = new Vector3(moveLR, vertVelocity, moveFB);

        //rodar player
        transform.Rotate(0, rotX, 0);

        //rodar a camera no eixo dos yy
        eyes.transform.localRotation = Quaternion.Euler(0, 0, rotY);
     

        //orientar o player na direção certa
        movement = transform.rotation * movement;

        //movimentar o player
        player.Move(movement * Time.deltaTime);
    }


    private void ApplyGravity()
    {
        if(player.isGrounded == true)
        {
            if (!hasJumped)
            {
                vertVelocity = Physics.gravity.y;
            }
            else
            {
                vertVelocity = jumpForce;
            }
            
        }
        else
        {
            vertVelocity += Physics.gravity.y * Time.deltaTime;
            vertVelocity = Mathf.Clamp(vertVelocity, -50f, jumpForce);
            hasJumped = false;
        }
    }
}
