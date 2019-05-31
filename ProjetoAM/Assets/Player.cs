using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -6f)
        {
            GameController.instance.KillPlayer();
            GetComponent<FPSController>().enabled = false;
            GetComponent<CharacterController>().enabled = false;
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        }
    }
}
