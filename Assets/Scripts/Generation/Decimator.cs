using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decimator : MonoBehaviour
{
    public delegate void FellToDeath();
    public static FellToDeath Dead;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Dead();
        }
        if(other.tag == "Platform")
        {
            PlatformGen.currentPlatforms--;
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
