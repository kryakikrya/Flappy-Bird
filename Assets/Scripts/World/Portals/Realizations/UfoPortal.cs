using UnityEngine;

public class UfoPortal : StrategyPortal
{
    public UfoPortal(float jumpForce, float gravityScale, Color color)
    {
        _moveStrategy = new UfoStrategy(jumpForce, gravityScale);

        _color = color;
    }
}
