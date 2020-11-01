

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    public GameObject timer;
    private float maxHealth = 100f;
    private string player_time;
    public Text timery;
    public AudioSource Death;
    public float health;

    private bool soundPlayer = true;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
        if (healthBar.fillAmount == 0)
        {
            if (soundPlayer)
            {
                Death.Play();
                timer.SetActive(true);
                Time.timeScale = 0f;
                soundPlayer = false;   
            }
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
    }
}
