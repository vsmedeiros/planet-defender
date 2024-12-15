using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject movementButtons;
    public TextMeshProUGUI enemiesKilledText; // Referência ao TextMeshPro
    public int enemiesKilled = 0; // Contador de inimigos mortos
    public GameObject gameOverPanel;

    public GameObject gameSuccessPanel;
    public EnemySpawner enemySpawner;

    public TextMeshProUGUI timerText;

    private float maximumTime = 180f;
    private bool running = true;

    private float elapsedTime = 0f;
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Finish();
    }

    public void Finish()
    {

        running = false;
        // movementButtons.SetActive(false);
        enemySpawner?.StopSpawning();
        Time.timeScale = 0;
    }

    public void Complete()
    {
        gameSuccessPanel.SetActive(true);
        Finish();
    }


    private void Start()
    {
        UpdateEnemiesKilledText(); // Atualiza o texto inicial
    }

    public void EnemyKilled()
    {
        enemiesKilled++;
        UpdateEnemiesKilledText(); // Atualiza o texto após um inimigo ser destruído
    }


    private void updateTimerText()
    {

        var currentTime = maximumTime - elapsedTime;

        int minutes = (int)(currentTime / 60);
        int seconds = (int)(currentTime % 60);


        timerText.text = $"Time: {minutes:D2}:{seconds:D2}";
    }

    public void Update()
    {

        if (running)
        {
            elapsedTime += Time.deltaTime;
            updateTimerText();
        }

        // Se o tempo acabar, chama o método CompleteLevel
        if (elapsedTime > maximumTime)
        {
            Complete();
        }

        // se ele clicar no botao esc levar para o menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMenu();
            return;
        }

    }

    private void UpdateEnemiesKilledText()
    {
        enemiesKilledText.text = "Enemies Killed: " + enemiesKilled; // Atualiza o texto na tela
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }


    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu"); // Load the Menu scene
    }
}