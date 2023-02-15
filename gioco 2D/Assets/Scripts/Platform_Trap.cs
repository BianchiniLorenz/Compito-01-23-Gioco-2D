using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Trap : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            anim.SetTrigger("Start");
        }
    }

   
    
}


