using UnityEngine;

public class ReversePortal : Portal
{
    public ReversePortal(Color color)
    {
        _color = color;
    }

    public override void Action(MovementContext context)
    {
        context.CurrentStrategy().Reverse(context.transform);
    }
}
