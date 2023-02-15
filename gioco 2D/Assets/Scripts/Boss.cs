using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Animator anim;
    public GameObject Player;
    private CircleCollider2D bosscollider;
    [Range(0f, 20f)]
    [SerializeField] public float Speed = 2f;

    [HideInInspector]public bool IsAwake = false;
    [HideInInspector]public bool IsAlive = true;
    [HideInInspector]public bool Damaged = false;
    [HideInInspector]public bool Phase2 = false; 

    private float Phase2Speed;

    public AudioSource BossMusic;
    public AudioSource DeathSound;
    

    //VARIABILI RELATIVE AGLI ATTACCHI DEL BOSS

    public GameObject Bullet;
    public GameObject Phase2Bullet;
    private float timer;
    private float timer1;
    [Tooltip("Intervallo di tempo tra un attacco e l'altro")] public float AttackSpeed = 2f;
    private float Phase2AttackSpeed;
    [HideInInspector]public bool Hell = false;
    [HideInInspector]public bool Hell1 = false;
    [HideInInspector]public bool Hell2 = false;
    
    [HideInInspector]public bool CanShoot;
    [HideInInspector]public bool BulletHell = false;


    void Start()
    {
        anim = GetComponent<Animator>();
        bosscollider = GetComponent<CircleCollider2D>();
        Phase2Speed = Speed * 2f;
        Phase2AttackSpeed = AttackSpeed * 0.75f;
        CanShoot = true;
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        timer1 += Time.deltaTime;

        if (IsAwake is true)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);
        

            if(Damaged is true)
            {

                if(CanShoot is true)
                {
                    if(Phase2 is false)
                    {
                        if (timer > AttackSpeed)
                        {
                            timer = 0;
                            Instantiate(Bullet, transform.position, Quaternion.identity);
                        }
                    }
                    else
                    {
                        if (timer > Phase2AttackSpeed)
                        {
                            timer = 0;
                            Instantiate(Bullet, transform.position, Quaternion.identity);
                        }

                        if (timer1 > AttackSpeed)
                        {
                            timer1 = 0;
                            Instantiate(Phase2Bullet, transform.position, Quaternion.identity);
                        }
                    }
                }

                if(BulletHell is true)
                {
                    anim.SetTrigger("BulletHell");
                }

            }
        }

        if(IsAlive is false)
        {
            IsAwake = false;
            Speed = 0f;
            anim.SetTrigger("Death");
            BossMusic.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            anim.SetTrigger("Awake");
            IsAwake = true;
            Destroy(bosscollider);
        }
    }

    //Funzioni chiamate nell'animazione Boss_Death
    private void Despawn()
    {
        Destroy(gameObject);
    }
    private void BossDeathSound()
    {
        DeathSound.Play();  
    }

    //Funzione chiamata nell'animazione Boss_Awake
    private void StartMusic()
    {
        BossMusic.Play();
    }

    //Funzioni chiamate nell'animazione Boss_BulletHell
    private void EnterBulletHell()
    {
        Speed = 0f;
        CanShoot = false;
    }
    private void BHell()
    {
        Hell = true;
    }
    private void BHell1()
    {
        Hell1 = true;
    }
    private void BHell2()
    {
        Hell2 = true;
    }
    private void EndBulletHell()
    {
        Speed = Phase2Speed;
        CanShoot = true;
        Phase2 = true;
        anim.SetTrigger("Phase2");
        BulletHell = false;
    }
}

