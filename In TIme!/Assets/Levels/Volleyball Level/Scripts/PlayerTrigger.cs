using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private VolleyballLevelManager vlm;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Body!");
        if (collision.gameObject.name == "Ball" && !vlm.isTouched)
        {
            vlm.isTouched = true;
        }
    }
}
