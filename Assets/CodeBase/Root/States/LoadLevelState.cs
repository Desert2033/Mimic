using MimicSpace;
using UnityEngine;
using UnityEngine.Playables;

public class LoadLevelState : IState
{
    private const string GameSceneName = "GameScene";
    private const string PlayerSpawnPointTag = "PlayerSpawnPoint";

    private IGameFactory _gameFactory;
    private IInputService _inputService;
    private GameStateMachine _gameStateMachine;
    private SceneLoader _sceneLoader;
    private GameObject _spaceShip;

    public LoadLevelState(GameStateMachine gameStateMachine,
        SceneLoader sceneLoader,
        IGameFactory gameFactory,
        IInputService inputService)
    {
        _gameFactory = gameFactory;
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
        _inputService = inputService;
    }

    public void Enter()
    {
        _sceneLoader.Load(GameSceneName, OnLoadedScene);
    }

    public void Exit()
    {
    }

    private void OnLoadedScene()
    {
        _spaceShip = _gameFactory.CreateSpaceShip(new Vector3(-1, 0, -9), new Quaternion(0, 90, 0, 0));
        Animator spaceShipAnimator = _spaceShip.GetComponent<Animator>();

        InitStartGameClip(spaceShipAnimator);
    }

    private void InitStartGameClip(Animator spaceShipAnimator)
    {
        GameObject timeline = _gameFactory.CreateStartTimeLine();
        PlayableDirector clip = timeline.GetComponent<PlayableDirector>();
        
        foreach (PlayableBinding item in clip.playableAsset.outputs)
        {
            if (item.sourceObject.name == "TrackShip")
                clip.SetGenericBinding(item.sourceObject, spaceShipAnimator);
            else if (item.sourceObject.name == "TrackCamera")
                clip.SetGenericBinding(item.sourceObject, Camera.main.GetComponent<Animator>());
        }

        clip.stopped += InitGameWorld;
        clip.Play();
    }

    private void InitGameWorld(PlayableDirector playableDirector)
    {
        GameObject player = InitPlayer();
        Hud hud = InitHud(player);

        InitCamera(player);
        InitSpawners(player);
        InitSpaceShip(hud);

        _gameStateMachine.Enter<GameLoopState>();
    }

    private void InitSpaceShip(Hud hud)
    {
        ShipCargo cargo = _spaceShip.GetComponent<ShipCargo>();
        cargo.enabled = true;
        cargo.Construct(hud);
    }

    private Hud InitHud(GameObject player)
    {
        GameObject hudObject = _gameFactory.CreateHud();
        Hud hud = hudObject.GetComponent<Hud>();
        hud.CargoMaxForPlayer.Construct(player.GetComponent<ICargoRecipient>());
        hud.CargoForWin.Construct(_spaceShip.GetComponent<ICargoRecipient>());

        return hud;
    }

    private void InitSpawners(GameObject player)
    {
        PeopleSpawner[] peopleSpawners = GameObject.FindObjectsOfType<PeopleSpawner>();

        foreach (PeopleSpawner spawner in peopleSpawners)
        {
            spawner.Spawn(_gameFactory, player.transform);
        }
    }

    private void InitCamera(GameObject player)
    {
        CameraFollow cameraFollow = Camera.main.GetComponent<CameraFollow>();
        cameraFollow.Construct(player.transform);
    }

    private GameObject InitPlayer()
    {
        GameObject playerSpawnPoint = GameObject.FindWithTag(PlayerSpawnPointTag);
        GameObject player = _gameFactory.CreatePlayer(
            playerSpawnPoint.transform.position,
            playerSpawnPoint.transform.rotation);

        Movement movement = player.GetComponent<Movement>();
        movement.Construct(_inputService);

        return player;
    }
}