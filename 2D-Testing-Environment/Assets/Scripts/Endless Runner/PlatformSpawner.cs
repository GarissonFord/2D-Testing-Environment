using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;

    public Transform[] spawnPoints;
    public float timeBetweenSpawns, timeOfLastSpawn;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
        //foreach (Transform point in spawnPoints)
          //  Debug.Log(point.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timeOfLastSpawn > timeBetweenSpawns)
        {
            int i = Random.Range(1, spawnPoints.Length - 1);
            Instantiate(platform, spawnPoints[i].position, spawnPoints[i].rotation);
            timeOfLastSpawn = Time.time;
        }
    }
}
