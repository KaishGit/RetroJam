using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDronePowerUp : MonoBehaviour {

    public GameObject[] alldrones;

    private void Start()
    {
        SpawnerB.countDestroy++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("----");
        alldrones = GameObject.FindGameObjectsWithTag("Enemy");
        if (collision.gameObject.GetComponent<RobotControl>())
        {
            foreach (GameObject o in alldrones) {
                o.GetComponent<EnemyControl>().onMouseDown();
            }
            SpawnerB.countDestroy--;
            Destroy(gameObject);
        }
     
    }
}
