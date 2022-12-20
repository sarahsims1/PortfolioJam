using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static float scoreAct;
    public TMP_Text score;
    public TMP_Text update;
    public static TMP_Text updateStatic;
    public Animator updateAnim;
    public static Animator uiAnimator;
    public LevelManager levelManager;

    void Start()
    {
        updateStatic = update;
        uiAnimator = updateAnim;
        scoreAct = 0;
        ObstacleSlow.ObstacleHit += Oof;
        updateAnim = update.gameObject.GetComponent<Animator>();
    }

    private void OnDestroy()
    {
        ObstacleSlow.ObstacleHit -= Oof;
    }
    private void Update()
    {
        scoreAct += 0.05f * LevelManager.speed;
        score.text = Mathf.RoundToInt(scoreAct).ToString();
    }
    public static void ModifyScore(float modification, string text)
    {
        scoreAct = scoreAct + modification;
        updateStatic.text = text;
        uiAnimator.Play("oof");
    }

    public void Oof()
    {
        scoreAct = scoreAct - 1000f;
        update.text = "Oof!\n-1000";
        updateAnim.Play("oof");
    }

}
