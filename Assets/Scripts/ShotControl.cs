using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControl : MonoBehaviour
{
    public float Velocidade = 5;
    public Transform Robot;
    public Vector3 MomentPosition;

    void Start()
    {
        Robot = GameObject.Find("Robot").transform;
        MomentPosition = new Vector3(Robot.position.x, Robot.position.y);
    }

    void Update()
    {
        //var direcao = Robot.transform.position - transform.position;

        //transform.Translate((transform.position + direcao.normalized) * Velocidade * Time.deltaTime);

        transform.position = Vector2.MoveTowards(transform.position, MomentPosition, Velocidade * Time.deltaTime);

        if (Vector2.Distance(transform.position, MomentPosition) < 0.1)
        {
            Destroy(gameObject);
        }

        //transform.Translate(0, -Velocidade * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<RobotControl>().TakeDamage(100);
        Destroy(this.gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
