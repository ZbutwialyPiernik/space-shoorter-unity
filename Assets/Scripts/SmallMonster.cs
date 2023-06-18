using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMonster : MonoBehaviour
{
    public float distance = 0.5f;
    public GameObject knife;
    public GameObject fastKnife;

    private Vector2 direction;
    private float speed;
    private float targetTime = 1f;

    void Start()
    {
        direction = transform.right;
        speed = GameManager.Instance.smallMonsterSpeed;
    }

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
        targetTime -= Time.deltaTime;
        if (targetTime <= 0)
        {
            float randomChanceToSpawnMonster = Random.value;
            if(randomChanceToSpawnMonster < 0.75f)
            {
                ThrowAKnife();
            } 
            else
            {
                ThrowFastKnife();
            }
            targetTime = Random.Range(GameManager.Instance.minKnifeRate, GameManager.Instance.maxKnifeRate);
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall"))
        {
            transform.position = transform.position + Vector3.down * distance;
            transform.Rotate(0, 180, 0);
        }
    }

    private void ThrowAKnife()
    {
        Instantiate(knife, transform.position, Quaternion.Euler(-180, 0, 0));
    }

    private void ThrowFastKnife()
    {
        Instantiate(fastKnife, transform.position, Quaternion.Euler(-180, 0, 0));
    }
    
}
