using UnityEngine;

public class GameLoopState : IState
{
    private GameStateMachine _gameStateMachine;
    private IGameFactory _gameFactory;

    public GameLoopState(GameStateMachine gameStateMachine, IGameFactory gameFactory)
    {
        _gameStateMachine = gameStateMachine;
        _gameFactory = gameFactory;
    }

    public void Enter()
    {
       _gameFactory.Hud.RestartGame.onClick.AddListener(RestartGame);
       _gameFactory.Hud.BackToMenu.onClick.AddListener(BackToMenu);
    }

    public void Exit()
    {

    }

    private void BackToMenu()
    {
        _gameStateMachine.Enter<LoadMainMenuState>();
    }

    private void RestartGame()
    {
        _gameStateMachine.Enter<LoadLevelState>();
    }
}
