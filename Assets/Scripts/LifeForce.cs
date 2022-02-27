using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeForce : MonoBehaviour
{
    protected int healthAmount;
    private Transform effectsFolder;
    private ScoreCounter score;

    [SerializeField] protected int maxHealth = 1;
    [SerializeField] private int scoreAmount = 0;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private AudioSource deathSoundEffect;

    virtual public void Start()
    {
        healthAmount = maxHealth;
        effectsFolder = GameObject.Find("Effects").transform;
        score = GameObject.FindGameObjectsWithTag("Score")[0].GetComponent<ScoreCounter>();
    }

    virtual public void takeDamage(int damage)
    {
        healthAmount -= damage;

        if (healthAmount <= 0)
        {
            Die();
        }
    }

    virtual public void Die()
    {
        deathSoundEffect.Play();
        Instantiate(deathEffect, transform.position, Quaternion.identity, effectsFolder);
        Destroy(gameObject);
        score.AddScore(scoreAmount);
    }
}
