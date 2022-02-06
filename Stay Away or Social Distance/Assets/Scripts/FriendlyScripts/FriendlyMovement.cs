using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyMovement : MonoBehaviour
{

    public Vector2 highBounds;
    public Vector2 lowBounds;
    private Transform target;
    private Vector2 choosePoint;
    public float moveSpeed;
    private Vector2 position;


    void SelectLocation()
    {
        choosePoint = new Vector2(Random.Range(lowBounds.x, highBounds.x), Random.Range(highBounds.y, lowBounds.y));
    }

    // Update is called once per frame
    void Update()
    {
        position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        if (Vector2.Distance(choosePoint, position) < 0.001f)
        {
            SelectLocation();
        }
        gameObject.transform.position = Vector2.MoveTowards(position, choosePoint, Time.deltaTime * moveSpeed);
    }
}