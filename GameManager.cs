using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;

    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        gameOver.SetActive(false);
        PauseFunction();
    }

    public void PlayFunction()
    {
        
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1;

        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        foreach (Pipes pipe in pipes) { Destroy(pipe.gameObject); }
    }
    
    public void PauseFunction()
    {
        Time.timeScale = 0;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        PauseFunction();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
