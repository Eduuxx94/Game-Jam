using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public  GameObject pauseMenu;
    private GameObject instaPauseMenu;
    public static bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                Pause();
            else
                Resume();
        }
    }

    public void Resume()
    {
        if (instaPauseMenu)
            Destroy(instaPauseMenu);
        isPaused = false;
        Time.timeScale = 1f; // Resume time
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pause time
        instaPauseMenu = Instantiate(pauseMenu);
        instaPauseMenu.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("Exiting game...");
        Application.Quit();
    }
}