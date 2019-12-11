﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 1000;
    public int currentHealth;
    public Slider healthBar;

    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public Image damageImage;



    FirstPersonAIO playerController;
    bool isDead;
    bool damaged;

    void OnTriggerEnter(Collider other)
    {
        healthBar.value -= 10;
    }

    void Awake()
    {

        playerController = GetComponent<FirstPersonAIO>();

        currentHealth = startingHealth;
    }


    void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
            
            if (currentHealth <= 0 && !isDead)
            {

            Death();
            SceneManager.LoadScene("SampleScene");
        }
    }


    void Death()
    {
        isDead = true;
        playerController.enabled = false;
    }
}

