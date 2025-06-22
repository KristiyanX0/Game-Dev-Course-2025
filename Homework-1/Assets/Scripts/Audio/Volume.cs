using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Image displayImage;
    [SerializeField] private Sprite[] imageOptions;
    private int currentImageIndex = 3;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        UpdateVolumeAndImage();
    }

    public void ChangeVolumeAndImage()
    {
        if (imageOptions.Length == 0 || displayImage == null) return;

        currentImageIndex = (currentImageIndex + 1) % imageOptions.Length; // Automatically wraps back to the first image
        UpdateVolumeAndImage();
    }

    private void UpdateVolumeAndImage()
    {
        if (audioSource != null)
        {
            audioSource.volume = (float)currentImageIndex / (imageOptions.Length - 1);
        }

        if (displayImage != null && imageOptions.Length > 0)
        {
            displayImage.sprite = imageOptions[currentImageIndex];
        }
    }
}