using YG;

public class Yandex
{
    public void ShowFullScreenAD()
    {
        YandexGame.FullscreenShow();
    }

    public void SaveLiderBoard(int bestScore)
    {
        YandexGame.NewLeaderboardScores("LiderBoardSuika", bestScore);
    }
}
