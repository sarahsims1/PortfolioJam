using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class Death : MonoBehaviour
{
    public Animator volume;
    public float dangerTime;
    private float timeSpent;
    public static bool inDanger;
    private bool dangerCoolDown;
    public LevelManager levelManager;

    public GameObject resetScreen;

    void Awake()
    {
        inDanger = false;
        dangerCoolDown = false;
        timeSpent = 0;
        ObstacleSlow.ObstacleHit += DeathApproaches;
        Decimator.Dead += DoNotFearTheReaper;
    }

    private void OnDestroy()
    {
        ObstacleSlow.ObstacleHit -= DeathApproaches;
        Decimator.Dead -= DoNotFearTheReaper;
    }
    // Update is called once per frame
    void Update()
    {
        if(inDanger)
        {
            timeSpent += Time.deltaTime * 1f;
            if(timeSpent > dangerTime)
            {
                inDanger = false;
                timeSpent = 0;

                MusicStarter.SetUnMuffled();
            }
        }
    }

    private void DeathApproaches()
    {
        if (!inDanger)
        {
            inDanger = true;
            volume.Play("fadeDefault");
            dangerCoolDown = false;
            StartCoroutine(StartAnimation());

            MusicStarter.SetMuffled();
        }
        else 
        {
            DoNotFearTheReaper();

            FMODUnity.RuntimeManager.PlayOneShot("event:/MonsterBite");
            MusicStarter.StopGameMusic();
        }
    }

    private void DoNotFearTheReaper()
    {
        LevelManager.speed = 0;
        LevelManager.targetSpeed = 0;
        if (resetScreen != null)resetScreen.SetActive(true);
    }

}
