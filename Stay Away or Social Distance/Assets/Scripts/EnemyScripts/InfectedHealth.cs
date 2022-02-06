using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectedHealth : MonoBehaviour
{
    public int enemyMaxHealth = 100;
    int enemyCurrentHealth;

    InfectedHealthBar enemyHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealthBar = GameObject.Find("EnemyCanvas").GetComponentInChildren<InfectedHealthBar>();
        enemyCurrentHealth = enemyMaxHealth;
        enemyHealthBar.SetEnemyMaxHealth(enemyMaxHealth);
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Space)) {
            EnemyTakeDamage(20);
        }
    }

    public void EnemyTakeDamage(int damage) {
        enemyCurrentHealth -= damage;
        enemyHealthBar.SetEnemyHealth(enemyCurrentHealth);
    }
}
