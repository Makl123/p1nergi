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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int addedScore)
    {
        score += addedScore;
        scoreText.text = "Score: " + score;
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
