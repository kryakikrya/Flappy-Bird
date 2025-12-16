using UnityEngine;

public abstract class Portal : MonoBehaviour
{
    protected IMoveStrategy _moveStrategy;

    public virtual void ChangePlayerStrategy(MovementContext context)
    {
        if (_moveStrategy != null)
        {
            context.ChangeStrategy(_moveStrategy);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out MovementContext context))
        {
            ChangePlayerStrategy(context);
        }
    }
}
