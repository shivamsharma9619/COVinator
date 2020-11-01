using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    public void loadMain()
    {
        SceneManager.LoadScene("main");
    }

    public void Quitgame()
    {
        Application.Quit();
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void openHelp()
    {
        SceneManager.LoadScene("help");
    }
}
