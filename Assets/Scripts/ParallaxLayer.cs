using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    private Vector3 initPos;
    private Transform mainCam;

    [SerializeField] private float movementForce = 1f;

    private float movementScaleY = 0.75f;

    private void Start()
    {
        initPos = transform.position;
        mainCam = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        float newPosX = initPos.x + mainCam.position.x * movementForce;
        float newPosY = initPos.y + mainCam.position.y * movementForce * movementScaleY;
        transform.position = new Vector2(newPosX, newPosY);
    }
}
