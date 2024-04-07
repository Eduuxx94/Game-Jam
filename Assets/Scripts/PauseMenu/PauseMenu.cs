using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pause;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public static bool isPaused;

	void Start()
	{
		pauseMenu.SetActive(false);
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
		pauseMenu.SetActive(false);
		isPaused = false;
		Time.timeScale = 1f; // Resume time
		Debug.Log("Resuming game...");
    }

    public void Pause()
    {
		Debug.Log("Pausing game...");
		optionsMenu.SetActive(false);
		pause.SetActive(true);
		pauseMenu.SetActive(true);
		Time.timeScale = 0f; // Pause time
		isPaused = true;
    }

    public void Quit()
    {
        Debug.Log("Exiting game...");
        Application.Quit();
    }
}
