using UnityEngine;
using System.Collections.Generic;

public class WallsPool
{
    private List<Wall> AviableWalls = new List<Wall>();
    private List<Wall> UnaviableWalls = new List<Wall>();

    private WallsPoolController _controller;

    private Transform _spawnPoint;
    private float _yOffset;

    private List<Portal> _portalList;

    public void InitializeInfo(WallsInfo wallsInfo, WallsPoolController controller)
    {
        _spawnPoint = wallsInfo.SpawnPoint.transform;
        _yOffset = wallsInfo.YOffset;

        _controller = controller;
    }

    public void InitializeWall(Wall wall)
    {
        AviableWalls.Add(wall);
    }

    public void KillWall(Wall wall)
    {
        UnaviableWalls.Remove(wall);

        AviableWalls.Add(wall);

        wall.gameObject.SetActive(false);
    }

    public void CreateWall()
    {
        if (AviableWalls.Count > 0)
        {
            AviableWalls[0].gameObject.SetActive(true);
            AviableWalls[0].transform.position = new Vector3 (_spawnPoint.position.x, Random.Range(-_yOffset, _yOffset), _spawnPoint.position.z);

            _controller.CreatePortal(AviableWalls[0]);

            UnaviableWalls.Add(AviableWalls[0]);

            AviableWalls.RemoveAt(0);
        }
        else
        {
            Wall newWall = _controller.CreateNewWall();
        }
    }
}
