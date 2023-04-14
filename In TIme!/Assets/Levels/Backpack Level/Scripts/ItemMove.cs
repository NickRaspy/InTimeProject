using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if (UNITY_EDITOR)
using UnityEditor;
#endif

public class ItemMove : MonoBehaviour
{
    private Touch touch;
    private Rigidbody2D rb;

    public bool isTouchingItem = false;
    public bool isInBackpack = false;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }
    private void OnMouseDown()
    {
        rb.Sleep();
        isTouchingItem = true;
    }
    private void OnMouseUp()
    {
        rb.WakeUp();
        isTouchingItem = false;
    }
    private void FixedUpdate()
    {
#if (UNITY_EDITOR)
        if (isTouchingItem && !isInBackpack)
        {
            rb.MovePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
#else
if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved && isTouchingItem && !isInBackpack)
            {
                rb.MovePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }
#endif

    }
}
