using UnityEngine;

public abstract class Portal
{
    protected Color _color;

    protected IMoveStrategy _moveStrategy;

    public abstract void Action(MovementContext context);

    public Color GetColor() => _color;
}
