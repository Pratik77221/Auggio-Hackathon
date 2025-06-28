using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles the UI toggle for enabling or disabling the character GameObject.
/// </summary>
public class CharacterSpawnModeActiveStatusHandler : MonoBehaviour
{
    // UI toggle for showing/hiding the character
    [SerializeField] private Toggle _characterToggle;

    // Reference to the ConvaiCharacterSpawner
    private ConvaiCharacterSpawner _convaiCharacterSpawner;

    // Cached reference to the spawned character
    private GameObject _spawnedCharacter;

    private void Awake()
    {
        _convaiCharacterSpawner = FindObjectOfType<ConvaiCharacterSpawner>();

        if (_characterToggle != null)
            _characterToggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void Start()
    {
        // Cache the spawned character if it exists
        _spawnedCharacter = GameObject.FindWithTag("ConvaiCharacter");

        // Optionally sync toggle with character state
        if (_characterToggle != null && _spawnedCharacter != null)
        {
            _characterToggle.isOn = _spawnedCharacter.activeSelf;
        }
    }

    private void OnToggleValueChanged(bool isActive)
    {
        if (_spawnedCharacter != null)
        {
            _spawnedCharacter.SetActive(isActive);
        }
    }

    private void OnDestroy()
    {
        if (_characterToggle != null)
            _characterToggle.onValueChanged.RemoveListener(OnToggleValueChanged);
    }
}
