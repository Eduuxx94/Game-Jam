using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public  GameObject pause;
    public  GameObject pauseMenu;
    public	GameObject optionsMenu;
    public static bool isPaused;

	void Start()
	{
		pause.SetActive(false);
		isPaused = false;
	}

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
		pause.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f; // Resume time
    }

    public void Pause()
    {
		optionsMenu.SetActive(false);
		pauseMenu.SetActive(true);
		pause.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f; // Pause time
    }

    public void Quit()
    {
        Debug.Log("Exiting game...");
        Application.Quit();
    }
}
