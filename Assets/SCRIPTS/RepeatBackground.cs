using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth; // Anchura de una unidad de fondo

    private void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2f; //la anchura en posición x porque es donde lo quiero. //getComponent: accedo unicamente a la-
                                                              //-componente BoxColidder del game object que tiene asignado este script.
    }

    private void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }


}
