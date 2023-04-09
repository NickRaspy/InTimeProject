using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerBox : MonoBehaviour
{
    public bool isRightAnswer = false;
    public bool isClicked = false;
    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.black;
    }
    private void OnMouseDown()
    {
        if (!isClicked)
        {
            if (isRightAnswer) gameObject.GetComponent<SpriteRenderer>().color = Color.green; else gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            foreach(GameObject g in GameObject.FindGameObjectsWithTag("MathLevel_Box")) if(g != gameObject) g.SetActive(false);
            isClicked = true;
        }
    }
}
