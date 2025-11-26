using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UIMEnd : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = (Mathf.Round(GameManager.Instance.timeAlive).ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonMenu()
    {
        SceneManager.LoadScene("Menu");
        GameManager.Instance.InitGame();
    }

    public void ButtonGame()
    {
        SceneManager.LoadScene("Game");
        GameManager.Instance.InitGame();
    }

    public void ButtonExit()
    {
        Application.Quit();
    }
}
