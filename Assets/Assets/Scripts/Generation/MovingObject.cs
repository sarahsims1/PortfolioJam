using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public LevelManager levelManager;
    private void Start()
    {
        StartCoroutine(CanISpeakToTheManager());
    }
    void Update()
    {
        if (levelManager == null) return;
        gameObject.transform.position += new Vector3(0, 0, -levelManager.speed * Time.deltaTime);
    }

    private IEnumerator CanISpeakToTheManager()
    {
        yield return new WaitUntil(() => FindObjectOfType<LevelManager>() != null);
        levelManager = FindObjectOfType<LevelManager>();
    }
}
