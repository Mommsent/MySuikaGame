using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeInFadeOut : MonoBehaviour
{
    [SerializeField] private Image _panal;
    [SerializeField] private float _timeToFade = 2f;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += FadeGame;
        GameOver.gameHasEnded += StartToFade;
    }

    private void StartToFade()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        _panal.gameObject.SetActive(true);
        Color startColor = _panal.color;
        startColor.a = 0f;
        _panal.color = startColor;

        float elapsedTime = 0f;
        while (elapsedTime < _timeToFade)
        {
            elapsedTime += Time.deltaTime;

            float newAlpha = Mathf.Lerp(0f, 1f, (elapsedTime / _timeToFade));
            startColor.a = newAlpha;
            _panal.color = startColor;

            yield return null;
        }
    }

    private void FadeGame(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(FadeGameIn());
    }

    private IEnumerator FadeGameIn()
    {
        _panal.gameObject.SetActive(true);
        Color startColor = _panal.color;
        startColor.a = 1f;
        _panal.color = startColor;

        float elapsedTime = 0f;
        while (elapsedTime < _timeToFade)
        {
            elapsedTime += Time.deltaTime;

            float newAlpha = Mathf.Lerp(1f, 0f, (elapsedTime / _timeToFade));
            startColor.a = newAlpha;
            _panal.color = startColor;

            yield return null;
        }
        _panal.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= FadeGame;
        GameOver.gameHasEnded -= StartToFade;
    }
}
