using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StartGameUiController : MonobehaviourSingletonInterface<StartGameUiController>
{
    private void Start()
    {
        Time.timeScale = 1;
    }

    private Animator _animator => GetComponent<Animator>();
    public void SetAnimTriggerPram(string paramName)
    {
        _animator.SetTrigger(paramName);
    }
    public void QuitGame()
    {
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
