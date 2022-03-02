using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [HideInInspector] private CameraController cam;
    [HideInInspector] private float borderX, borderY;
    [HideInInspector] private Transform objectsFolder;

    [Header("Parameters")]
    [SerializeField] private GameObject[] initialObjectsPool;
    [SerializeField] private int initialObjectsNum = 40;

    private void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
        borderX = cam.borderX + 10f;
        borderY = cam.borderY + 5f;
        objectsFolder = GameObject.Find("Foreground Objects").transform;

        spawnInitialObjects();
    }

    private void spawnInitialObjects()
    {
        for (int i = 0; i < initialObjectsNum; i++)
        {
            GameObject randomObject = initialObjectsPool[Random.Range(0, initialObjectsPool.Length)];

            float posX = Random.Range(-borderX, borderX);
            float posBorderY = (borderY) / initialObjectsNum;
            float posY = Random.Range(-borderY + posBorderY * i, posBorderY * (i + 1));

            Quaternion angle = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)));
            Instantiate(randomObject, new Vector2(posX, posY), angle, objectsFolder);
        }
    }
}
