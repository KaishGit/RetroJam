using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speedForward = 10;
    public float speedSide = 1;
    public float MoveInterval = 2;
    private DateTime _nextMove;
    int side = 0;
    bool inForwardMovement = true;
    public GameObject ShotPosition;
    public GameObject Shot;


    void Start()
    {
        _nextMove = DateTime.Now.AddSeconds(MoveInterval);
        StartCoroutine(toSide());
    }

    void Update()
    {
        if (DateTime.Now > _nextMove)
        {

            if (inForwardMovement)
            {
                transform.Translate(0, -speedForward * Time.deltaTime, 0);
                Instantiate(Shot, ShotPosition.transform.position, Quaternion.identity);
            }
            else if (side == 0)
            {
                transform.Translate(-speedForward * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.Translate(speedForward * Time.deltaTime, 0, 0);
            }

            _nextMove = DateTime.Now.AddSeconds(MoveInterval);
        }


    }

    IEnumerator toSide()
    {
        yield return new WaitForSeconds(1);
        inForwardMovement = !inForwardMovement;
        side = UnityEngine.Random.Range(1, 5) % 2;
        StartCoroutine(toSide());
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
