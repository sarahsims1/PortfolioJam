using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var movePoint = Vector3.forward * -LevelManager.speed * Time.deltaTime;
        transform.Translate(movePoint, Space.World);
    }
}
