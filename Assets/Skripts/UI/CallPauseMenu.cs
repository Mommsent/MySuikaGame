using UnityEngine;

public class CallPauseMenu : MonoBehaviour
{
    [Header("Menu")]
    private bool gameIsPaused;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject Settings;

    private void OnEnable()
    {
        Player.menuWasPressed += PauseGame;
    }

    public void PauseGame()
    {
        gameIsPaused = !gameIsPaused;

        if (gameIsPaused)
        {
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
            Settings.SetActive(false);
        }
    }

    private void OnDisable()
    {
        Player.menuWasPressed -= PauseGame;
    }
}
