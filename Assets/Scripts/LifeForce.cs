using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeForce : MonoBehaviour
{
    [HideInInspector] protected int healthAmount;
    [HideInInspector] private Transform effectsFolder;
    [HideInInspector] private ScoreCounter score;

    [Header("Parameters")]
    [SerializeField] protected int maxHealth = 1;
    [SerializeField] private int scoreAmount = 0;

    [Header("Effects")]
    [SerializeField] private GameObject deathEffect;

    virtual public void Start()
    {
        healthAmount = maxHealth;
        effectsFolder = GameObject.Find("Effects").transform;
        score = GameObject.FindGameObjectsWithTag("Score")[0].GetComponent<ScoreCounter>();
    }

    virtual public void TakeDamage(int damage)
    {
        healthAmount -= damage;

        if (healthAmount <= 0)
        {
            Die();
        }
    }

    virtual public void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity, effectsFolder);
        Destroy(gameObject);
        score.AddScore(scoreAmount);
    }
}
