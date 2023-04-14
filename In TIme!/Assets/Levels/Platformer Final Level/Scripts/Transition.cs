using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] UI ui;
    void ShowFinalImage()
    {
        ui.finalImage.SetActive(true);
        GameManager.instance.win = true;
        StartCoroutine(FinalCooldown());
    }
    IEnumerator FinalCooldown()
    {
        yield return new WaitForSeconds(3f);
        GameManager.instance.EndGame();
    }
}
