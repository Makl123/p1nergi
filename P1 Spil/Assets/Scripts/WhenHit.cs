using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WhenHit : MonoBehaviour
{
    /// <summary>
    /// Code inspired by Unity Learn Lesson 2.4 - Collision Decisions and modified to fit this project.
    /// </summary>
    private GameManager _gameManager;

    private SpawnManager _spawnManager;

    private TextMeshPro _otherWrongQuestion;

    private TextMeshPro _otherRightQuestion;

    public GameObject[] _showQuestionColourArray;
    
    



    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("GameManager").GetComponent<SpawnManager>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _otherWrongQuestion = GameObject.FindWithTag("Incorrect").GetComponent<TextMeshPro>();
        _otherRightQuestion = GameObject.FindWithTag("Correct").GetComponent<TextMeshPro>();

    }

    public void ShowWrongAnswers()
    {
        _showQuestionColourArray = GameObject.FindGameObjectsWithTag("Incorrect");
        foreach (var question in _showQuestionColourArray)
        {
            question.GetComponent<TextMeshPro>().color = Color.red;
        }
    }

    public void ShowRightAnswers()
    {
        _showQuestionColourArray = GameObject.FindGameObjectsWithTag("Correct");
        foreach (var question in _showQuestionColourArray)
        {
            question.GetComponent<TextMeshPro>().color = Color.green;
        }
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
                    _gameManager.UpdateScore(5);
                    _gameManager.UpdateReward(1);
                    GetComponent<TextMeshPro>().color = Color.green;
                    ShowWrongAnswers();

                }
                else if (col.CompareTag("Barrier"))
                {
                    Destroy(gameObject);
                }
                break;
            
            case "Incorrect":
                if (col.CompareTag("Player")) 
                {
                    _gameManager.UpdateHealth(1);
                    _spawnManager.SetStopSpawn(false);
                    GetComponent<TextMeshPro>().color = Color.red;
                    _otherRightQuestion.GetComponent<TextMeshPro>().color = Color.green;
                    ShowWrongAnswers();
                    ShowRightAnswers();
                }
                else if (col.CompareTag("Barrier"))
                {
                    Destroy(gameObject);
                }
                break;


        }
    }
}
