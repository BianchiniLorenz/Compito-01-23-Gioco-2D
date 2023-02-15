using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectItems : MonoBehaviour
{
    [HideInInspector]public int score = 0;
    [SerializeField] public Text ScoreCount;
    [SerializeField] public AudioSource ItemSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            ItemSound.Play();
            Destroy(collision.gameObject);
            score++;
            ScoreCount.text = "score: " + score;
        }

    }
}
