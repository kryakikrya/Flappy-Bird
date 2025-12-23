using UnityEngine;

public class WaveStrategy : IMoveStrategy, INeedExit
{
    public bool IsReversed { get; private set; } = false;

    private const float _angle = 25f;

    private float _scale = 3f;

    public bool IsHoldable
    {
        get
        {
            return true;
        }
        set { }
    }

    public WaveStrategy(float speed)
    {
        _scale = speed;
    }

    public void Move(float deltaTime, Rigidbody2D rb)
    {
        float reverse = IsReversed ? -1 : 1;

        rb.velocity = new Vector2(rb.velocity.x, _scale * reverse);

        rb.gameObject.transform.rotation = Quaternion.Euler(0, 0, _angle * reverse);
    }

    public void ApplyGravity(float deltaTime, Rigidbody2D rb)
    {
        float reverse = IsReversed ? -1 : 1;

        rb.velocity = new Vector2(rb.velocity.x, -_scale * reverse);

        rb.gameObject.transform.rotation = Quaternion.Euler(0, 0, -_angle * reverse);
    }

    public void Exit(GameObject player)
    {
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        player.transform.localScale = Vector3.one;
        IsReversed = false;
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
}
