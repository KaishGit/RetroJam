using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerB : MonoBehaviour {


    public static int count = 0;
    public static int countDestroy = 0;
    public Transform[] points;
    public Transform[] pointsDestroy;
    public GameObject enemies;
    public GameObject destroyEnemy;
    public Transform startPoint;
    public Transform endPoint;
    public float timeToPowerUp = 5;
    public float timeToDestroyEnergy = 5;

    private void Start()
    {
        StartCoroutine(ConstantDamage());
        StartCoroutine(DestroyAllEnemys());
    }

    public void NewPowerUp()
    {
        float x = Random.Range(startPoint.position.x, endPoint.position.x);
        float y = Random.Range(startPoint.position.y, endPoint.position.y);
        float z = Random.Range(startPoint.position.z, endPoint.position.z);

        Vector3 np = new Vector3(x, y, z);
        NewMethod(np);
    }

    public void NewPowerUpDefineed()
    {
        Vector3 a = points[Random.Range(0, points.Length)].transform.position;
        NewMethod(a);
    }
    public void NewPowerUpDefineedDestroy()
    {
        Vector3 a = pointsDestroy[Random.Range(0, points.Length)].transform.position;
        NewMethodDestroy(a);
    }

    IEnumerator ConstantDamage()
    {
        yield return new WaitForSeconds(timeToPowerUp);
        if (count <= 0)
            NewPowerUpDefineed();

        StartCoroutine(ConstantDamage());
    }


    IEnumerator DestroyAllEnemys()
    {
        yield return new WaitForSeconds(timeToDestroyEnergy);
        if (countDestroy <= 0)
            NewPowerUpDefineedDestroy();

        StartCoroutine(DestroyAllEnemys());
    }

    private void NewMethod(Vector3 spawnPosition)
    {
        Instantiate(enemies, spawnPosition, Quaternion.identity);
    }
    private void NewMethodDestroy(Vector3 spawnPosition)
    {
        Instantiate(destroyEnemy, spawnPosition, Quaternion.identity);
    }
}
