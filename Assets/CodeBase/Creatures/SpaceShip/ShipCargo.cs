using System;
using UnityEngine;

public class ShipCargo : MonoBehaviour, ICargoRecipient
{
    private const int _countCargoForWin = 5;

    [SerializeField] private TakeZone _takeZone;

    private Hud _hud;
    private int _currentCargo;

    public int MaxCargo => _countCargoForWin;
    public int CurrentCargo => _currentCargo;


    public event Action<int, int> OnCargoCountChanged;

    public void Construct(Hud hud)
    {
        _hud = hud;
    }

    private void OnEnable()
    {
        _takeZone.OnTakeCargo += TakeCargo;
    }

    private void OnDisable()
    {
        _takeZone.OnTakeCargo -= TakeCargo;
    }

    private void TakeCargo(int currentCargo)
    {
        _currentCargo += currentCargo;

        OnCargoCountChanged?.Invoke(_currentCargo, _countCargoForWin);

        if (_currentCargo >= _countCargoForWin)
            _hud.ShowWin();
    }
}
