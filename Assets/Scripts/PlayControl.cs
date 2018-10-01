using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayControl : MonoBehaviour {


    public void ToGoScreen(int position) {
        SceneManager.LoadScene(position);
    }
}
