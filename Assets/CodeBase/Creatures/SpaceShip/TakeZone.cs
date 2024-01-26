using System;
using UnityEngine;

public class TakeZone : MonoBehaviour
{
    public event Action<int> OnTakeCargo; 

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerCargo playerCargo))
        {
            OnTakeCargo?.Invoke(playerCargo.CurrentCargo);
            playerCargo.CleanCargo();
        }
    }
}
