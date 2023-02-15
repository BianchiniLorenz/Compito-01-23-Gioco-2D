using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHell1 : MonoBehaviour
{
    private Animator anim;
    public Boss boss;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (boss.Hell1 is true)
        {
            anim.SetTrigger("Attack1");
        }
    }
}
