using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStarter : MonoBehaviour
{
    static FMOD.Studio.EventInstance gameMusic;
    static FMOD.Studio.EventInstance monsterRoarRandom;
    public GameObject roarSoundEmitter;
    
    void Start()
    {
        
    }

    void MusicStart()
    {
        gameMusic = FMODUnity.RuntimeManager.CreateInstance("event:/GameMusic");
        gameMusic.start();
        gameMusic.release();
    }

    public static void SetMuffled()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("InDanger", 1);
    }

    public static void SetUnMuffled()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("InDanger", 0);
    }

    public static void StopGameMusic()
    {
        gameMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    public static void MonsterRoarRandom()
    {
        monsterRoarRandom = FMODUnity.RuntimeManager.CreateInstance("event:/MonsterRoarRandom");
        monsterRoarRandom.start();
        monsterRoarRandom.release();
    }
}
