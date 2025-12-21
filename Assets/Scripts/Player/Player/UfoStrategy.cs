using UnityEngine;

public class UfoStrategy : IMoveStrategy, INeedExit
{
    public bool IsReversed { get; private set; } = false;

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
        if (IsReversed)
        {
            IsReversed = false;
            player.localScale = new Vector3(player.localScale.x, 1, player.localScale.z);
        }
        else
        {
            IsReversed = true;
            player.localScale = new Vector3(player.localScale.x, -1, player.localScale.z);
        }
    }

    public void Exit(GameObject player)
    {
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        player.transform.localScale = Vector3.one;
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
