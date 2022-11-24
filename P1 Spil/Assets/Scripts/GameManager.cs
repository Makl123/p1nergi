using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Code inspired by Unity Learn Lesson 5.2 Keeping Score and modified to fit the project
    /// </summary>

    public int score;

    private int health = 3;
    private int reward;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI rewardText;

    public SpawnManager spawnManager;
    

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("GameManager").GetComponent<SpawnManager>();
        Debug.Log("Spawn manager exist on: " + spawnManager.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void UpdateScore(int addedScore)
    {
        score += addedScore;
        scoreText.text = "Score: " + score;

        if (score%10 == 0 && score != 0)
        {
            spawnManager.SetStopSpawn(true);
            StartBonusStage();
        }
        
    }

    public void StartBonusStage()
    {
        int questionIndex = Random.Range(0, spawnManager.questionArray.Length);
        if (spawnManager.questionArray[questionIndex].activeInHierarchy) return;
        spawnManager.ActivateQuestion(questionIndex);
    }

    public void UpdateHealth(int damageTaken)
    {
        health -= damageTaken;
        healthText.text = "HP: " + health;
            
        if (health <= 0)
        {
            Debug.Log("You are dead");
        }
    }
    public int GetScore()
    {
        return score;
    }

    public void UpdateReward(int addedReward)
    {
        reward += addedReward;
        rewardText.text = "x " + reward;
    }
}
