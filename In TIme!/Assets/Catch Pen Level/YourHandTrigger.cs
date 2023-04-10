using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourHandTrigger : MonoBehaviour
{
    [SerializeField] private CatchPenManager cpm;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Pen")
        {
            cpm.inHand = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Pen")
        {
            cpm.inHand = false;
        }
    }
}
