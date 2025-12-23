using UnityEngine;
using Zenject;

public class WallDestroyer : MonoBehaviour
{
    private WallsPool _pool;

    [Inject]
    public void Construct(WallsPool pool)
    {
        _pool = pool;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Wall wall))
        {
            _pool.KillWall(wall);
        }
    }
}
