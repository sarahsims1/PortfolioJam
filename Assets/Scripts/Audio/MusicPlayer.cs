using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    FMOD.Studio.EventInstance gameMusic;

    void Start()
    {
        gameMusic = FMODUnity.RuntimeManager.CreateInstance("event:/GameMusic");
        gameMusic.start();
        gameMusic.release();
    }

}
