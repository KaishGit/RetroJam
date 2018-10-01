using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorControl : MonoBehaviour
{
    public float Intervalo;
    public bool moveToTopDown;
    public List<GameObject> ListBox;
   
    private DateTime _nextSpawn;

    void Start()
    {
        _nextSpawn = DateTime.Now.AddSeconds(Intervalo);
    }

    void Update()
    {
        if (!UiManager.Instance.Pause)
        {
            if (DateTime.Now > _nextSpawn)
            {
                Instantiate(ListBox[UnityEngine.Random.Range(0, ListBox.Count)], transform.position, Quaternion.identity);
                _nextSpawn = DateTime.Now.AddSeconds(Intervalo + (UnityEngine.Random.Range(1f, 2f)));
            }
        }      
    }
}
