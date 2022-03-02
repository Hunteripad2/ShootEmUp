using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector] private Transform effectsFolder;

    [Header("Parameters")]
    [SerializeField] private float lifeTime = 2f;
    [SerializeField] private int damage = 1;
    [SerializeField] private string targetType;

    [Header("Effects")]
    [SerializeField] private GameObject hitEffect;

    private void Start()
    {
        effectsFolder = GameObject.Find("Effects").transform;
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        LifeForce targetLife = collider.GetComponent<LifeForce>();

        if (collider.CompareTag(targetType) || collider.CompareTag("Foreground"))
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity, effectsFolder);

            if (targetLife != null)
            {
                targetLife.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
