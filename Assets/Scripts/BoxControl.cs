using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControl : MonoBehaviour
{
    public float Velocidade = 5;
    public bool moveToRight;

    void Start()
    {

    }

    void Update()
    {
        if (moveToRight)
        {
            transform.Translate(Velocidade * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Translate(-Velocidade * Time.deltaTime, 0, 0);
        }

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
