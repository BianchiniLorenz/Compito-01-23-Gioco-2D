using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    public GameObject Bullet;
    private float Timer;
    [SerializeField] public float AttackSpeed = 1f;
    public AudioSource BulletSound;

    void Update()
    {
        Timer += Time.deltaTime;

        if (Input.GetMouseButton(0) && Timer > AttackSpeed)
        {
            Timer = 0;
            Instantiate(Bullet, transform.position, Quaternion.identity);
            BulletSound.Play();
        }
    }
}
