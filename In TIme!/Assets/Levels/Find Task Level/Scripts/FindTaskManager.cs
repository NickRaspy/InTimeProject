using System;
using System.Collections.Generic;
using UnityEngine;

public class FindTaskManager : MonoBehaviour
{
    [Serializable]
    public class WindowsLang
    {
        public Sprite winScreen;
        public Sprite loseScreen;
    }
    public GameObject points;
    public Sprite taskSprite;
    public GameObject win;
    public GameObject lose;
    public Sprite[] otherSprites;
    public List<string> taskLang;
    public List<WindowsLang> wLang;
    public bool canClick = true;
    private string symbols = "abcdefghijklmnopqrstuvwxyz123456789";
    // Start is called before the first frame update
    void Start()
    {
        win.SetActive(false);
        lose.SetActive(false);
        win.GetComponent<SpriteRenderer>().sprite = wLang[LanguageManager.lmInstance.lang].winScreen;
        lose.GetComponent<SpriteRenderer>().sprite = wLang[LanguageManager.lmInstance.lang].loseScreen;
        ShortcutsGenerator();
    }
    void ShortcutsGenerator()
    {
        int a = UnityEngine.Random.Range(1,6), b = UnityEngine.Random.Range(1,8);
        points.transform.Find(a.ToString()).Find(b.ToString()).GetComponent<SpriteRenderer>().sprite = taskSprite;
        points.transform.Find(a.ToString()).Find(b.ToString()).Find("Text").GetComponent<TextMesh>().text = taskLang[LanguageManager.lmInstance.lang];
        for(int i = 1; i < 6; i++)
        {
            for (int j = 1; j < 8; j++)
            {
                if(i != a || j != b)
                {
                    int rSprite = UnityEngine.Random.Range(0, 5);
                    points.transform.Find(i.ToString()).Find(j.ToString()).GetComponent<SpriteRenderer>().sprite = otherSprites[rSprite];
                    int rNameSize = UnityEngine.Random.Range(5, 10);
                    points.transform.Find(i.ToString()).Find(j.ToString()).Find("Text").GetComponent<TextMesh>().text = "";
                    for (int m = 0; m <= rNameSize; m++)
                    {
                        int rSymbol = UnityEngine.Random.Range(0, 35);
                        points.transform.Find(i.ToString()).Find(j.ToString()).Find("Text").GetComponent<TextMesh>().text += symbols[rSymbol];
                    }
                }
            }
        }
    }
    public void GetClicked(bool isTask)
    {
        if (isTask)
        {
            win.SetActive(true);
            GameManager.instance.win = true;
        }
        else lose.SetActive(true);
        canClick = false;
    }
}
