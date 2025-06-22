using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject gameOverScreen;
    
    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        // Make sure game over screen is hidden at start
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
    }

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        // Initialize game components and settings here
        Debug.Log("Game initialized");
    }

    public void ShowGameOver()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f; // Optional: pause the game
            Debug.Log("Game Over screen displayed");
        }
        else
        {
            Debug.LogError("Game Over screen reference is missing!");
        }
    }

    public void HideGameOver()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
            Time.timeScale = 1f; // Resume the game
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        HideGameOver();
        // Add code to restart the level or reload the scene
        Debug.Log("Game restarted");
    }
}
