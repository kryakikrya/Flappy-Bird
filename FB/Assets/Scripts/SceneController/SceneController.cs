using Zenject;

public class SceneController
{
    private const string _menuName = "Menu";

    private AdsController _ads;

    public SceneController()
    {
        _ads = new AdsController(_menuName);
    }

    private void OnPlayerDied()
    {
        _ads.ShowAds();
    }
}
