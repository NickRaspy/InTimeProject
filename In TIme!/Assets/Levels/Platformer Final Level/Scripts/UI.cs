using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Animator transUp;
    [SerializeField] private Animator transDown;
    [SerializeField] private GameObject[] controls;
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
    void Update()
    {
        if(Time.timeScale == 0f) foreach (GameObject go in controls) go.SetActive(false);
        else foreach (GameObject go in controls) go.SetActive(true);
    }
}
