using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if (UNITY_EDITOR)
using UnityEditor;
#endif

public class CatchPenManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D pen;
    [SerializeField] private SpriteRenderer oppositeFingers;
    [SerializeField] private SpriteRenderer yoursFingers;
    [SerializeField] private Sprite fingerOpen;
    [SerializeField] private Sprite fingerClosed;

    public bool inHand = false;
    public bool didClick = false;
    private Touch touch;
    void Start()
    {
        pen.Sleep();
        StartCoroutine(Countdown());
    }
    void Update()
    {
#if UNITY_EDITOR
    if(Input.GetKeyDown(KeyCode.Space)) 
    {
        if (inHand)
        {
            didClick = true;
            pen.Sleep();
            yoursFingers.sprite = fingerClosed;
            yoursFingers.sortingOrder = 3;
        }
        else
        {
            didClick = true;
            yoursFingers.sprite = fingerClosed;
        }
    }
#else
    if(Input.touchCount > 0)
    {
        touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began){
            if (inHand)
            {
                didClick = true;
                pen.Sleep();
                yoursFingers.sprite = fingerClosed;
                yoursFingers.sortingOrder = 3;
            }
            else
            {
                didClick = true;
                yoursFingers.sprite = fingerClosed;
            }
        }
    }
#endif
    }
    IEnumerator Countdown()
    {
        yield return new WaitForSecondsRealtime(3f);
        oppositeFingers.sprite = fingerOpen;
        oppositeFingers.sortingOrder = 1;
        pen.WakeUp();
    }
}
