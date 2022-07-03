using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[RequireComponent(typeof(VerticalLayoutGroup))]
public class LevelContainerController : MonobehaviourSingletonInterface<LevelContainerController>
{
    public GameObject AvaiableLevelUIElementPrefabs;
    public GameObject UnAvaiableLevelUIElementPrefabs;


    private void Start()
    {
        Initial();
    }

    public void Initial()
    {
        Debug.Log("Run Here");
        var sceneBuildCount = SceneManager.sceneCountInBuildSettings;
        var currentLevel = GameDataManager.Singleton.CurrentLevel;

        var levelsCount = sceneBuildCount - 1; // excepts menu scene

        for (int i = 1; i < levelsCount+1; i++)
        {
            GameObject newEle;
            if (i <= currentLevel)
            {
                newEle=Instantiate(AvaiableLevelUIElementPrefabs);
            }
            else
            {
                newEle = Instantiate(UnAvaiableLevelUIElementPrefabs);
            }
            
            newEle.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Level " + i;
            int iCopy = i;
            newEle.GetComponent<Button>().onClick.AddListener(delegate { SceneManager.LoadScene(iCopy); });
            newEle.transform.SetParent(this.transform);
        }
    }
    
   
}
