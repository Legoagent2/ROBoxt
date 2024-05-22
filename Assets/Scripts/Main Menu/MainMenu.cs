using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string scenename;

    public void NewGame()
    {
        SceneManager.LoadScene(scenename);
    }

    public void Quitgame()
    {
        Application.Quit();
    }
}
