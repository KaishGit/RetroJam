using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorControl : MonoBehaviour
{
    public float Intervalo;
    public GameObject BoxA;
   
    private DateTime _nextSpawn;

    void Start()
    {
        _nextSpawn = DateTime.Now.AddSeconds(Intervalo);
    }

    void Update()
    {
        if(DateTime.Now > _nextSpawn)
        {
            Instantiate(BoxA, transform.position, Quaternion.identity);
            _nextSpawn = DateTime.Now.AddSeconds(Intervalo);
        }
    }
}
