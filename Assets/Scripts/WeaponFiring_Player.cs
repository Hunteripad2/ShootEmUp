using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFiring_Player : WeaponFiring
{
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            base.Fire();
        }
    }
}
