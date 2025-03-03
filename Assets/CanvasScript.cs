using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    // Reference to the text display on the UI
    [SerializeField] private TextMeshProUGUI textDisplay;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject scoreDisplay;
    [SerializeField] private GameObject startGameScreen;

    private void OnEnable()
    {
        LogicManagerScript.OnAddScore += UpdateScore;
        birdScript.OnCollideWithPipe += GameOverScene;
        birdScript.OnGameStart += StartGameScreenSwap;
    }

    private void OnDisable()
    {
        LogicManagerScript.OnAddScore -= UpdateScore;
        birdScript.OnCollideWithPipe -= GameOverScene;
        birdScript.OnGameStart -= StartGameScreenSwap;
    }

    private void UpdateScore(int newScore)
    {
        textDisplay.text = newScore.ToString();
    }

    public void GameOverScene()
    {
        gameOverScreen.SetActive(true);
    }

    public void StartGameScreenSwap()
    {
        startGameScreen.SetActive(false);
        scoreDisplay.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
