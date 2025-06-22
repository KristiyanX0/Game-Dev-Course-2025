using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    [Tooltip("Event that will be invoked when this key is collected")]
    [SerializeField] private UnityEvent OnKeyCollected;
    
    [Tooltip("Tag of the object that can collect this key")]
    [SerializeField] private string collectorTag = "Player";
    
    [Tooltip("The sprite to show when key exists (before collection)")]
    [SerializeField] private Sprite keyExistsSprite;
    
    [Tooltip("The sprite to show when key is collected")]
    [SerializeField] private Sprite keyCollectedSprite;
    
    private bool isCollected = false;
    private SpriteRenderer spriteRenderer;
    
    private void Awake()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider == null || !boxCollider.isTrigger)
        {
            Debug.LogError($"Key '{gameObject.name}' requires a BoxCollider2D with 'Is Trigger' enabled!");
        }
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError($"Key '{gameObject.name}' requires a SpriteRenderer component!");
        }
        else if (keyExistsSprite != null)
        {
            spriteRenderer.sprite = keyExistsSprite;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isCollected) return;
        
        if (other.CompareTag(collectorTag))
        {
            CollectKey();
        }
    }
    
    private void CollectKey()
    {
        isCollected = true;
        
        OnKeyCollected?.Invoke();
        
        if (spriteRenderer != null && keyCollectedSprite != null)
        {
            spriteRenderer.sprite = keyCollectedSprite;
        }
        
        if (TryGetComponent<BoxCollider2D>(out var collider))
        {
            collider.enabled = false;
        }
    }
}
