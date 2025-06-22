using UnityEngine;

public class Toggle : MonoBehaviour
{
    public void ToggleGameObject(GameObject target)
    {
        // Toggle the active state of the target GameObject
        target.SetActive(!target.activeSelf);
    }
}
