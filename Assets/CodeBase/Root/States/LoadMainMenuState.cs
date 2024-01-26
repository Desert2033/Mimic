using System;
using UnityEngine;
using UnityEngine.UI;

public class LoadMainMenuState : IState
{
    private const string MainMenuScene = "MainMenuScene";

    private GameStateMachine _gameStateMachine;
    private SceneLoader _sceneLoader;
    private IGameFactory _gameFactory;

    public LoadMainMenuState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IGameFactory gameFactory)
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
        _gameFactory = gameFactory;
    }

    public void Enter()
    {
        _sceneLoader.Load(MainMenuScene, OnLoadedScene);
    }

    private void OnLoadedScene()
    {
        GameObject mainMenuObject = _gameFactory.CreateMainMenu();
        MainMenuUI mainMenu = mainMenuObject.GetComponent<MainMenuUI>();

       _gameStateMachine.Enter<MenuLoopState, Button>(mainMenu.PlayButton);
    }

    public void Exit()
    {
    }
}