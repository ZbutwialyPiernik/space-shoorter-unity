using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{

    private float cooldown = 5;
    private float timeToNextUsage;
    
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(TryToDetonate);
        timeToNextUsage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeToNextUsage -= Math.Max(0, Time.deltaTime);
    }

    private void TryToDetonate()
    {
        if (timeToNextUsage <= 0)
        {
            timeToNextUsage = cooldown;
            Detonate();
        }
    }

    private void Detonate()
    {
        foreach (var monster in GameObject.FindGameObjectsWithTag("Monster"))
        {
            Destroy(monster);
        }
    }
    
}
