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

    public abstract void Action(MovementContext context);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out MovementContext context))
        {
            Action(context);
            _signalBus?.Fire<PortalPassedSignal>();
        }
    }
}
