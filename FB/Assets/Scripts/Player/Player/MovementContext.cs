using UnityEngine;

public class MovementContext
{
    private KeyCode _key;

    private IMoveStrategy _currentStrategy;

    private Rigidbody2D _rb;

    public IMoveStrategy CurrentStrategy() => _currentStrategy;

    public MovementContext(KeyCode key, IMoveStrategy startStrategy, Rigidbody2D rb)
    {
        _key = key;

        _currentStrategy = startStrategy;

        _rb = rb;
    }

    public void Tick()
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
