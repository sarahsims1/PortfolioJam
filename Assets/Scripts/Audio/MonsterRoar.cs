using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRoar : MonoBehaviour
{
    public GameObject soundEmitter;

    void StartingRoar()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/MonsterRoar", soundEmitter);
    }
}
