using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorControl : MonoBehaviour
{
    public float Intervalo;
    //public GameObject BoxA;
    public bool moveToTopDown;
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
            Vector3 tmp = transform.position; ;

            if (moveToTopDown)
                tmp.y += UnityEngine.Random.Range(-10F, 10F);
            else 
                tmp.x += UnityEngine.Random.Range(-5F, 5F);

            Instantiate(ListBox[UnityEngine.Random.Range(0, ListBox.Count)], tmp, Quaternion.identity);
            _nextSpawn = DateTime.Now.AddSeconds(Intervalo + (UnityEngine.Random.Range(0,1f)));
        }
    }
}
