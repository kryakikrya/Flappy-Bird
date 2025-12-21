public abstract class StrategyPortal : Portal
{
    public override void Action(MovementContext context)
    {
        ChangePlayerStrategy(context);
    }

    public virtual void ChangePlayerStrategy(MovementContext context)
    {
        if (_moveStrategy != null && context.CurrentStrategy() != _moveStrategy)
        {
            context.ChangeStrategy(_moveStrategy);
        }
    }
}
