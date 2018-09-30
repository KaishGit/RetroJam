using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour {

    public float powerRestore = 100;

    private void Start()
    {
        SpawnerB.count++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpawnerB.count--;
        collision.gameObject.GetComponent<RobotControl>().UpLife(powerRestore);
            Destroy(gameObject);
     
    }
}
