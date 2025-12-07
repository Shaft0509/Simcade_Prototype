using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    public float maxTime = 60f;

    [Header("References")]
    public CarPhysics car;
    public TextMeshProUGUI timerText;
    public GameObject youWinScreen;
    public GameObject youLoseScreen;

    private float timeRemaining;
    private bool gameEnded = false;

    void Start()
    {
        timeRemaining = maxTime;

        if (youWinScreen != null) youWinScreen.SetActive(false);
        if (youLoseScreen != null) youLoseScreen.SetActive(false);
    }

    void Update()
    {
        if (gameEnded) return;

        HandleTimer();
    }

    void HandleTimer()
    {
        timeRemaining -= Time.deltaTime;

        if (timerText != null)
            timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString();

        if (timeRemaining <= 0f)
        {
            EndGame(false);
        }
    }

    public void GoalReached()
    {
        if (!gameEnded)
        {
            EndGame(true);
        }
    }

    void EndGame(bool won)
    {
        gameEnded = true;

        if (car != null)
            car.enabled = false;

        if (won)
        {
            if (youWinScreen != null) youWinScreen.SetActive(true);
            Debug.Log("You win!");
        }
        else
        {
            if (youLoseScreen != null) youLoseScreen.SetActive(true);
            Debug.Log("You lose!");
        }
    }
}
