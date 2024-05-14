using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    private int _bestScore;
    private int _defaultBestScoreValue = 0;

    [Header("Sore")]
    [SerializeField]
    private Score _score;

    [Header("SoreText")]
    [SerializeField]
    private TextMeshProUGUI _finaleScoreText;
    [SerializeField]
    private TextMeshProUGUI _theBestScoreText;
    [SerializeField]
    private TextMeshProUGUI _currentScoreText;

    private void OnEnable()
    {
        GameOverTrigger.gameHasEnded += ShowFinaleScore;
        _score.ScoreHasChanged += ShowCurrentScore;
    }

    void Start()
    {
        ShowTheBestScore();
        ShowCurrentScore();
    }

    private void ShowTheBestScore()
    {
        _bestScore = PlayerPrefs.GetInt("HighScore", _defaultBestScoreValue);
        _theBestScoreText.text = "Лучший счёт: " + _bestScore;
    }

    private void ShowFinaleScore()
    {
        _finaleScoreText.text = "Финальный результат: " + _score.CurrentScore;
    }

    private void ShowCurrentScore()
    {
        _currentScoreText.text = _score.CurrentScore.ToString();
    }

    private void OnDisable()
    {
        GameOverTrigger.gameHasEnded -= ShowFinaleScore;
    }
}
