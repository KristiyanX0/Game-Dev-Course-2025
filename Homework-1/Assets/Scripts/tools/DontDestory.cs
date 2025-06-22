using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        // Make this object persistent across scenes
        DontDestroyOnLoad(gameObject);
    }
}
