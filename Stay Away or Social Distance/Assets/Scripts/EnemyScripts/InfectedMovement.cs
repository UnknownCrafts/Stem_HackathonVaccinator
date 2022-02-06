using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectedMovement : MonoBehaviour
{

    public Vector2 highBounds;
    public Vector2 lowBounds;

    private Vector2 target;
    public float moveSpeed;
    Rigidbody2D rb;
    private Vector2 position;

    void Start()
    {
        SelectLocation();
    }


    void Update()
    {
        position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        if (Vector2.Distance(target, position) < 0.001f)
        {
            SelectLocation();
        }
        gameObject.transform.position = Vector2.MoveTowards(position, target, Time.deltaTime * moveSpeed);
    }
    void SelectLocation()
    {
        target = new Vector2(Random.Range(lowBounds.x, highBounds.x), Random.Range(highBounds.y, lowBounds.y)).normalized;
    }
}
