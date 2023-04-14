using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    [SerializeField] private GameObject gate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            gate.GetComponent<Animator>().Play("Close");
            collision.GetComponent<PlayerControl>().camera = null;
        }
    }
}
