using System;
using UnityEngine;

public class PlayerAttackZone : MonoBehaviour
{
    private GameObject _personOnAttack;

    public event Action<GameObject> OnPersonTrigger;
    public event Action OnPersonTriggerOut;

    private void OnTriggerEnter(Collider other)
    {
        if (_personOnAttack != null)
            return;

        if (other.TryGetComponent(out PersonMovement personMovement))
        {
            _personOnAttack = personMovement.gameObject;
            OnPersonTrigger?.Invoke(_personOnAttack);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _personOnAttack)
        {
            _personOnAttack = null;
            OnPersonTriggerOut?.Invoke();
        }
    }
}
