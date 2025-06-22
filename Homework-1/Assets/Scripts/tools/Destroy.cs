using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Target GameObject to destroy
    public GameObject targetToDestroy;
    
    // Optional delay before destroying
    public float delay = 0f;
    
    // Flag to determine if this GameObject should also be destroyed
    public bool destroySelf = false;

    // Method to destroy the target
    public void DestroyTarget()
    {
        if (targetToDestroy != null)
        {
            Destroy(targetToDestroy, delay);
        }
        
        if (destroySelf)
        {
            Destroy(gameObject, delay);
        }
    }
    
    // Method to set target and destroy it immediately
    public void DestroyObject(GameObject objectToDestroy)
    {
        if (objectToDestroy != null)
        {
            Destroy(objectToDestroy);
        }
    }
    
    // Method to destroy with custom delay
    public void DestroyObjectWithDelay(GameObject objectToDestroy, float customDelay)
    {
        if (objectToDestroy != null)
        {
            Destroy(objectToDestroy, customDelay);
        }
    }
}
