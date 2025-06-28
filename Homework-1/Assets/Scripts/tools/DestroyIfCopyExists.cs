using UnityEngine;

public class DestroyIfCopyExists : MonoBehaviour
{
    private void Awake()
    {
        // Find all objects with the same tag as this object
        GameObject[] objectsWithSameTag = GameObject.FindGameObjectsWithTag(gameObject.tag);
        
        // If more than one object with the same tag exists
        if (objectsWithSameTag.Length > 1)
        {
            // Check if this instance is not the first one
            foreach (GameObject obj in objectsWithSameTag)
            {
                if (obj != gameObject)
                {
                    // If another object with the same tag exists, destroy this one
                    Destroy(gameObject);
                    return;
                }
            }
        }
    }
}
