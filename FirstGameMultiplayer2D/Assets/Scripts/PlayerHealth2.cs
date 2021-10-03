using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth2 : MonoBehaviour
{
    [SerializeField] float healthMax = 100;
    [SerializeField] Text healthText;
    [SerializeField] Slider healthSlider;
    private static float _health;
    private void GetHealth()
    {
        healthSlider.value = _health / healthMax;
        healthText.text = _health.ToString();
    }
    void Start()
    {
        _health = healthMax;
    }
    private void Update()
    {
        GetHealth();
    }
    public static void TakingLives(float amount)
    {
        _health -= amount;
        _health = Mathf.Clamp(_health, 0, 100);
        if (_health == 0) 
        {
            CounterWin2.Counter++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
