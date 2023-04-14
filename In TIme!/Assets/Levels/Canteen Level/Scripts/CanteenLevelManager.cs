using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CanteenLevelManager : MonoBehaviour
{
    [SerializeField] private Dishes[] dishes;
    [SerializeField] private SpriteRenderer[] dishesPoints;
    public SpriteRenderer wishDish;
    public Sprite[] marks;
    public Human[] humans;
    public SpriteRenderer human;

    public int randomHuman;
    public bool isClicked = false;
    void Start()
    {
        randomHuman = Random.Range(0, humans.Length);
        Decider();
    }
    void Decider()
    {
        human.sprite = humans[randomHuman].normal;
        for (int i = 0; i < dishesPoints.Length; i++)
        {
            while (true)
            {
                int rDish = Random.Range(0, dishes.Length);
                if (!dishes[rDish].isUsed)
                {
                    dishes[rDish].isUsed = true;
                    dishesPoints[i].sprite = dishes[rDish].dish;
                    break;
                }
            }
        }
        int rWish = Random.Range(0, 3);
        wishDish.sprite = dishesPoints[rWish].sprite;
    }
    [Serializable]
    public class Human
    {
        public Sprite normal;
        public Sprite sad;
        public Sprite happy;
    }
    [Serializable]
    public class Dishes
    {
        public Sprite dish;
        public bool isUsed;
    }
}
