using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private GameObject _portalPoint;

    private WallsPool _pool;

    private Portal _portal;

    public Transform PortalPoint() => _portalPoint.transform;

    public Portal Portal() => _portal;

    public void InitializePool(WallsPool pool)
    {
        _pool = pool;
    }

    public void SetPortal(Portal portal)
    {
        _portal = portal;
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
