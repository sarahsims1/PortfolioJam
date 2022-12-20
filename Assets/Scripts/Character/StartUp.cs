using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    public Animator mainCam;
    public LevelManager levelManager;
    public GameObject startScreen;

    private FMOD.Studio.EventInstance menuMusic;

    private void Start()
    {
        levelManager.targetSpeed = 0;
        levelManager.speed = 0;

        menuMusic = FMODUnity.RuntimeManager.CreateInstance("event:/MenuMusic");
        menuMusic.start();
        menuMusic.release();
        
    }
    public void Starting()
    {
        if(mainCam != null)mainCam.Play("turnaround");
        if (levelManager != null) levelManager.targetSpeed = 50f;
        startScreen.SetActive(false);

        menuMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
