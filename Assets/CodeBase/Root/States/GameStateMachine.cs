using System;
using System.Collections.Generic;

public class GameStateMachine
{
    private Dictionary<Type, IExistableState> _states;
    private IExistableState _currentState;

    public GameStateMachine(SceneLoader sceneLoader, AllServices allServices)
    {
        _states = new Dictionary<Type, IExistableState>()
        {
            [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, allServices),
            [typeof(LoadMainMenuState)] = new LoadMainMenuState(this, sceneLoader, allServices.Single<IGameFactory>()),
            [typeof(MenuLoopState)] = new MenuLoopState(this),
            [typeof(LoadLevelState)] = new LoadLevelState(this, 
            sceneLoader, 
            allServices.Single<IGameFactory>(),
            allServices.Single<IInputService>()),
            [typeof(GameLoopState)] = new GameLoopState(this, allServices.Single<IGameFactory>()),
        };
    }

    public void Enter<TState>() where TState : class, IState
    {
        IState state = ChangeState<TState>();
        state.Enter();
    }

    public void Enter<TState, TParameter>(TParameter parameter) where TState : class, IStateWithParameter<TParameter>
    {
        IStateWithParameter<TParameter> state = ChangeState<TState>();
        state.Enter(parameter);
    }

    private TState ChangeState<TState>() where TState : class, IExistableState
    {
        _currentState?.Exit();

        TState state = GetState<TState>();
        _currentState = state;

        return state;
    }

    private TState GetState<TState>() where TState : class, IExistableState => 
        _states[typeof(TState)] as TState;
}