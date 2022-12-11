using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Code inspired by Unity Learn Lesson 1.3 High Speed Chase and modified to fit this project.
/// </summary>
public class ObjectMovement : MonoBehaviour
{
    public float Speed;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Speed * Time.deltaTime * Vector2.down);
    }

    public void UpdateSpeed(float speed)
    {
        Speed = speed;
    }
}