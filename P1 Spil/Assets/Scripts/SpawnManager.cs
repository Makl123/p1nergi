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

    private float timer = 0f;
    [SerializeField]
    private bool stopSpawn = false;
    
    // Start is called before the first frame update
    void Start()
    {
       // InvokeRepeating("SpawnRandomObject",startDelay,spawnInterval);
       //questionText.gameObject.SetActive(false);
       //SetDeactivate();
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

    public void SetDeactivate()
    {
        foreach (GameObject question in questionArray)
        {
            question.SetActive(false);
        }
    }


    public void SetStopSpawn(bool b)
    {
        Debug.Log("Stop spawn is set to" + b);
        stopSpawn = b;
    }
    public void SpawnRandomObject()
    {
        int objectIndex = Random.Range(0, objectPrefabs.Length);
        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), 6);

        Instantiate(objectPrefabs[objectIndex], spawnPos, objectPrefabs[objectIndex].transform.rotation);
    }

    public void ActivateQuestion(int index)
    {
        questionArray[index].SetActive(true);
    }
}
