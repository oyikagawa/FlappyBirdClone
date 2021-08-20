using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStatesController : ChangeSceneBehavior
{
    public static GameStatesController gameStatesController;

    public Text scoreText;
    public Text gameOverText;
    public GameObject gameOverObj;
    public bool isGameOver = false;

    private int score = 0;

    void Awake()
    {
        if (gameStatesController == null)
        {
            gameStatesController = this;
        } else if (gameStatesController != this)
        {
            Destroy(gameObject);
        }

        GameEvents.gameEvents.OnTubePass += OnIncreaseScore;
        GameEvents.gameEvents.OnGameOver += OnStopAction;
    }

    private void OnStopAction()
    {
        HighscoreSaveLoadController.SaveHighscore(score);
        int bestResult = HighscoreSaveLoadController.LoadFirstHighscore();

        scoreText.enabled = false;
        gameOverText.text = $"Score: {score} \n Best result: {bestResult}";
        gameOverObj.SetActive(true);
        isGameOver = true;
    }

    private void OnIncreaseScore()
    {
        score++;
        scoreText.text = $"Score: {score}";   
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDestroy()
    {
        GameEvents.gameEvents.OnTubePass -= OnIncreaseScore;
        GameEvents.gameEvents.OnGameOver -= OnStopAction;
    }
}
