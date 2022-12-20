using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Staging : MonoBehaviour
{
    public static bool lowGravity;
    public float gravityChange;
    public Vector2 whenToStartRange;

    public Animator anime;
    public TMP_Text text;
    void Start()
    {
        StartCoroutine(Stages());
    }

    private IEnumerator Stages()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(whenToStartRange.x, whenToStartRange.y));
            lowGravity = !lowGravity;
            if (lowGravity)
            {
                Physics.gravity = new Vector3(0, gravityChange, 0);
                text.text = "Gravity Offline";
                anime.Play("gravity");
            }
            else
            {
                Physics.gravity = new Vector3(0, -9.8f, 0);
                text.text = "Gravity Back Online";
                anime.Play("gravity");
            }
        }
    }
}
