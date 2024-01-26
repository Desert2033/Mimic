using UnityEngine;

public class BootstrapState : IState
{
    private const string NameScene = "BootstrapScene";

    private GameStateMachine _gameStateMachine;
    private SceneLoader _sceneLoader;
    private AllServices _allServices;

    public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices allServices)
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
        _allServices = allServices;

        RegisterServices();
    }

    public void Enter()
    {
        _sceneLoader.Load(NameScene, OnSceneLoad);
    }

    public void Exit()
    {
    }

    private void RegisterServices()
    {
        _allServices.Register<IInputService>(new MobileInputService());
        _allServices.Register<IAssets>(new AssetProvider());
        _allServices.Register<IGameFactory>(new GameFactory(_allServices.Single<IAssets>()));
    }

    private void OnSceneLoad()
    {
        _gameStateMachine.Enter<LoadMainMenuState>();
    }
}