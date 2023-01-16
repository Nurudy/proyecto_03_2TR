using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstaclePrefab; 
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
        Instantiate(obstaclePrefab, spawnPos,//Instantiate necesita, qué, dónde y cómo
        obstaclePrefab.transform.rotation);

    }
}


