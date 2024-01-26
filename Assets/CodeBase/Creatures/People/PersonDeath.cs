using UnityEngine;

public class PersonDeath : MonoBehaviour
{
    [SerializeField] private PersonMovement _movement;
    [SerializeField] private PersonHealth _health;

    private void OnEnable()
    {
        _health.OnHealthRunOut += Die;
    }

    private void OnDisable()
    {
        _health.OnHealthRunOut -= Die;
    }

    private void Die()
    {
        _movement.Stop();
        _movement.enabled = false;
    }
}
