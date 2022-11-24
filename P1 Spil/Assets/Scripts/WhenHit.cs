using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenHit : MonoBehaviour
{
    /// <summary>
    /// Code inspired by Unity Learn Lesson 2.4 - Collision Decisions and modified to fit this project.
    /// </summary>
    private GameManager GameManager;

    private SpawnManager SpawnManager;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnManager = GameObject.Find("GameManager").GetComponent<SpawnManager>();
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
                    GameManager.UpdateScore(5);
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
                else if (col.tag == "Player")
                {
                    Destroy(gameObject);
                    GameManager.UpdateHealth(1); 
                }
                break;
            
            case "Correct":
                if (col.tag == "Player")
                {
                    Debug.Log("Player chose correct");
                    SpawnManager.SetStopSpawn(false);
                    Destroy(gameObject);
                    GameManager.UpdateScore(5);
                    GameManager.UpdateReward(1);
   
                }
                else if (col.tag == "Barrier")
                {
                    Destroy(gameObject);
                }
                break;
            
            case "Incorrect":
                if (col.tag == "Player") 
                {
                    Destroy(gameObject);
                    SpawnManager.SetStopSpawn(false);
                }
                else if (col.tag == "Barrier")
                {
                    Destroy(gameObject);
                }
                break;


        }
    }
}
