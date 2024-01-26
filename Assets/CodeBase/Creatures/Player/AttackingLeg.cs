using UnityEngine;

public class AttackingLeg : MonoBehaviour
{
    private const float DistanceToDestroy = 1f;

    [SerializeField] private LineRenderer _line;

    private Transform _target;
    private Transform _player;
    private IHealth _targetHealth;
    private bool _canBring = false;
    private float _bringSpeed = 8f;

    public void Construct(Transform transform, Transform player)
    {
        _target = transform;
        _player = player;

        _targetHealth = _target.GetComponent<IHealth>();

        _targetHealth.OnHealthRunOut += StartBringTarget;
    }

    private void Update()
    {
        if (_canBring)
        {
            BringTarget(Time.deltaTime * _bringSpeed);

            if (CanStopBring())
                StopBringTarget();
        }
        else
        {
            ClingToTarget();
        }
    }

    private bool CanStopBring() =>
        Vector3.Distance(_line.GetPosition(0), _line.GetPosition(1)) <= DistanceToDestroy;

    private void StartBringTarget()
    {
        _canBring = true;
    }

    private void StopBringTarget()
    {
        Destroy(_target.gameObject);
        Destroy(gameObject);
    }

    public void ClingToTarget()
    {
        Vector3 targetPosition = _target.position;
        targetPosition.y += 1.5f;

        _line.SetPosition(0, _player.position);
        _line.SetPosition(1, targetPosition);
    }

    public void BringTarget(float step)
    {
        Vector3 lineNewPosition = Vector3.MoveTowards(_line.GetPosition(1), _line.GetPosition(0), step);

        _line.SetPosition(0, _player.position);
        _line.SetPosition(1, lineNewPosition);
        _target.position = lineNewPosition;
    }
}
