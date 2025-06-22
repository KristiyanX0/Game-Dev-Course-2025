using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance { get; private set; }
    
    [Header("Health Settings")]
    [SerializeField] private int damage = 1;
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private GameObject healthUIObject; // Reference to the GameObject with IHealthUI implementation
    
    [Header("Events")]
    public UnityEvent OnHealthDepleted;

    private IHealthUI PlayerHealthUI;
    public int currentHealth;
    
    private void Awake()
    {
        // Implement singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        

        if (healthUIObject != null)
        {
            PlayerHealthUI = healthUIObject.GetComponent<IHealthUI>();
            if (PlayerHealthUI == null)
            {
                Debug.LogError("The assigned GameObject does not have a component implementing IHealthUI!");
            }
        }
        else
        {
            Debug.LogWarning("No Health UI GameObject assigned!");
        }
        
    }
    
    private void Start()
    {
        // Initialize the UI with our health values
        if (PlayerHealthUI != null)
        {
            PlayerHealthUI.Initialize(maxHealth);
            this.ResetHealth();
        }
    }

    public void ApplyDamage()
    {
        TakeDamage(damage);
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth < 0)
            currentHealth = 0;
            
        if (PlayerHealthUI != null)
        {
            PlayerHealthUI.UpdateDisplay(currentHealth);
        }
        
        if (currentHealth <= 0)
        {
            PlayerDeath();
            OnHealthDepleted?.Invoke();
        }
    }
    
    public void ResetHealth()
    {
        currentHealth = maxHealth;
        
        if (PlayerHealthUI != null)
        {
            PlayerHealthUI.UpdateDisplay(currentHealth);
        }
    }
    
    private void PlayerDeath()
    {
        Debug.Log("Player has died!");
        
        // Add death logic here:
        // - Disable player control
        // - Play death animation
        // - Show game over screen
        // Example: GetComponent<PlayerController>().enabled = false;
    }

}
