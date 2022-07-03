using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButtonController : MonoBehaviour
{
    public GameObject AlertUIWaitForNewLvUpdate;
    public void LoadNextLevel()
    {
        var currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneBuildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(currentSceneBuildIndex+1);
        }
        else
        {
            //test
            Debug.Log("wait for new update");
        }
    }
}
