using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu_Principal : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Run()
    {
        SceneManager.LoadSceneAsync(6);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
