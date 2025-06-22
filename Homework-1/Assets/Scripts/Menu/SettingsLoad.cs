using UnityEngine;
using UnityEngine.UI;

public class SettingsLoad : MonoBehaviour
{
    public string objectName; // Name of the GameObject to find

    public Button button;

    void Awake()
    {
        GameObject foundObject = FindGameObjectByName(objectName);
        
        button.onClick.AddListener(() =>
        {
            if (foundObject != null)
            {
                foundObject.SetActive(!foundObject.activeSelf);
            }
            else
            {
                Debug.LogWarning($"GameObject with name {objectName} not found.");
            }
        });
    }

    private GameObject FindGameObjectByName(string name)
    {
        // Search for both active and inactive objects
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.name == name)
            {
                return obj;
            }
        }
        return null;
    }
}
