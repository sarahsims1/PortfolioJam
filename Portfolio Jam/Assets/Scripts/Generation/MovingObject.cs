using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public LevelManager levelManager;
    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    void Update()
    {
        if (levelManager == null) return;
        gameObject.transform.position += new Vector3(0, 0, -levelManager.speed * Time.deltaTime);
    }
}
