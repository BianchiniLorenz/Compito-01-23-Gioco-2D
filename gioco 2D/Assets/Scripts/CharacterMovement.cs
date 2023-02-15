using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D Collider;
    private Animator anim;
    private SpriteRenderer sprite;
    
    private float Horizontal;

    [Range(0f,20f)]
    [SerializeField] private float MoveSpeed = 7f;
    [Range(0f,35f)]
    [SerializeField] private float JumpHeight = 21f;
    [Tooltip("Layer su cui puoi saltare")][SerializeField] private LayerMask Layers;
    [SerializeField] private AudioSource JumpSound;

    private enum MovementState
    {
        idle,
        running,
        jumping,
        falling
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Collider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        
        rb.velocity = new Vector2(Horizontal * MoveSpeed, rb.velocity.y);
        
        //jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            JumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
        }



        Animation();
        
    }

    private void Animation()
    {
        MovementState state;

        if (Horizontal > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (Horizontal < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if(rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("Movement",(int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(Collider.bounds.center, Collider.bounds.size, 0f, Vector2.down, 1f, Layers );
    }

    
}
