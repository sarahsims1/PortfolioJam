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

    private FMOD.Studio.EventInstance monsterFootsteps;
    private FMOD.Studio.Bus fmodBus;

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
                StopMonsterSounds();
            }
        }
    }

    private void DeathApproaches()
    {
        if (!inDanger)
        {
            inDanger = true;
            volume.Play("fadeDefault");

            MusicStarter.SetMuffled();
            MonsterSounds();
        }
        else 
        {
            DoNotFearTheReaper();

            fmodBus = FMODUnity.RuntimeManager.GetBus("Bus:/");
            fmodBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            FMODUnity.RuntimeManager.PlayOneShot("event:/MonsterBite");
            FMODUnity.RuntimeManager.PlayOneShot("event:/DeathPiano");
            
            MusicStarter.StopGameMusic();
        }
    }

    private void DoNotFearTheReaper()
    {
        LevelManager.speed = 0;
        LevelManager.targetSpeed = 0;
        if (resetScreen != null)resetScreen.SetActive(true);
    }

    void MonsterSounds()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/MonsterRoarRandom");
        monsterFootsteps = FMODUnity.RuntimeManager.CreateInstance("event:/MonsterFootsteps");
        monsterFootsteps.start();
        monsterFootsteps.release();
    }
    void StopMonsterSounds()
    {
        monsterFootsteps.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
