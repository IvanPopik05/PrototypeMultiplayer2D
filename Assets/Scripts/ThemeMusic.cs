using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeMusic : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
