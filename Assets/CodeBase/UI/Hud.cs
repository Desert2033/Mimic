using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Hud : MonoBehaviour
{
    private const float DurationShowHint = 2f;

    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private Button _closeMenu;
    [SerializeField] private Button _restartGame;
    [SerializeField] private Button _backToMenu;
    [SerializeField] private Button _menuButton;
    [SerializeField] private CargoBar _cargoMaxForPlayer;
    [SerializeField] private CargoBar _cargoForWin;
    [SerializeField] private GameObject _hintText;
    [SerializeField] private GameObject _levelComplete;

    public CargoBar CargoMaxForPlayer => _cargoMaxForPlayer;
    public CargoBar CargoForWin => _cargoForWin;
    public Button RestartGame => _restartGame;
    public Button BackToMenu => _backToMenu;

    private void OnEnable()
    {
        _menuButton.onClick.AddListener(ShowMenuPanel);
        _closeMenu.onClick.AddListener(HideMenuPanel);

        StartCoroutine(ShowHint());
    }

    private void OnDisable()
    {
        _menuButton.onClick.RemoveListener(ShowMenuPanel);
        _closeMenu.onClick.RemoveListener(HideMenuPanel);
    }

    public void ShowWin()
    {
        _menuPanel.SetActive(true);
        _levelComplete.SetActive(true);

        _closeMenu.gameObject.SetActive(false);
    }

    private void ShowMenuPanel()
    {
        _menuPanel.SetActive(true);
    }

    private void HideMenuPanel()
    {
        _menuPanel.SetActive(false);
    }

    private IEnumerator ShowHint()
    {
        yield return new WaitForSeconds(DurationShowHint);
        _hintText.SetActive(false);
    }

}
