using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rb;
    [SerializeField] public float Speed = 15f;
    [SerializeField] public float LifeTime = 2f;
    private float Timer;

    private Boss boss;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        boss = GetComponent<Boss>();

        Vector3 Direction = Player.transform.position - transform.position;

        rb.velocity = new Vector2(Direction.x, Direction.y).normalized * Speed;
    }

    void Update()
    {
        Timer += Time.deltaTime;

        if(Timer > LifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
