using UnityEngine;
using Zenject;

public abstract class Portal : MonoBehaviour
{
    private SignalBus _signalBus;

    protected IMoveStrategy _moveStrategy;

    public void InitializeBus(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    public virtual void ChangePlayerStrategy(MovementContext context)
    {
        if (_moveStrategy != null)
        {
            context.ChangeStrategy(_moveStrategy);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out MovementContext context))
        {
            ChangePlayerStrategy(context);
            _signalBus?.Fire<PortalPassedSignal>();
        }
    }
}
