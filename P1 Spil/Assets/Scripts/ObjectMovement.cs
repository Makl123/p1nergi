using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    /// <summary>
    /// Code inspired by Unity Learn Lesson 1.3 High Speed Chase and modified to fit this project.
    /// </summary>
    public float speed = 3F;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime*speed);
    }
}
