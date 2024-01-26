using UnityEngine;

public class GameRunner : MonoBehaviour
{
    [SerializeField] private GameBootstrapper _gameBootstrapperPrefab;

    private void Awake()
    {
        GameBootstrapper bootstrapper = FindObjectOfType<GameBootstrapper>();

        if (bootstrapper == null)
            Instantiate(_gameBootstrapperPrefab);
    }
}
