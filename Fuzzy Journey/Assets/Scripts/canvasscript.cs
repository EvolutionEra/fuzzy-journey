using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class canvasscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playagain()
    {
        SceneManager.LoadScene("Lawn", LoadSceneMode.Single);
    }

    public void mainmenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void exit()
    {
        Application.Quit();
    }
}
