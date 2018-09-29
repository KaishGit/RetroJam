using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

    // Use this for initialization
    public Transform tiles;
    public float speed;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        tiles.Translate(Vector3.right * speed);
	}
}
