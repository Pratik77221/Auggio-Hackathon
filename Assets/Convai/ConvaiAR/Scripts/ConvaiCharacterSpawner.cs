using UnityEngine;

/// <summary>
/// Instantiates a Convai character at the start of the scene.
/// </summary>
public class ConvaiCharacterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _characterPrefab;
    [SerializeField] private Vector3 _spawnPosition = Vector3.zero;
    [SerializeField] private Quaternion _spawnRotation = Quaternion.identity;

    private void Start()
    {
        if (_characterPrefab != null)
        {
            Instantiate(_characterPrefab, _spawnPosition, _spawnRotation);
            Debug.Log("Character spawned at scene start.");
        }
        else
        {
            Debug.LogError("Character prefab is not assigned.");
        }
    }
}
