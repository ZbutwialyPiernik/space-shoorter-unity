using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour
{
    public float speed = 2f;

    private Vector2 direction = Vector2.up;

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            EventManager.MonsterKilled();
        }
        if (collision.CompareTag("Boss"))
        {
            Destroy(gameObject);
            EventManager.BossHit();
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
