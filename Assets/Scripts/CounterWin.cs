using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterWin : MonoBehaviour
{
    [SerializeField] private Text winText;
    public static int Counter;

    private void SetText() 
    {
        winText.text = $"Побед: {Counter}";
    }
    void Update()
    {
        SetText();
    }
}
