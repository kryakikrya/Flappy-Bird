using UnityEngine;

public class WaveStrategy : IMoveStrategy, INeedExit
{
    public bool IsReversed { get; private set; }

    private const float _angle = 25f;

    private float _scale = 3f;

    public WaveStrategy(float speed)
    {
        _scale = speed;

        IsReversed = false;
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
            return true;
        }
        set { }
    }
}
