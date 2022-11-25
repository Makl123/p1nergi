using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    /// <summary>
    /// Code inspired by Unity Learn Lesson 1.3 High Speed Chase and modified to fit this project.
    /// </summary>
    public float Speed = 3F;
    private GameManager _gameManager;
    // Start is called before the first frame update
    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * UpdateSpeed());
    }
    private float UpdateSpeed()
    {
        switch (_gameManager.GetScore())
        {   
            case 5:
                Speed = 4F;
                return Speed;
            default:
                return Speed;
        }
    }
}
