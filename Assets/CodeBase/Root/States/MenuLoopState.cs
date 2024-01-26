using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuLoopState : IStateWithParameter<Button>
{
    private GameStateMachine _gameStateMachine;
    private Button _playButton;

    public MenuLoopState(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }

    public void Enter(Button playButton)
    {
        _playButton = playButton;

        _playButton.onClick.AddListener(OnClickPlayButton);
    }

    public void Exit()
    {
        _playButton.onClick.RemoveListener(OnClickPlayButton);
    }

    private void OnClickPlayButton()
    {
        _gameStateMachine.Enter<LoadLevelState>();
    }
}