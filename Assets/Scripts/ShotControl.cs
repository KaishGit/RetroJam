using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControl : MonoBehaviour
{
    public float Velocidade = 5;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, -Velocidade * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
