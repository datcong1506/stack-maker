using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasuMenuController : MonobehaviourSingletonInterface<PasuMenuController>
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        InGameUIController.Singleton.gameObject.SetActive(true);
        GameStateManager.Singleton.Playing();
    }

    public void Pause()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
