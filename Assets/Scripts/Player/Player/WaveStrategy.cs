using UnityEngine;

public class WaveStrategy : IMoveStrategy, INeedExit
{
    private float _scale = 3f;

    public WaveStrategy(float speed)
    {
        _scale = speed;
    }

    public void Move(float deltaTime, Rigidbody2D rb)
    {
        rb.velocity = new Vector2(rb.velocity.x, _scale);

        rb.gameObject.transform.rotation = Quaternion.Euler(0, 0, 35f);
    }

    public void ApplyGravity(float deltaTime, Rigidbody2D rb)
    {
        rb.velocity = new Vector2(rb.velocity.x, -_scale);

        rb.gameObject.transform.rotation = Quaternion.Euler(0, 0, -35f);
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
