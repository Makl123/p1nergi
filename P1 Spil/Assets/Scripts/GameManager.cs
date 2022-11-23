using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Code inspired by Unity Learn Lesson 5.2 Keeping Score and modified to fit the project
    /// </summary>
    
    private int score;
    private int health = 3;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    public SpawnManager spawnManager;
    

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("GameManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void UpdateScore(int addedScore)
    {
        score += addedScore;
        scoreText.text = "Score: " + score;

        if (score%100 == 0 && score != 0)
        {
            spawnManager.SetStopSpawn(true);
            StartBonusStage();
        }
        
    }

    public void StartBonusStage()
    {
        spawnManager.questionText.gameObject.SetActive(true);
        int questionIndex = Random.Range(0, spawnManager.questionArray.Length);
        Vector2 spawnPos = new Vector2(0, 6);

        Instantiate(spawnManager.questionArray[questionIndex], spawnPos, spawnManager.questionArray[questionIndex].transform.rotation);

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
   
}
