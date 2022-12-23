using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class StartUp : MonoBehaviour
{
    public Animator mainCam;
    public LevelManager levelManager;
    public GameObject startScreen;
    public float fogDistance;
    public float fadeSpeed;
    private bool fadeStart;

    private FMOD.Studio.EventInstance menuMusic;
    private FMOD.Studio.EventInstance gameMusic;

    private void Start()
    {
        MusicStarter.SetUnMuffled();
        LevelManager.targetSpeed = 0;
        LevelManager.speed = 0;

        menuMusic = FMODUnity.RuntimeManager.CreateInstance("event:/MenuMusic");
        gameMusic = FMODUnity.RuntimeManager.CreateInstance("event:/GameMusic");
        menuMusic.start();
        menuMusic.release();
    }

    private void Update()
    {
        if(RenderSettings.fogEndDistance >= fogDistance)
        {
            return;
        }
        else if(fadeStart)
        {
            RenderSettings.fogEndDistance += fadeSpeed * Time.deltaTime;
        }
    }
    public void Starting()
    {
        if(mainCam != null)mainCam.Play("turnaround");
        if (levelManager != null) LevelManager.targetSpeed = 50f;
        startScreen.SetActive(false);
        menuMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        gameMusic.start();
        FMODUnity.RuntimeManager.PlayOneShot("event:/MonsterRoar");
        fadeStart = true;
    }
}
