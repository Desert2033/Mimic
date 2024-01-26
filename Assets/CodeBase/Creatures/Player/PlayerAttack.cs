using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerAttackZone _attackZone;
    [SerializeField] private GameObject _attackingLegPrefab;
    [SerializeField] private GameObject _attackZoneCanvas;

    private GameObject _attakingLeg;
    private PersonHealth _personHealth;
    private float _damage = 1f;
    private float _cooldownAttack = 1f;
    private float _currentCooldown = 0f;

    public event Action OnKillPerson;

    private void OnEnable()
    {
        _attackZone.OnPersonTrigger += StartAttackPerson;
        _attackZone.OnPersonTriggerOut += StopAttackPerson;
    }


    private void OnDisable()
    {
        _attackZone.OnPersonTrigger -= StartAttackPerson;
        _attackZone.OnPersonTriggerOut -= StopAttackPerson;
    }

    private void Update()
    {
        if (_personHealth == null)
            return;

        _currentCooldown -= Time.deltaTime;

        if (_currentCooldown <= 0f) 
        {
            Attack(_personHealth);
            _currentCooldown = _cooldownAttack;
        }
    }

    private void StopAttackPerson()
    {
        _personHealth.OnHealthRunOut -= KillPerson;

        Destroy(_attakingLeg);
        _personHealth = null;

        _attackZoneCanvas.SetActive(false);
    }

    private void KillPerson()
    {
        _personHealth.OnHealthRunOut -= KillPerson;
        _personHealth = null;
        _attackZoneCanvas.SetActive(false);

        OnKillPerson?.Invoke();
    }

    private void StartAttackPerson(GameObject person)
    {
        _personHealth = person.GetComponent<PersonHealth>();
        _personHealth.OnHealthRunOut += KillPerson;

        _attackZoneCanvas.SetActive(true);
        SpawnAttackLeg(person);
    }

    private void SpawnAttackLeg(GameObject person)
    {
        _attakingLeg = Instantiate(_attackingLegPrefab);
        AttackingLeg attackingLeg = _attakingLeg.GetComponent<AttackingLeg>();

        attackingLeg.Construct(person.transform, transform);
        attackingLeg.ClingToTarget();
    }

    private void Attack(PersonHealth personHP)
    {
        personHP.TakeDamage(_damage);
    }
}
