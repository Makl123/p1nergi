using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    /// <summary>
    /// Code inspired by Unity Learn Lesson 2.3 - Random Animal Stampede and Unity Learn Lesson 2.4 - Collision Decisions and modified to fit this project.
    /// </summary>
    
    public GameObject[] objectPrefabs;
    public GameObject[] questionArray;

    public TextMeshProUGUI questionText;

    private float spawnRangeX = 5F;

    private float startDelay = 2F;

    private float spawnInterval = 1.5F;

    public GameManager gameManager;

    private List<string> questions = new List<string>()
    {
        "How many people live in the sub-Saharan Africa?",
        "What percentage of the World's population does sub-Saharan Africa consist of?",
        "In 2021, how many people in the sub-Saharan Africa were without electricity?",
        "In 2021, how many people in the sub-Saharan Africa were without access to clean cooking?",
        "What is the goal of the seventh Sustainable Development Goal?",
    };

    


    private float timer = 0f;
    [SerializeField]
    private bool stopSpawn = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("SpawnRandomObject",startDelay,spawnInterval);
        questionText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (stopSpawn) return;
        
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0;
            SpawnRandomObject();
        }
        
    }


    public void SetStopSpawn(bool b)
    {
        stopSpawn = b;
    }
    void SpawnRandomObject()
    {
        int objectIndex = Random.Range(0, objectPrefabs.Length);
        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), 6);

        Instantiate(objectPrefabs[objectIndex], spawnPos, objectPrefabs[objectIndex].transform.rotation);
    }

}
