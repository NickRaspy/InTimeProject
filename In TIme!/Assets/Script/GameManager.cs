using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    private GameObject gameRightNow;
    public bool isInfinite = false;
    public bool win = false;
    public bool isMiniGamePlayed;
    public bool isFinal;
    public int gameNumber = 0;
    public int livesNumber = 3;
    private int amountOfLevels = 0;
    [Header("For Infinite Only")]
    [SerializeField] private Image[] infiniteGameCounter = new Image[3];
    [Header ("Visuals in Scene")]
    [SerializeField] private Image gameCounter;
    [SerializeField] private Image background;
    [SerializeField] private Animator BGTransition;
    [SerializeField] private Animator fairyAnim;
    [SerializeField] private Animator[] transitions;
    [SerializeField] private Image[] lives;
    [SerializeField] private GameObject allLives;
    [SerializeField] private GameObject winLoseScreen;
    [SerializeField] private GameObject timer;
    [Header("Sprite Collection")]
    [SerializeField] private Sprite lostLive;
    [SerializeField] private Sprite[] backgrounds;
    [SerializeField] private Sprite finalBG;
    [SerializeField] private Sprite[] numbers;
    [SerializeField] private Sprite wire;
    [SerializeField] private Sprite burnedWire;
    [SerializeField] private Sprite bomb;
    [SerializeField] private Sprite explosion;
    [SerializeField] private Sprite winText;
    [SerializeField] private Sprite loseText;
    [Header("Level Managing")]
    [SerializeField] private List<GameObject> miniGames;
    [SerializeField] private GameObject finalGame;
    public List<GameObject> unplayedMiniGames;
    void Start()
    {
        winLoseScreen.SetActive(false);
        for(int i = 0; i < miniGames.Count; i++)
        {
            unplayedMiniGames[i] = miniGames[i];
        }
        StartCoroutine(PrepareToGame());
        timer.SetActive(false);
    }

    public void MiniGameStart()
    {
        if (isInfinite)
        {
            int rGame = Random.Range(0, unplayedMiniGames.Count - 1);
            gameRightNow = Instantiate(unplayedMiniGames[rGame]);
            unplayedMiniGames.RemoveAt(rGame);
            unplayedMiniGames.Add(gameRightNow);
        }
        else
        {
            if (unplayedMiniGames.Count > 0)
            {
                int rGame = Random.Range(0, unplayedMiniGames.Count);
                gameRightNow = Instantiate(unplayedMiniGames[rGame]);
                unplayedMiniGames.RemoveAt(rGame);
                timer.SetActive(true);
                StartCoroutine(Timer());
            }
            else gameRightNow = Instantiate(finalGame);
        }
        gameCounter.gameObject.SetActive(false); background.gameObject.SetActive(false); fairyAnim.gameObject.SetActive(false); allLives.SetActive(false);
    }
    public void BGChange(bool isFinal)
    {
        if (!isFinal)
        {
            int rBG = Random.Range(0, backgrounds.Length);
            background.sprite = backgrounds[rBG];
        }
        else background.sprite = finalBG;
    }
    public void MiniGameEnd()
    {
        Destroy(gameRightNow);
        gameRightNow = null;
        gameCounter.gameObject.SetActive(true); background.gameObject.SetActive(true); fairyAnim.gameObject.SetActive(true); allLives.SetActive(true);
        timer.SetActive(false);
        isMiniGamePlayed = false;
    }
    public void WinCheck()
    {
        if (isInfinite)
        {
            if (win)
            {
                fairyAnim.SetBool("isSuccess", true);
            }
            else
            {
                fairyAnim.SetBool("isFail", true);
                lives[livesNumber].sprite = lostLive;
                livesNumber--;
            }
            StartCoroutine(AnimationCooldown());
            gameNumber++;
            gameCounter.sprite = numbers[gameNumber];
        }
        else
        {
            if (gameNumber == miniGames.Count)
            {
                if (win)
                {
                    BGChange(true);
                    fairyAnim.SetBool("isSuccess", true);
                    StartCoroutine(PrepareToWin());
                }
                else
                {
                    BGChange(false);
                    fairyAnim.SetBool("isFail", true);
                    lives[livesNumber].sprite = lostLive;
                    livesNumber--;
                    StartCoroutine(AnimationCooldown());
                }
            }
            else
            {
                BGChange(false);
                if (win)
                {
                    fairyAnim.SetBool("isSuccess", true);
                }
                else
                {
                    fairyAnim.SetBool("isFail", true);
                    lives[livesNumber].sprite = lostLive;
                    livesNumber--;
                }
                gameNumber++;
                gameCounter.sprite = numbers[gameNumber];
                StartCoroutine(AnimationCooldown());
            }
        }
    }
    public void EndGame()
    {
        isMiniGamePlayed = true;
        transitions[0].Play("GameTransitionUp"); transitions[1].Play("GameTransitionDown");
        StartCoroutine(BGTrasition());
    }
    public IEnumerator PrepareToGame()
    {
        win = false;
        yield return new WaitForSeconds(3f);
        transitions[0].Play("GameTransitionUp"); transitions[1].Play("GameTransitionDown");
    }
    public IEnumerator BGTrasition()
    {
        yield return new WaitForSeconds(3f);
        BGTransition.Play("BGTransitionAlpha");
    }
    public IEnumerator AnimationCooldown()
    {
        yield return new WaitForSeconds(2f);
        if(livesNumber >= 0)
        {
            if (win) fairyAnim.SetBool("isSuccess", false);
            else fairyAnim.SetBool("isFail", false);
            StartCoroutine(PrepareToGame());
        }
        else
        {
            winLoseScreen.SetActive(true);
            winLoseScreen.transform.Find("WinLose").GetComponent<Image>().sprite = loseText;
        }
    }
    public IEnumerator PrepareToWin()
    {
        yield return new WaitForSeconds(2f);
        winLoseScreen.SetActive(true);
        winLoseScreen.transform.Find("WinLose").GetComponent<Image>().sprite = winText;
    }
    public void InfiniteCounterSet(int a)
    {
        for(int i = 0; i < infiniteGameCounter.Length; i++)
        {
            infiniteGameCounter[i].sprite = numbers[a % 10];
            a /= 10;
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitLevel()
    {
        SceneManager.LoadScene("Main");
    }
    IEnumerator Timer()
    {
        timer.transform.Find("Bomb").GetComponent<Image>().sprite = bomb;
        yield return new WaitForSeconds(1f);
        Image[] wiresSprites = new Image[6];
        GameObject wires = timer.transform.Find("Wires").gameObject;
        wires.transform.Find("7").gameObject.SetActive(true);
        for (int i = 0; i < 6; i++)
        {
            wires.transform.Find((i + 1).ToString()).gameObject.SetActive(true);
            wiresSprites[i] = wires.transform.Find((i + 1).ToString()).gameObject.GetComponent<Image>();
            wiresSprites[i].sprite = wire; 
        }
        yield return new WaitForSeconds(1f);
        wires.transform.Find("7").gameObject.SetActive(false);
        wiresSprites[5].sprite = burnedWire;
        for (int i = 5; i > 0; i--) 
        {
            yield return new WaitForSeconds(1f);
            wiresSprites[i].gameObject.SetActive(false);
            wiresSprites[i - 1].sprite = burnedWire;
        }
        yield return new WaitForSeconds(1f);
        wiresSprites[0].gameObject.SetActive(false);
        timer.transform.Find("Bomb").GetComponent<Image>().sprite = explosion;
        yield return new WaitForSeconds(1f);
        EndGame();
    }
}
