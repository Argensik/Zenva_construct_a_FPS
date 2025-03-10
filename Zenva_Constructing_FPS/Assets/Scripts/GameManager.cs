﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreToWin;
    public int curScore;

    public bool gamePaused;

    //instance
    public static GameManager instance;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    private void Awake()
    {
        //set the instance to this script
        instance = this;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            TogglePauseGame();
    }

    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked;

        //toggle the pause menu
        GameUI.instance.TogglePauseMenu(gamePaused);
    }

    public void AddScore(int score)
    {
        curScore += score;

        //update the score text
        GameUI.instance.UpdateScoreText(curScore);

        //have we reached the score to win?
        if (curScore >= scoreToWin)
            WinGame();
    }

    void WinGame()
    {
        //set the end game screen
        GameUI.instance.SetEndGameScreen(true, curScore);

        Time.timeScale = 0.0f;
        gamePaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoseGame()
    {
        //set teh endgame screen
        GameUI.instance.SetEndGameScreen(false, curScore);

        Time.timeScale = 0.0f;
        gamePaused = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
