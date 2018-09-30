using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayControl : MonoBehaviour {


    public void ToGoScreen(int position) {
        Application.LoadLevel(position);
    }
}
