﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("Title Screen");
    }

    public void ExitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
