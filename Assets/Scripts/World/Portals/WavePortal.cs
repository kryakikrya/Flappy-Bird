using UnityEngine;

public class WavePortal : Portal
{
    [SerializeField] private float _speedScale = 3f;

    private void Awake()
    {
        _moveStrategy = new WaveStrategy(_speedScale);
    }
}
