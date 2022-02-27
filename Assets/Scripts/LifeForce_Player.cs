using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeForce_Player : LifeForce
{
    private RectTransform healthBar;

    [SerializeField] private AudioSource damageSoundEffect;

    override public void Start()
    {
        base.Start();

        healthBar = (RectTransform)GameObject.FindGameObjectsWithTag("Health Bar")[0].transform;
    }

    override public void takeDamage(int damage)
    {
        base.takeDamage(damage);

        damageSoundEffect.Play();
        healthBar.localScale = new Vector2((float)healthAmount / (float)maxHealth, 1);
    }

    override public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
