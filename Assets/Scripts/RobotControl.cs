using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RobotControl : MonoBehaviour
{
    public float Velocidade = 5;
    public GameObject StartPoint;
    SoundController sc;
    float maxLife = 100;
    public float life = 100;
    public Slider uiLife;
    public float constantDamage = 3;
    public float constantDamageTime = 1;


    void Start()
    {
        sc = GameObject.Find("SoundController").GetComponent<SoundController>();
        StartCoroutine(ConstantDamage());
    }

    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            transform.Translate(0, Velocidade * Time.deltaTime, 0);
            sc.playFootStep();
        }
        if (Input.GetKeyDown("s"))
        {
            transform.Translate(0, - Velocidade * Time.deltaTime, 0);
            sc.playFootStep();
        }
        if (Input.GetKeyDown("a"))
        {
            transform.Translate(-Velocidade * Time.deltaTime, 0, 0);
            sc.playFootStep();
        }
        if (Input.GetKeyDown("d"))
        {
            transform.Translate(Velocidade * Time.deltaTime, 0, 0);
            sc.playFootStep();
        }
    }

    public void ReturnToStart()
    {
        //transform.position = StartPoint.transform.position;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TakeDamage(float damage)
    {
        life -= damage;
        if (life <= 0) {
            life = maxLife;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        uiLife.value = life / maxLife;
    }

    IEnumerator ConstantDamage()
    {
        yield return new WaitForSeconds(constantDamageTime);
        TakeDamage(constantDamage);
        StartCoroutine(ConstantDamage());
    }

    public void UpLife(float upLife) {
        life = Mathf.Clamp(life + upLife, 0, maxLife);
        uiLife.value = life / maxLife;
    }


}
