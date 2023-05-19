using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfosLang : MonoBehaviour
{
    [TextArea]
    public List<string> infos;
    void Start()
    {
        gameObject.GetComponent<TextMesh>().text = infos[LanguageManager.lmInstance.lang];
    }
}
