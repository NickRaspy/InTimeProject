using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTransition : MonoBehaviour
{
    void GameStart()
    {
        if (!GameManager.instance.isMiniGamePlayed) GameManager.instance.MiniGameStart();
        else GameManager.instance.MiniGameEnd();
    }
    void PrepareToStart()
    {
        if (!GameManager.instance.isMiniGamePlayed)
        {
            GameManager.instance.MiniGameSet();
            GameManager.instance.LevelTitleSet();
        }
    }
}
