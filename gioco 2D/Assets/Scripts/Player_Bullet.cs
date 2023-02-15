using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] public float Speed = 15f;
    [SerializeField] public float LifeTime = 2f;
    private float Timer;

    private Camera MainCamera;
    private Vector3 MousePosition;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        MousePosition = MainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 Direction = MousePosition - transform.position;
        rb.velocity = new Vector2(Direction.x, Direction.y).normalized * Speed;
    }

    
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > LifeTime)
        {
            Destroy(gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        } 
    }
}
