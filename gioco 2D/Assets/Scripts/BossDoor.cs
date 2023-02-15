using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
   
    [Tooltip("waypoint posizione aperta")] public GameObject Open;
    [Tooltip("waypoint posizione chiusa")] public GameObject Close;
    private float DoorSpeed = 5f;

    public Boss boss;
    
    void Update()
    {
        if (boss.IsAwake == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, Close.transform.position, DoorSpeed * Time.deltaTime);
        }

        if(boss.IsAlive == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, Open.transform.position, DoorSpeed * Time.deltaTime);
        }
    }
}
