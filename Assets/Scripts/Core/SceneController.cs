using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using YG;

public class SceneController : MonoBehaviour
{
    [SerializeField] private string _menuName = string.Empty;

    [Inject]  private SignalBus _signalBus;

    private void OnEnable()
    {
        _signalBus.Subscribe<PlayerDiedSignal>(OnPlayerDied);
        YG2.onCloseAnyAdv += ChangeScene;
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<PlayerDiedSignal>(OnPlayerDied);
    }

    private void OnPlayerDied(PlayerDiedSignal signal)
    {
        YG2.InterstitialAdvShow();
    }

    private void ChangeScene()
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
