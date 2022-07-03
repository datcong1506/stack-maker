using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameInput",menuName = "Scriptableobject/single/gameinput")]
public class GameInputManager : ScripableSingletonInterface<GameInputManager>
{
    private GameInputs _gameInputs;

    public GameInputs GameInputs
    {
        get
        {
            if (_gameInputs == null)
            {
                _gameInputs = new GameInputs();
            }

            return _gameInputs;
        }
    }
}
