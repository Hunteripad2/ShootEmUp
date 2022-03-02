using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [Header("Cursor")]
    [SerializeField] private Texture2D crosshairTexture;
    [SerializeField] private float crosshairOffset = 32f;

    private void Start()
    {
        Cursor.SetCursor(crosshairTexture, new Vector2(crosshairOffset, crosshairOffset), CursorMode.Auto);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
