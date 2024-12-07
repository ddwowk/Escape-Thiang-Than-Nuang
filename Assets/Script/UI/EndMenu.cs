using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void Resetart()
    {
        SceneManager.LoadScene("Game");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
