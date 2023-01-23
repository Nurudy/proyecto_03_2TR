using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30;
    public float leftBound; 
    private void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(translation: Vector3.left * Time.deltaTime * speed, Space.World);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle)"))   //destruye los obstáculos cuando desaparecen de la escena o cuando cumplen su objetivo
        {
            Destroy(gameObject);
        }
    }

    

 

    private PlayerController playerControllerScript;
     private void Start()
    {

        playerControllerScript = FindObjectOfType<PlayerController>(); 
        
        
    }
}
