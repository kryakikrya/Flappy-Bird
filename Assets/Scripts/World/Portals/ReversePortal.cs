public class ReversePortal : Portal
{
    public override void Action(MovementContext context)
    {
        context.CurrentStrategy().Reverse(context.transform);
    }
}
