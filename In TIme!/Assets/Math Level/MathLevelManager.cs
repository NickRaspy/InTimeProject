using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathLevelManager : MonoBehaviour
{
    [Header("Number Sprites")]
    [SerializeField] private Sprite zero;
    [SerializeField] private Sprite one;
    [SerializeField] private Sprite two;
    [SerializeField] private Sprite three;
    [SerializeField] private Sprite four;
    [SerializeField] private Sprite five;
    [SerializeField] private Sprite six;
    [SerializeField] private Sprite seven;
    [SerializeField] private Sprite eight;
    [SerializeField] private Sprite nine;
    [SerializeField] private Sprite plus;
    [SerializeField] private Sprite minus;
    [SerializeField] private Sprite divide;
    [SerializeField] private Sprite multi;
    [Header("Task Objects")]
    [SerializeField] private SpriteRenderer leftNumber1;
    [SerializeField] private SpriteRenderer leftNumber2;
    [SerializeField] private SpriteRenderer oper;
    [SerializeField] private SpriteRenderer rightNumber1;
    [SerializeField] private SpriteRenderer rightNumber2;
    [Header("Answer Objects")]
    [SerializeField] private GameObject[] boxes = new GameObject[3];
    void Start()
    {
        TaskGenerator();
    }
    void TaskGenerator()
    {
        int a = Random.Range(1, 21), b = Random.Range(1,21), result = default, rChooseOper = Random.Range(0,4);
        switch(rChooseOper)
        {
            case 0:
                oper.sprite = plus;
                NumberGetting(a, leftNumber1, leftNumber2);
                NumberGetting(b, rightNumber1, rightNumber2);
                result = a + b;
                break; 
            case 1:
                oper.sprite = minus;
                while (a - b <= 0) b--;
                if (b > 1) b -= Random.Range(0, b);
                NumberGetting(a, leftNumber1, leftNumber2);
                NumberGetting(b, rightNumber1, rightNumber2);
                result = a - b;
                break;
            case 2:
                oper.sprite = multi;
                while(a*b >= 100)
                {
                    int r = Random.Range(0, 2);
                    if (r == 0) a--; else b--;
                }
                NumberGetting(a, leftNumber1, leftNumber2);
                NumberGetting(b, rightNumber1, rightNumber2);
                result = a * b;
                break;
            case 3:
                oper.sprite = divide;
                bool prime = true;
                while (prime)
                {
                    for (int i = 2; i < Mathf.Sqrt(a); i++)
                    {
                        if (a % i == 0)
                        {
                            prime = false;
                            break;
                        }
                    }
                    if (prime) a++; else break;
                }
                while (a % b != 0) b--;
                NumberGetting(a, leftNumber1, leftNumber2);
                NumberGetting(b, rightNumber1, rightNumber2);
                result = a / b;
                break;

        }
        Debug.Log("result: " + result);
        int rChooseBox = Random.Range(0, 3);
        NumberGetting(result, boxes[rChooseBox].transform.Find("LeftN1").GetComponent<SpriteRenderer>(), boxes[rChooseBox].transform.Find("LeftN2").GetComponent<SpriteRenderer>());
        boxes[rChooseBox].GetComponent<AnswerBox>().isRightAnswer = true;
        for(int i = 0; i < 3; i++) if(i != rChooseBox) NumberGetting(Random.Range(0,51), boxes[i].transform.Find("LeftN1").GetComponent<SpriteRenderer>(), boxes[i].transform.Find("LeftN2").GetComponent<SpriteRenderer>());
    }
    void NumberGetting(int a, SpriteRenderer sr1, SpriteRenderer sr2)
    {
        if (a >= 10)
        {
            int m = a % 10;
            sr2.sprite = NumberSetting(m);
            a = (a - m) / 10;
            sr1.sprite = NumberSetting(a);
        }
        else
        {
            sr2.sprite = NumberSetting(a);
            sr1.sprite = zero;
        }
    }
    Sprite NumberSetting(int a)
    {
        Sprite newSprite = default;
        switch (a)
        {
            case 0:
                newSprite = zero;
                break;
            case 1:
                newSprite = one;
                break;
            case 2:
                newSprite = two;
                break;
            case 3:
                newSprite = three;
                break;
            case 4:
                newSprite = four;
                break;
            case 5: 
                newSprite = five;
                break;
            case 6:
                newSprite = six;
                break;
            case 7:
                newSprite = seven;
                break;
            case 8:
                newSprite = eight;
                break;
            case 9:
                newSprite = nine;
                break;
        }
        return newSprite;
    }
}
