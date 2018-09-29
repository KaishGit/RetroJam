using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControl : MonoBehaviour
{
    public float Velocidade = 5;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            transform.Translate(0, Velocidade * Time.deltaTime, 0);
        }
        if (Input.GetKeyDown("s"))
        {
            transform.Translate(0, - Velocidade * Time.deltaTime, 0);
        }
        if (Input.GetKeyDown("a"))
        {
            transform.Translate(-Velocidade * Time.deltaTime, 0, 0);
        }
        if (Input.GetKeyDown("d"))
        {
            transform.Translate(Velocidade * Time.deltaTime, 0, 0);
        }
    }
}
