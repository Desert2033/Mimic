using UnityEngine;

public class RotationRepeater : MonoBehaviour
{
    [SerializeField] private Vector3 _speedRotation;

    private void Update()
    {
        transform.rotation *= Quaternion.Euler(_speedRotation);
    }
}
