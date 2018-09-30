using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandom : MonoBehaviour {

    public AudioSource[] audios;
    int lastplay;
	// Use this for initialization
	void Start () {
        audios = GetComponents<AudioSource>();
	}
	
    public void play(){
        audios[lastplay].Stop();
        int randIndex = UnityEngine.Random.Range(0,audios.Length);
        audios[randIndex].Play();
        lastplay = randIndex;
    }

}
