using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Item")
        {
            collision.GetComponent<Rigidbody2D>().Sleep();
            collision.GetComponent<ItemMove>().isInBackpack = true;
            GameManager.instance.win = true;
            Debug.Log("Entered");
        }
    }
}
