using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        //BGmusic.instance.gameObject.GetComponent<AudioSource>().Play();
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
        BGmusic.instance.gameObject.GetComponent<AudioSource>().Pause();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
