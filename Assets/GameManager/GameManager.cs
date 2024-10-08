using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using Dan.Demo;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject leaderboardPanel;
    public GameObject movementButtons;
    public TextMeshProUGUI enemiesKilledText; // Referência ao TextMeshPro
    public int enemiesKilled = 0; // Contador de inimigos mortos
    public GameObject gameOverPanel; // Referência ao painel de Game Over
    public LeaderboardManager leaderboardManager;
    public EnemySpawner enemySpawner;
    public void GameOver()
    {
        gameOverPanel.SetActive(true); 
        leaderboardPanel.SetActive(true);
        movementButtons.SetActive(false);
        enemySpawner?.StopSpawning();
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Define esta instância
            DontDestroyOnLoad(gameObject); // Não destrói ao carregar novas cenas
        }
        else
        {
            Destroy(gameObject); // Destroi esta instância se já existir
        }
    }
    private void Start()
    {
        UpdateEnemiesKilledText(); // Atualiza o texto inicial
    }

    public void EnemyKilled()
    {
        enemiesKilled++;
        UpdateEnemiesKilledText(); // Atualiza o texto após um inimigo ser destruído
        leaderboardManager.AddPlayerScore();
    }

    private void UpdateEnemiesKilledText()
    {
        enemiesKilledText.text = "Enemies Killed: " + enemiesKilled; // Atualiza o texto na tela
    }
}