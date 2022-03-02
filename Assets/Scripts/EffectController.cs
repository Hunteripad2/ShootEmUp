using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    [Header("Sound Effects")]
    [SerializeField] private AudioSource[] soundEffects;

    private void Start()
    {
        if (soundEffects.Length != 0)
        {
            int randomIndex = Random.Range(0, soundEffects.Length);
            soundEffects[randomIndex].Play();
        }
    }

    private void RemoveEffect()
    {
        Destroy(gameObject);
    }
}
