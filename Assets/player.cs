using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Transform playerSpawnPoints; // The original spawn point
    public bool respawn = false;

    private Transform[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        //remember to comment m8
        spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
        print(spawnPoints.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
