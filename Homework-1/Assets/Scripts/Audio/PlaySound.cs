using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    
    private void Start()
    {
        if (audioSource == null)
        {
            // First try to get the component from this GameObject
            audioSource = GetComponent<AudioSource>();
            
            // If still null, try to find an AudioSource by tag
            if (audioSource == null)
            {
                GameObject audioObject = GameObject.FindWithTag("audio");
                if (audioObject != null)
                {
                    audioSource = audioObject.GetComponent<AudioSource>();
                }
                
                // Log warning if audio source is still not found
                if (audioSource == null)
                {
                    Debug.LogWarning("PlaySound: No AudioSource found. Make sure there's an AudioSource component on this GameObject or on an object tagged 'audio'.");
                }
            }
        }
    }

    /// <summary>
    /// Plays the provided audio clip
    /// </summary>
    /// <param name="clip">The audio clip to play</param>
    /// <param name="volume">Volume of the sound (0.0 to 1.0)</param>
    public void Play(AudioClip clip)
    {
        if (audioSource == null || clip == null) return;
        
        audioSource.clip = clip;
        audioSource.Play();
    }
    
    /// <summary>
    /// Plays the audio clip once without changing the AudioSource's clip property
    /// </summary>
    /// <param name="clip">The audio clip to play</param>
    /// <param name="volume">Volume of the sound (0.0 to 1.0)</param>
    public void PlayOneShot(AudioClip clip)
    {
        if (audioSource == null || clip == null) return;
        
        audioSource.PlayOneShot(clip);
    }
    
    /// <summary>
    /// Stops any currently playing sound
    /// </summary>
    public void StopSound()
    {
        if (audioSource == null) return;
        
        audioSource.Stop();
    }
}
