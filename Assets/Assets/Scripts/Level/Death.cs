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
    }

    private void OnDestroy()
    {
        ObstacleSlow.ObstacleHit -= DeathApproaches;
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
            }
        }
    }

    private void DeathApproaches()
    {
        if (!inDanger)
        {
            inDanger = true;
            dangerCoolDown = false;
            StartCoroutine(StartAnimation());
        }
        else if (dangerCoolDown)
        {
            DoNotFearTheReaper();
        }
    }

    private void DoNotFearTheReaper()
    {
        levelManager.speed = 0;
        levelManager.targetSpeed = 0;
        if (resetScreen != null)resetScreen.SetActive(true);
    }

    private IEnumerator StartAnimation()
    {
        volume.SetBool("start", true);
        yield return new WaitForSeconds(3f);
        dangerCoolDown = true;
        volume.SetBool("start", false);
    }
}
