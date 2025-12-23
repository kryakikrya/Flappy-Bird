using UnityEngine;
using Zenject;

public class MovementContext : MonoBehaviour
{
    [SerializeField] private KeyCode _key;

    [Inject] IMoveStrategy _startStrategy;

    private IMoveStrategy _currentStrategy;

    private Rigidbody2D _rb;

    public IMoveStrategy CurrentStrategy() => _currentStrategy;

    private void Awake()
    {
        _currentStrategy = _startStrategy;

        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_currentStrategy.IsHoldable)
        {
            UseHoldableStrategy();
        }
        else
        {
            UseNotHoldableStrategy();
        }
    }

    public void UseHoldableStrategy()
    {
        if (Input.GetKey(_key))
        {
            _currentStrategy.Move(Time.deltaTime, _rb);
        }
        else
        {
            _currentStrategy.ApplyGravity(Time.deltaTime, _rb);
        }
    }

    public void UseNotHoldableStrategy()
    {
        if (Input.GetKeyDown(_key))
        {
            _currentStrategy.Move(Time.deltaTime, _rb);
        }
        else
        {
            _currentStrategy.ApplyGravity(Time.deltaTime, _rb);
        }
    }

    public void ChangeStrategy(IMoveStrategy strategy)
    {
        if (_currentStrategy is INeedExit exit)
        {
            exit.Exit(_rb.gameObject);
        }

        _currentStrategy = strategy;
    }
}
