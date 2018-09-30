using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControl : MonoBehaviour
{
    public float Velocidade = 5;
    public bool moveToRight;
    public float damage = 50;

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
        collision.GetComponent<RobotControl>().TakeDamage(damage);
        collision.GetComponent<RobotControl>().TakeDamage(damage);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
