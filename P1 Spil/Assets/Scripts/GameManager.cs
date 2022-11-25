using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Code inspired by Unity Learn Lesson 5.2 Keeping Score and modified to fit the project
    /// </summary>

    public int Score;

    private int _health = 3;
    private int _reward;
    
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI RewardText;

    public SpawnManager SpawnManager;
    public GameObject[] FinishedQuestions = new GameObject[5];

    // Start is called before the first frame update
    private void Start()
    {
        SpawnManager = GameObject.Find("GameManager").GetComponent<SpawnManager>();
        HealthText.text = "HP: " + _health;
    }

    public void UpdateScore(int addedScore)
    {
        Score += addedScore;
        ScoreText.text = "Score: " + Score;

        if (Score % 20 != 0 || Score == 0) return;
        SpawnManager.SetStopSpawn(true);
        StartBonusStage();

    }

    private void StartBonusStage()
    {
        var questionIndex = Random.Range(0, SpawnManager.QuestionArray.Length);
        while (FinishedQuestions[questionIndex] != null)
        {
            questionIndex = Random.Range(0, SpawnManager.QuestionArray.Length);
        }
        
        SpawnManager.ActivateQuestion(questionIndex);
        FinishedQuestions[questionIndex] = SpawnManager.QuestionArray[questionIndex];
    }

    public void UpdateHealth(int damageTaken)
    {
        _health -= damageTaken;
        HealthText.text = "HP: " + _health;
        
        if (_health <= 0)
        {
            Application.Quit();
        }
    }
    public int GetScore()
    {
        return Score;
    }

    public void UpdateReward(int addedReward)
    {
        _reward += addedReward;
        RewardText.text = "x " + _reward;
    }
}
