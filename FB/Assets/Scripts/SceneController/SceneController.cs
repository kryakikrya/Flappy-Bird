using Zenject;

public class SceneController
{
    private const string _menuName = "Menu";

    private SignalBus _signalBus;

    private AdsController _ads;

    public SceneController(SignalBus bus)
    {
        _signalBus = bus;

        Subscribe();

        _ads = new AdsController(_menuName);
    }

    private void Subscribe()
    {
        _signalBus.Subscribe<PlayerDiedSignal>(OnPlayerDied);
    }

    public void Unsubscribe()
    {
        _signalBus.Unsubscribe<PlayerDiedSignal>(OnPlayerDied);
    }

    private void OnPlayerDied(PlayerDiedSignal signal)
    {
        _ads.ShowAds();
    }
}
