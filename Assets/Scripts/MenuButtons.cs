using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ArenaOne()
    {
        SceneManager.LoadScene("Arena1");
    }

    public void ArenaTwo()
    {
        SceneManager.LoadScene("Arena2");
    }

    /*
     public void ArenaThree()
    {
        SceneManager.LoadScene("");
    }

    */

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void EndGame()
    {
        Application.Quit();
        Debug.Log("Application has been snapped.");
    }
}
