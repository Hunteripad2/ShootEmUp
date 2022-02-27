using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFiring : MonoBehaviour
{
    private Transform projectilesFolder;
    private Transform effectsFolder;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float shotForce = 1000f;
    [SerializeField] private float fireCooldown = 0.15f;
    [SerializeField] private GameObject shootEffect;

    private float lastShot = 0f;

    virtual public void Start()
    {
        projectilesFolder = GameObject.Find("Projectiles").transform;
        effectsFolder = GameObject.Find("Effects").transform;
    }

    public void Fire()
    {
        if (Time.time > fireCooldown + lastShot)
        {
            Instantiate(shootEffect, transform.position, transform.rotation, effectsFolder);
            GameObject projectileGO = Instantiate(projectilePrefab, transform.position, transform.rotation, projectilesFolder);
            projectileGO.GetComponent<Rigidbody2D>().AddForce(projectileGO.transform.up * shotForce);
            lastShot = Time.time;
        }
    }
}
