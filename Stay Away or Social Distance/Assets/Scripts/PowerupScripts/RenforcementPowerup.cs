using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenforcementPowerup : MonoBehaviour
{
    [SerializeField] GameObject enforcerFriendly;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            for (int i = 0; i < 2; i++)
            {
                GameObject instantiateEnforcerFriendly = Instantiate(enforcerFriendly, transform.position, Quaternion.identity);

                instantiateEnforcerFriendly.GetComponent<enforcerMovement>().AddBounds(GameObject.Find("NPCSpawner").GetComponent<Spawner>().npcBounds);
            }
            Destroy(gameObject);
        }
    }
}
