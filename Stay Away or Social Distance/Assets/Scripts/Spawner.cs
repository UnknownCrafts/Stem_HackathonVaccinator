using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private List<BoxCollider2D> bounds = new List<BoxCollider2D>();
    [SerializeField] private List<GameObject> NPC = new List<GameObject>();

    [SerializeField] private int FriendlyNPC_Count;
    [SerializeField] private int InfectedNPC_Count;
    int iterations;
    Vector2 randomPosition;

    GameObject SpawnNPC;

    BoxCollider2D randomBounds;

    // Start is called before the first frame update
    void Start()
    {
        iterations = FriendlyNPC_Count + InfectedNPC_Count;
    }

    // Update is called once per frame
    void Update()
    {
        while (iterations <=0) {
            for (int i = 0; i < FriendlyNPC_Count; i++)
            {
                InstantiateFriendlyNPC();
                iterations -= 1;
            }
            for (int i = 0; i < InfectedNPC_Count; i++)
            {
                InstantiateInfectedNPC();
                iterations -= 1;
            }
        }
    }
    public void InstantiateFriendlyNPC() {
        randomBounds = bounds[Random.Range(0, bounds.Count)];
        SpawnNPC = NPC[0];
        Vector2 colliderPos = new Vector2(randomBounds.transform.position.x, randomBounds.transform.position.y) + randomBounds.offset;
        float randomPosX = Random.Range(colliderPos.x - randomBounds.size.x / 2, colliderPos.x + randomBounds.size.x / 2);
        float randomPosY = Random.Range(colliderPos.y - randomBounds.size.y / 2, colliderPos.y + randomBounds.size.y / 2);

        randomPosition = new Vector2(randomPosX, randomPosY);

        
        GameObject instantiatedNPC = Instantiate(SpawnNPC, randomPosition, Quaternion.identity);
    }

    public void InstantiateInfectedNPC() {
        randomBounds = bounds[Random.Range(0, bounds.Count)];
        SpawnNPC = NPC[0];
        Vector2 colliderPos = new Vector2(randomBounds.transform.position.x, randomBounds.transform.position.y) + randomBounds.offset;
        float randomPosX = Random.Range(colliderPos.x - randomBounds.size.x / 2, colliderPos.x + randomBounds.size.x / 2);
        float randomPosY = Random.Range(colliderPos.y - randomBounds.size.y / 2, colliderPos.y + randomBounds.size.y / 2);

        randomPosition = new Vector2(randomPosX, randomPosY);

        
        GameObject instantiatedNPC = Instantiate(SpawnNPC, randomPosition, Quaternion.identity);
    }
}
