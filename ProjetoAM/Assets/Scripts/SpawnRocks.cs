using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocks : MonoBehaviour {

    public Transform rockSpawn;

    public GameObject SpawnableArea;

    public GameObject MeteorPrefab;

    [SerializeField]
    float SpawnHeight;

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

        Vector3 min = GetComponent<MeshFilter>().mesh.bounds.min;
        Vector3 max = GetComponent<MeshFilter>().mesh.bounds.max;

        Vector3 spawnLocation = new Vector3(Random.Range(min.x, max.x), SpawnableArea.transform.position.y + SpawnHeight, Random.Range(min.z, max.z));

        //spawn theRock
        GameObject meteor = Instantiate(MeteorPrefab, spawnLocation, Quaternion.identity);
        meteor.name = "meteor";
        meteor.transform.SetParent(this.transform);

        //wait for a random amount of seconds
        StartCoroutine("Wait");
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(Random.Range(1, 5));
        SpawnRock();
    }
}
