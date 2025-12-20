using UnityEngine;

public class MovementContext : MonoBehaviour
{
    [SerializeField] private KeyCode _key;

    private IMoveStrategy _currentStrategy;

    private Rigidbody2D _rb;

    public IMoveStrategy CurrentStrategy() => _currentStrategy;

    private void Awake()
    {
        _currentStrategy = new UfoStrategy(0, 0);

        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
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

        bool reversed = _currentStrategy.IsReversed;

        _currentStrategy = strategy;

        transform.localScale = Vector3.one;

        if (reversed)
        {
            _currentStrategy.Reverse(transform);
        }
    }
}
