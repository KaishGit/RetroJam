using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public enum TypeSong { GRASS , ASPHALT };

    public SoundRandom footSongs;
    public SoundRandom shotSongs;

    public void playShot()
    {
        shotSongs.play();

    }

    public void playFootStep()
    {
        footSongs.play();
    }
}
