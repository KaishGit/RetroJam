using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorControl : MonoBehaviour
{
    public float Intervalo;
    public List<GameObject> ListEnemy;

    private DateTime _nextSpawn;

    void Start()
    {
        _nextSpawn = DateTime.Now.AddSeconds(Intervalo);
    }

    void Update()
    {
        if (DateTime.Now > _nextSpawn)
        {
            Instantiate(ListEnemy[UnityEngine.Random.Range(0, ListEnemy.Count)], transform.position, Quaternion.identity);
            _nextSpawn = DateTime.Now.AddSeconds(Intervalo + (UnityEngine.Random.Range(0, 2.0f)));
        }
    }
}
