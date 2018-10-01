using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorControl : MonoBehaviour
{
    public float FirstSpawn;
    public float Intervalo;
    public bool moveToTopDown;
    public List<GameObject> ListBox;
    public float DistanceRobot;
    public GameObject Robot;

    private DateTime _nextSpawn;

    void Start()
    {
        _nextSpawn = DateTime.Now.AddSeconds(FirstSpawn);
    }

    void Update()
    {
        if (!UiManager.Instance.Pause)
        {

            if (Vector2.Distance(transform.position, Robot.transform.position) > DistanceRobot)
            {
                if (DateTime.Now > _nextSpawn)
                {
                    Vector3 tmp = transform.position; ;

                    if (moveToTopDown)
                        tmp.y += UnityEngine.Random.Range(-5F, 5F);
                    else
                        tmp.x += UnityEngine.Random.Range(-10F, 10F);

                    Instantiate(ListBox[UnityEngine.Random.Range(0, ListBox.Count)], tmp, Quaternion.identity);
                    _nextSpawn = DateTime.Now.AddSeconds(Intervalo + (UnityEngine.Random.Range(0, 1f)));
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawWireSphere(transform.position, DistanceRobot);

        //if (moveToTopDown)
        //{
        //    Gizmos.DrawWireCube(transform.position, new Vector3(0.5f, 5, 0));
        //}
        //else
        //{
        //    Gizmos.DrawWireCube(transform.position, new Vector3(10, 0.5f, 0));
        //}
    }

}
