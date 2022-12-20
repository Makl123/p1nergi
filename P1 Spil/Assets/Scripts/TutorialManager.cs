using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public List<GameObject> objectList;

    private float _spawnRangeX = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 1;
            { }

            Destroy(GameObject.FindWithTag("InfoBox"));
        }

        if (GameObject.FindGameObjectWithTag("Item") == null)
        {
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {

                SpawnRandomObject();

            } 
        }

        StartCoroutine(GoToMainGame());

        IEnumerator GoToMainGame()
        {
            yield return new WaitForSeconds(2);

            if (GameObject.FindGameObjectWithTag("Item") == null)
            {
                if (GameObject.FindGameObjectWithTag("Enemy") == null)
                {
                    SceneManager.LoadScene("MainGame");
                }
            }
        }
    }

    private void SpawnRandomObject()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-_spawnRangeX, _spawnRangeX), 6);

        Instantiate(objectList[0], spawnPos, objectList[0].transform.rotation);
        objectList.Remove(objectList[0]);
    }
}