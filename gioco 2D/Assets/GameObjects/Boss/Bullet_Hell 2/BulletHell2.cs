using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHell2 : MonoBehaviour
{
    private Animator anim;
    public Boss boss;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (boss.Hell2 is true)
        {
            anim.SetTrigger("Attack2");
        }
    }
}
