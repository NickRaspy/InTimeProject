using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTransition : MonoBehaviour
{
    [SerializeField] private MenuUI mui;
    void StartLevel()
    {
        mui.LevelStart();
    }
}
