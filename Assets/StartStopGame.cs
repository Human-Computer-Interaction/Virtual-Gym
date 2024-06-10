using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartStopGame : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Gym");
    }
    public void StopGame()
    {
        Application.Quit();
    }
}
