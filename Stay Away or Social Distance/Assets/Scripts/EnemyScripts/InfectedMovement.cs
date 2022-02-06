using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectedMovement : MonoBehaviour
{

    public Vector2 highBounds;
    public Vector2 lowBounds;

    private Transform target;
    private Vector2 choosePoint;
    public float moveSpeed;
    private Vector2 position;
    [SerializeField] private int attackDamage = 10;
	[SerializeField] private int attackSpeed = 1;
    private float canAttack;


    void SelectLocation()
    {
        choosePoint = new Vector2(Random.Range(lowBounds.x, highBounds.x), Random.Range(highBounds.y, lowBounds.y));
    }
    private void FixedUpdate() {
		if (target != null) {
			float step = moveSpeed * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, target.position, step);
		} else {
            position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            if (Vector2.Distance(choosePoint, position) < 0.001f)
            {
                SelectLocation();
            }
            gameObject.transform.position = Vector2.MoveTowards(position, choosePoint, Time.deltaTime * moveSpeed);
        }
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			if (attackSpeed <= canAttack) {
				other.gameObject.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
				canAttack = 0f;
			} else {
				canAttack += Time.deltaTime;
			}
		}
	}

	private void OnCollisionStay2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			if (attackSpeed <= canAttack) {
				other.gameObject.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
				canAttack = 0f;
			} else {
				canAttack += Time.deltaTime;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			target = other.transform;
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			target = null;
		}
	}
}
