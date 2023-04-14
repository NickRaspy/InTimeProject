using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackLevelManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer item;
    [SerializeField] private Sprite[] itemsSprites;
    void Start()
    {
        int a = Random.Range(0, itemsSprites.Length);
        item.sprite = itemsSprites[a];
    }
}
