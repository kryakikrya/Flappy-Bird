using UnityEngine;

public class WaveStrategy : IMoveStrategy, INeedExit
{
    private const float _angle = 25f;

    private float _scale = 3f;

    public WaveStrategy(float speed)
    {
        _scale = speed;
    }

    public void Move(float deltaTime, Rigidbody2D rb)
    {
        rb.velocity = new Vector2(rb.velocity.x, _scale);

        rb.gameObject.transform.rotation = Quaternion.Euler(0, 0, _angle);
    }

    public void ApplyGravity(float deltaTime, Rigidbody2D rb)
    {
        rb.velocity = new Vector2(rb.velocity.x, -_scale);

        rb.gameObject.transform.rotation = Quaternion.Euler(0, 0, -_angle);
    }

    public void Exit(GameObject player)
    {
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
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
