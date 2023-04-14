using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] GameObject transitions;
    [SerializeField] GameObject camera;
    private int level;
    void Start()
    {
        Time.timeScale= 1.0f;
    }
    void Level1Load()
    {
        SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive);
    }
    void InfiniteLoad()
    {
        SceneManager.LoadSceneAsync("Infinite", LoadSceneMode.Additive);
    }
    public void LevelSet(int level)
    {
        this.level = level;
        transitions.transform.Find("TransitionUp").GetComponent<Animator>().Play("MenuTransitionUp");
        transitions.transform.Find("TransitionDown").GetComponent<Animator>().Play("MenuTransitionDown");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void LevelStart()
    {
        switch (level)
        {
            case 0: 
                InfiniteLoad();
                break;
            case 1:
                Level1Load();
                break;
        }
        StartCoroutine(UIDestroyCountdown());
        GetComponent<Canvas>().sortingOrder = -4;
    }
    IEnumerator UIDestroyCountdown()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        Destroy(camera);
        Destroy(transitions);
    }
}
