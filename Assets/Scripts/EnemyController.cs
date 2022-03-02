using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [HideInInspector] private Rigidbody2D rb;
    [HideInInspector] private Transform player;
    [HideInInspector] private Vector2 playerPos;
    [HideInInspector] public float currentDistance;

    [Header("Movement")]
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float optimalDistance = 5f;

    [Header("Collision")]
    [SerializeField] private int collisionDamage = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    private void FixedUpdate()
    {
        playerPos = player.position;
        MoveToPlayer();
        RotateToPlayer();
    }

    private void MoveToPlayer()
    {
        currentDistance = Vector2.Distance(playerPos, transform.position);

        if (currentDistance > optimalDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos, Time.deltaTime * movementSpeed);
        }
    }

    private void RotateToPlayer()
    {
        playerPos -= (Vector2)transform.position;

        float angle = Mathf.Atan2(playerPos.y, playerPos.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<LifeForce>().TakeDamage(collisionDamage);
            GetComponent<LifeForce>().TakeDamage(collisionDamage);
        }
    }
}
