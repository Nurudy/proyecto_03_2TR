using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Animator _animator;
    public float gravityModifier = 1.5f;

    public AudioClip[] jumpSounds;
    public AudioClip[] crashSounds;
    private AudioSource _audioSource;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;

        _audioSource = GetComponent<AudioSource>();


    }


    public bool gameOver;
    public float jumpForce = 10;
      private void Update() //a partir de aquí, se programa hacer un salto una vez que el object toca el suelo. Te bloquea el doble salto en el aire.
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !gameOver)
        {
            Jump(); //aqui declaras la funcion para que haga caso
           
        }

    }




    private bool isOnTheGround = true;

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            //Destroy(otherCollider.collider); //esta linea de codigo destruye el GameObject cuando el player se choca
            GameOver();

        }
        else if (otherCollider.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
            dirtParticle.Play();
        }
        
    }

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    private void GameOver()
    {
        gameOver = true;
        _animator.SetBool("Death_b", true);
        _animator.SetInteger("DeathType_int", Random.Range(1, 3));
        dirtParticle.Stop();
        explosionParticle.Play();
        ChooseRandomSFX(crashSounds);
    }

    private void Jump()
    {
        isOnTheGround = false;
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        _animator.SetTrigger(name: "Jump_trig");
        dirtParticle.Stop();
        ChooseRandomSFX(jumpSounds);
        
    }

    private void ChooseRandomSFX(AudioClip[] sounds)
    {
        int randomIdx = Random.Range(0, sounds.Length);
        _audioSource.PlayOneShot(sounds[randomIdx], 1); //el 1 es el máximo 
    }



}
