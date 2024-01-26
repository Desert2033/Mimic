using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CargoBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cargoText;
    [SerializeField] private Slider _cargoCurrent;

    private ICargoRecipient _cargoRecipient;

    public void Construct(ICargoRecipient cargoRecipient)
    {
        _cargoRecipient = cargoRecipient;

        _cargoRecipient.OnCargoCountChanged += ChangeCountCargo;

        ChangeCountCargo(_cargoRecipient.CurrentCargo, _cargoRecipient.MaxCargo);
    }

    private void OnDisable()
    {
        _cargoRecipient.OnCargoCountChanged -= ChangeCountCargo;
    }

    public void ChangeCountCargo(int currentCargo, int maxCargo)
    {
        if (currentCargo == maxCargo)
            _cargoText.text = "MAX";
        else
            _cargoText.text = $"{currentCargo}/{maxCargo}";

        if (_cargoCurrent != null)
            _cargoCurrent.value = (float)currentCargo / (float)maxCargo;
    }
}
