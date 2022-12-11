using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    //All of this can be done by one method
    public void GoToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GoToStartMenu() 
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void GoToLearnMore()
    {
        SceneManager.LoadScene("LearnMore");
    }

    public void GoToTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }
}
