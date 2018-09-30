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
    public GameObject Boom;

    public Sprite[] imagesToMovement;
    public Vector3 originalSize;

    SpawnerB sb;

    void Start()
    {
        originalSize = transform.localScale;
        sb = GameObject.Find("PowerUpControll").GetComponent<SpawnerB>();
        sc = GameObject.Find("SoundController").GetComponent<SoundController>();
        StartCoroutine(ConstantDamage());
    }

    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            Vector3 botposition = transform.position;
            transform.Translate(0, Velocidade * Time.deltaTime, 0);
            if (transform.position.y > sb.startPoint.position.y) 
                transform.position = botposition;
            sc.playFootStep();
            gameObject.GetComponent<SpriteRenderer>().sprite = imagesToMovement[0];
            transform.localScale = originalSize;
        }
        if (Input.GetKeyDown("s"))
        {
            //transform.Translate(0, - Velocidade * Time.deltaTime, 0);
            Vector3 botposition = transform.position;
            transform.Translate(0, - Velocidade * Time.deltaTime, 0);
            if (transform.position.y < sb.endPoint.position.y)
                transform.position = botposition;
            sc.playFootStep();
            gameObject.GetComponent<SpriteRenderer>().sprite = imagesToMovement[1];
            transform.localScale = originalSize;
        }
        if (Input.GetKeyDown("a"))
        {
            //transform.Translate(-Velocidade * Time.deltaTime, 0, 0);
            Vector3 botposition = transform.position;
            transform.Translate(-Velocidade * Time.deltaTime, 0, 0);
            if (transform.position.x < sb.startPoint.position.x)
                transform.position = botposition;
            sc.playFootStep();
            gameObject.GetComponent<SpriteRenderer>().sprite = imagesToMovement[2];
            transform.localScale = originalSize;
        }
        if (Input.GetKeyDown("d"))
        {
            //transform.Translate(Velocidade * Time.deltaTime, 0, 0);
            Vector3 botposition = transform.position;
            transform.Translate(Velocidade * Time.deltaTime, 0, 0);
            if (transform.position.x > sb.endPoint.position.x)
                transform.position = botposition;
            sc.playFootStep();
            gameObject.GetComponent<SpriteRenderer>().sprite = imagesToMovement[2];
            transform.localScale = originalSize;
        }
    }

    //public void ReturnToStart()
    //{
    //    //transform.position = StartPoint.transform.position;
    //    //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //    SceneManager.LoadScene(0);
    //}

    public void TakeDamage(float damage)
    {
        life -= damage;
        if (life <= 0) {
            life = maxLife;
            //transform.position = StartPoint.transform.position;
            Instantiate(Boom, transform.position, Quaternion.identity);
            gameObject.GetComponent<Renderer>().enabled = false;
            StartCoroutine(RestartTime());
        }
        uiLife.value = life / maxLife;
    }

    IEnumerator ConstantDamage()
    {
        yield return new WaitForSeconds(constantDamageTime);
        TakeDamage(constantDamage);
        StartCoroutine(ConstantDamage());
    }

    IEnumerator RestartTime()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }

    public void UpLife(float upLife) {
        life = Mathf.Clamp(life + upLife, 0, maxLife);
        uiLife.value = life / maxLife;
    }


}
