using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFiring_Enemy : WeaponFiring
{
    private EnemyController enemy;

    [SerializeField] private float minimalDistance = 10f;

    override public void Start()
    {
        base.Start();

        enemy = transform.parent.GetComponent<EnemyController>();
    }

    private void FixedUpdate()
    {
        if (enemy.currentDistance <= minimalDistance)
        {
            base.Fire();
        }
    }
}
