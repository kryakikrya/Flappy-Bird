using UnityEngine;

public class WavePortal : StrategyPortal
{
    public WavePortal(float speedScale, Color color)
    {
        _moveStrategy = new WaveStrategy(speedScale);

        _color = color;
    }
}
