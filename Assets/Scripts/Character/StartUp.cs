using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    public Animator mainCam;
    public LevelManager levelManager;
    public GameObject startScreen;

    private void Start()
    {
        levelManager.targetSpeed = 0;
        levelManager.speed = 0;
    }
    public void Starting()
    {
        if(mainCam != null)mainCam.Play("turnaround");
        if (levelManager != null) levelManager.targetSpeed = 50f;
        startScreen.SetActive(false);
    }
}
