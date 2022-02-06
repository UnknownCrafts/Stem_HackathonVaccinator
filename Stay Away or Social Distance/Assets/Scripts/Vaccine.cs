using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaccine : MonoBehaviour
{

    [HideInInspector] public float VaccineVelocity;


    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10f);
    }


    private void FixedUpdate() {
        rb.velocity = transform.up * VaccineVelocity;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            other.GetComponent<InfectedHealth>().EnemyTakeDamage(100);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
