using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staging : MonoBehaviour
{
    public static bool lowGravity;
    public float gravityChange;
    public Vector2 whenToStartRange;
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
            }
            else
            {
                Physics.gravity = new Vector3(0, -10, 0);
            }
        }
    }
}
