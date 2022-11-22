using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenHit : MonoBehaviour
{
    /// <summary>
    /// Code inspired by Unity Learn Lesson 2.4 - Collision Decisions and modified to fit this project.
    /// </summary>
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (tag)
        {
            case "Item":
                if (col.tag == "Player")
                {
                    Destroy(gameObject);
                    gameManager.UpdateScore(5);
                }
                else if (col.tag == "Barrier")
                {
                    Destroy(gameObject);
                }
                break;

            case "Enemy":
                if (col.tag == "Barrier")
                {
                    Destroy(gameObject);
                }
                else
                {
                    Destroy(gameObject);
                    gameManager.UpdateHealth(1);
                }
                break;
        }
    }
}
