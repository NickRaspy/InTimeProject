using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Animator transUp;
    [SerializeField] private Animator transDown;
    public GameObject finalImage;
    void Start()
    {
        finalImage.SetActive(false);
        GetComponent<Canvas>().sortingOrder = 2;
    }
    public void Transition()
    {
        Debug.Log("Playing");
        transUp.SetBool("isReady", true);
        transDown.SetBool("isReady", true);
    }
}
