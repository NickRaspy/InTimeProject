using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager lmInstance;
    [Serializable]
    public class Languages
    {
        public string lvl1;
        public string inf;
        public string exit;
        public Sprite title;
    }
    public int lang;
    public int Lang 
    {
        get { return lang; }
        set { MenuLangSet(); }
    }
    [SerializeField] public List<Languages> languages;
    private void Awake()
    {
        lmInstance= this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        lang = 0;
        Lang = 0;
    }
    void MenuLangSet()
    {
        GameObject ui = GameObject.Find("UI");
        ui.transform.Find("Title").GetComponent<Image>().sprite = languages[Lang].title;
        ui.transform.Find("Level 1").Find("Text").GetComponent<Text>().text = languages[Lang].lvl1;
        ui.transform.Find("Infinite").Find("Text").GetComponent<Text>().text = languages[Lang].inf;
        ui.transform.Find("Exit").Find("Text").GetComponent<Text>().text = languages[Lang].exit;
    }

}
