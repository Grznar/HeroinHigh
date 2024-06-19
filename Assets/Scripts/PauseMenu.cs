using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;

    void Start()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
        else
        {
            Debug.LogError("Pause menu GameObject is not assigned in the inspector!");
        }
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (isPaused && Input.GetKeyDown(KeyCode.M))
        {
            GoToMainMenu(); // Pokud je hra pozastavena a hr�� stiskne M, vr�t� se do hlavn�ho menu
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f; // Zastav� b�h hry
            Debug.Log("Game paused");
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f; // Obnov� b�h hry
            Debug.Log("Game resumed");
        }
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Nastav� �as na norm�ln� hodnotu (pokud byl n�hodou pozastaven)
        SceneManager.LoadScene("MejnMenu"); // Na�te sc�nu s hlavn�m menu
    }
}