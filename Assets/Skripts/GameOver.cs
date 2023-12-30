using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public delegate void GameHasEnded();
    public static event GameHasEnded gameHasEnded;

    private float _timer = 0f;
    private float _timeTillGameOVer = 1.5f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        _timer += Time.deltaTime;

        if(_timer > _timeTillGameOVer)
        {
            Debug.Log("Game has restarted!");
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            gameHasEnded?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _timer = 0f;
    }
}
