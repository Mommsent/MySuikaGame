using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private float _timeToFade;

    [SerializeField] private UserInput input;

    private void Start()
    {
        Out();
    }

    public void In()
    {
        StartCoroutine(Fading());
        
    }

    public void Out()
    {
        StartCoroutine(Fading(1f,0f));
    }

    private IEnumerator Fading(float startValue = 0f, float endValue = 1f)
    {
        input.enabled = false;

        _image.gameObject.SetActive(true);
        Color startColor = _image.color;
        startColor.a = startValue;
        _image.color = startColor;

        float elapsedTime = startValue;
        while (elapsedTime < _timeToFade)
        {
            elapsedTime += Time.deltaTime;

            float newAlpha = Mathf.Lerp(startValue, endValue, (elapsedTime / _timeToFade));
            startColor.a = newAlpha;
            _image.color = startColor;

            yield return null;
        }

        input.enabled = true;
    }
}
