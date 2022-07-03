using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertSomeWorld : MonoBehaviour
{
    [SerializeField] private string word = "Hello world";
    private void Update()
    {
        Debug.Log(gameObject.name);
    }
}
