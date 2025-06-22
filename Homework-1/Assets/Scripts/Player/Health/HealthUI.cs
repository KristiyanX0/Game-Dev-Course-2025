using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour, IHealthUI
{
    [Header("Heart UI")]
    [SerializeField] private GameObject heartPrefab; // Prefab of heart UI element
    [SerializeField] private Transform heartsParent; // Parent transform to hold instantiated hearts
    [SerializeField] private Sprite fullHeartSprite; // Sprite for a full heart
    [SerializeField] private Sprite emptyHeartSprite; // Sprite for an empty heart
    
    private List<Image> heartImages = new List<Image>(); // List to store instantiated heart images

    public void Initialize(int maxHealth)
    {
        foreach (Transform child in heartsParent)
        {
            Destroy(child.gameObject);
        }
        heartImages.Clear();
        
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject heartInstance = Instantiate(heartPrefab, heartsParent);
            Image heartImage = heartInstance.GetComponent<Image>();
            
            if (heartImage != null)
            {
                heartImage.sprite = fullHeartSprite;
                heartImages.Add(heartImage);
            }
        }
    }

    public void UpdateDisplay(int currentHealth)
    {
        for (int i = 0; i < heartImages.Count; i++)
        {
            if (i < currentHealth)
            {
                heartImages[i].sprite = fullHeartSprite;
            }
            else
            {
                heartImages[i].sprite = emptyHeartSprite;
            }
        }
    }
}
