using System.Collections;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [Header("Confirmetion")]
    [SerializeField] private GameObject comfirmationPrompt = null;

    [Header("Menu")]
    private bool gameIsPaused;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject Settings;

    private void OnEnable()
    {
        AudioSettings.HadSaved += ShowConfirmMassage;
        Player.menuWasPressed += PauseGame;
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void ShowConfirmMassage()
    {
        StartCoroutine(ConfirmationBox());
    }

    private IEnumerator ConfirmationBox()
    {
        comfirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2f);
        comfirmationPrompt.SetActive(false);
    }

    public void PauseGame()
    {
        gameIsPaused = !gameIsPaused;

        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            Settings.SetActive(false);
        }
    }

    private void OnDisable()
    {
        AudioSettings.HadSaved -= ShowConfirmMassage;
        Player.menuWasPressed -= PauseGame;
    }
}
