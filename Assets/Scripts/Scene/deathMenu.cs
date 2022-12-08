using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathMenu : MonoBehaviour
{
    public void backToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
