using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SetSoundToButtons : MonoBehaviour
{
    [Tooltip("The audio clip to play when any button is clicked")]
    [SerializeField] private AudioClip buttonClickSound;
    
    [Tooltip("Volume for the button click sound")]
    [Range(0f, 1f)]
    [SerializeField] private float buttonVolume = 1f;
    
    [Tooltip("AudioSource to play the button click sound")]
    [SerializeField] private AudioSource audioSource;
    
    private void OnEnable()
    {
        // Subscribe to the scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    private void OnDisable()
    {
        // Unsubscribe from the scene loaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    private void Start()
    {
        SetupButtonSounds();
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // When a new scene is loaded, find and set up buttons again
        Debug.Log($"Scene loaded: {scene.name}. Setting up button sounds.");
        SetupButtonSounds();
    }
    
    private void SetupButtonSounds()
    {
        // Find all buttons in the scene
        Button[] allButtons = FindObjectsOfType<Button>(true);
        
        Debug.Log($"Found {allButtons.Length} buttons in the scene");
        
        // Attach click sound to each button
        foreach (Button button in allButtons)
        {
            button.onClick.AddListener(() => PlayButtonSound());
            Debug.Log($"Added sound to button: {button.gameObject.name}");
        }
    }
    
    private void PlayButtonSound()
    {
        if (buttonClickSound != null && audioSource != null)
        {
            // Use the current audioSource volume setting when playing the sound
            audioSource.PlayOneShot(buttonClickSound, buttonVolume * audioSource.volume);
            Debug.Log("Button sound played with volume of " + (buttonVolume * audioSource.volume));
        }
        else
        {
            Debug.LogWarning("Button sound or audio source is missing!");
        }
    }
}
