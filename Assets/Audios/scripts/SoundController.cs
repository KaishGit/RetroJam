using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public enum TypeSong { GRASS , ASPHALT };

    public SoundRandom footSongs;
    public SoundRandom shotSongs;
    public SoundRandom explosaoSongs;


    public void playShot()
    {
        shotSongs.play();

    }

    public void playExplosao()
    {
        explosaoSongs.play();

    }


    public void playFootStep()
    {
        footSongs.play();
    }
}
