using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneController : MonoBehaviour
{
    [SerializeField] private string _menuName = string.Empty;

    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    private void OnEnable()
    {
        _signalBus.Subscribe<PlayerDiedSignal>(OnPlayerDied);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<PlayerDiedSignal>(OnPlayerDied);
    }

    private void OnPlayerDied(PlayerDiedSignal signal)
    {
        if (_menuName != string.Empty)
        {
            SceneManager.LoadScene(_menuName);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
