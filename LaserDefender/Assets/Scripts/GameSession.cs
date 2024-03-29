﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{

    int score=0;

    private void Awake()
    {
        if(FindObjectsOfType<GameSession>().Length>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int killScore)
    {
        score += killScore;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }


}
