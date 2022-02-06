using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyMovement : MonoBehaviour
{

    public BoxCollider2D bounds = new BoxCollider2D();
    private Transform target;
    private Vector2 choosePoint;
    public float moveSpeed;
    private Vector2 position;

    void Start()
    {
        SelectLocation();
    }
    public void AddBounds(BoxCollider2D newBounds)
    {
        bounds = newBounds;
    }
    void SelectLocation()
    {
        Vector2 boundsPos = new Vector2(bounds.transform.position.x, bounds.transform.position.y) + bounds.offset;
        float randomPosX = Random.Range(boundsPos.x - bounds.size.x / 2, boundsPos.x + bounds.size.x / 2);
        float randomPosY = Random.Range(boundsPos.y - bounds.size.y / 2, boundsPos.y + bounds.size.y / 2);
        choosePoint = new Vector2(randomPosX, randomPosY);
        print(choosePoint);
    }

    void FixedUpdate()
    {
        position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        print(position);
        if (Vector2.Distance(choosePoint, position) < 0.001f)
        {
            SelectLocation();
        }
        gameObject.transform.position = Vector2.MoveTowards(position, choosePoint, Time.deltaTime * moveSpeed);
    }
}
