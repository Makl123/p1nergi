using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Code inspired by Unity Learn Lesson 2.3 - Random Animal Stampede and Unity Learn Lesson 2.4 - Collision Decisions and modified to fit this project.
/// </summary>
public class SpawnManager : MonoBehaviour
{
    public GameObject[] ObjectPrefabs;
    public GameObject[] QuestionArray;

    private float _spawnRangeX = 5f;
    private float _spawnInterval = 1.5f;
    private float _currentSpeed = 3f;
    private float _timer = 0f;
    private bool _stopSpawn = false;

    private void FixedUpdate()
    {
        if (_stopSpawn) return;

        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            _timer = 0;
            SpawnRandomObject();
        }
    }

    public void SetStopSpawn(bool b)
    {
        _stopSpawn = b;
    }

    private void SpawnRandomObject()
    {
        int objectIndex = Random.Range(0, ObjectPrefabs.Length);
        Vector2 spawnPos = new Vector2(Random.Range(-_spawnRangeX, _spawnRangeX), 6);

        GameObject obj = Instantiate(ObjectPrefabs[objectIndex], spawnPos, ObjectPrefabs[objectIndex].transform.rotation); //Saving the instantiated game object as a variable so it is easier to call
        obj.GetComponent<ObjectMovement>().UpdateSpeed(_currentSpeed); //Call the UpdateSpeed method on the game object using _currentSpeed as input 
    }

    public void ActivateQuestion(int index)
    {
        QuestionArray[index].SetActive(true);
        _currentSpeed++;
    }
}
