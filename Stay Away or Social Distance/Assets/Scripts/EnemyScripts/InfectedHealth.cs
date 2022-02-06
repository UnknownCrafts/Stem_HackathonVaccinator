using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectedHealth : MonoBehaviour
{
    public int enemyMaxHealth = 100;
    int enemyCurrentHealth;

    public InfectedHealthBar enemyHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
        enemyHealthBar.SetEnemyMaxHealth(enemyMaxHealth);
    }

    public void EnemyTakeDamage(int damage) {
        enemyCurrentHealth -= damage;
        enemyHealthBar.SetEnemyHealth(enemyCurrentHealth);
        if (enemyCurrentHealth <= 0) {
            Destroy(gameObject);
        }
    }
}
