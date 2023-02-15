using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Boss Boss;

    [Range(1, 50)]
    [SerializeField] private float MaxHealth = 10;
    private float CurrentHealth;
    public Image HealthBar;

    void Start()
    {
        CurrentHealth = MaxHealth;
        HealthBar.enabled = false;
    }

    void Update()
    {
        HealthBar.fillAmount = Mathf.Clamp(CurrentHealth / MaxHealth, 0, 1);

        if(Boss.IsAwake is true)    { HealthBar.enabled = true; }
        
        if(CurrentHealth < (MaxHealth * 99f) / 100)     { Boss.Damaged = true; }

        if (CurrentHealth < (MaxHealth * 55f) / 100)
        {
            if (Boss.Phase2 is false) 
            {
            Boss.BulletHell = true; 
            }
        }

        if (CurrentHealth < 1f)     { Boss.IsAlive = false; }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Boss.IsAwake && collision.gameObject.CompareTag("PlayerAttack"))
        {
            CurrentHealth -= 1f;
        }
    }
}
