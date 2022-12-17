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
        scoreAct += 0.05f * levelManager.speed;
        score.text = Mathf.RoundToInt(scoreAct).ToString();
    }
    void Oof()
    {
        if (obstacleCooldown)
        {
            scoreAct = scoreAct - 1000f;
            update.text = "Oof!\n-1000";
            StartCoroutine(AnimationPlay());
            obstacleCooldown = false;
        }
    }

    private IEnumerator AnimationPlay()
    {     
        updateAnim.SetBool("start", true);
        yield return new WaitForSeconds(1f);
        updateAnim.SetBool("start", false);
        obstacleCooldown = true;
    }
}
