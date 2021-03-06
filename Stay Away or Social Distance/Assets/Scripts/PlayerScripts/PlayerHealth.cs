using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;

    HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("Canvas").GetComponentInChildren<HealthBar>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
            SceneManager.LoadScene("Death Scene");
    }


}
