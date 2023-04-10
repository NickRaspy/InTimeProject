using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceDeathZone : MonoBehaviour
{
    [SerializeField] private PlatformMove platform;
    [SerializeField] private SpriteRenderer man;
    [SerializeField] private Sprite cryingMan;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BalanceLevel_Box"))
        {
            platform.canMove = false;
            man.sprite = cryingMan;
        }
    }
}
