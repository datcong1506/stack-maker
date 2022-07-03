using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevelUIController : MonoBehaviour
{
    public TextMeshProUGUI stackCountText;
    [SerializeField] private AnimationCurve countPlusCurve;
    private void OnEnable()
    {

        if (SceneManager.GetActiveScene().buildIndex >= SceneManager.sceneCountInBuildSettings-1)
        {
            var nextButton = GameObject.Find("NextLevelButton");
            if (nextButton != null)
            {
                Destroy(nextButton);
            }
        }
        StartCoroutine(StackCountAnim(StackController.Singleton.stacks.Count));
    }
    
    IEnumerator StackCountAnim(int count)
    {

        float initialTime = 0;

        while (initialTime<3)
        {
            initialTime += Time.deltaTime;
            stackCountText.text = "" + Math.Round(count * countPlusCurve.Evaluate(initialTime),0);
            yield return null;
        }
    }
}
