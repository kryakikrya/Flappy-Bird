using UnityEngine;

public abstract class Model : MonoBehaviour
{
    [SerializeField] protected View _view;

    public abstract void SetData();
}
