using UnityEngine;

public interface IHealthUI
{
    void Initialize(int maxHealth);
    void UpdateDisplay(int currentHealth);
}
