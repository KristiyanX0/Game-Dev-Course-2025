using UnityEngine;

public class HideOnStart : MonoBehaviour
{
    public bool hideOnStart = false;
    void Awake()
    {
        if (gameObject.activeSelf && hideOnStart)
        {
            gameObject.SetActive(false);
        }
    }
}
