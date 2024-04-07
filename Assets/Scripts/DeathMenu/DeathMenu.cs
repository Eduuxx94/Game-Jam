using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
	public GameObject menu;
	public GameObject uidocument;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Health.death_flag)
		{
			uidocument.SetActive(false);
			menu.SetActive(true);
		}
    }

	public void Retry()
	{
		menu.SetActive(false);
		uidocument.SetActive(true);
		SceneManager.LoadSceneAsync(1);
		Health.death_flag = false;
	}

	public void MainMenu()
	{
		menu.SetActive(false);
		uidocument.SetActive(true);
		SceneManager.LoadSceneAsync(0);
		Health.death_flag = false;
	}
}
