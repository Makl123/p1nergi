using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenHit : MonoBehaviour
{
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
        if (tag == "Item")
        {
            Destroy(gameObject); 
            gameManager.UpdateScore(5); 
        }

        if (tag == "Enemy")
        {
            Destroy(gameObject);
            gameManager.UpdateHealth(1);
        }
       
    }
}
