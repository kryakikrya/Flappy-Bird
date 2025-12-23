using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private KeyCode _key;

    private MovementContext _movementContext;

    private AdsController _adsController;

    public MovementContext Context() => _movementContext;

    [Inject]
    private void Construct(AdsController ads, IMoveStrategy startStrategy)
    {
        _adsController = ads;

        _movementContext = new MovementContext(_key, startStrategy, GetComponent<Rigidbody2D>());
    }

    private void Update()
    {
        _movementContext.Tick();
    }

    public void Death()
    {
        _adsController.ShowAds();
    }
}
