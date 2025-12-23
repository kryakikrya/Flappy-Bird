using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private KeyCode _key;

    private SignalBus _signalBus;

    private MovementContext _movementContext;

    public MovementContext Context() => _movementContext;

    [Inject]
    private void Construct(IMoveStrategy startStrategy, SignalBus bus)
    {
        _movementContext = new MovementContext(_key, startStrategy, GetComponent<Rigidbody2D>());

        _signalBus = bus;
    }

    private void Update()
    {
        _movementContext.Tick();
    }

    public void Death()
    {
        _signalBus.Fire<PlayerDiedSignal>();
    }
}
