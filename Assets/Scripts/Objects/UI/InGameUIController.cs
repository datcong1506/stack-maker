using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIController : MonobehaviourSingletonInterface<InGameUIController>
{
    private void Start()
    {
        Time.timeScale = 1;
    }

    public void Pause()
    {
        PasuMenuController.Singleton.Pause();
        gameObject.SetActive(false);
        Time.timeScale = 0;
        
    }
}
