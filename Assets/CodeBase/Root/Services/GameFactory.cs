using UnityEngine;

public class GameFactory : IGameFactory
{
    public Hud Hud { get; private set; }
    
    private IAssets _assets;

    public GameFactory(IAssets assets)
    {
        _assets = assets;
    }

    public GameObject CreateMainMenu() =>
        _assets.Instantiate(AssetPath.MainMenuPath);

    public GameObject CreateHud()
    {
        GameObject hudObject = _assets.Instantiate(AssetPath.HudPath);
        Hud = hudObject.GetComponent<Hud>();
        return hudObject;
    }

    public GameObject CreateSpaceShip(Vector3 at, Quaternion rotation) =>
        _assets.Instantiate(AssetPath.SpaceShipPath, at, rotation);

    public GameObject CreateStartTimeLine() =>
        _assets.Instantiate(AssetPath.StartGameTimeLinePath);

    public GameObject CreatePlayer(Vector3 at, Quaternion rotation) =>
        _assets.Instantiate(AssetPath.PlayerPath, at, rotation);

    public GameObject CreatePerson(GameObject prefab, Vector3 at, Quaternion rotation) => 
        _assets.Instantiate(prefab, at, rotation);
}
