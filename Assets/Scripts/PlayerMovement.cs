using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] private Rigidbody2D rb;
    [HideInInspector] private CameraController cam;
    [HideInInspector] private float borderX, borderY;

    [Header("Movement")]
    [SerializeField] private float movementSpeed = 15f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main.GetComponent<CameraController>();
        borderX = cam.borderX + 10f;
        borderY = cam.borderY + 5f;
    }

    private void Update()
    {
        MoveByAxis();
    }
    private void FixedUpdate()
    {
        RotateToMouse();
        ClampPosition();
    }

    private void MoveByAxis()
    {
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(dirX * movementSpeed, dirY * movementSpeed);
    }

    private void ClampPosition()
    {
        float posX = Mathf.Clamp(transform.position.x, -borderX, borderX);
        float posY = Mathf.Clamp(transform.position.y, -borderY, borderY);
        transform.position = new Vector2(posX, posY);
    }

    private void RotateToMouse()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 playerPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos -= playerPos;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
