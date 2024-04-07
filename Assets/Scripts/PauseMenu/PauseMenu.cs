using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
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
		Time.timeScale = 1f; // Resume time
        pauseMenu.SetActive(false);
        isPaused = false;
		Debug.Log("Resuming game...");
    }

	public void	Resume_test()
	{
		Time.timeScale = 1f; // Resume time
        pauseMenu.SetActive(false);
        isPaused = false;
		Debug.Log("Resuming game...");
	}

    public void Pause()
    {
		Time.timeScale = 0f; // Pause time
		pauseMenu.SetActive(true);
		isPaused = true;
    }

    public void Quit()
    {
        Debug.Log("Exiting game...");
        Application.Quit();
    }
}
