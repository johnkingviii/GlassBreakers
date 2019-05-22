using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocks : MonoBehaviour {

    public Transform rockSpawn;
    public GameObject[] rocks;

    int spawnSpot;

    void Start()
    {
        SpawnRock();
    }

    void Update()
    {
    }

    void SpawnRock()
    {
        //change up spawn position of rocks a bit
        spawnSpot = Random.Range(-1, 8);
        //pick a random rock prefab from our array of prefabs, copy it to the new theRock object
        GameObject theRock = rocks[Random.Range(0, rocks.Length)];

        //spawn theRock
        Instantiate(theRock, new Vector3(transform.position.x + spawnSpot, transform.position.y, transform.position.z), Quaternion.identity);
        //give it a random direction and velocity
        theRock.GetComponent<Rigidbody2D>().velocity = ((Vector2)Random.onUnitSphere).normalized * Random.Range(5, 10);

        //destroy theRock after 2 seconds
        Destroy(theRock, 2f);

        //wait for a random amount of seconds
        Wait();

        //spawn another rock
        SpawnRock();
    }

    public static IEnumerator Wait()
    {
        yield return new WaitForSeconds(Random.Range(.2f, .5f));
    }
}
