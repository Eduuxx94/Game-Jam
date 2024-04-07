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
		Debug.Log("Resuming game...");
		Time.timeScale = 1f; // Resume time
        pause.SetActive(false);
        isPaused = false;
    }

    public void Pause()
    {
		Debug.Log("Pausing game...");
		optionsMenu.SetActive(false);
		pauseMenu.SetActive(true);
		pause.SetActive(true);
		Time.timeScale = 0f; // Pause time
		isPaused = true;
    }

    public void Quit()
    {
        Debug.Log("Exiting game...");
        Application.Quit();
    }
}
