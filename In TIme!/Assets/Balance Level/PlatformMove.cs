using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using Unity.VisualScripting;
#if (UNITY_EDITOR)
using UnityEditor;
#endif

public class PlatformMove : MonoBehaviour
{
    [SerializeField] GameObject block1;
    [SerializeField] GameObject block2;
    [SerializeField] GameObject block3;
    [SerializeField] GameObject hint;
    bool isMoving = false;
    public float speed;
    public float blockSpeed = 2f;
    public bool canMove = true;
    private Touch touch;
    // Update is called once per frame
    void Update()
    {
        float h = default;
#if UNITY_EDITOR
    h = Input.GetAxis("Horizontal");
        if (h != 0 && !hint.IsDestroyed()) Destroy(hint);
#else
    if(Input.touchCount > 0)
    {
        touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Moved)
        {
            if(!hint.IsDestroyed()) Destroy(hint);
            h = touch.deltaPosition.x/10;
        }
    }
#endif

        if (canMove) transform.Translate(h * speed * Time.deltaTime, 0, 0);
        if (h != 0) isMoving = true; else isMoving = false;
        if (!isMoving && canMove)
        {
            if(block1.transform.position.x < 0)
            {
                block1.transform.Translate(-blockSpeed * Time.deltaTime / 6,0,0);
                block2.transform.Translate(-blockSpeed * Time.deltaTime / 3, 0, 0);
                block3.transform.Translate(-blockSpeed * Time.deltaTime / 2, 0, 0);
            }
            else
            {
                block1.transform.Translate(blockSpeed * Time.deltaTime / 6, 0, 0);
                block2.transform.Translate(blockSpeed * Time.deltaTime / 3, 0, 0);
                block3.transform.Translate(blockSpeed * Time.deltaTime / 2, 0, 0);
            }
        }
        if(isMoving && canMove)
        {
            block1.transform.Translate(h*blockSpeed * Time.deltaTime / 3, 0, 0);
            block2.transform.Translate(h*blockSpeed * Time.deltaTime / 2, 0, 0);
            block3.transform.Translate(h*blockSpeed * Time.deltaTime, 0, 0);
        }
    }
}
