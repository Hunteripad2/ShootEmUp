using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform enemiesFolder;

    [SerializeField] private float maxSpawnChance = 300f;
    [SerializeField] private float maxSeed = 18000f;
    [SerializeField] private GameObject suicideEnemy;
    [SerializeField] private GameObject lightEnemy;

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

        if (Random.Range(0, maxSeed) < Mathf.Min(spawnChance, maxSpawnChance))
        {
            spawnEnemy(lightEnemy);
        }
    }

    private void spawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, transform.position, Quaternion.identity, enemiesFolder);
    }
}
