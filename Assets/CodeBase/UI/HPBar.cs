using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Slider _currentHP;
    [SerializeField] private GameObject _objectWithHealth;
    
    private IHealth _health;

    private void OnEnable()
    {
        _health = _objectWithHealth.GetComponent<IHealth>();

        _health.OnChangeHP += ChangeHP;
    }

    private void OnDisable()
    {
        _health.OnChangeHP -= ChangeHP;
    }

    public void ChangeHP(float currentHP, float maxHP)
    {
        _currentHP.value = currentHP / maxHP;
    }
}
