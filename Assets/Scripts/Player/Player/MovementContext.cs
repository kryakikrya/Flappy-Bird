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
        Debug.Log(_currentStrategy.IsReversed);

        if (_currentStrategy.IsHoldable)
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
        else
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
    }

    public void ChangeStrategy(IMoveStrategy strategy)
    {
        if (_currentStrategy is INeedExit exit)
        {
            exit.Exit(_rb.gameObject);
        }

        if (_currentStrategy.IsReversed)
        {
            _currentStrategy = strategy;
            _currentStrategy.Reverse(transform);
        }
        else
        {
            _currentStrategy = strategy;
        }

        Debug.Log(_currentStrategy.GetType().Name);
    }
}
