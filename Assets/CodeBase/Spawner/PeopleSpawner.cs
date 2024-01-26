using UnityEngine;

public class PeopleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _personPrefab;

    public void Spawn(IGameFactory gameFactory, Transform playerTransform)
    {
        GameObject person = gameFactory.CreatePerson(_personPrefab, transform.position, transform.rotation);

        PersonMovement personMovement = person.GetComponent<PersonMovement>();

        personMovement.Construct(playerTransform);
    }
}
