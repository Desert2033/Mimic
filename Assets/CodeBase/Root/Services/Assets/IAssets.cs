using UnityEngine;

public interface IAssets : IService
{
    GameObject Instantiate(string path);
    GameObject Instantiate(string path, Vector3 at, Quaternion rotation);
    GameObject Instantiate(GameObject prefab, Vector3 at, Quaternion rotation);
}