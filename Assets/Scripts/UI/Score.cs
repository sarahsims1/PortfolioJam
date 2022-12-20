using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static float scoreAct;
    public TMP_Text score;
    public TMP_Text update;
    public Animator updateAnim;
    public LevelManager levelManager;
    private bool obstacleCooldown = true;

    void Start()
    {
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
    void Oof()
    {
        scoreAct = scoreAct - 1000f;
        update.text = "Oof!\n-1000";
        updateAnim.Play("oof");
    }

}
