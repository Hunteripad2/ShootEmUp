using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFiring : MonoBehaviour
{
    [HideInInspector] private Transform projectilesFolder;
    //[HideInInspector] private Transform effectsFolder;
    [HideInInspector] private float lastShot;

    [Header("Prefab")]
    [SerializeField] private GameObject projectilePrefab;

    [Header("Parameters")]
    [SerializeField] private float shotForce = 1000f;
    [SerializeField] private float fireCooldown = 0.15f;

    [Header("Effects")]
    [SerializeField] private GameObject shootEffect;

    virtual public void Start()
    {
        projectilesFolder = GameObject.Find("Projectiles").transform;
        //effectsFolder = GameObject.Find("Effects").transform;
    }

    public void Fire()
    {
        if (Time.time > fireCooldown + lastShot)
        {
            Instantiate(shootEffect, transform.position, transform.rotation, gameObject.transform);
            GameObject projectileGO = Instantiate(projectilePrefab, transform.position, transform.rotation, projectilesFolder);
            projectileGO.GetComponent<Rigidbody2D>().AddForce(projectileGO.transform.up * shotForce);
            lastShot = Time.time;
        }
    }
}
