using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneControle : MonoBehaviour
{
    private float loadSceneDilay = 2.5f;
    [SerializeField]
    private GameObject _gameOverMenu;
    [SerializeField] 
    private UserInput input;
    private Yandex _yandex;

    [Inject]
    private void Construct(Yandex yandex)
    {
        this._yandex = yandex;
    }

    private void OnEnable()
    {
        GameOverTrigger.gameHasEnded += ShowGameOverScreen;
    }

    private void ShowGameOverScreen()
    {
        _gameOverMenu.SetActive(true);
        input.enabled = false;
    }

    public void ReloadScene()
    {
        _yandex.ShowFullScreenAD();
        StartCoroutine(Dilay());
    }

    private IEnumerator Dilay()
    {
        yield return new WaitForSeconds(loadSceneDilay);
        SceneManager.LoadScene("SampleScene");
    }

    private void OnDisable()
    {
        GameOverTrigger.gameHasEnded -= ShowGameOverScreen;
    }
}
