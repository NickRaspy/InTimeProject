using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollision : MonoBehaviour
{
    [SerializeField] private VolleyballLevelManager vlm;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Got it!");
        if (collision.gameObject.name == "Ball" && !vlm.isTouched)
        {
            vlm.isTouched = true;
        }

    }
}
