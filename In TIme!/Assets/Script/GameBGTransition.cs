using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBGTransition : MonoBehaviour
{
    void CheckWin() 
    {
        GameManager.instance.WinCheck();
    }
}
