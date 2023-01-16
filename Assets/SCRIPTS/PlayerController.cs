using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Animator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();


    }


    public bool gameOver;
    public float jumpForce = 10;
      private void Update() //a partir de aquí, se programa hacer un salto una vez que el object toca el suelo. Te bloquea el doble salto en el aire.
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !gameOver)
        {
            isOnTheGround = false;
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _animator.SetTrigger(name: "Jump_trig");
        }

    }




    private bool isOnTheGround = true;
    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
        }else if (otherCollider.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
        }
        
    }



}
