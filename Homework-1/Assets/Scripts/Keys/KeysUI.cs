using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeysUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keysText;
    [SerializeField] private string textFormat = "Keys: {0}/{1}";

    KeyManager keyManager;

    public bool searchForAllKeys = true;
    public int totalKeys;
    public int collectedKeys;
    
    private void Awake()
    {
        if (keysText == null)
        {
            keysText = GetComponent<TextMeshProUGUI>();
            if (keysText == null)
            {
                Debug.LogError("TextMeshProUGUI component not found on KeysUI object!");
            }
        }
    }

    private void Start()
    {
        if (searchForAllKeys)
        {
            GameObject[] keyObjects = GameObject.FindGameObjectsWithTag("Key");
            totalKeys = keyObjects.Length;
        }

        collectedKeys = KeyManager.CollectedKeys;
        totalKeys = KeyManager.TotalKeys;

        UpdateKey(collectedKeys, totalKeys);
    }
    
    public void UpdateKey(int collectedKeys, int totalKeys)
    {
        Debug.Log($"Updating keys UI: {collectedKeys}/{totalKeys}");
        if (keysText != null)
        {
            keysText.text = $"Keys: {collectedKeys}/{totalKeys}";
        }
    }
    public void UpdateKey()
    {
        collectedKeys++;
        UpdateKey(collectedKeys, totalKeys);
    }
}
