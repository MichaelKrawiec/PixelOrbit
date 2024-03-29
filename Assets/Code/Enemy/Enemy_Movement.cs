using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public GameObject Player;
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Vector3 MoveDirection;
    private bool onRange = false;
    public float range = 1.0f;

    public Rigidbody2D Star_Ship;

    private int maxHealth = 50;
    private int currentHealth;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }


if (onRange)
        {

            moveCharacter(movement);
            onRange = Vector3.Distance(transform.position, player.position) < range;
        }
    
    Vector3 clampedPosition = transform.position;
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        
    }

    void moveCharacter(Vector2 direction)
    {

        if (MoveDirection.magnitude < 1)
        {
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Laser")
        {
            TakeDamage(25);
            Destroy(collision.gameObject);
        }

    }
}
