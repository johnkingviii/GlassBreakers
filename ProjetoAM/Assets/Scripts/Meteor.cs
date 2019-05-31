using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float Duration;

    public float Speed;


    // Start is called before the first frame update
    void Start()
    {
        //give it a random direction and velocity
        GetComponent<Rigidbody>().velocity = ((Vector2)Random.onUnitSphere).normalized * Random.Range(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            ScoreCounter.instance.AwardKill();

            Destroy(this.gameObject);
        }
    }
}
