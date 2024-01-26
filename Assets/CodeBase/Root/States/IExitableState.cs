public interface IExistableState
{
    void Exit();
}

public interface IState : IExistableState
{
    void Enter();
}

public interface IStateWithParameter<TParameter> : IExistableState
{
    void Enter(TParameter parameter);    
}