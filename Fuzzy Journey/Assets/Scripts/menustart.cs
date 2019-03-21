using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menustart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void loadstart()
    {
        SceneManager.LoadScene("Lawn", LoadSceneMode.Single);
    }

    public void loadcontrols()
    {
        SceneManager.LoadScene("Controls", LoadSceneMode.Single);
    }

    public void loadexit()
    {
        Application.Quit();
    }
}
