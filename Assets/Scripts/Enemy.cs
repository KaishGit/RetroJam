using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float life = 1;
    public Rigidbody projectile;
    public float speedForward = 1;
    public float speedSide = 1;

    // Use this for initialization
    void Start () {
        Fire();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speedForward * Time.deltaTime);
    }

    void Fire() {
        Rigidbody clone;
        Bullet bullet = projectile.gameObject.GetComponent<Bullet>();
        bullet.instancer = Bullet.Instancer.ENEMY;
        Vector3 n = transform.forward.normalized * 10;
        clone = (Rigidbody)Instantiate(projectile, n, projectile.rotation);
        clone.AddForce(transform.forward * bullet.speed);
    }

    void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.gameObject.GetComponent<Bullet>();
        if (bullet) {
            life -= bullet.power;
            Destroy(other.gameObject);
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
