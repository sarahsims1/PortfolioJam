using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debuging : MonoBehaviour
{
    public GameObject[] gameObject1;
    void Start()
    {
        Debug.Log(gameObject1[0].GetComponent<MeshRenderer>().bounds.size.x);
        Debug.Log(gameObject1[1].GetComponent<MeshRenderer>().bounds.size.x);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
