using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;
    public Text Scoretext;
    public GameObject ScorePainel;
    public bool Pause;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Update()
    {

    }

    public void ShowScore()
    {
        Pause = true;

        ScorePainel.SetActive(true);
        Time.timeScale = 0;

        int min = (int)(Time.timeSinceLevelLoad / 60);
        int sec = (int)(Time.timeSinceLevelLoad % 60);

        Scoretext.text = string.Format("You survived by {0} min e {1} s", min, sec);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        Pause = false;
        SceneManager.LoadScene(1);
    }
}
