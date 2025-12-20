using UnityEngine;

public interface IMoveStrategy
{
    public bool IsReversed { get; }

    public void Reverse(Transform player);

    public void Move(float deltaTime, Rigidbody2D rb);

    public void ApplyGravity(float deltaTime, Rigidbody2D rb);

    public bool IsHoldable { get; set; }
}
