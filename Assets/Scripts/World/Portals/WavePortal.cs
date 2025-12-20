using UnityEngine;

public class WavePortal : StrategyPortal
{
    [SerializeField] private float _speedScale = 3f;

    private void Awake()
    {
        _moveStrategy = new WaveStrategy(_speedScale);
    }
}
