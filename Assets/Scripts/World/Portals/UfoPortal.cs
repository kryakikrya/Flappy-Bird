
using UnityEngine;

public class UfoPortal : Portal
{
    [SerializeField] private float _jumpForce = 5f;

    [SerializeField] private float _gravityScale = -7f;

    private void Awake()
    {
        _moveStrategy = new UfoStrategy(_jumpForce, _gravityScale);
    }
}
