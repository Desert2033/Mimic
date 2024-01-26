using UnityEngine;

public interface IGameFactory : IService
{
    Hud Hud { get; }

    GameObject CreateHud();
    GameObject CreateMainMenu();
    GameObject CreatePerson(GameObject prefab, Vector3 at, Quaternion rotation);
    GameObject CreatePlayer(Vector3 at, Quaternion rotation);
    GameObject CreateSpaceShip(Vector3 at, Quaternion rotation);
    GameObject CreateStartTimeLine();
}
