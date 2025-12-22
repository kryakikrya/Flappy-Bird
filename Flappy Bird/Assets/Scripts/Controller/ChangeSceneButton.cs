using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour
{
    [SerializeField] private int _id;

    public void ChangeScene()
    {
        SceneManager.LoadScene(_id);
    }
}
