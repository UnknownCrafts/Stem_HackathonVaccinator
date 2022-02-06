using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyHealth : MonoBehaviour
{
    public int friendlyMaxHealth = 100;
    int friendlyCurrentHealth;
    [SerializeField] GameObject infectedNPC;

    public FriendlyHealthBar friendlyHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        friendlyCurrentHealth = friendlyMaxHealth;
        friendlyHealthBar.SetFriendlyMaxHealth(friendlyMaxHealth);
    }

    public void FriendlyTakeDamage(int damage)
    {
        friendlyCurrentHealth -= damage;
        friendlyHealthBar.SetFriendlyHealth(friendlyCurrentHealth);
        if (friendlyCurrentHealth <= 0)
        {
            FindObjectOfType<AudioManager>().Play("NormalToInfect");
            GameObject instantiatedNPC = Instantiate(infectedNPC, gameObject.transform.position, Quaternion.identity);
            instantiatedNPC.GetComponent<InfectedMovement>().AddBounds(gameObject.GetComponent<FriendlyMovement>().bounds);
            Destroy(gameObject);
        }
    }
}
