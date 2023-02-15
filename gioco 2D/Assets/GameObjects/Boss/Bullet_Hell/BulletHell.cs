using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHell : MonoBehaviour
{
    private Animator anim;
    public Boss boss;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(boss.Hell is true)
        {
            anim.SetTrigger("Attack");
        }
    }
}
