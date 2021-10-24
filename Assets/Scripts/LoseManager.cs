using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseManager : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    
}
