using UnityEngine;

public class CameraFreeze : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, 0, -10);
    }
}
