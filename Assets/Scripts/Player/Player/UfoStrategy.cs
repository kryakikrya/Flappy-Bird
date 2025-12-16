using UnityEngine;

public class UfoStrategy : IMoveStrategy
{
    private float _jumpForce = 5f;

    private float _gravityScale = -7f;

    public UfoStrategy(float force, float gravity)
    {
        _jumpForce = force;
        _gravityScale = gravity;
    }

    public void Move(float deltaTime, Rigidbody2D rb)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);

        rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    public void ApplyGravity(float deltaTime, Rigidbody2D rb)
    {
        rb.velocity += new Vector2(0, _gravityScale * deltaTime);
    }

    public bool IsHoldable 
    { 
        get
        {
            return false;
        }
        set { }
    }
}
