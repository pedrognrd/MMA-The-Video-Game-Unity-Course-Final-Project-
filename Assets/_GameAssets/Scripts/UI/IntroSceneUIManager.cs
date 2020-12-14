using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSceneUIManager : MonoBehaviour
{
    public Button buttonContinue;

    public void LoadScene1()
    {
        // Loading Scene1
        PlayerPrefs.DeleteKey("Score");
        SceneManager.LoadScene("Scene1");
    }

    public void ConfigGame()
    {
        // TODO
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
