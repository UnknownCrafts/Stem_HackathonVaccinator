using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enforcerMovement : MonoBehaviour
{
    public BoxCollider2D bounds = new BoxCollider2D();
    private List<int> targetList = new List<int>();
    private Hashtable targetPositions = new Hashtable();
    public float maxTargetingTime;
    private float timeTargeting;
    private Vector2 choosePoint;
    public float moveSpeed;
    private Vector2 position;
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private int attackSpeed = 1;
    private float canAttack;
    void Start()
    {
        SelectLocation();
    }

    public void AddBounds(BoxCollider2D newBounds) {
        bounds = newBounds;
    }

    void SelectLocation()
    {
        Vector2 boundsPos = new Vector2(bounds.transform.position.x, bounds.transform.position.y) + bounds.offset;
        float randomPosX = Random.Range(boundsPos.x - bounds.size.x / 2, boundsPos.x + bounds.size.x / 2);
        float randomPosY = Random.Range(boundsPos.y - bounds.size.y / 2, boundsPos.y + bounds.size.y / 2);
        choosePoint = new Vector2(randomPosX, randomPosY);
    }
    private void FixedUpdate()
    {

        float step = moveSpeed * Time.deltaTime;

        timeTargeting += Time.deltaTime;
        canAttack += Time.deltaTime;
        if (timeTargeting >= maxTargetingTime && targetList.Count != 0)
        {
            int currentTarget = targetList[0];
            targetPositions.Remove(currentTarget);
            targetList.Remove(currentTarget);
            timeTargeting = 0;
        }
        if (targetList.Count != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, ((Transform)targetPositions[targetList[0]]).position, step);
        }
        else
        {
            position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            if (Vector2.Distance(choosePoint, position) < 0.001f)
            {
                SelectLocation();
            }
            gameObject.transform.position = Vector2.MoveTowards(position, choosePoint, step);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (attackSpeed <= canAttack)
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<InfectedHealth>().EnemyTakeDamage(attackDamage);
                canAttack = 0f;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (attackSpeed <= canAttack)
        {

            if (other.gameObject.tag == "Enemy")
            {

                other.gameObject.GetComponent<InfectedHealth>().EnemyTakeDamage(attackDamage);
                canAttack = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {

            targetList.Add(other.GetInstanceID());
            targetPositions.Add(other.GetInstanceID(), other.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && targetList.Count != 0)
        {
            targetList.Remove(other.GetInstanceID());
            targetPositions.Remove(other.GetInstanceID());
            timeTargeting = 0;
        }
    }
}
