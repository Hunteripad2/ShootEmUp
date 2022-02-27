using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform effectsFolder;
    //private enum targetType { player, enemy }

    [SerializeField] private float lifeTime = 2f;
    [SerializeField] private int damage = 1;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private string targetType;
    [SerializeField] private AudioSource shootSoundEffect;

    private void Start()
    {
        effectsFolder = GameObject.Find("Effects").transform;
        shootSoundEffect.Play();
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(targetType) || collider.CompareTag("Foreground"))
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity, effectsFolder);
            Destroy(gameObject);
        }

        if (collider.CompareTag(targetType))
        {
            collider.GetComponent<LifeForce>().takeDamage(damage);
        }
    }
}
