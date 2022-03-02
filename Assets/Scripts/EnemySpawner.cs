using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [HideInInspector] private Transform enemiesFolder;

    [Header("Randomization")]
    [SerializeField] private float maxSpawnChance = 300f;
    [SerializeField] private float maxSeed = 18000f;

    [Header("Enemies")]
    [SerializeField] private GameObject suicideEnemy;
    [SerializeField] private GameObject lightEnemy;
    [SerializeField] private GameObject heavyEnemy;

    private float spawnChance = 0f;

    private void Start()
    {
        enemiesFolder = GameObject.Find("Enemies").transform;
        spawnEnemy(suicideEnemy);
    }

    private void FixedUpdate()
    {
        spawnChance += Time.deltaTime;

        if (Random.Range(0, maxSeed) < Mathf.Min(spawnChance * 2, maxSpawnChance))
        {
            spawnEnemy(suicideEnemy);
        }
        else if (Random.Range(0, maxSeed) < Mathf.Min(spawnChance, maxSpawnChance))
        {
            spawnEnemy(lightEnemy);
        }
        else if (Random.Range(0, maxSeed) < Mathf.Min(spawnChance / 2, maxSpawnChance))
        {
            spawnEnemy(heavyEnemy);
        }
    }

    private void spawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, transform.position, Quaternion.identity, enemiesFolder);
    }
}
