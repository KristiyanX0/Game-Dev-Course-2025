using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class KeyManager : MonoBehaviour
{
    // Static instance for singleton pattern
    public static KeyManager Instance { get; private set; }
    
    // Static variables to track all keys
    public static int TotalKeys = 0;
    public static int CollectedKeys = 0;
    
    // Static event to notify UI when keys are collected
    public static event Action OnKeyCollectionChanged;
    
    // Unity Event when all keys are collected
    [SerializeField] private UnityEvent OnAllKeysCollected;
    
    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        // Reset counters
        TotalKeys = 0;
        CollectedKeys = 0;
        
        // Find all keys in the scene
        GameObject[] keyObjects = GameObject.FindGameObjectsWithTag("Key");
        TotalKeys = keyObjects.Length;
        
        // Notify UI components about initial key count
        OnKeyCollectionChanged?.Invoke();
    }
    
    
    public void KeyCollected()
    {
        CollectedKeys++;
        
        // Notify UI components about key collection
        OnKeyCollectionChanged?.Invoke();
        
        // Check if all keys are collected
        if (CollectedKeys >= TotalKeys)
        {
            OnAllKeysCollected?.Invoke();
        }
        
        Debug.Log($"Key collected! {CollectedKeys}/{TotalKeys} keys found.");
    }
}
