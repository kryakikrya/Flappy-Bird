using UnityEngine;

public class ReversePortal : Portal
{
    public ReversePortal(Color color)
    {
        _color = color;
    }

    public override void Action(Player player)
    {
        player.Context().CurrentStrategy().Reverse(player.transform);
    }
}
