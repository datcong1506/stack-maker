using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayGameUiController : MonoBehaviour
{
    public GameObject PauseButton;



    public void EndInitialAnim()
    {
        PauseButton.SetActive(true);
        GameStateManager.Singleton.Playing();
        
    }
        
}
