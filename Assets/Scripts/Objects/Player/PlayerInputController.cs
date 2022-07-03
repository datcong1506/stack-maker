using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{

    private GameInputs.PlayerActions _playerActions;
    private PlayerController _playerController => GetComponent<PlayerController>();
    private void OnEnable()
    {
        _playerActions = GameInputManager.Singleton.GameInputs.Player;
        if (!_playerActions.enabled)
        {
            _playerActions.Enable();
        }
        
    }

    private Vector2 startPosision;
    private Vector2 endPosision;
    private void Update()
    {
        if(GameStateManager.Singleton.GameState!=GameState.Playing) return;
        if (_playerActions.MoveTouch.WasPressedThisFrame())
        {

            StartCoroutine(InvalidInput());
        }
        
    }

    IEnumerator InvalidInput()
    {

        startPosision = _playerActions.TouchPosision.ReadValue<Vector2>();
        while (_playerActions.MoveTouch.inProgress)
        {
            yield return null;
        }

        endPosision = _playerActions.TouchPosision.ReadValue<Vector2>();

        var direc = endPosision - startPosision;
        direc.Normalize();


        var inputDirec = new Vector3();
        if (direc != Vector2.zero)
        {
            if (direc.x > 0)
            {
                if (direc.y > 0)
                {
                    if (direc.x > direc.y)
                    {
                        inputDirec = Vector3.right;
                    }
                    else
                    {
                        inputDirec=Vector3.up;
                    }
                }
                else
                {
                    
                }
            }
        }

        inputDirec = Vector3.right * direc.x + Vector3.forward * direc.y;

        if (Mathf.Abs(inputDirec.x) > Mathf.Abs(inputDirec.z))
        {
            inputDirec.z = 0;
        }
        else
        {
            inputDirec.x = 0;
        }
        inputDirec.Normalize();

        _playerController.inputDirec = inputDirec;
    }
}
