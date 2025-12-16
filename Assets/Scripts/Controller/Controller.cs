using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    [SerializeField] protected View _view;
    [SerializeField] protected Model _model;

    public abstract void OnInput();
}
