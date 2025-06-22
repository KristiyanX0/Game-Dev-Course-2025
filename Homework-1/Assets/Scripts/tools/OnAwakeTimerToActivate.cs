using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAwakeTimerToActivate : MonoBehaviour
{
    // List of objects to activate
    [SerializeField] private List<GameObject> objectsToActivate;
    
    // Public variable for delay time in seconds
    public float delayTime = 3f;

    private void Awake()
    {
        // Start the timer coroutine
        StartCoroutine(ActivateObjectsAfterDelay(delayTime));
    }

    private IEnumerator ActivateObjectsAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Activate each object in the list
        foreach (var obj in objectsToActivate)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}
