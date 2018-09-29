using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float life = 1;
    public Rigidbody projectile;
    public float speedForward = 10;
    public float speedSide = 1;
    bool inForwardMovement = true;

    // Use this for initialization
    void Start () {
        Fire();
        StartCoroutine(toSide());
    }

    int side = 0;
    IEnumerator toSide()
    {
        yield return new WaitForSeconds(1);
        inForwardMovement = !inForwardMovement;
        side = Random.Range(1, 5) % 2;
        StartCoroutine(toSide());
    }


    // Update is called once per frame
    void Update () {
        if (inForwardMovement)
            transform.Translate(Vector3.forward * speedForward * Time.deltaTime);
        else if ( side == 0)
        {
            transform.Translate(Vector3.left * speedForward * Time.deltaTime);
        }
        else {
            transform.Translate(Vector3.right * speedForward * Time.deltaTime);
        }
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
