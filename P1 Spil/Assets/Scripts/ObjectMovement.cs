using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    /// <summary>
    /// Code inspired by Unity Learn Lesson 1.3 High Speed Chase and modified to fit this project.
    /// </summary>
    public float Speed;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * Speed);
    }
    public void UpdateSpeed(float speed)
    {
        Speed = speed;
    }
}
