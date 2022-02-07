using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    [SerializeField] private List<BoxCollider2D> bounds = new List<BoxCollider2D>();
    [SerializeField] private List<GameObject> powerUps = new List<GameObject>();

    GameObject SpawnPowerup;
    BoxCollider2D randomBounds;

    Vector2 randomPosition;

    float coolDown;
    float setCoolDown = 30f;

    void Start() {
        coolDown = setCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (coolDown <= 0) {
            for (int i = 0; i < 3; i++)
            {
                InstantiatePowerup();
            }
            coolDown = setCoolDown;

        } else {
            coolDown -= Time.deltaTime;
        }
    }

    void InstantiatePowerup() {
        randomBounds = bounds[Random.Range(0, bounds.Count)];
        SpawnPowerup = powerUps[Random.Range(0, powerUps.Count)];
        Vector2 colliderPos = new Vector2(randomBounds.transform.position.x, randomBounds.transform.position.y) + randomBounds.offset;
        float randomPosX = Random.Range(colliderPos.x - randomBounds.size.x / 2, colliderPos.x + randomBounds.size.x / 2);
        float randomPosY = Random.Range(colliderPos.y - randomBounds.size.y / 2, colliderPos.y + randomBounds.size.y / 2);

        randomPosition = new Vector2(randomPosX, randomPosY);

        GameObject instantiatedPowerup = Instantiate(SpawnPowerup, randomPosition, Quaternion.identity);
    }
}
