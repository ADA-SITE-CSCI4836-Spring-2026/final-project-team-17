using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float timeLeft = 60f;
    public Text timerText;
    public GameObject enemy;

    private bool enemyStarted = false;
    private bool gameEnded = false;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;

        if (enemy != null)
            enemy.SetActive(false);

        UpdateTimerUI();
    }

    void Update()
    {
        if (gameEnded || enemyStarted) return;

        timeLeft -= Time.deltaTime;

    if (timeLeft <= 0f)
    {
    timeLeft = 0f;
    gameEnded = true;

    timerText.text = "TIME UP!";
    Time.timeScale = 0f;
    }
    else
        {
            UpdateTimerUI();
        }
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
            timerText.text = "Time: " + Mathf.CeilToInt(timeLeft);
    }

    public void WinGame()
    {
        gameEnded = true;
        timerText.text = "YOU WIN!";
        Time.timeScale = 0f;
    }

    public void LoseGame()
    {
        gameEnded = true;
        timerText.text = "GAME OVER!";
        Time.timeScale = 0f;
    }
}