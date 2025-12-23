using UnityEngine;
using Zenject;

public class BlankPortal : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _color;

    private Portal _portal;

    private SignalBus _signalBus;

    public void InitializeBus(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    public void ChangePortal(Portal portal)
    {
        _portal = portal;

        _color.color = _portal.GetColor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _portal.Action(player);
            _signalBus.Fire<PortalPassedSignal>();
        }
    }
}
