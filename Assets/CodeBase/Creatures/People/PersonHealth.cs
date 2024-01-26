using System;
using UnityEngine;

public class PersonHealth : MonoBehaviour, IHealth
{
    private float _maxHealth = 3f;
    private float _currentHealth;

    public event Action OnHealthRunOut;
    public event Action<float, float> OnChangeHP;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        OnChangeHP?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0f)
            OnHealthRunOut?.Invoke();
    }
}
