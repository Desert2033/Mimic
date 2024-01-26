using System;
using UnityEngine;

public class PlayerCargo : MonoBehaviour, ICargoRecipient
{
    [SerializeField] private PlayerAttack _attack;

    private int _maxCargo = 3;
    private int _currentCargo = 0;

    public int MaxCargo =>_maxCargo;
    public int CurrentCargo => _currentCargo;

    public event Action<int, int> OnCargoCountChanged;

    private void OnEnable()
    {
        _attack.OnKillPerson += AddCargo;
    }

    private void OnDisable()
    {
        _attack.OnKillPerson -= AddCargo;
    }

    public void CleanCargo()
    {
        _currentCargo = 0;
        _attack.enabled = true;

        OnCargoCountChanged?.Invoke(_currentCargo, _maxCargo);
    }

    private void AddCargo()
    {
        _currentCargo++;

        OnCargoCountChanged?.Invoke(_currentCargo, _maxCargo);

        if (_currentCargo >= _maxCargo)
        {
            _attack.enabled = false;
        }
    }
}
