using UnityEngine;

public interface IMoveStrategy
{
    public void Move(float deltaTime, Rigidbody2D rb);

    public void ApplyGravity(float deltaTime, Rigidbody2D rb);

    public bool IsHoldable { get; set; }
}
