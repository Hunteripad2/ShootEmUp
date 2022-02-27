using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] public float borderX = 36f;
    [SerializeField] public float borderY = 34f;

    void Update()
    {
        float posX = transform.position.x;
        float posY = transform.position.y;

        if (player.position.x > -borderX && player.position.x < borderX)
        {
            posX = player.position.x;
        }
        if (player.position.y > -borderY && player.position.y < borderY)
        {
            posY = player.position.y;
        }

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
