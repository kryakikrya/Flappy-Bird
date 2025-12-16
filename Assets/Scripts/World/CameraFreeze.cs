using UnityEngine;

public class CameraFreeze : MonoBehaviour
{
    private const float ZPosition = -10;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, 0, ZPosition);
    }
}
