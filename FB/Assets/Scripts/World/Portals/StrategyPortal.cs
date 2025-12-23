public abstract class StrategyPortal : Portal
{
    public override void Action(Player player)
    {
        ChangePlayerStrategy(player.Context());
    }

    public virtual void ChangePlayerStrategy(MovementContext context)
    {
        if (_moveStrategy != null && context.CurrentStrategy() != _moveStrategy)
        {
            context.ChangeStrategy(_moveStrategy);
        }
    }
}
