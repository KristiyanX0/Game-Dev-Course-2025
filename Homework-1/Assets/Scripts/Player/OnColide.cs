using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Invokes UnityEvent when this object collides with another object.
/// Can be filtered by tag.
/// </summary>
public class OnColide : MonoBehaviour
{
    [Tooltip("Event triggered when collision happens")]
    public UnityEvent onCollisionEnter;

    [Tooltip("Only detect collisions with objects having this tag")]
    public string targetTag = "";

    [Tooltip("If true, will check for tag match. If false, triggers on all collisions")]
    public bool useTagFilter = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (!useTagFilter || collision.gameObject.CompareTag(targetTag))
        {
            onCollisionEnter.Invoke();
        }
    }
}
