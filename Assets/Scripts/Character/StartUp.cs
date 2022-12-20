using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class StartUp : MonoBehaviour
{
    public Animator mainCam;
    public LevelManager levelManager;
    public GameObject startScreen;

    private FMOD.Studio.EventInstance menuMusic;
    public float fogDistance;
    public float fogBlue;
    private Color color = new Color(0, 0, 0);
    private void Start()
    {
        LevelManager.targetSpeed = 0;
        LevelManager.speed = 0;

        menuMusic = FMODUnity.RuntimeManager.CreateInstance("event:/MenuMusic");
        menuMusic.start();
        menuMusic.release();
    }
    public void Starting()
    {
        if(mainCam != null)mainCam.Play("turnaround");
        if (levelManager != null) LevelManager.targetSpeed = 50f;
        startScreen.SetActive(false);
        
        menuMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        
        while (RenderSettings.fogEndDistance < fogDistance)
        {
            RenderSettings.fogEndDistance += 1 * Time.deltaTime;
        }
        while(RenderSettings.fogColor.b < fogBlue)
        {
            color.b += 0.5f * Time.deltaTime;
            RenderSettings.fogColor = color;
        }

        
    }
}
