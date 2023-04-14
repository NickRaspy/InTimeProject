using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [Serializable]
    public enum ObstacleType
    {
        Spike, SquashUp, SquashDown
    }
    [SerializeField]private ObstacleType type;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(type == ObstacleType.Spike && collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerControl>().Death();
        }
    }
}
