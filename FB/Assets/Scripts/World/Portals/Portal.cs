using UnityEngine;

public abstract class Portal
{
    protected Color _color;

    protected IMoveStrategy _moveStrategy;

    public abstract void Action(Player player);

    public Color GetColor() => _color;
}
