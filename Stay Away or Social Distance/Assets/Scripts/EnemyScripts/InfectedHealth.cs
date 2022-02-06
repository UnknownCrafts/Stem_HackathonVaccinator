using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectedHealth : MonoBehaviour
{
    public int enemyMaxHealth = 100;
    int enemyCurrentHealth;
    [SerializeField] GameObject friendlyNPC;

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
            GameObject instantiatedNPC = Instantiate(friendlyNPC, gameObject.transform.position, Quaternion.identity);
            instantiatedNPC.GetComponent<FriendlyMovement>().AddBounds(gameObject.GetComponent<InfectedMovement>().bounds);
            Destroy(gameObject);
        }
    }
}
