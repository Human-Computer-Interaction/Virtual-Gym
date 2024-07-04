using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartStopGame : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Gym");
        Time.timeScale = 1;
    }
    public void StopGame()
    {
        Application.Quit();
    }
}
