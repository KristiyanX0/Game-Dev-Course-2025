using UnityEngine;
using UnityEngine.SceneManagement;

public class OnSceneLoadActivate : MonoBehaviour
{
    [Tooltip("GameObject to activate when the target scene is loaded")]
    [SerializeField] private GameObject objectToActivate;

    [Tooltip("Name of the scene that will trigger object activation")]
    [SerializeField] private string targetSceneName = "";

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
        if (string.IsNullOrEmpty(targetSceneName))
        {
            ActivateObject();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (string.IsNullOrEmpty(targetSceneName) || scene.name == targetSceneName)
        {
            ActivateObject();
        }
    }

    private void ActivateObject()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Object to activate is not assigned in " + gameObject.name);
        }
    }
}
