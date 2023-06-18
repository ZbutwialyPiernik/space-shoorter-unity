using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public TouchTest myTouch;
    public GameObject knife;
    public Transform spawner;

    public float rateLimit = 0.5f;

    private float timeToNextKnife = 0;
    private Collider2D myCollider;
    private Touch firstFinger;

    void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0 && timeToNextKnife == 0)
        {
            if (myCollider == Physics2D.OverlapPoint(myTouch.endPosition) && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                ThrowAKnife();
                timeToNextKnife = rateLimit;
            }
        }
        timeToNextKnife = Math.Max(0, timeToNextKnife - Time.deltaTime);
    }

    private void ThrowAKnife()
    {
        Instantiate(knife, spawner.position, Quaternion.Euler(0, 0, 0));
    }

}
