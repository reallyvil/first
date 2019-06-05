using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Transform playerSpawnPoints; // The original spawn point
    public bool respawn = false;

    private Transform[] spawnPoints;
    private bool lastToggle = false;
    // Start is called before the first frame update
    void Start()
    {
        //remember to comment m8
        spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastToggle != respawn)
        {
            Respawn();
            respawn = false;
        }
        else
        {
            lastToggle = respawn;
        }
    }
    private void Respawn()
    {
        int a = Random.Range (2, spawnPoints.Length);
        transform.position = spawnPoints [a].transform.position;
    }
}
