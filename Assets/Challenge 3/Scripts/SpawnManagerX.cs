using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    /* public GameObject[] objectPrefabs;
     private float spawnDelay = 2;
     private float spawnInterval = 1.5f;

     private PlayerControllerX playerControllerScript;

     // Start is called before the first frame update
     void Start()
     {
         InvokeRepeating("SpawnsObject", spawnDelay, spawnInterval);
         playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
     }

     // Spawn obstacles
     void SpawnObjects ()
     {
         // Set random spawn location and random object index
         Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
         int index = Random.Range(0, objectPrefabs.Length);

         // If game is still active, spawn new object
         if (!playerControllerScript.gameOver)
         {
             Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
         }

     }*/
    public GameObject [] obstaclePrefab;

    private float startDelay = 1f;
    private float repeatRate = 1f;

    private PlayerControllerX playerControllerScript;

    private void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerControllerX>();

        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    private void Update()
    {
        if (playerControllerScript.gameOver)
        {
            CancelInvoke("SpawnObstacle");
        }
    }

    private void SpawnObstacle()
    {
        Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
        int index = Random.Range(0, obstaclePrefab.Length);


        Instantiate(obstaclePrefab[index], transform.position,
            obstaclePrefab[index].transform.rotation);
    }



}
