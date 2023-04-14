using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Ball") 
        {
            collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            if(gameObject.name == "FreezeBallUp")
            {
                GameManager.instance.win = true;
            }
        }
    }
}
