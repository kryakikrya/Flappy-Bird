using UnityEngine.SceneManagement;
using YG;

public class AdsController
{
    private string _menuName;

    public AdsController(string menu)
    {
        YG2.onCloseAnyAdv += ChangeScene;

        _menuName = menu;
    }

    public void ShowAds()
    {
        YG2.InterstitialAdvShow();
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(_menuName);
    }
}
