using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

 public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstaclePrefabs; 
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private PlayerController playerControllerScript; 



    private void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController>();

        InvokeRepeating(methodName: "SpawnObstacle", time: startDelay,
          repeatRate);


    }

    private void Update()
    {
        if (playerControllerScript.gameOver)
        {
            CancelInvoke(methodName: "SpawnObstacle");
        }
    }

    private float startDelay = 2f;
    private float repeatRate = 2f;

    private void SpawnObstacle()

    {
        int randomIdx = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[randomIdx], spawnPos,//Instantiate necesita, qué, dónde y cómo
        obstaclePrefabs[randomIdx].transform.rotation);

    }
}


