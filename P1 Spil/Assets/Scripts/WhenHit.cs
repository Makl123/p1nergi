using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Code inspired by Unity Learn Lesson 2.4 - Collision Decisions and modified to fit this project.
/// </summary>
public class WhenHit : MonoBehaviour
{
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

    private void ShowWrongAnswers()
    {
        _showQuestionColourArray = GameObject.FindGameObjectsWithTag("Incorrect");
        foreach (var question in _showQuestionColourArray)
        {
            question.GetComponent<TextMeshPro>().color = Color.red;
        }
    }

    private void ShowRightAnswers()
    {
        _showQuestionColourArray = GameObject.FindGameObjectsWithTag("Correct");
        foreach (var question in _showQuestionColourArray)
        {
            question.GetComponent<TextMeshPro>().color = Color.green;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }
        switch (tag)
        {
            case "Item":
                if (col.CompareTag("Player")) 
                {
                    Destroy(gameObject);
                    _gameManager.UpdateScore(5);
                }
                break;

            case "Enemy":
                if (col.CompareTag("Player"))
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
                break;
            
            case "Incorrect":
                if (col.CompareTag("Player")) 
                {
                    _spawnManager.SetStopSpawn(false);
                    _gameManager.UpdateHealth(1);
                    GetComponent<TextMeshPro>().color = Color.red;
                    _otherRightQuestion.GetComponent<TextMeshPro>().color = Color.green;
                    ShowWrongAnswers();
                    ShowRightAnswers();
                }
                break;
        }
    }
}
