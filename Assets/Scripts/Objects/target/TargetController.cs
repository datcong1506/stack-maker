using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public GameObject close;
    public GameObject open;

    public GameObject partical;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameStateManager.Singleton.GameState = GameState.End;
            close.SetActive(false);
            open.SetActive(true);
            partical.SetActive(true);
        }
    }
}

    
