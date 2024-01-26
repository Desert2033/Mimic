using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    
    private Transform _playerTransform;

    public void Construct(Transform playerTransform)
    {
        _playerTransform = playerTransform;
    }

    private void LateUpdate()
    {
        if(_playerTransform != null)
            Follow();
    }

    private void Follow()
    {
        transform.position = _playerTransform.position + _offset;
    }
}
