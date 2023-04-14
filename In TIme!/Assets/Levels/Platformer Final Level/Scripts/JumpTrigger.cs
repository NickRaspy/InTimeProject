using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.parent.GetComponent<PlayerControl>().canJump = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.parent.GetComponent<PlayerControl>().canJump = false;
    }
}
