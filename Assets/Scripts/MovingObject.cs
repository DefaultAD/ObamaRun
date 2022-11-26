using UnityEngine;

public class MovingObject : MonoBehaviour, IPooledObject
{
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void OnSpawned()
    {
        _playerMovement.MovingObjects.Add(transform);
    }
}
