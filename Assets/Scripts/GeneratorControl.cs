using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorControl : MonoBehaviour
{
    public float Intervalo;
    //public GameObject BoxA;
    public List<GameObject> ListBox;
   
    private DateTime _nextSpawn;

    void Start()
    {
        _nextSpawn = DateTime.Now.AddSeconds(Intervalo);
    }

    void Update()
    {
        if(DateTime.Now > _nextSpawn)
        {
            Instantiate(ListBox[UnityEngine.Random.Range(0, ListBox.Count)], transform.position, Quaternion.identity);
            _nextSpawn = DateTime.Now.AddSeconds(Intervalo + (UnityEngine.Random.Range(0,1f)));
        }
    }
}
