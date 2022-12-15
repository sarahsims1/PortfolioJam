using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private float scoreAct;
    public TMP_Text score;
    public TMP_Text update;
    public Animator updateAnim;
    public LevelManager levelManager;
    private bool obstacleCooldown = true;

    void Start()
    {
        ObstacleSlow.ObstacleHit += Oof;
        updateAnim = update.gameObject.GetComponent<Animator>();
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
