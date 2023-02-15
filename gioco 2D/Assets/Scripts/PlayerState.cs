using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Vector3 SpawnPoint;
    [SerializeField] private AudioSource DeathSound;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        SpawnPoint = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Death();
        }
    }

    

    private void Death()
    {
        DeathSound.Play();
        anim.SetTrigger("Death");
        rb.bodyType = RigidbodyType2D.Static;
        coll.enabled = false;
    }

    //funzione chiamata dall'animazione "Player_Death"
    private void Respawn()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
        transform.position = SpawnPoint;
        }
        rb.bodyType = RigidbodyType2D.Dynamic;
        coll.enabled = true;
        anim.SetTrigger("Respawn");
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            SpawnPoint = transform.position;
            Debug.Log("checkpoint");
        }

        if (collision.gameObject.CompareTag("Trap"))
        {
            Death();
        }
    }
    
}
