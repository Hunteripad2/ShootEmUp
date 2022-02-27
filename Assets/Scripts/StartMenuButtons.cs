using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuButtons : MonoBehaviour
{
    private ScoreCounter score;

    [SerializeField] private AudioSource ButtonSoundEffect;

    private void Start()
    {
        score = GameObject.FindGameObjectsWithTag("Score")[0].GetComponent<ScoreCounter>();
    }

    public void StartGame()
    {
        ButtonSoundEffect.Play();
        score.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartGame()
    {
        ButtonSoundEffect.Play();
        score.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        ButtonSoundEffect.Play();
        Application.Quit();
    }
}
