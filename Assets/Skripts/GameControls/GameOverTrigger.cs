using UnityEngine;
using Zenject;

public class GameOverTrigger : MonoBehaviour
{
    private float _timer = 0f;
    private float _timeTillGameOVer = 1f;

    public delegate void GameHasEnded();
    public static event GameHasEnded gameHasEnded;

    private void OnTriggerStay2D(Collider2D collision)
    {
        _timer += Time.deltaTime;

        if (_timer > _timeTillGameOVer)
        {
            gameHasEnded?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _timer = 0f;
    }
}
