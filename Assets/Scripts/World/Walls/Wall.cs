using UnityEngine;
using Zenject;

public class Wall : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private GameObject _portalPoint;

    [SerializeField] private BlankPortal _portal;

    private WallsPool _pool;

    public Transform PortalPoint() => _portalPoint.transform;

    public void InitializePool(WallsPool pool)
    {
        _pool = pool;
    }

    public void SetPortal(Portal portal, SignalBus bus)
    {
        _portal.ChangePortal(portal);
        _portal.InitializeBus(bus);
    }

    private void Update()
    {
        transform.Translate(new Vector3 (-_speed, 0, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.Death();
        }
    }
}
