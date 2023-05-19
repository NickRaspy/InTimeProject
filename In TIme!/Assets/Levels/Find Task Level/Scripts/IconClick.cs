using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconClick : MonoBehaviour
{
    [SerializeField] private FindTaskManager ftm;
    private void OnMouseDown()
    {
        if(gameObject.transform.Find("Text").GetComponent<TextMesh>().text == ftm.taskLang[LanguageManager.lmInstance.lang] && ftm.canClick) ftm.GetClicked(true);
        else ftm.GetClicked(false);
    }
}
