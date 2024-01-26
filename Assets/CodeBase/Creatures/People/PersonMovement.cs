using UnityEngine;
using UnityEngine.AI;

public class PersonMovement : MonoBehaviour
{
    private const float DistanceToRunAway = 4f;
    private const string IsRunAnimation = "IsRun";

    [SerializeField] private NavMeshAgent _meshAgent;
    [SerializeField] private Animator _animator;
    
    private Transform _playerTransform;

    public void Construct(Transform playerTransform)
    {
        _playerTransform = playerTransform;
    }

    private void Update()
    {
        if (CanMove())
            Move();
        else
            Stop();
    }

    public void Stop()
    {
        _animator.SetBool(IsRunAnimation, false);
    }

    public void Move()
    {
        Vector3 directionToPlayer = transform.position - _playerTransform.position;
        Vector3 newPosition = transform.position + directionToPlayer;

        _meshAgent.destination = newPosition;
        _animator.SetBool(IsRunAnimation, true);
    }

    private bool CanMove() =>
        Vector3.Distance(_playerTransform.position, transform.position) <= DistanceToRunAway;
}
