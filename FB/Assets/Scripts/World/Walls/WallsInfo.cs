using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WallsInfo")]
public class WallsInfo : ScriptableObject
{
    public int WallsCount;

    public Wall WallPrefab;

    public Vector3 SpawnPoint;

    public float YOffset;

    public float Cooldown;

    public float CooldownOffset;
}
