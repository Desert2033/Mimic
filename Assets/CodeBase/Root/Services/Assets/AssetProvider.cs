using UnityEngine;

public class AssetProvider : IAssets
{
    public GameObject Instantiate(string path)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        return Object.Instantiate(prefab);
    }

    public GameObject Instantiate(GameObject prefab, Vector3 at, Quaternion rotation) =>
        Object.Instantiate(prefab, at, rotation);

    public GameObject Instantiate(string path, Vector3 at, Quaternion rotation)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        return Object.Instantiate(prefab, at, rotation);
    }
}
