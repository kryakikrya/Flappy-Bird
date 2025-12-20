using UnityEngine;

public class UfoStrategy : IMoveStrategy
{
    public bool IsReversed { get; private set; }

    private float _jumpForce = 5f;

    private float _gravityScale = -7f;

    public UfoStrategy(float force, float gravity)
    {
        _jumpForce = force;
        _gravityScale = gravity;

        IsReversed = false;
    }

    public void Move(float deltaTime, Rigidbody2D rb)
    {
        float reverse = IsReversed ? -1 : 1;

        rb.velocity = new Vector2(rb.velocity.x, 0);

        rb.AddForce(Vector2.up * _jumpForce * reverse, ForceMode2D.Impulse);
    }

    public void ApplyGravity(float deltaTime, Rigidbody2D rb)
    {
        float reverse = IsReversed ? -1 : 1;

        rb.velocity += new Vector2(0, reverse * _gravityScale * deltaTime);
    }

    public void Reverse(Transform player)
    {
        player.localScale = new Vector3(player.localScale.x, player.localScale.y * -1, player.localScale.z);

        IsReversed = !IsReversed;
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
