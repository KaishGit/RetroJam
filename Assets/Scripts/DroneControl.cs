using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneControl : MonoBehaviour
{
    public float speedForward = 10;
    public float speedSide = 1;
    public float MoveInterval = 2;
    private DateTime _nextMove;
    public float ShotInterval = 1;
    private DateTime _nextShot;
    int side = 0;
    bool inForwardMovement = true;
    public GameObject ShotPosition;
    public GameObject Shot;
    public GameObject Robot;

    SoundController sc;

    void Start()
    {
        sc = GameObject.Find("SoundController").GetComponent<SoundController>();
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

        if(DateTime.Now > _nextShot)
        {
            Instantiate(Shot, ShotPosition.transform.position, Quaternion.identity);
            sc.playShot();

            _nextShot = DateTime.Now.AddSeconds(ShotInterval + UnityEngine.Random.Range(0,1));
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
        //collision.GetComponent<RobotControl>().TakeDamage(100);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

}
