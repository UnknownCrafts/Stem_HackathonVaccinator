using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyHealth : MonoBehaviour
{
    public int friendlyMaxHealth = 100;
    int friendlyCurrentHealth;

    public FriendlyHealthBar friendlyHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        friendlyCurrentHealth = friendlyMaxHealth;
        friendlyHealthBar.SetFriendlyMaxHealth(friendlyMaxHealth);
    }

    public void EnemyTakeDamage(int damage) {
        friendlyCurrentHealth -= damage;
        friendlyHealthBar.SetFriendlyHealth(friendlyCurrentHealth);
        if (friendlyCurrentHealth <= 0) {
            Destroy(gameObject);
        }
    }
}
