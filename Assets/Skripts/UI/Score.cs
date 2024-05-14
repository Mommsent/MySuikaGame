using UnityEngine;
using Zenject;
using System;

public class Score : MonoBehaviour
{
    public int CurrentScore {  get; private set; }

    public Action ScoreHasChanged;

    private Yandex _yandex;
    [Inject]
    private void Construct(Yandex yandex)
    {
        this._yandex = yandex;
    }

    private void OnEnable()
    {
        ColliderInformer.wasCollided += Increase;
        GameOverTrigger.gameHasEnded += IsItTheBestScore;
    }

    private void Increase(int amount)
    {
        CurrentScore += amount;
        ScoreHasChanged?.Invoke();
    }

    private void IsItTheBestScore()
    {
        if (CurrentScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", CurrentScore);
            _yandex.SaveLiderBoard(CurrentScore);
        }
    }

    private void OnDisable()
    {
        ColliderInformer.wasCollided -= Increase;
        GameOverTrigger.gameHasEnded -= IsItTheBestScore;
    }
}
