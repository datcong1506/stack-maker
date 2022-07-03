using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameData",menuName = "Scriptableobject/single/gamedata" )]
public class GameDataManager : ScripableSingletonInterface<GameDataManager>
{
    public int CurrentLevel;
    
}
