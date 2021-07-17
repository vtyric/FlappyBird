using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private PipeGenerator pipeGenerator;
    [SerializeField] private GameScreen startScreen;
    [SerializeField] private GameScreen gameOverScreen;

    private void Start()
    {
        Time.timeScale = 0;
        startScreen.Open();
    }

    private void OnEnable()
    {
        startScreen.PlayButtonClick += OnPlayButtonClick;
        gameOverScreen.PlayButtonClick += OnRestartButtonClick;
        bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        startScreen.PlayButtonClick -= OnPlayButtonClick;
        gameOverScreen.PlayButtonClick -= OnRestartButtonClick;
        bird.GameOver -= OnGameOver;
    }

    private void OnPlayButtonClick()
    {
        startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        gameOverScreen.Close();
        startScreen.Close();
        pipeGenerator.ResetPool();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        bird.RestartGame();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.Open();
    }
}