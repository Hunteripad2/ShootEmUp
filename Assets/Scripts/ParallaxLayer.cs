using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [HideInInspector] private Vector3 initPos;
    [HideInInspector] private Transform mainCam;

    [Header("Movement")]
    [SerializeField] private float movementForce = 1f;
    [SerializeField] private float movementScaleY = 0.75f;

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
