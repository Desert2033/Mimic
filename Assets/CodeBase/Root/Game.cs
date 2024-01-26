public class Game
{
    public GameStateMachine StateMachine { get; private set; } 
    
    public Game(ICoroutineRunner coroutineRunner)
    {
        StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), AllServices.Container);
    }
}
