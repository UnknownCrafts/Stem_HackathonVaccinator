using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private List<BoxCollider2D> bounds = new List<BoxCollider2D>();
    [SerializeField] private List<GameObject> NPC = new List<GameObject>();
    Vector2 randomPosition;

    GameObject SpawnNPC;

    BoxCollider2D randomBounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateNPC();
    }

    public void InstantiateNPC() {
        randomBounds = bounds[Random.Range(0, bounds.Count)];
        SpawnNPC = NPC[Random.Range(0, NPC.Count)];
        Vector2 colliderPos = new Vector2(randomBounds.transform.position.x, randomBounds.transform.position.y) + randomBounds.offset;
        float randomPosX = Random.Range(colliderPos.x - randomBounds.size.x / 2, colliderPos.x + randomBounds.size.x / 2);
        float randomPosY = Random.Range(colliderPos.y - randomBounds.size.y / 2, colliderPos.y + randomBounds.size.y / 2);

        randomPosition = new Vector2(randomPosX, randomPosY);

        
        GameObject instantiatedNPC = Instantiate(SpawnNPC, randomPosition, Quaternion.identity);
}
}
