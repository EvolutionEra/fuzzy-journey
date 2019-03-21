using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menucontrol : MonoBehaviour
{
    public void loadmain()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
