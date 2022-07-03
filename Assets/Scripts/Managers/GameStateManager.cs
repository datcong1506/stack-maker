using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class GameStateManager : MonobehaviourSingletonInterface<GameStateManager>
{
    public GameState _gameState;

    public GameState GameState
    {
        get
        {
            return _gameState;
        }
        set
        {
            if(value==_gameState) return;
            
            _gameState=value;
            switch (_gameState)
            {
                case GameState.End:
                    OnEndGameEvent?.Invoke();
                    break;
            }
        }
        
    }

    public UnityEvent OnEndGameEvent;
    
    
    public GameObject EndLevelUi;
    public GameObject MainGameUi;
    public TextMeshProUGUI stackCountText;
    public CinemachineVirtualCamera camEnd;
    private void Start()
    {
        GameState = GameState.Initial;
        OnEndGameEvent.AddListener(End);
    }
    
    private void End()
    {
        GameDataManager.Singleton.CurrentLevel++;
        
        camEnd.Priority = 11;
        StartCoroutine(EndDelay());
    }

    IEnumerator  EndDelay()
    {
        yield return new WaitForSeconds(3f);
        EndLevelUi.SetActive(true);
        MainGameUi.SetActive(false);
    }

    public void Pause()
    {
        this.GameState = GameState.Pause;
    }

    public void Playing()
    {
        this.GameState = GameState.Playing;
    }
    
}

public enum GameState{
    Initial,
    Playing,
    Pause,
    End,
}

