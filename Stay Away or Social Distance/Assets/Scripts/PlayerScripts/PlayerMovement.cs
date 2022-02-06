using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    
    Rigidbody2D rb;

    Vector2 movement;

    void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (mousePosition.x > 0f) {
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else if (mousePosition.x < 0f) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void FixedUpdate() {
        rb.velocity = movement*moveSpeed;
    }

    void MovementInput() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveX, moveY).normalized;
    }

    void FaceMouse() {

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (mousePosition.x > 0f) {
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else if (mousePosition.x < 0f) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
