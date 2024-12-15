using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    [SerializeField]
    private string gameLevel = "Level1";

    // Update is called once per frame
    public void PlayGame()
    {
        SceneManager.LoadScene(gameLevel);
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
