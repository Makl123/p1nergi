using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenHit : MonoBehaviour
{
    /// <summary>
    /// Code inspired by Unity Learn Lesson 2.4 - Collision Decisions and modified to fit this project.
    /// </summary>
    private GameManager _gameManager;

    private SpawnManager _spawnManager;



    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("GameManager").GetComponent<SpawnManager>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    
    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (tag)
        {
            case "Item":
                if (col.CompareTag("Player")) 
                {
                    Destroy(gameObject);
                    _gameManager.UpdateScore(5);
                }
                else if (col.CompareTag("Barrier"))
                {
                    Destroy(gameObject);
                }
                break;

            case "Enemy":
                if (col.CompareTag("Barrier"))
                {
                    Destroy(gameObject);
                }
                else if (col.CompareTag("Player"))
                {
                    Destroy(gameObject);
                    _gameManager.UpdateHealth(1);
                }
                break;
            
            case "Correct":
                if (col.CompareTag("Player"))
                {
                    _spawnManager.SetStopSpawn(false);
                    Destroy(gameObject);
                    _gameManager.UpdateScore(5);
                    _gameManager.UpdateReward(1);

                }
                else if (col.CompareTag("Barrier"))
                {
                    Destroy(gameObject);
                }
                break;
            
            case "Incorrect":
                if (col.CompareTag("Player")) 
                {
                    Destroy(gameObject);
                    _spawnManager.SetStopSpawn(false);
                }
                else if (col.CompareTag("Barrier"))
                {
                    Destroy(gameObject);
                }
                break;


        }
    }
}
